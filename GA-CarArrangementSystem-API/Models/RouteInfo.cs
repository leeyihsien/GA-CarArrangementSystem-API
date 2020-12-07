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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string RouteId { get; set; }
        public string RouteName { get; set; }
        public string RouteStartingStation { get; set; }
        public string RouteTerminalStation { get; set; }
        public double RouteCostTime { get; set; }
        public string RouteType { get; set; }

        public string RouteRemark { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
