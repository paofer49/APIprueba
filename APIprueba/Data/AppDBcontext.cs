using Microsoft.EntityFrameworkCore;
using APIprueba.Models;

namespace APIprueba.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options) 
        { 
        
        }

        public DbSet<Tabla1> Tabla1 { get; set; }

        public DbSet<Cars> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tabla1>().HasData(
                new Tabla1
                {
                    Id = 1,
                    Nombre = "Primero",
                    Cantidad = 8,
                    Descripcion = "Jajaja"
                },
                new Tabla1
                {
                    Id = 2,
                    Nombre = "Segundo",
                    Cantidad = 10,
                    Descripcion = "Jejeje"
                },
                new Tabla1
                {
                    Id = 3,
                    Nombre = "Tercero",
                    Cantidad = 15,
                    Descripcion = "Jijiji"
                }
            );

            modelBuilder.Entity<Cars>().HasData(
                new Cars 
                { 
                    Id = 1,
                    Name ="Lighting McQueen",
                    Color = "Rojo",
                },
                new Cars
                {
                    Id = 2,
                    Name = "Mater",
                    Color = "Cafe"
                },
                new Cars
                {
                    Id = 3,
                    Name = "Doc Hudson",
                    Color = "Azul"
                }
            );
        }
    }

}
