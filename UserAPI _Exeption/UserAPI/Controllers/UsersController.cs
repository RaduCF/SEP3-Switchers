using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAPI.Model;

namespace UserAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/Users")]
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
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task/*<ActionResult<User>>*/ PostUser(User user)
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
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                    //return Conflict();
                    //throw new NotImplementedException("The username  is already in the system");
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.Accepted);
                }
            }
            //manager.RegisterUser(user);
           /* bool blah = false;
            if (blah)
            {
                throw new HttpResponseException(HttpStatusCode.AlreadyReported);
                // throw new NotImplementedException("The username  is already in the system");
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.Accepted);
            }*/
            //return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }


        //login to database
        // POST: api/Users/login
        [Microsoft.AspNetCore.Mvc.HttpPost("{id}")]
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
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.Accepted);
                }
            }

                 manager.Login(login);
                 bool blah=false;

                    if (blah)
                    {
                        throw new HttpResponseException(HttpStatusCode.BadRequest);
                        // throw new NotImplementedException("Either username or password is incorrect");
                    }
                    else
                    {
                        throw new HttpResponseException(HttpStatusCode.Accepted);
                    }
                
           return CreatedAtAction("GetUser", new { id = login }, login);

        }


        //--------------------------------------------------------------------------------------------------// 

        // GET: api/Users
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
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
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
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
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
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

