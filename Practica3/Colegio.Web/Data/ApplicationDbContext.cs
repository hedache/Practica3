using Colegio.Web.Models;
using Microsoft.EntityFrameworkCore;


namespace Colegio.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Municipio> Municipios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Municipio>()
                .HasIndex(t => t.Name)
                .IsUnique();

        }
    }
}
