using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<InfoPersonal> InfoPersonales { get; set; }
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
    }
}
