﻿// <auto-generated />
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
    [Migration("20230104125054_addedAnimals")]
    partial class addedAnimals
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FastTravel.Models.Animal", b =>
                {
                    b.Property<int>("animalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("animalID"));

                    b.Property<string>("animalType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("maxWeight")
                        .HasColumnType("real");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("animalID");

                    b.ToTable("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
