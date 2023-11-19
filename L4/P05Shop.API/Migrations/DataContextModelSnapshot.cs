﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P05Shop.API.Models;

#nullable disable

namespace P05Shop.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("P06Shop.Shared.SongModel.Song", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("AlbumTitle")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<long>("Duration")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AlbumTitle = "Fresh",
                            Artist = "Ramon Lockman",
                            Duration = 129L,
                            ReleaseDate = new DateTime(2019, 1, 6, 2, 27, 25, 828, DateTimeKind.Local).AddTicks(904),
                            Title = "Gorgeous Wooden Chair"
                        },
                        new
                        {
                            Id = 2L,
                            AlbumTitle = "Rubber",
                            Artist = "Leonard Bailey",
                            Duration = 101L,
                            ReleaseDate = new DateTime(2022, 4, 13, 5, 21, 23, 89, DateTimeKind.Local).AddTicks(4680),
                            Title = "Sleek Cotton Shoes"
                        },
                        new
                        {
                            Id = 3L,
                            AlbumTitle = "Fresh",
                            Artist = "Dan O'Hara",
                            Duration = 265L,
                            ReleaseDate = new DateTime(2021, 7, 9, 10, 25, 6, 900, DateTimeKind.Local).AddTicks(8531),
                            Title = "Incredible Rubber Bike"
                        },
                        new
                        {
                            Id = 4L,
                            AlbumTitle = "Rubber",
                            Artist = "Luther Cruickshank",
                            Duration = 50L,
                            ReleaseDate = new DateTime(2014, 11, 15, 17, 33, 33, 749, DateTimeKind.Local).AddTicks(8873),
                            Title = "Generic Steel Chips"
                        },
                        new
                        {
                            Id = 5L,
                            AlbumTitle = "Concrete",
                            Artist = "Alyssa Will",
                            Duration = 101L,
                            ReleaseDate = new DateTime(2014, 5, 26, 15, 31, 29, 421, DateTimeKind.Local).AddTicks(7655),
                            Title = "Generic Granite Shirt"
                        },
                        new
                        {
                            Id = 6L,
                            AlbumTitle = "Granite",
                            Artist = "Jaime Veum",
                            Duration = 191L,
                            ReleaseDate = new DateTime(2020, 9, 21, 8, 34, 24, 215, DateTimeKind.Local).AddTicks(4682),
                            Title = "Ergonomic Rubber Bacon"
                        },
                        new
                        {
                            Id = 7L,
                            AlbumTitle = "Concrete",
                            Artist = "Tommie Keeling",
                            Duration = 281L,
                            ReleaseDate = new DateTime(2016, 5, 27, 12, 14, 50, 894, DateTimeKind.Local).AddTicks(801),
                            Title = "Incredible Fresh Soap"
                        },
                        new
                        {
                            Id = 8L,
                            AlbumTitle = "Granite",
                            Artist = "Toby Mitchell",
                            Duration = 70L,
                            ReleaseDate = new DateTime(2021, 4, 22, 21, 36, 7, 10, DateTimeKind.Local).AddTicks(99),
                            Title = "Fantastic Metal Salad"
                        },
                        new
                        {
                            Id = 9L,
                            AlbumTitle = "Steel",
                            Artist = "Shari Pacocha",
                            Duration = 40L,
                            ReleaseDate = new DateTime(2021, 6, 11, 1, 24, 16, 707, DateTimeKind.Local).AddTicks(5994),
                            Title = "Sleek Cotton Shirt"
                        },
                        new
                        {
                            Id = 10L,
                            AlbumTitle = "Rubber",
                            Artist = "Irvin Weimann",
                            Duration = 237L,
                            ReleaseDate = new DateTime(2022, 4, 12, 19, 47, 5, 29, DateTimeKind.Local).AddTicks(7587),
                            Title = "Generic Steel Pizza"
                        },
                        new
                        {
                            Id = 11L,
                            AlbumTitle = "Granite",
                            Artist = "Elena Schuppe",
                            Duration = 117L,
                            ReleaseDate = new DateTime(2022, 2, 26, 23, 4, 11, 454, DateTimeKind.Local).AddTicks(9757),
                            Title = "Licensed Soft Tuna"
                        },
                        new
                        {
                            Id = 12L,
                            AlbumTitle = "Soft",
                            Artist = "Clara Gleichner",
                            Duration = 158L,
                            ReleaseDate = new DateTime(2021, 10, 17, 9, 43, 52, 485, DateTimeKind.Local).AddTicks(8809),
                            Title = "Tasty Plastic Shirt"
                        },
                        new
                        {
                            Id = 13L,
                            AlbumTitle = "Rubber",
                            Artist = "Gloria Kutch",
                            Duration = 105L,
                            ReleaseDate = new DateTime(2015, 11, 8, 1, 36, 24, 364, DateTimeKind.Local).AddTicks(3281),
                            Title = "Practical Frozen Computer"
                        },
                        new
                        {
                            Id = 14L,
                            AlbumTitle = "Fresh",
                            Artist = "Tracy Harris",
                            Duration = 124L,
                            ReleaseDate = new DateTime(2023, 4, 27, 12, 25, 12, 881, DateTimeKind.Local).AddTicks(1338),
                            Title = "Sleek Frozen Mouse"
                        },
                        new
                        {
                            Id = 15L,
                            AlbumTitle = "Rubber",
                            Artist = "Alexander Hoppe",
                            Duration = 117L,
                            ReleaseDate = new DateTime(2015, 5, 6, 6, 0, 34, 380, DateTimeKind.Local).AddTicks(676),
                            Title = "Rustic Plastic Car"
                        },
                        new
                        {
                            Id = 16L,
                            AlbumTitle = "Soft",
                            Artist = "Jesse Bartell",
                            Duration = 204L,
                            ReleaseDate = new DateTime(2016, 9, 23, 9, 52, 39, 812, DateTimeKind.Local).AddTicks(4895),
                            Title = "Tasty Frozen Pants"
                        },
                        new
                        {
                            Id = 17L,
                            AlbumTitle = "Fresh",
                            Artist = "Carroll Orn",
                            Duration = 163L,
                            ReleaseDate = new DateTime(2018, 9, 13, 20, 16, 43, 394, DateTimeKind.Local).AddTicks(6483),
                            Title = "Generic Steel Tuna"
                        },
                        new
                        {
                            Id = 18L,
                            AlbumTitle = "Steel",
                            Artist = "Helen Pagac",
                            Duration = 60L,
                            ReleaseDate = new DateTime(2019, 2, 21, 9, 20, 4, 814, DateTimeKind.Local).AddTicks(9649),
                            Title = "Generic Metal Table"
                        },
                        new
                        {
                            Id = 19L,
                            AlbumTitle = "Wooden",
                            Artist = "Antonio Predovic",
                            Duration = 269L,
                            ReleaseDate = new DateTime(2020, 9, 2, 3, 25, 42, 637, DateTimeKind.Local).AddTicks(6631),
                            Title = "Handmade Metal Gloves"
                        },
                        new
                        {
                            Id = 20L,
                            AlbumTitle = "Wooden",
                            Artist = "Gerard Jast",
                            Duration = 151L,
                            ReleaseDate = new DateTime(2023, 2, 26, 16, 28, 35, 302, DateTimeKind.Local).AddTicks(8393),
                            Title = "Intelligent Concrete Chips"
                        },
                        new
                        {
                            Id = 21L,
                            AlbumTitle = "Metal",
                            Artist = "Don Rau",
                            Duration = 134L,
                            ReleaseDate = new DateTime(2016, 8, 4, 16, 32, 47, 348, DateTimeKind.Local).AddTicks(6613),
                            Title = "Small Plastic Keyboard"
                        },
                        new
                        {
                            Id = 22L,
                            AlbumTitle = "Wooden",
                            Artist = "Glenda Ortiz",
                            Duration = 217L,
                            ReleaseDate = new DateTime(2022, 6, 5, 12, 48, 16, 275, DateTimeKind.Local).AddTicks(3507),
                            Title = "Small Soft Chips"
                        },
                        new
                        {
                            Id = 23L,
                            AlbumTitle = "Frozen",
                            Artist = "Traci McGlynn",
                            Duration = 73L,
                            ReleaseDate = new DateTime(2021, 5, 24, 10, 17, 44, 184, DateTimeKind.Local).AddTicks(437),
                            Title = "Awesome Plastic Gloves"
                        },
                        new
                        {
                            Id = 24L,
                            AlbumTitle = "Metal",
                            Artist = "Lola Hudson",
                            Duration = 101L,
                            ReleaseDate = new DateTime(2023, 1, 3, 3, 59, 21, 8, DateTimeKind.Local).AddTicks(4805),
                            Title = "Handmade Rubber Car"
                        },
                        new
                        {
                            Id = 25L,
                            AlbumTitle = "Rubber",
                            Artist = "Alberta Hickle",
                            Duration = 128L,
                            ReleaseDate = new DateTime(2020, 9, 26, 11, 7, 22, 819, DateTimeKind.Local).AddTicks(2626),
                            Title = "Small Concrete Hat"
                        },
                        new
                        {
                            Id = 26L,
                            AlbumTitle = "Plastic",
                            Artist = "Terri Rippin",
                            Duration = 96L,
                            ReleaseDate = new DateTime(2021, 12, 27, 22, 20, 51, 511, DateTimeKind.Local).AddTicks(7559),
                            Title = "Gorgeous Granite Bacon"
                        },
                        new
                        {
                            Id = 27L,
                            AlbumTitle = "Steel",
                            Artist = "Kelly Farrell",
                            Duration = 188L,
                            ReleaseDate = new DateTime(2014, 7, 26, 14, 19, 40, 212, DateTimeKind.Local).AddTicks(2558),
                            Title = "Practical Plastic Chips"
                        },
                        new
                        {
                            Id = 28L,
                            AlbumTitle = "Plastic",
                            Artist = "Marta Rutherford",
                            Duration = 45L,
                            ReleaseDate = new DateTime(2016, 3, 10, 14, 54, 39, 219, DateTimeKind.Local).AddTicks(6183),
                            Title = "Refined Steel Gloves"
                        },
                        new
                        {
                            Id = 29L,
                            AlbumTitle = "Steel",
                            Artist = "Yvette Bashirian",
                            Duration = 181L,
                            ReleaseDate = new DateTime(2017, 12, 13, 8, 50, 51, 650, DateTimeKind.Local).AddTicks(4225),
                            Title = "Handmade Rubber Pants"
                        },
                        new
                        {
                            Id = 30L,
                            AlbumTitle = "Soft",
                            Artist = "Santos Tremblay",
                            Duration = 35L,
                            ReleaseDate = new DateTime(2022, 3, 27, 18, 24, 30, 742, DateTimeKind.Local).AddTicks(815),
                            Title = "Licensed Rubber Shirt"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}