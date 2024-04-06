using FinanceTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinanceTracker.DAL.Database
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> Users { get; private set; }
        public DbSet<Transaction> Transactions { get; private set; }
        public DbSet<Category> Categories { get; private set; }
    }
}