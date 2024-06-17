using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Traversal;Integrated Security=True;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutItem> AboutItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        
    }
}