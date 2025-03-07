using ApiProjeKampi.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
namespace ApiProjeKampi.WebApi.Context
{
    public class ApiContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-4ROLKKOD;initial catalog=ApiYummyDb;integrated security=true;");
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Chef> chefs { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Feature> features { get; set; }
        public DbSet<Image> ımages { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Testimonial> testimonials { get; set; }
    }
}
