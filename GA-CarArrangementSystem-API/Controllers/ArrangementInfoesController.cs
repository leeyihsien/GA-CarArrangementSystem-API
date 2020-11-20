using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GA_CarArrangementSystem_API.Data;
using GA_CarArrangementSystem_API.Models;

namespace GA_CarArrangementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrangementInfoesController : ControllerBase
    {
        private readonly DataContext _context;

        public ArrangementInfoesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ArrangementInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArrangementInfo>>> GetArrangmentInfo()
        {
            return await _context.ArrangementInfo.ToListAsync();
        }

        // GET: api/ArrangementInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArrangementInfo>> GetArrangementInfo(string id)
        {
            var arrangementInfo = await _context.ArrangementInfo.FindAsync(id);

            if (arrangementInfo == null)
            {
                return NotFound();
            }

            return arrangementInfo;
        }

        // PUT: api/ArrangementInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArrangementInfo(string id, ArrangementInfo arrangementInfo)
        {
            if (id != arrangementInfo.ArrangementId)
            {
                return BadRequest();
            }

            _context.Entry(arrangementInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArrangementInfoExists(id))
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

        // POST: api/ArrangementInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArrangementInfo>> PostArrangementInfo(ArrangementInfo arrangementInfo)
        {
            _context.ArrangementInfo.Add(arrangementInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArrangementInfoExists(arrangementInfo.ArrangementId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArrangementInfo", new { id = arrangementInfo.ArrangementId }, arrangementInfo);
        }

        // DELETE: api/ArrangementInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArrangementInfo>> DeleteArrangementInfo(string id)
        {
            var arrangementInfo = await _context.ArrangementInfo.FindAsync(id);
            if (arrangementInfo == null)
            {
                return NotFound();
            }

            _context.ArrangementInfo.Remove(arrangementInfo);
            await _context.SaveChangesAsync();

            return arrangementInfo;
        }

        private bool ArrangementInfoExists(string id)
        {
            return _context.ArrangementInfo.Any(e => e.ArrangementId == id);
        }
    }
}
