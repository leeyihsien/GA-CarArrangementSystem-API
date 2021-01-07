using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_CarArrangementSystem_API.Models
{
    public class UserAcc
    {
        [Key]
        public int id { get; set; }
        public char manuf { get; set; }

        public string account { get; set; }

        public string empno { get; set; }

        public string vname { get; set; }

        public string passw { get; set; }

        public char sex { get; set; }

        public string dept { get; set; }

        public string email { get; set; }
        public string token { get; set; }
        public string image { get; set; }
        public DateTime indat { get; set; }
        public string intime { get; set; }
        public DateTime updat { get; set; }
        public string uptime { get; set; }



        //[InverseProperty("UserAcc")]
        //public virtual ICollection<GARoleUser> GARoleUser { get; set; }
    }
}
