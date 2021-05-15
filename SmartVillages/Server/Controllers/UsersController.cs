using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartVillages.Server.Data;
using SmartVillages.Shared;
using MimeKit;
using MailKit.Net.Smtp;

namespace SmartVillages.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostUser/{id}")]
        public async Task<ActionResult<User>> PostUser(int id, User user)
        {
            user.UserType = await _context.UserType.SingleOrDefaultAsync(t => t.UserTypeId == id);
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPost("login/{id}")]
        public async Task<ActionResult<User>> Login(int id, UserSignIn user)
        {
            var type = await _context.UserType.SingleOrDefaultAsync(t => t.UserTypeId == id);
            var User = await _context.User.SingleOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password && u.SecretCode == user.SecretCode && u.UserType == type);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        // LOGOUT
        // await _localStorageService.RemoveItem("user");

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        [HttpPost("SendEmail")]
        public async Task SendEmail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Elliot ALderson","elliotalderson050@gmail.com"));
            message.To.Add( new MailboxAddress("Antonio Sertić", "antonio.sertic@vuv.hr"));
            message.Subject = "Test Subject";

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h3>Please click on Confirm to confirm your email!</h3><br><a href='https://localhost:5001/index'>Confirm</a>";
            bodyBuilder.TextBody = "This is some plain text";

            message.Body = bodyBuilder.ToMessageBody();
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("elliotalderson050@gmail.com", "EvilCorp");
                await client.SendAsync(message);
                client.Disconnect(true);
            }
        }
    }
}
