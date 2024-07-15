using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.DTOs.CommentDto
{
    public class CommentDto
    {
        public string ArticleId { get; set; }
        public string ReaderId { get; set; }
        public string CommentId { get; set;}
        public string Content { get; set;}

    }
}