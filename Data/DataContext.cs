using Microsoft.EntityFrameworkCore;
using Pasta_API.Models;

namespace Pasta_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        // Tabelas do banco
      

        public DbSet<Arma> Armas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


           


            // ==========================================
            // CONFIGURAÇÃO DA TABELA DE ARMAS
            // ==========================================

            modelBuilder.Entity<Arma>()
                .ToTable("TB_ARMAS");

            modelBuilder.Entity<Arma>()
                .HasKey(static a => a.Id);

            modelBuilder.Entity<Arma>()
                .Property(static a => a.Nome)
                .IsRequired();

            modelBuilder.Entity<Arma>()
                .Property(a => a.Dano)
                .IsRequired();


        
            _ = modelBuilder.Entity<Arma>().HasData(

                new Arma
                {
                    Id = 1,
                    Nome = "Espada",
                    Dano = 50
                },

                new Arma
                {
                    Id = 2,
                    Nome = "Machado",
                    Dano = 60
                },

                new Arma
                {
                    Id = 3,
                    Nome = "Arco",
                    Dano = 40
                },

                new Arma
                {
                    Id = 4,
                    Nome = "Lança",
                    Dano = 45
                },

                new Arma
                {
                    Id = 5,
                    Nome = "Martelo",
                    Dano = 70
                },

                new Arma
                {
                    Id = 6,
                    Nome = "Adaga",
                    Dano = 30
                },

                new Arma
                {
                    Id = 7,
                    Nome = "Katana",
                    Dano = 65
                }
            );
        }

    
        
        
    }
}
