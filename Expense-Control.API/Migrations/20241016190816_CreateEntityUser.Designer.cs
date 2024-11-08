﻿// <auto-generated />
using System;
using Expense_Control.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Expense_Control.API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241016190816_CreateEntityUser")]
    partial class CreateEntityUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Expense_Control.API.Domain.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Email");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("timestamp")
                        .HasColumnName("inactive_date");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Password");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("timestamp")
                        .HasColumnName("register_date");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
