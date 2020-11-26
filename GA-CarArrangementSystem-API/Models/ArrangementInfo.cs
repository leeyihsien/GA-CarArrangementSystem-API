using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_CarArrangementSystem_API.Models
{
    public class ArrangementInfo
    {
        [Key]
        public string ArrangementId {get; set;}
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

        public DateTime UpdateAt { get; set; }
    }
}
