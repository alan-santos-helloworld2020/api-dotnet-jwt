using Microsoft.AspNetCore.Mvc;
using back.Repository;
using back.Models;
using back.HashConfiguration;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly DatabaseContext db;
        public LoginController(DatabaseContext Userdb)
        {
            db = Userdb;
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> save(User user)
        {
            HashConfig hash = new HashConfig();
            string result = hash.passwordEncoder(user);
            user.Password = result;
            db.Add(user);
            var res = await db.SaveChangesAsync();
            return Ok(res);
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> login(User user)
        {
            HashConfig hash = new HashConfig();
            var login = db.users.Where(u => u.Email == user.Email).FirstOrDefault();
            if (login is null)
            {
                return NotFound();
            }
            else
            {
                if (hash.decodePassword(user, login.Password))
                {
                    return Ok(login);
                }
                else
                {
                    return NotFound();
                }
            }

        }

    }


}