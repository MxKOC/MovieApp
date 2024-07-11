using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.IdentityModels;

namespace DatabaseLayer.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }

        public string ReaderId { get; set; }
        public Reader Reader { get; set; } // Yorumu yapan Reader

        public int ArticleId { get; set; }
        public Article Article { get; set; } // Yorum yapılan Article

    }
}