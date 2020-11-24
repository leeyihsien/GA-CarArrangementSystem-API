using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA_CarArrangementSystem_API.DTO
{
    public class ArrangementInfoDTO
    {

        /// <summary>
        /// 防止資料過度張貼，DTO可以決定某些顯示給user的data，其餘則隱藏起來
        /// 在Controller 裡面將物件部分更改為DTO即可
        /// </summary>

        public string ArrangementId { get; set; }

        public DateTime ArrangeDate { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string RouteId { get; set; }

        public DateTime GoTime { get; set; }

        public DateTime BackTime { get; set; }

        public string CarId { get; set; }

        public string DriverId { get; set; }

        public string ArrangementStatus { get; set; }

        public string ArrangementRemark { get; set; }

        public ArrangementInfoDTO()
        {
            this.ArrangeDate = DateTime.Now;
        }
    }
}
