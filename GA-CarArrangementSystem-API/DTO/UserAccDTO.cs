using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace GA_CarArrangementSystem_API.DTO
{
    public class UserAccDTO
    {
        public int id { get; set; }

        [Required]
        public string account { get; set; }

        [Required]
        public string passw { get; set; }

        public string token { get; set; }


        //public List<string> GARole { get; set; }
    }
}
