using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoiffeurApp.Models
{
    public class StaffPermission
    {

        [Key]
        public int PermissionId { get; set; }

        public int StaffId { get; set; }
        [ForeignKey(nameof(StaffId))]
        public User User { get; set; }

        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public bool IsDeleted { get; set; }

         
    }
}