using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace DatabaseLayer.IdentityModels
{
    public class Reader : IdentityUser
    {
        public int ReaderId  { get; set; }
        public int MyProperty { get; set; }
        public DateTime JoinTime { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Comment> FavoriteGenres { get; set; }
        public ICollection<FavoriteArticle> FavoriteArticles { get; set; }
        public ICollection<FavoriteArticle> FollowedWriters { get; set; }
    }
}