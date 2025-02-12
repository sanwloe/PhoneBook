using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DataContext
{
    public class PBDataContext : DbContext
    {
        public PBDataContext(DbContextOptions<PBDataContext> opt) : base(opt)
        {
            var r = this.Database.EnsureCreated();
        }
        public DbSet<NumberInfo> Numbers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("DataSource=database.db");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NumberInfo>().HasKey(x => x.Number);
            modelBuilder.Entity<NumberInfo>().HasIndex(x => x.Number).IsUnique();
            modelBuilder.Entity<NumberInfo>().HasData(
                [
                    new NumberInfo() { Number = "+38012345678" },
                    new NumberInfo() { Number = "+38023456781" },
                    new NumberInfo() { Number = "+38034567812" },
                    new NumberInfo() { Number = "+38045678123" },
                    new NumberInfo() { Number = "+38056781234" }
                ]);
            base.OnModelCreating(modelBuilder);
        }
    }
}
