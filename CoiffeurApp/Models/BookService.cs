﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoiffeurApp.Models
{
    public class BookService
    {
        [Key]
        public int BookServiceId { get; set; }
     
       public int ServiceId { get; set; }
    
        public int BookId { get; set; }
       
        public bool IsDeleted { get; set; }
    }
}