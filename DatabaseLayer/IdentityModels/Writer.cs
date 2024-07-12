using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace DatabaseLayer.IdentityModels
{
    public class Writer : IdentityUser
    {
        public string Country { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime JoinTime { get; set; }
        public string Rate { get; set; }
        public string WebPage { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public ICollection<FollowedWriter> FollowedWriters { get; set; }



    }
}