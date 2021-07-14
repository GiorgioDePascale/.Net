using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Book
    {
        public int ID { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string ISBN { get; set; }
        public bool Available { get; set; }

        public Author Author { get; set; }
        public User User { get; set; }
    }
}