using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_CarArrangementSystem_API.Models
{
    public class GARole
    {
        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string RoleRoute { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        //[InverseProperty("GARole")]
        //public virtual ICollection<GARoleUser> GARoleUser { get; set; }

    }
}
