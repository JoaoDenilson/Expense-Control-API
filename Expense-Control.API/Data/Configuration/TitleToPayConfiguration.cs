using Expense_Control.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expense_Control.API.Data.Configuration
{
    public class TitleToPayConfiguration : IEntityTypeConfiguration<TitleToPay>
    {
        public void Configure(EntityTypeBuilder<TitleToPay> builder)
        {
            builder.ToTable("titleToPay")
                .HasKey(t => t.Id);

            builder.Property(p => p.Description)
                .HasColumnType("VARCHAR")
                .HasColumnName("Description")
                .IsRequired();

            builder.Property(p => p.OriginalValue)
                .HasColumnType("double precision")
                .HasColumnName("OriginalValue")
                .IsRequired();

            builder.Property(p => p.AmountPaid)
                .HasColumnType("double precision")
                .HasColumnName("AmountPaid")
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

            builder.Property(p => p.PaymentDate)
                .HasColumnType("timestamp")
                .HasColumnName("PaymentDate");

            builder.Property(p => p.InactiveDate)
                .HasColumnType("timestamp")
                .HasColumnName("inactive_date");

            builder.HasOne(p => p.User).WithMany().HasForeignKey(fk => fk.UserId);
            builder.HasOne(p => p.NatureLaunch).WithMany().HasForeignKey(fk => fk.NatureLaunchId);
        }
    }
}