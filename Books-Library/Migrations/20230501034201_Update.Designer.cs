﻿// <auto-generated />
using System;
using Books_Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Books_Library.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230501034201_Update")]
    partial class Update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Books_Library.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ISBNNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Arthur Kostler",
                            ISBNNumber = 58974265L,
                            Title = "Darkness at Noon"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Mary Smith",
                            ISBNNumber = 756655656L,
                            Title = "Circle of Pain"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Mario Puzo",
                            ISBNNumber = 123679458L,
                            Title = "God Father"
                        });
                });

            modelBuilder.Entity("Books_Library.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Rörvägen 2",
                            FirstName = "Misha",
                            LastName = "Samsson",
                            PhoneNumber = "0717894987"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Kyrkgatan 12d ",
                            FirstName = "Tonny",
                            LastName = "Jules",
                            PhoneNumber = "078452588"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Storgatan 24",
                            FirstName = "Leroy",
                            LastName = "Henry",
                            PhoneNumber = "0707456669"
                        });
                });

            modelBuilder.Entity("Books_Library.Models.UserBorrowing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBorrowings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            BorrowDate = new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsReturned = false,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            BorrowDate = new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsReturned = true,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            BookId = 2,
                            BorrowDate = new DateTime(2021, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsReturned = false,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            BookId = 2,
                            BorrowDate = new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsReturned = false,
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            BookId = 3,
                            BorrowDate = new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsReturned = true,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Books_Library.Models.UserBorrowing", b =>
                {
                    b.HasOne("Books_Library.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Books_Library.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
