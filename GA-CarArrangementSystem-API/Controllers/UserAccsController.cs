using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GA_CarArrangementSystem_API.Data;
using GA_CarArrangementSystem_API.Models;
using GA_CarArrangementSystem_API._Services.Interface;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using GA_CarArrangementSystem_API.DTO;

namespace GA_CarArrangementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccsController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly IUserService _userService;
        private readonly IConfiguration _config;


        public UserAccsController(UserContext context, IUserService userService, IConfiguration configuration)
        {
            _context = context;
            _userService = userService;
            _config = configuration;
        }

        // GET: api/UserAccs
        [HttpGet]
        public async Task<IActionResult> GetUserAcc()
        {
            var model = await _userService.GetAll();
            return Ok(model);
        }

        // GET: api/UserAccs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAcc(int id)
        {
            var userAcc = await _userService.GetUser(id);

            if (userAcc == null)
            {
                return NotFound();
            }

            return Ok(userAcc);
        }

 

    // PUT: api/UserAccs/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAcc(int id, UserAcc userAcc)
        {
            if (id != userAcc.id)
            {
                return BadRequest();
            }

            _context.Entry(userAcc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccExists(id))
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

        // POST: api/UserAccs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserAcc>> PostUserAcc(UserAcc userAcc)
        {
            _context.UserAcc.Add(userAcc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserAcc", new { id = userAcc.id }, userAcc);
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserAccDTO userLogin)
        {
            var user = _userService.Login(userLogin.account, userLogin.passw);
            if (user == null)
            {
                return BadRequest();
            }



            return Ok(user);
        }
    
    // DELETE: api/UserAccs/5
    [HttpDelete("{id}")]
        public async Task<ActionResult<UserAcc>> DeleteUserAcc(int id)
        {
            var userAcc = await _context.UserAcc.FindAsync(id);
            if (userAcc == null)
            {
                return NotFound();
            }

            _context.UserAcc.Remove(userAcc);
            await _context.SaveChangesAsync();

            return userAcc;
        }

        private bool UserAccExists(int id)
        {
            return _context.UserAcc.Any(e => e.id == id);
        }
    }
}
