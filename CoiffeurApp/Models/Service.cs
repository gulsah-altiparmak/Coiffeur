using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoiffeurApp.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        public String Title { get; set; }
       
        public String Url { get; set; }
        public bool IsActive { get; set; }
        public int ServiceTime { get; set; }
        public int ServicePrice { get; set; }
        //public String Image { get; set; }
        public int SortOrder { get; set; }
        public bool IsDelete { get; set; }
        [NotMapped]
        public bool IsChecked { get; set; }
    }
}