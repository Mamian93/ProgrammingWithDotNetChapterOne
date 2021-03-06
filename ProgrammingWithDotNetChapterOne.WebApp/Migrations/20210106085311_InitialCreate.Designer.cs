﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProgrammingWithDotNetChapterOne.WebApp.Data;

namespace ProgrammingWithDotNetChapterOne.WebApp.Migrations
{
    [DbContext(typeof(CalculatorContext))]
    [Migration("20210106085311_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ProgrammingWithDotNetChapterOne.WebApp.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("CostOfWorkingHour")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("SearchHistoryId")
                        .HasColumnType("integer");

                    b.Property<double>("TransportCost")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("SearchHistoryId")
                        .IsUnique();

                    b.ToTable("City");
                });

            modelBuilder.Entity("ProgrammingWithDotNetChapterOne.WebApp.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("AssemblyTime")
                        .HasColumnType("double precision");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int?>("SearchHistoryId")
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("SearchHistoryId");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("ProgrammingWithDotNetChapterOne.WebApp.Models.SearchHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("ModuleName1")
                        .HasColumnType("text");

                    b.Property<string>("ModuleName2")
                        .HasColumnType("text");

                    b.Property<string>("ModuleName3")
                        .HasColumnType("text");

                    b.Property<string>("ModuleName4")
                        .HasColumnType("text");

                    b.Property<double>("ProductionCost")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("SearchHistory");
                });

            modelBuilder.Entity("ProgrammingWithDotNetChapterOne.WebApp.Models.City", b =>
                {
                    b.HasOne("ProgrammingWithDotNetChapterOne.WebApp.Models.SearchHistory", "SearchHistory")
                        .WithOne("City")
                        .HasForeignKey("ProgrammingWithDotNetChapterOne.WebApp.Models.City", "SearchHistoryId");
                });

            modelBuilder.Entity("ProgrammingWithDotNetChapterOne.WebApp.Models.Module", b =>
                {
                    b.HasOne("ProgrammingWithDotNetChapterOne.WebApp.Models.SearchHistory", "SearchHistory")
                        .WithMany()
                        .HasForeignKey("SearchHistoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
