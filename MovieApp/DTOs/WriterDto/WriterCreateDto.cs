using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.DTOs.ArticleDto
{
    public class WriterCreateDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public string Country { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime JoinTime { get; set; }
        public int Rate { get; set; }
        public string WebPage { get; set; }

    }
}