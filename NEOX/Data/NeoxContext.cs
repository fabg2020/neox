using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Neox.Models;

namespace Neox.Data
{
    public partial class NeoxContext : DbContext
    {
        public NeoxContext()
        {
        }

        public NeoxContext(DbContextOptions<NeoxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Edad).HasColumnType("DECIMAL");

                entity.Property(e => e.Direccion).HasColumnType("VARCHAR(8000)");


            });

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
