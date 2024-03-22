using FinanceTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DAL.Database
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Account> Accounts { get; }
        public DbSet<Transaction> Transactions { get; }
        public DbSet<User> Users { get; }
        public DbSet<Category> Categories { get; }
    }
}