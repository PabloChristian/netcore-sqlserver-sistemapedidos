using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Domain.Entities;
using SistemaPedidos.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPedidos.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> ItensPedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\\Program Files (x86)\\SQLServer\\SistemaPedidos2.mdf;Trusted_connection=true;");
            optionsBuilder.UseSqlServer("Data source=(localdb)\\mssqllocaldb;Initial Catalog=SistemaPedidos;Trusted_connection=true;",
                           p => p.EnableRetryOnFailure(
                               maxRetryCount: 2,
                               maxRetryDelay: 
                               TimeSpan.FromSeconds(5),
                               errorNumbersToAdd: null));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
                
    }
}
