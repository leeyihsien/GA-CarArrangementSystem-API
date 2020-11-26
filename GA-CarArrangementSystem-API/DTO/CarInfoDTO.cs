using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA_CarArrangementSystem_API.DTO
{
    public class CarInfoDTO
    {
        public string CarId { get; set; }

        public string CarBrand { get; set; }

        public string CarOwner { get; set; }

        public int CarPassengerVolume { get; set; }
        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
