using Microsoft.EntityFrameworkCore;
using ProgrammingWithDotNetChapterOne.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingWithDotNetChapterOne.WebApp.Data
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchHistory>()
                .HasOne(a => a.City)
                .WithOne(a => a.SearchHistory)
                .HasForeignKey<City>(b => b.SearchHistoryId);
        }

        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<City> City { get; set; }
    }
}
