﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab_60_cats_API.Models;

namespace lab_60_cats_API.Migrations
{
    [DbContext(typeof(CatDbContext))]
    [Migration("20200302144212_adding-annotations-category")]
    partial class addingannotationscategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab_60_cats_API.Models.Cat", b =>
                {
                    b.Property<int>("CatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CatName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.HasKey("CatID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Cats");

                    b.HasData(
                        new
                        {
                            CatID = 1,
                            CatName = "Kitty",
                            CategoryID = 1,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatID = 2,
                            CatName = "Garfield",
                            CategoryID = 2,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatID = 3,
                            CatName = "Rengar",
                            CategoryID = 3,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("lab_60_cats_API.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Bengal"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Tabby"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Siamese"
                        });
                });

            modelBuilder.Entity("lab_60_cats_API.Models.Cat", b =>
                {
                    b.HasOne("lab_60_cats_API.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");
                });
#pragma warning restore 612, 618
        }
    }
}
