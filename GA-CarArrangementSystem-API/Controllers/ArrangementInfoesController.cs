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
using GA_CarArrangementSystem_API._Repostories.Interface;

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
        private readonly DataContext _context;        

        public ArrangementInfoesController(DataContext context)
        {
            
            _context = context;
            
        }                        

        // GET: api/ArrangementInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArrangementInfoDTO>>> GetArrangmentInfo()
        {
            return await _context.ArrangementInfo.Select(x => ArrangementInfoToDTO(x)).ToListAsync();
        }

        // GET: api/ArrangementInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArrangementInfoDTO>> GetArrangementInfo(string id)
        {
            var arrangementInfo = await _context.ArrangementInfo.FindAsync(id);

            if (arrangementInfo == null)
            {
                return NotFound();
            }

            return ArrangementInfoToDTO(arrangementInfo);
        }

        // PUT: api/ArrangementInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArrangementInfo(string id, ArrangementInfoDTO arrangementInfoDTO)
        {
            if (id != arrangementInfoDTO.ArrangementId)
            {
                return BadRequest();
            }

            _context.Entry(arrangementInfoDTO).State = EntityState.Modified;

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
        public async Task<ActionResult<ArrangementInfoDTO>> PostArrangementInfo(ArrangementInfoDTO arrangementInfoDTO)
        {
            var arrangementInfo = new ArrangementInfo
            {
                ArrangementId = arrangementInfoDTO.ArrangementId,

                ArrangeDate = arrangementInfoDTO.ArrangeDate,

                UserId = arrangementInfoDTO.UserId,

                UserName = arrangementInfoDTO.UserName,

                RouteId = arrangementInfoDTO.RouteId,

                GoTime = arrangementInfoDTO.GoTime,

                BackTime = arrangementInfoDTO.BackTime,

                CarId = arrangementInfoDTO.CarId,

                DriverId = arrangementInfoDTO.DriverId
            };
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

            return CreatedAtAction("GetArrangementInfo", new { id = arrangementInfo.ArrangementId }, ArrangementInfoToDTO(arrangementInfo));
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


        /// <summary>
        /// 宣告將model 轉換為 DTO 的方法，可以更改Controller 中 return 物件
        /// 全部換成DTO，確保資料隱密性
        /// </summary>
        /// <param name="arrangementInfo"></param>
        /// <returns></returns>
        private static ArrangementInfoDTO ArrangementInfoToDTO(ArrangementInfo arrangementInfo)
            => new ArrangementInfoDTO
            {
                ArrangementId = arrangementInfo.ArrangementId,

                ArrangeDate = arrangementInfo.ArrangeDate,

                UserId = arrangementInfo.UserId,

                UserName = arrangementInfo.UserName,

                RouteId = arrangementInfo.RouteId,

                GoTime = arrangementInfo.GoTime,

                BackTime = arrangementInfo.BackTime,

                CarId = arrangementInfo.CarId,

                DriverId = arrangementInfo.DriverId
            };
    }
}
