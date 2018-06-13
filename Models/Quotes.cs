using System;
using System.ComponentModel.DataAnnotations;
namespace quotingDojo.Models
{
    public class Quotes
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Quote { get; set; }

    }
}