using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DatabaseLayer.Models;
using DatabaseLayer.IdentityModels;
using Microsoft.AspNetCore.Identity;


namespace DataAccessLayer.Context
{
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Reader> Readers { get; set; }




        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }




    }
}