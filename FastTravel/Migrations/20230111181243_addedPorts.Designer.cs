﻿// <auto-generated />
using System;
using FastTravel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FastTravel.Migrations
{
    [DbContext(typeof(FastTravelDbContext))]
    [Migration("20230111181243_addedPorts")]
    partial class addedPorts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FastTravel.Data.FlightData", b =>
                {
                    b.Property<int>("flightNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("flightNumber"));

                    b.Property<float>("adult")
                        .HasColumnType("real");

                    b.Property<float>("child")
                        .HasColumnType("real");

                    b.Property<DateTime?>("date1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("date2")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("destination")
                        .HasColumnType("int");

                    b.Property<float>("elder")
                        .HasColumnType("real");

                    b.Property<int>("plane")
                        .HasColumnType("int");

                    b.Property<int>("source")
                        .HasColumnType("int");

                    b.Property<int?>("stop1")
                        .HasColumnType("int");

                    b.Property<int?>("stop2")
                        .HasColumnType("int");

                    b.HasKey("flightNumber");

                    b.ToTable("FlightsData");
                });

            modelBuilder.Entity("FastTravel.Models.Plane", b =>
                {
                    b.Property<int>("planeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("planeID"));

                    b.Property<string>("company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("seatsNum")
                        .HasColumnType("int");

                    b.HasKey("planeID");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("FastTravel.Models.Port", b =>
                {
                    b.Property<int>("portID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("portID"));

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("portID");

                    b.ToTable("Ports");
                });
#pragma warning restore 612, 618
        }
    }
}