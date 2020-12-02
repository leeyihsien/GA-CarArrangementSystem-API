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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace GA_CarArrangementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverInfoesController : ControllerBase
    {
        private readonly IDriverInfoService _driverInfoService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DriverInfoesController(IDriverInfoService driverInfoService, IWebHostEnvironment webHostEnvironment)
        {
            _driverInfoService = driverInfoService;
            _webHostEnvironment = webHostEnvironment;
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
        [HttpPut]
        public async Task<IActionResult> PutDriverInfo(DriverInfoDTO driverInfoDTO)
        {
                var model = await _driverInfoService.Update(driverInfoDTO);
                return Ok(model);
        }

        // DELETE: api/DriverInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverInfo(string id)
        {
            var model = await _driverInfoService.Delete(id);
            return Ok(model);
        }


        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _webHostEnvironment.ContentRootPath + "/Image/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }

            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }

    }
}
