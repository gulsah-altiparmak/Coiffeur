using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoiffeurApp.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public DateTime? StartingDate { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int StaffId { get; set; }
        [ForeignKey(nameof(StaffId))]
        public User Staff { get; set; }

        public bool IsDeleted { get; set; }

        //public ICollection<BookService> BookServices { get; set; }


        [NotMapped]
        public List<BookService> bookServices { get; set; }

    }
}