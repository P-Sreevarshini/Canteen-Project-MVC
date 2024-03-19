﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnetapp.Data;

#nullable disable

namespace dotnetapp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240319102810_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("dotnetapp.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CoverImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Author 1",
                            CategoryId = 1,
                            CoverImage = "book1.jpg",
                            Description = "Description for Book 1",
                            Price = 19.99m,
                            Title = "Book Title 1"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Author 2",
                            CategoryId = 2,
                            CoverImage = "book2.jpg",
                            Description = "Description for Book 2",
                            Price = 24.99m,
                            Title = "Book Title 2"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Author 3",
                            CategoryId = 3,
                            CoverImage = "book3.jpg",
                            Description = "Description for Book 3",
                            Price = 29.99m,
                            Title = "Book Title 3"
                        });
                });

            modelBuilder.Entity("dotnetapp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Non-Fiction"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Science"
                        });
                });

            modelBuilder.Entity("dotnetapp.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("dotnetapp.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("ShoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartItem");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("dotnetapp.Models.Book", b =>
                {
                    b.HasOne("dotnetapp.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("dotnetapp.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("dotnetapp.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dotnetapp.Models.ShoppingCart", null)
                        .WithMany("Items")
                        .HasForeignKey("ShoppingCartId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("dotnetapp.Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("dotnetapp.Models.ShoppingCart", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
