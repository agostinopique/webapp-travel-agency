using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace webapp_travel_agency.Models
{
    public class TravelContext : IdentityDbContext<IdentityUser>
    {
        public TravelContext()
        {

        }

        public TravelContext(DbContextOptions<TravelContext> options) : base(options)
        {

        }
        public DbSet<PacchettoViaggio> PacchettoViaggio { get; set; }

        public DbSet<Message> Message { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=travel-agency-db;Integrated Security=True");
        }
    }
}
