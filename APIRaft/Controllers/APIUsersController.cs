using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIRaft.Data;
using APIRaft.Models;
using Microsoft.AspNetCore.Hosting;

namespace APIRaft.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class APIUsersController : ControllerBase
    {
        private readonly RaftpjContext db;
        private readonly IWebHostEnvironment _environment;

        public APIUsersController(RaftpjContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            _environment = environment;
        }

        // GET: APIUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await db.User.ToListAsync();
        }

        // GET: api/APIUsers/5
        [Route("GetUser/{userId}")]
        [HttpGet]
        public ActionResult GetUser(string userId)
        {
            var data = (from r in db.User.Where(a => a.UserId == userId).ToList()
                        select new
                        {
                            UserEmail = r.UserEmail,
                            UserPassword = r.UserPassword,
                            UserTel = r.UserTel,
                            UserName = r.UserName,
                            UserId = r.UserId,
                        }).ToList();

            return new JsonResult(data);
           
        }

       
      

        //Post APIUsers/Register
        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult> Register([FromBody]User data)
        {
            db.User.Add(data);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(data.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = data.UserId }, data);
        }


        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<User>> Login([FromBody] User user)
        {

            try
            {
                var chk = db.User.Where(a => a.UserEmail == user.UserEmail && a.UserPassword == user.UserPassword)
                    .FirstOrDefault();
                if (chk != null)
                {
                    var data = (from r in db.User.Where(a => a.UserEmail == user.UserEmail).ToList()
                                select new
                                {
                                    UserEmail = r.UserEmail,
                                    UserPassword = r.UserPassword,                                  
                                    UserTel = r.UserTel,
                                    UserName = r.UserName,
                                    UserId = r.UserId,
                                }).ToList();

                    return new JsonResult(data);

                }
                else
                {
                    return base.StatusCode(500, "flse");
                }

            }
            catch (Exception e)
            {
                return base.StatusCode(500, e);
            }

        }

        private bool UserExists(string id)
        {
            return db.User.Any(e => e.UserId == id);
        }
    }
}
