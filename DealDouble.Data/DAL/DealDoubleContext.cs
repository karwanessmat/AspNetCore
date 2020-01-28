using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DealDouble.Entities.Entities;

namespace DealDouble.Data.DAL
{
    public    class DealDoubleContext:DbContext
    {

        public DbSet<Production> Productions { get; set; }
        public DealDoubleContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Production>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.Property(p => p.ActualAmount)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(p => p.StartingDate)
                    .HasColumnType("Date");
                entity.Property(p => p.EndingDate)
                    .IsRequired()
                    .HasColumnType("Date");

            });
        }

    }
}
