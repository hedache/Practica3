using Colegio.Web.Models;
using Microsoft.EntityFrameworkCore;


namespace Colegio.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Barrio> Barrios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alumno>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<Municipio>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<Barrio>()
                .HasIndex(t => t.Name)
                .IsUnique();

        }
    }
}
