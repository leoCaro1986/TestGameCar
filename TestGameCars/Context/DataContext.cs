using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestGameCars.Entities;

namespace TestGameCars.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Car> cars { get; set; }
        public DbSet<Driver> drivers { get; set; }
        public DbSet<Game> games { get; set; }
        public DbSet<Line> lines { get; set; }
        public DbSet<Player> players { get; set; }
        public DbSet<Track> tracks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-DCQ1439;Database=TestGameCarDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(a => a.driver)
                .WithOne(b => b.car)
                .HasForeignKey<Driver>(b => b.idCar);

            modelBuilder.Entity<Driver>()
               .HasOne(a => a.player)
               .WithOne(b => b.driver)
               .HasForeignKey<Player>(b => b.idDriver);


            modelBuilder.Entity<Track>()
              .HasOne(c => c.line)
              .WithMany(e => e.tracks)
              .HasForeignKey(c => c.idLine);

            modelBuilder.Entity<Game>()
             .HasOne(c => c.player)
             .WithMany(e => e.games)
             .HasForeignKey(c => c.idPlayer);

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasOne(p => p.car)
                .WithMany(b => b.games)
                .HasForeignKey(p => p.idCar)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.driver)
                    .WithMany(b => b.games)
                    .HasForeignKey(p => p.idDriver)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.line)
                    .WithMany(b => b.games)
                    .HasForeignKey(p => p.idLine)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.track)
                    .WithMany(b => b.games)
                    .HasForeignKey(p => p.idTrack)
                    .OnDelete(DeleteBehavior.Restrict);

            });
        }


    }
}
