﻿using System;
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

        private readonly Random _random = new Random();

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
            user.EmailConfirmationCode = GenerateCode();
            user.UserType = await _context.UserType.SingleOrDefaultAsync(t => t.UserTypeId == id);
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", user);
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
        public async Task SendEmail(User user, bool issecret = false)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Smart Villages", "elliotalderson050@gmail.com"));
            message.To.Add(new MailboxAddress(user.FirstName + " " + user.LastName, user.Email));
            message.Subject = issecret ? "Secret code" : "Email confirmation";

            var bodyBuilder = new BodyBuilder();
            var code = issecret ? user.SecretCode : user.EmailConfirmationCode;
            if(issecret)
            {
                bodyBuilder.HtmlBody = "<div style='text-align: center; height: 200px;'><h1>Welcome to Smart Villages <span style='color: lightseagreen;'>" + user.FirstName + "</span></h1><h3 style='margin-bottom: 0; margin-top: 20px'>Your secret code for login is below:</h3><br><p style='font-size: 50px;font-weight: bold;margin-top: 0;'>" + user.SecretCode + "</p></div>";
            }
            else
            {
                bodyBuilder.HtmlBody = "<div style='text-align: center;height: 150px;'><h1>Welcome to Smart Villages <span style='color: lightseagreen;'>" + user.FirstName + "</span></h1><h3>Please click on Confirm to confirm your email!</h3><br><a style='color: white; background-color: #31B58E;padding: 10px 20px;border-radius: 5px;font-size: 17px;text-decoration: none;' href='https://localhost:5001/emailconfirmation/" + code + "/" + user.OIB + "'>Confirm</a></div>";
            }

            message.Body = bodyBuilder.ToMessageBody();

            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("elliotalderson050@gmail.com", "EvilCorp");
                    await client.SendAsync(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            /*
            {
                "Id": 13,
                "FirstName": "Antonio",
                "LastName":	"Sertić",
                "Email": "a@a",
                "Bio": "NULL",
                "Sex": "NULL",
                "OIB": "45789658965",
                "EmailConfirm": false,
                "Locked": true,
                "Country": "Cro",
                "City": "Na",
                "Address": "NULL",
                "Number": "4789595562",
                "SecretCode": "NULL",
                "BirthDate": "2020-02-07T00:00:00.0000000",
                "UserTypeId": 2,
                "DateCreated": "2021-05-05T13:51:58.3440000",
                "Password": "12345678",
                "TermsAndConditions": true,
                "EmailConfirmationCode": "NULL"
            }
             */
        }

        [HttpPost("ConfirmEmail/{oib}")]
        public async Task<ActionResult> ConfirmEmail(string oib, [FromBody] string code)
        {
            var User = await _context.User.SingleOrDefaultAsync(u => u.EmailConfirmationCode == code && u.OIB == oib);

            if (User == null)
            {
                return NotFound();
            }
            else
            {
                User.EmailConfirm = true;
                User.Locked = false;
                User.SecretCode = GenerateCode();
                _context.Entry(User).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                // Opet poslati email a pravim SecretCod-om
                await SendEmail(User, true);

                return CreatedAtAction("ConfirmEmail", User.SecretCode);
            }
        }

        public string GenerateCode()
        {
            string SecretCode = "";
            List<string> alphabet = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            for (var i = 0; i < 3; i++)
            {
                int num = RandomNumber(0, 9);
                int randchar = RandomNumber(0, 26);
                SecretCode += alphabet[randchar] + num;
            }

            return SecretCode;
        }

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

    }
}
