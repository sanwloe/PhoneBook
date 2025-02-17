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
        private const string ConnectionString = "Data Source=localhost;Database=phonebook;Integrated Security=True;Trust Server Certificate=True;";
        public PBDataContext()
        {
            
        }
        public PBDataContext(DbContextOptions<PBDataContext> opt) : base(opt)
        {
            if(this.Database.EnsureCreated())
            {
                this.Database.Migrate();
            }
        }
        public DbSet<NumberInfo> Numbers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NumberInfo>().Property(x => x.DateOfRegistration).HasColumnType("datetimeoffset");
            modelBuilder.Entity<NumberInfo>().Property(x => x.LastUpdateDate).HasColumnType("datetimeoffset");
            modelBuilder.Entity<NumberInfo>().HasKey(x => x.Number);
            modelBuilder.Entity<NumberInfo>().HasIndex(x => x.Number).IsUnique();
            modelBuilder.Entity<NumberInfo>().HasData(
                [
                    new NumberInfo() { Number = "+38012345678", FirstName = "A" , LastName = "B" , Description = "Data is not available." },
                    new NumberInfo() { Number = "+38023456781", FirstName = "A" , LastName = "B" , Description = "Data is not available." },
                    new NumberInfo() { Number = "+38034567812", FirstName = "A" , LastName = "B"  , Description = "Data is not available." },
                    new NumberInfo() { Number = "+38045678123", FirstName = "A" , LastName = "B"  , Description = "Data is not available." },
                    new NumberInfo() { Number = "+38056781234", FirstName = "A" , LastName = "B"  , Description = "Data is not available." }
                ]);
            base.OnModelCreating(modelBuilder);
        }
    }
}
