using System;
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
            /*
             * USER / MESSAGECONTENT / UNREADMESSAGES
             * 
             * 1. dohvatiti sve usere s kojima sam imao poruka.. znaci mogu biti i primatelj i posiljatelj
             * 2. po svakom od tih usera iz liste ici i dohvatiti zadnju poruku s njim
             * 3. prebrojati neprocitane poruke
             * 
            var First = await _context.User.SingleOrDefaultAsync(t => t.Id == personone);
            var Second = await _context.User.SingleOrDefaultAsync(t => t.Id == persontwo);
            var Messages = await _context.Message.Where(u => (u.PersonOne == First && u.PersonTwo == Second) || (u.PersonTwo == First && u.PersonOne == Second)).OrderBy(d => d.Date).ToListAsync();

            if (User == null)
            {
                return NotFound();
            }
            */
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

            // AllUsersOne i AllUsersTwo distinctat u jednu

            foreach (var singleUser in AllUsers)
            {
                var lastMessage = _context.Message.Where(u => (u.PersonOne == User && u.PersonTwo == singleUser) || (u.PersonOne == singleUser && u.PersonTwo == User)).OrderBy(o => o.Id).Last();
                var numOfUnread = _context.Message.Where(u => (u.PersonOne == singleUser && u.PersonTwo == User) && u.Seen == false).Count();
                LastMessages.Add(new LastMessage { 
                    User = singleUser,
                    MessageContent = lastMessage.MessageContent,
                    LastIsSeen = lastMessage.Seen,
                    UnreadMessages = numOfUnread
                });
            }
            return LastMessages;
        }
    }
}
