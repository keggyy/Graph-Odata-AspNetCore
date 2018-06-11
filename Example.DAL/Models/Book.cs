using Example.DAL.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Example.DAL.Models
{
    public class Book:IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
