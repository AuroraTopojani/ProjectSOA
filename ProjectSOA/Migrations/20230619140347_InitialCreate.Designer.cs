﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectSOA.Data;

#nullable disable

namespace ProjectSOA.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230619140347_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjectSOA.Models.Author", b =>
                {
                    b.Property<int>("AId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AId"));

                    b.Property<int>("Born")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("ProjectSOA.Models.Book", b =>
                {
                    b.Property<int>("bId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("bId"));

                    b.Property<int>("AuthorAId")
                        .HasColumnType("integer");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Written")
                        .HasColumnType("integer");

                    b.Property<bool>("availability")
                        .HasColumnType("boolean");

                    b.HasKey("bId");

                    b.HasIndex("AuthorAId");

                    b.HasIndex("StudentId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ProjectSOA.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Faculty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surame")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ProjectSOA.Models.Table", b =>
                {
                    b.Property<int>("tId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("tId"));

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.Property<bool>("tAvailability")
                        .HasColumnType("boolean");

                    b.HasKey("tId");

                    b.HasIndex("StudentId");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("ProjectSOA.Models.Book", b =>
                {
                    b.HasOne("ProjectSOA.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectSOA.Models.Student", null)
                        .WithMany("Books")
                        .HasForeignKey("StudentId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("ProjectSOA.Models.Table", b =>
                {
                    b.HasOne("ProjectSOA.Models.Student", null)
                        .WithMany("Tables")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("ProjectSOA.Models.Student", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}