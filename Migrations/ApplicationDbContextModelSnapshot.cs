﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationDemo.Data;

#nullable disable

namespace WebApplicationDemo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("WebApplicationDemo.models.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CertificateId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Certificates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CertificateId = "C001",
                            Description = "Certification A",
                            DueDate = new DateTime(2025, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3673),
                            StartDate = new DateTime(2024, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3625),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CertificateId = "C002",
                            Description = "Certification B",
                            DueDate = new DateTime(2025, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3683),
                            StartDate = new DateTime(2024, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3681),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            CertificateId = "C003",
                            Description = "Certification C",
                            DueDate = new DateTime(2025, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3689),
                            StartDate = new DateTime(2024, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3687),
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            CertificateId = "C004",
                            Description = "Certification D",
                            DueDate = new DateTime(2025, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3694),
                            StartDate = new DateTime(2024, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3692),
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            CertificateId = "C005",
                            Description = "Certification E",
                            DueDate = new DateTime(2025, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3700),
                            StartDate = new DateTime(2024, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3698),
                            UserId = 4
                        });
                });

            modelBuilder.Entity("WebApplicationDemo.models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john@example.com",
                            Name = "John Doe",
                            UserId = "U001"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1992, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane@example.com",
                            Name = "Jane Smith",
                            UserId = "U002"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1985, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alice@example.com",
                            Name = "Alice Johnson",
                            UserId = "U003"
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(1995, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "bob@example.com",
                            Name = "Bob Brown",
                            UserId = "U004"
                        });
                });

            modelBuilder.Entity("WebApplicationDemo.models.Certificate", b =>
                {
                    b.HasOne("WebApplicationDemo.models.User", null)
                        .WithMany("Certificates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplicationDemo.models.User", b =>
                {
                    b.Navigation("Certificates");
                });
#pragma warning restore 612, 618
        }
    }
}