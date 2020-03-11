﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab_63_ToDo_API_Users_Categories.Models;

namespace lab_63_ToDo_API_Users_Categories.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    [Migration("20200306111156_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab_63_ToDo_API_Users_Categories.Models.ToDo", b =>
                {
                    b.Property<int>("ToDoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ToDoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ToDoID");

                    b.HasIndex("UserID");

                    b.ToTable("ToDos");

                    b.HasData(
                        new
                        {
                            ToDoID = 1,
                            ToDoName = "Do this"
                        },
                        new
                        {
                            ToDoID = 2,
                            ToDoName = "And do this"
                        },
                        new
                        {
                            ToDoID = 3,
                            ToDoName = "And do this also"
                        });
                });

            modelBuilder.Entity("lab_63_ToDo_API_Users_Categories.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            UserName = "Fred"
                        },
                        new
                        {
                            UserID = 2,
                            UserName = "Johnny"
                        },
                        new
                        {
                            UserID = 3,
                            UserName = "Layla"
                        },
                        new
                        {
                            UserID = 4,
                            UserName = "Tim"
                        },
                        new
                        {
                            UserID = 5,
                            UserName = "Venus"
                        });
                });

            modelBuilder.Entity("lab_63_ToDo_API_Users_Categories.Models.ToDo", b =>
                {
                    b.HasOne("lab_63_ToDo_API_Users_Categories.Models.User", "User")
                        .WithMany("ToDos")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}