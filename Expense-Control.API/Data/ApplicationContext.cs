using Expense_Control.API.Data.Configuration;
using Expense_Control.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Expense_Control.API.Data
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            this.Users = this.Set<User>();
            this.NatureLaunche = this.Set<NatureLaunch>();
            this.TitleToPay = this.Set<TitleToPay>();
        }
        public DbSet<User> Users { get; set; }

        public DbSet<NatureLaunch> NatureLaunche { get; set; }

        public DbSet<TitleToPay> TitleToPay { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                _ = modelBuilder.ApplyConfiguration(new UsersConfiguration());
                _ = modelBuilder.ApplyConfiguration(new NatureLaunchConfiguration());
                _ = modelBuilder.ApplyConfiguration(new TitleToPayConfiguration());

                base.OnModelCreating(modelBuilder);
            }
            else
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
        }
    }
}
