using Expense_Control.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expense_Control.API.Data.Configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user")
                .HasKey(t => t.Id);

            builder.Property(p => p.Name)
                .HasColumnType("VARCHAR")
                .HasColumnName("Name");

            builder.Property(p => p.Email)
                .HasColumnType("VARCHAR")
                .HasColumnName("Email")
                .IsRequired();

            builder.Property(p => p.Password)
                .HasColumnType("VARCHAR")
                .HasColumnName("Password")
                .IsRequired();

            builder.Property(p => p.RegisterDate)
                .HasColumnType("timestamp")
                .HasColumnName("register_date")
                .IsRequired();

            builder.Property(p => p.InactiveDate)
                .HasColumnType("timestamp")
                .HasColumnName("inactive_date");
        }
    }
}
