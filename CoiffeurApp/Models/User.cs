using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoiffeurApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Phone { get; set; }
        public String Mail { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Image { get; set; }

        public bool IsDelete { get; set; }

        public String Type { get; set; }

        public List<StaffPermission> StaffPermission { get; set; }



    }
}