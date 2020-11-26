using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GA_CarArrangementSystem_API.Data;
using GA_CarArrangementSystem_API.Models;
using GA_CarArrangementSystem_API.DTO;
using GA_CarArrangementSystem_API._Repositories.Interface;
using GA_CarArrangementSystem_API._Repositories.Repositories;
using GA_CarArrangementSystem_API._Services.Interface;
using GA_CarArrangementSystem_API._Services.Services;

namespace GA_CarArrangementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDriversController : ControllerBase
    {
        private readonly ICarInfoService _carInfoService;
        private readonly DataContext  _context;

        public CarDriversController(ICarInfoService carInfoService)
        {
            _carInfoService = carInfoService;   
        }

        // GET: api/CarDrivers
        [HttpGet]
        public async Task<IActionResult> GetCarDriver()
        {

            var model = await _carInfoService.GetAllAsync();
            return Ok(model);
        }

        // GET: api/CarDrivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDriver>> GetCarDriver(int id)
        {
            var carDriver = await _context.CarDriver.FindAsync(id);

            if (carDriver == null)
            {
                return NotFound();
            }

            return carDriver;
        }

        // PUT: api/CarDrivers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarDriver(int id, CarDriver carDriver)
        {
            if (id != carDriver.Id)
            {
                return BadRequest();
            }

            _context.Entry(carDriver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarDriverExists(id))
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

        // POST: api/CarDrivers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CarDriver>> PostCarDriver(CarDriver carDriver)
        {
            _context.CarDriver.Add(carDriver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarDriver", new { id = carDriver.Id }, carDriver);
        }

        // DELETE: api/CarDrivers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarDriver>> DeleteCarDriver(int id)
        {
            var carDriver = await _context.CarDriver.FindAsync(id);
            if (carDriver == null)
            {
                return NotFound();
            }

            _context.CarDriver.Remove(carDriver);
            await _context.SaveChangesAsync();

            return carDriver;
        }

        private bool CarDriverExists(int id)
        {
            return _context.CarDriver.Any(e => e.Id == id);
        }
    }
}
