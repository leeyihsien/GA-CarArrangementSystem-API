using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GA_CarArrangementSystem_API.Models
{
    public class CarInfo
    {
        [Key]
        public string CarId { get; set; }

        public string CarBrand { get; set; }

        public string CarOwner { get; set; }

        public int CarPassengerVolume { get; set; }
    }
}
