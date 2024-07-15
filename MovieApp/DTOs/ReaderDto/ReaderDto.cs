using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.DTOs.ArticleDto
{
    public class ReaderDto
    {
        public string Id { get; set; }


        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int MyProperty { get; set; }
        public DateTime JoinTime { get; set; }

    }
}