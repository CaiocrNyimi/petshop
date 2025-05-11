using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Entities;

namespace PetShop.Infrastructure.Data
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options)
        { }

        public DbSet<Animal> Animais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
