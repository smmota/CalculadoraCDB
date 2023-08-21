using CalculoCDBWebAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDBWebAPI.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Taxa> Taxas { get; set; }
        public DbSet<Calculo> Calculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Taxa>()
                .Property(p => p.Descricao)
                .HasMaxLength(20);

            modelBuilder.Entity<Taxa>()
                .Property(p => p.ValorPercentual)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Taxa>()
                .HasData(
                    new Taxa { Id = 1, Descricao = "TB", ValorPercentual = 108 },
                    new Taxa { Id = 2, Descricao = "CDI", ValorPercentual = 0.9 });

            modelBuilder.Entity<Calculo>()
                .Property(p => p.ValorAplicado)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Calculo>()
                .Property(p => p.ValorBruto)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Calculo>()
                .Property(p => p.ValorLiquido)
                .HasPrecision(10, 2);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
