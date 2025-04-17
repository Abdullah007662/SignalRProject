using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SignalREntityLayer.Entities;

namespace SignalRDataAccessLayer.Concrete
{
    public class SignalRContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public SignalRContext(DbContextOptions<SignalRContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

    }
}
