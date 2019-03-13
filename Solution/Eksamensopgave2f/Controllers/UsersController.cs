using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eksamensopgave2f.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eksamensopgave2f.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        Eksamensopgave2DBContext _context;

        public UsersController(Eksamensopgave2DBContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Users> GetAllUsers() {
            return _context.Users.AsEnumerable();
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody]Users _user) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (_user.Password != "1234") {
                return BadRequest("Forkert brugernavn eller adgangkode");
            }

            Users user = _context.Users.FirstOrDefault(x => x.Name == _user.Name);

            user.Counter++;

            user.LastLogin = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}