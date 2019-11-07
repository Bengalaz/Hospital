using Hospital.Entity;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.Context
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Paciente> pacientes {get;set;}
        public DbSet<Consulta> consultas {get;set;}

        //Creador para que funcione
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>()
            .Property(p =>p.Nombre)
            .HasColumnName("Nombres")
            .HasMaxLength(50)
            .IsRequired();
        }
    }
}