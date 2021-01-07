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
    public class RouteSchedulesController : ControllerBase
    {
        private readonly IRouteScheduleService _routeScheduleService;

        public RouteSchedulesController(IRouteScheduleService routeScheduleService)
        {
            _routeScheduleService = routeScheduleService;
        }

        // GET: api/RouteSchedules
        [HttpGet]
        public async Task<IActionResult> GetRouteSchedule()
        {
            var model = await _routeScheduleService.GetAllAsync();
            return Ok(model);
        }

        // GET: api/RouteSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RouteSchedule>> GetRouteSchedule(int id)
        {
            var routeSchedule =  _routeScheduleService.GetById(id);

            if (routeSchedule == null)
            {
                return NotFound();
            }

            return Ok(routeSchedule);
        }

        // PUT: api/RouteSchedules/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRouteSchedule(RouteScheduleDTO routeSchedule)
        {

            var model = await _routeScheduleService.Update(routeSchedule);
            return Ok(model);
        }

        // POST: api/RouteSchedules
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostRouteSchedule(RouteScheduleDTO routeSchedule)
        {
            var model = await _routeScheduleService.Add(routeSchedule);
            return Ok(model);
        }

        // DELETE: api/RouteSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRouteSchedule(int id)
        {
            var model = await _routeScheduleService.Delete(id);
            return Ok(model);
     
        }

    }
}
