using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.IdentityModels;

namespace DatabaseLayer.Models
{
    public class FollowedWriter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string FollowedWriterId { get; set; }
        public string ReaderId { get; set; }
        public Reader Reader { get; set; }

        public string WriterId { get; set; }
        public Writer Writer { get; set; }
    }
}