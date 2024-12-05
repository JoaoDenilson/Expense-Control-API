using Expense_Control.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expense_Control.API.Data.Configuration
{
    public class NatureLaunchConfiguration : IEntityTypeConfiguration<NatureLaunch>
    {
        public void Configure(EntityTypeBuilder<NatureLaunch> builder)
        {
            builder.ToTable("natureLaunch")
                .HasKey(t => t.Id);

            builder.Property(p => p.Description)
                .HasColumnType("VARCHAR")
                .HasColumnName("Description")
                .IsRequired();

            builder.Property(p => p.Notes)
                .HasColumnType("VARCHAR")
                .HasColumnName("Notes");

            builder.Property(p => p.RegisterDate)
                .HasColumnType("timestamp")
                .HasColumnName("register_date")
                .IsRequired();

            builder.Property(p => p.InactiveDate)
                .HasColumnType("timestamp")
                .HasColumnName("inactive_date");

            builder.HasOne(p => p.User).WithMany().HasForeignKey(fk => fk.UserId);
        }
    }
}
