using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA_CarArrangementSystem_API.DTO
{
    public class RouteScheduleDTO
    {
        public int EventId { get; set; }
        public string RouteId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
