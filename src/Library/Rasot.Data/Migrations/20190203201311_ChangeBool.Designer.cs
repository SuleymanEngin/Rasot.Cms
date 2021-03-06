﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rasot.Data;

namespace Rasot.Data.Migrations
{
    [DbContext(typeof(RasotDbContext))]
    [Migration("20190203201311_ChangeBool")]
    partial class ChangeBool
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("Rasot.Core.Domain.Categories.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Deleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Rasot.Core.Domain.Contents.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("CustomerId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Rasot.Core.Domain.Contents.PostCategoryMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<int>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PostId");

                    b.ToTable("PostCategoryMapping");
                });

            modelBuilder.Entity("Rasot.Core.Domain.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("PasswordFormatType");

                    b.Property<string>("PasswordSalt");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Rasot.Core.Domain.Contents.Post", b =>
                {
                    b.HasOne("Rasot.Core.Domain.Customers.Customer", "Customer")
                        .WithMany("Posts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rasot.Core.Domain.Contents.PostCategoryMapping", b =>
                {
                    b.HasOne("Rasot.Core.Domain.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rasot.Core.Domain.Contents.Post", "Post")
                        .WithMany("PostCategories")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
