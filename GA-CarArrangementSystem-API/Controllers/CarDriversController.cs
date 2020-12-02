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
        private readonly ICarDriverService _carDriverService;

        public CarDriversController(ICarDriverService carDriverService)
        {
            _carDriverService = carDriverService;
        }

        // GET: api/CarDrivers
        [HttpGet]
        public async Task<IActionResult> GetCarDriver()
        {

            var model = await _carDriverService.GetAllAsync();
            return Ok(model);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarDriverById(string id)
        {
            var model = _carDriverService.GetById(id);
            return Ok(model);
        }




        [HttpPost]
        public async Task<IActionResult> PostCarDriver(CarDriverDTO carDriverDTO)
        {
            var model = await _carDriverService.Add(carDriverDTO);
            return Ok(model);
        }


        [HttpPut]
        public async Task<IActionResult> PutCarDriver( CarDriverDTO carDriverDTO)
        {
                var model = await _carDriverService.Update(carDriverDTO);
                return Ok(model);
       
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarDriver(string id)
        {
            var model = await _carDriverService.Delete(id);
            return Ok(model);
        }



        //private bool CarDriverExists(int id)
        //{
        //    return _context.CarDriver.Any(e => e.Id == id);
        //}
    }
}
