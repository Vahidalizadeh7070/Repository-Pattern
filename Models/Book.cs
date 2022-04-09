using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public class Book
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Author is Required")]
        public string Author { get; set; }
        [MinLength(10,ErrorMessage ="Subject needs more than 10 characters")]
        [MaxLength(100, ErrorMessage ="Subject needs less than 100 characters")]
        [Required(ErrorMessage = "Subject is Required")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "ReleaseDate is Required")]
        [DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; }
    }
}
