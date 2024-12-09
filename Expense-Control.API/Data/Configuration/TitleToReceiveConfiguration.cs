using Expense_Control.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expense_Control.API.Data.Configuration
{
    public class TitleToReceiveConfiguration : IEntityTypeConfiguration<TitleToReceive>
    {
        public void Configure(EntityTypeBuilder<TitleToReceive> builder)
        {
            builder.ToTable("titleToReceive")
                .HasKey(t => t.Id);

            builder.Property(p => p.Description)
                .HasColumnType("VARCHAR")
                .HasColumnName("Description")
                .IsRequired();

            builder.Property(p => p.OriginalValue)
                .HasColumnType("double precision")
                .HasColumnName("OriginalValue")
                .IsRequired();

            builder.Property(p => p.AmountReceive)
                .HasColumnType("double precision")
                .HasColumnName("AmountReceive")
                .IsRequired();

            builder.Property(p => p.Notes)
                .HasColumnType("VARCHAR")
                .HasColumnName("Notes");    

            builder.Property(p => p.RegisterDate)
                .HasColumnType("timestamp")
                .HasColumnName("register_date")
                .IsRequired();

            builder.Property(p => p.DueDate)
                .HasColumnType("timestamp")
                .HasColumnName("DueDate")
                .IsRequired();

            builder.Property(p => p.ReferenceDate)
                .HasColumnType("timestamp")
                .HasColumnName("ReferenceDate");

            builder.Property(p => p.ReceiveDate)
                .HasColumnType("timestamp")
                .HasColumnName("ReceiveDate");

            builder.Property(p => p.InactiveDate)
                .HasColumnType("timestamp")
                .HasColumnName("inactive_date");

            builder.HasOne(p => p.User).WithMany().HasForeignKey(fk => fk.UserId);
            builder.HasOne(p => p.NatureLaunch).WithMany().HasForeignKey(fk => fk.NatureLaunchId);
        }
    }
}