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
        }
        public DbSet<User> Users { get; set; }

        public DbSet<NatureLaunch> NatureLaunche { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                _ = modelBuilder.ApplyConfiguration(new UsersConfiguration());
                _ = modelBuilder.ApplyConfiguration(new NatureLaunchConfiguration());

                base.OnModelCreating(modelBuilder);
            }
            else
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
        }
    }
}
