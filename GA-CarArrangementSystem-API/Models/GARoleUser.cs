using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_CarArrangementSystem_API.Models
{
    public class GARoleUser
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public int RoleId { get; set; }
        public DateTime UpdateAt { get; set; }
        public int UserId { get; set; }

        //[ForeignKey(nameof(RoleId))]
        //[InverseProperty(nameof(GARole.GARoleUser))]
        //public virtual GARole Role { get; set; }

        //[ForeignKey(nameof(UserId))]
        //[InverseProperty(nameof(UserAcc.GARoleUser))]
        //public virtual UserAcc User { get; set; }
    }
}
