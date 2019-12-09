using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAPI.Model;

namespace UserAPI.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;
        private UserLogic manager = new UserLogic();

        public UsersController(UserContext context)
        {
            _context = context;
            manager = new UserLogic();
        }

        //registering new user both into in-memory and database
        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            manager.RegisterUser(user);
            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }


        //login to database
        // POST: api/Users/login
        [HttpPost("{id}")]
        public async Task<ActionResult<Login>> PostLogin(Login login)
        {
            Console.WriteLine("test");
            _context.Login.Add(login);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(login.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            manager.Login(login);

            return CreatedAtAction("GetUser", new { id = login }, login);

        }


        //--------------------------------------------------------------------------------------------------// 

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, User user)
        {
            if (id != user.ID)
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



        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}

