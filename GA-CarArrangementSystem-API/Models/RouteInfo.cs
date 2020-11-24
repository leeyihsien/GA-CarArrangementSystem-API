using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GA_CarArrangementSystem_API.Models
{
    public class RouteInfo
    {
        [Key]
        public string RouteId { get; set; }
        public string RouteName { get; set; }
        public string RouteStart { get; set; }
        public string RouteEnd { get; set; }
        public int RouteCostTime { get; set; }
        public Boolean RouteOneWay { get; set; }
        public Boolean RouteRoundTrip { get; set; }

        public string RouteRemark { get; set; }
    }
}
