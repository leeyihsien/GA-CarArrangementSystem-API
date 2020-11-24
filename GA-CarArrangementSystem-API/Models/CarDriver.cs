using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GA_CarArrangementSystem_API.Models
{
    public class CarDriver
    {
        [Key]
        public int Id { get; set; }
        public string CarId {get; set;}

        public string DriverId { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
