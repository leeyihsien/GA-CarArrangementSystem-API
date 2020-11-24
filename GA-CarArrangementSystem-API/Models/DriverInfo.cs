using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GA_CarArrangementSystem_API.Models
{
    public class DriverInfo
    {
        [Key]
        public string DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public string DriverPhoto { get; set; }
    }
}
