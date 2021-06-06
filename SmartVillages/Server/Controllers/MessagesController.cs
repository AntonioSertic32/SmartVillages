﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using SmartVillages.Server.Data;
using SmartVillages.Shared;

namespace SmartVillages.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly DataContext _context;

        public MessagesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessage()
        {
            return await _context.Message.ToListAsync();
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            var message = await _context.Message.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, Message message)
        {
            if (id != message.Id)
            {
                return BadRequest();
            }

            _context.Entry(message).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("postmessage/{personone}/{persontwo}")]
        public async Task<ActionResult<Message>> PostMessage(Message message, int personone, int persontwo)
        {
            message.PersonOne = await _context.User.SingleOrDefaultAsync(t => t.Id == personone);
            message.PersonTwo = await _context.User.SingleOrDefaultAsync(t => t.Id == persontwo);
            _context.Message.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = message.Id }, message);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _context.Message.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.Message.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageExists(int id)
        {
            return _context.Message.Any(e => e.Id == id);
        }

        [HttpGet("getmessagesbyuser/{personone}/{persontwo}")]
        public async Task<ActionResult<List<Message>>> GetMessagesByUser(int personone, int persontwo)
        {
            var First = await _context.User.SingleOrDefaultAsync(t => t.Id == personone);
            var Second = await _context.User.SingleOrDefaultAsync(t => t.Id == persontwo);
            var Messages = await _context.Message.Where(u => (u.PersonOne == First && u.PersonTwo == Second) || (u.PersonTwo == First && u.PersonOne == Second)).OrderBy(d => d.Date).ToListAsync();

            if (User == null)
            {
                return NotFound();
            }

            return Messages;
        }

        [HttpGet("getalllastmessages/{user}")]
        public async Task<ActionResult<List<LastMessage>>> GetAllLastMessages(int user)
        {
            /* moguć error ako korisnik nema ni jedne poruke.. */
            List<LastMessage> LastMessages = new List<LastMessage>();
            List<User> AllUsers = new List<User>();
            var User = await _context.User.SingleOrDefaultAsync(t => t.Id == user);
            var AllUsersOne = await _context.Message.Where(u => u.PersonOne == User).Select(n => n.PersonTwo).Distinct().ToListAsync();
            var AllUsersTwo = await _context.Message.Where(u => u.PersonTwo == User).Select(n => n.PersonOne).Distinct().ToListAsync();

            foreach (var item in AllUsersOne)
                AllUsers.Add(item);
            foreach (var item in AllUsersTwo)
                AllUsers.Add(item);
            AllUsers = AllUsers.DistinctBy(x => x.Id).ToList();

            foreach (var singleUser in AllUsers)
            {
                var lastMessage = _context.Message.Where(u => (u.PersonOne == User && u.PersonTwo == singleUser) || (u.PersonOne == singleUser && u.PersonTwo == User)).OrderBy(o => o.Id).Last();
                var numOfUnread = _context.Message.Where(u => (u.PersonOne == singleUser && u.PersonTwo == User) && u.Seen == false).Count();
                bool isLastSeen = false;
                lastMessage.MessageContent = lastMessage.MessageContent.Count() > 80 ? lastMessage.MessageContent.Substring(0, 37) + "..." : lastMessage.MessageContent;
                if (lastMessage.PersonOne == User) 
                {
                    isLastSeen = true;
                }
                else if(lastMessage.PersonTwo == User && lastMessage.Seen)
                {
                    isLastSeen = true;
                }
                LastMessages.Add(new LastMessage { 
                    MessageID = lastMessage.Id,
                    User = singleUser,
                    MessageContent = lastMessage.MessageContent,
                    LastIsSeen = isLastSeen,
                    UnreadMessages = numOfUnread,
                    Date = lastMessage.Date
                });
            }
            List<LastMessage> LastMessagesOrdered = LastMessages.OrderBy(o => o.Date, OrderByDirection.Descending).ToList();
            return LastMessagesOrdered;
        }

        [HttpPost("setasseen")]
        public async Task<IActionResult> SetAsSeen(LastMessage LastMessage)
        {
            // nade tu zadnju poruku i preko nje sve druge
            var one = _context.Message.Where(m => m.Id == LastMessage.MessageID).Select(s => s.PersonOne);
            var two = _context.Message.Where(m => m.Id == LastMessage.MessageID).Select(s => s.PersonTwo);
            var messages = _context.Message.Where(u => (u.PersonOne == one.FirstOrDefault() && u.PersonTwo == two.FirstOrDefault()) && u.Seen == false).ToList();
            foreach (var m in messages)
            {
                m.Seen = true;
                _context.Entry(m).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
