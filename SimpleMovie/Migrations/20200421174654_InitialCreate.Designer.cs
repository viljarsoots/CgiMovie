﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleMovie.Data;

namespace SimpleMovie.Migrations
{
    [DbContext(typeof(MovieAppContext))]
    [Migration("20200421174654_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleMovie.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SimpleMovie.Models.Movie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Categoryid")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Categoryid");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("SimpleMovie.Models.Movie", b =>
                {
                    b.HasOne("SimpleMovie.Models.Category", null)
                        .WithMany("Movies")
                        .HasForeignKey("Categoryid");
                });
#pragma warning restore 612, 618
        }
    }
}
