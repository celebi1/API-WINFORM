using Microsoft.EntityFrameworkCore;
using CODESWEBAPI.Models; // Personel modelini içe aktarın

namespace CODESWEBAPI
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"server=ARDAPOS-1\SQL2019;initial catalog=DbLearn;integrated security=true");

            }
        }

        public DbSet<Personel> Personels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().ToTable("Personels");
        }
    }
}
