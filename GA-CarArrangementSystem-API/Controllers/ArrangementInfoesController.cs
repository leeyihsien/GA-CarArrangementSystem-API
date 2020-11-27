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

/// <summary>
/// 預設的controller 中具有 DbContext
/// 基於設計原則，Controller 應呼叫service去進行商業邏輯的運作
/// 所以匯入service 就好
/// </summary>

namespace GA_CarArrangementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrangementInfoesController : ControllerBase
    {
        private readonly IArrangementInfoService _arrangementInfoService;

        public ArrangementInfoesController(IArrangementInfoService arrangementInfoService)
        {

            _arrangementInfoService = arrangementInfoService;

        }
        //   GET: api/ArrangementInfoes
        [HttpGet]
        public async Task<IActionResult> GetArrangmentInfo()
        {
            var model = await _arrangementInfoService.GetAllAsync();
            return Ok(model);
        }

        //   GET: api/ArrangementInfoes/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArrangmentInfoById(string id)
        {
            var model = _arrangementInfoService.GetById(id);
            return Ok(model);
        }

        //   POST: api/ArrangementInfoes

        [HttpPost]
        public async Task<IActionResult> PostArrangementInfo(ArrangementInfoDTO arrangementInfo)
        {
            var model = await _arrangementInfoService.Add(arrangementInfo);
            return Ok(model);
        }


        //   PUT: api/ArrangementInfoes/id

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArrangementInfo(string id, ArrangementInfoDTO arrangementInfo)
        {
           if (id != arrangementInfo.ArrangementId)
            {
                return BadRequest();
            } 
           else
            {
                var model = await _arrangementInfoService.Update(arrangementInfo);
                return Ok(model);
            }
            
        }


        //Delete:　api/ArrangementInfoes/{id}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArrangement(string id)
        {
            var model = await _arrangementInfoService.Delete(id);
            return Ok(model);

        }


        /// <summary>
        /// 宣告將model 轉換為 DTO 的方法，可以更改Controller 中 return 物件
        /// 全部換成DTO，確保資料隱密性
        /// </summary>
        /// <param name="arrangementInfo"></param>
        /// <returns></returns>
        //private static ArrangementInfoDTO ArrangementInfoToDTO(ArrangementInfo arrangementInfo)
        //    => new ArrangementInfoDTO
        //    {
        //        ArrangementId = arrangementInfo.ArrangementId,

        //        ArrangeDate = arrangementInfo.ArrangeDate,

        //        UserId = arrangementInfo.UserId,

        //        UserName = arrangementInfo.UserName,

        //        RouteId = arrangementInfo.RouteId,

        //        GoTime = arrangementInfo.GoTime,

        //        BackTime = arrangementInfo.BackTime,

        //        CarId = arrangementInfo.CarId,

        //        DriverId = arrangementInfo.DriverId
        //    };
    }
}
