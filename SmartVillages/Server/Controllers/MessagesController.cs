﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}
