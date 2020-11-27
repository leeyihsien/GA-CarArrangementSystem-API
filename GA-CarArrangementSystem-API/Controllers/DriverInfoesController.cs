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
    public class DriverInfoesController : ControllerBase
    {
        private readonly IDriverInfoService _driverInfoService;
        private readonly DataContext _context;

        public DriverInfoesController(IDriverInfoService driverInfoService,DataContext context)
        {
            _driverInfoService = driverInfoService;
            _context = context;
        }

        // GET: api/DriverInfoes
        [HttpGet]
        public async Task<IActionResult> GetDriverInfo()
        {
            var model = await _driverInfoService.GetAllAsync();
            return Ok(model);
        }

        // GET: api/DriverInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverInfoById(string id)
        {
            var model = _driverInfoService.GetById(id);
            return Ok(model);

        }


        // POST: api/DriverInfoes
        [HttpPost]
        public async Task<IActionResult> PostDriverInfo(DriverInfoDTO driverInfoDTO)
        {
            var model = await _driverInfoService.Add(driverInfoDTO);
            return Ok(model);
        }

        // PUT: api/DriverInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriverInfo(string id, DriverInfoDTO driverInfoDTO)
        {

            if (id != driverInfoDTO.DriverId)
            {
                return BadRequest();
            }
            else
            {
                var model = _driverInfoService.Update(driverInfoDTO);
                return Ok(model);
            }
        }

        // DELETE: api/DriverInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverInfo(string id)
        {
            var model = await _driverInfoService.Delete(id);
            return Ok(model);
        }

    }
}
