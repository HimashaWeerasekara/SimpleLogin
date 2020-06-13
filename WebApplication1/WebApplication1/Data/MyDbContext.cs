using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class MyDbContext : IdentityDbContext<User>
    {
        public DbSet<Division> Divisions { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }
}
