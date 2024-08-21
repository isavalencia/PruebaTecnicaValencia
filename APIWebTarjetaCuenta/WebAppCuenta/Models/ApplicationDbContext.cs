using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using APIWebTarjetaCuenta.Models;

namespace WebAppCuenta.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Transacciones> Transacciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transacciones>()
                .Property(t => t.tipo)
                .HasColumnType("int");

            base.OnModelCreating(modelBuilder);
        }
    }
}