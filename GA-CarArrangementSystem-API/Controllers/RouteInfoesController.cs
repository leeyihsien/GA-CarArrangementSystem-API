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
    public class RouteInfoesController : ControllerBase
    {
        private readonly IRouteInfoService _routeInfoService;

        public RouteInfoesController(IRouteInfoService routeInfoService,DataContext context)
        {
            _routeInfoService = routeInfoService;
        }

        // GET: api/RouteInfoes
        [HttpGet]
        public async Task<IActionResult> GetRouteInfo()
        {
            var model = await _routeInfoService.GetAllAsync();
            return Ok(model);
        }

        // GET: api/RouteInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRouteInfoById(string id)
        {
            var model = _routeInfoService.GetById(id);
            return Ok(model);
        }

        // POST: api/RouteInfoes/5
        [HttpPost]
        public async Task<IActionResult> PostRouteInfo(RouteInfoDTO routeInfoDTO)
        {
            var model = await _routeInfoService.Add(routeInfoDTO);
            return Ok(model);
        }


        // PUT: api/RouteInfoes/5
        [HttpPut]
        public async Task<IActionResult> PutRouteInfo(RouteInfoDTO routeInfoDTO)
        {
                var model = await _routeInfoService.Update(routeInfoDTO);
                return Ok(model);
        }

        // DELETE: api/RouteInfoes/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteRouteInfo(string id)
        {
            var model = await _routeInfoService.Delete(id);
            return Ok(model);
        }

   
  
     
    }
}
