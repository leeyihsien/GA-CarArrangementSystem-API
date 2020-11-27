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
    public class CarInfoesController : ControllerBase
    {
        private readonly ICarInfoService _carInfoService;
        private readonly DataContext _context;

        public CarInfoesController(ICarInfoService carInfoService,DataContext context)
        {
            _carInfoService = carInfoService;
            _context = context;
        }

        // GET: api/CarInfoes
        [HttpGet]
        public async Task<IActionResult> GetCarInfo()
        {
            var model = await _carInfoService.GetAllAsync();
            return Ok(model);
        }

        // GET: api/CarInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarInfo(string id)
        {
            var model = _carInfoService.GetById(id);
            return Ok(model);
            
        }


        // POST: api/CarInfoes/5
        [HttpPost]

        public async Task<IActionResult> PostCarInfo(CarInfoDTO carInfoDTO)
        {
            var model = await _carInfoService.Add(carInfoDTO);
            return Ok(model);
        }


        // PUT: api/CarInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarInfo(string id, CarInfoDTO carInfoDTO)
        {
            if (id != carInfoDTO.CarId)
            {
                return BadRequest();
            }
            else
            {
                var model = await _carInfoService.Update(carInfoDTO);
                return Ok(model);
            }
        }


        // DELETE: api/CarInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarInfo(string id)
        {
            var model = await _carInfoService.Delete(id);
            return Ok(model);
        }

    

   

    }
}
