using FinanceTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.DAL.Database.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.FirstName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(x => x.Login)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Password)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}