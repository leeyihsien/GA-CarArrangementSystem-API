using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA_CarArrangementSystem_API.DTO
{
    public class CarDriverDTO
    {
        public int Id { get; set; }
        public string CarId { get; set; }

        public string DriverId { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
