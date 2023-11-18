using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P05Shop.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Duration = table.Column<long>(type: "bigint", nullable: false),
                    AlbumTitle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    Artist = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "AlbumTitle", "Artist", "Duration", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1L, "Fresh", "Ramon Lockman", 129L, new DateTime(2019, 1, 6, 2, 27, 25, 828, DateTimeKind.Local).AddTicks(904), "Gorgeous Wooden Chair" },
                    { 2L, "Rubber", "Leonard Bailey", 101L, new DateTime(2022, 4, 13, 5, 21, 23, 89, DateTimeKind.Local).AddTicks(4680), "Sleek Cotton Shoes" },
                    { 3L, "Fresh", "Dan O'Hara", 265L, new DateTime(2021, 7, 9, 10, 25, 6, 900, DateTimeKind.Local).AddTicks(8531), "Incredible Rubber Bike" },
                    { 4L, "Rubber", "Luther Cruickshank", 50L, new DateTime(2014, 11, 15, 17, 33, 33, 749, DateTimeKind.Local).AddTicks(8873), "Generic Steel Chips" },
                    { 5L, "Concrete", "Alyssa Will", 101L, new DateTime(2014, 5, 26, 15, 31, 29, 421, DateTimeKind.Local).AddTicks(7655), "Generic Granite Shirt" },
                    { 6L, "Granite", "Jaime Veum", 191L, new DateTime(2020, 9, 21, 8, 34, 24, 215, DateTimeKind.Local).AddTicks(4682), "Ergonomic Rubber Bacon" },
                    { 7L, "Concrete", "Tommie Keeling", 281L, new DateTime(2016, 5, 27, 12, 14, 50, 894, DateTimeKind.Local).AddTicks(801), "Incredible Fresh Soap" },
                    { 8L, "Granite", "Toby Mitchell", 70L, new DateTime(2021, 4, 22, 21, 36, 7, 10, DateTimeKind.Local).AddTicks(99), "Fantastic Metal Salad" },
                    { 9L, "Steel", "Shari Pacocha", 40L, new DateTime(2021, 6, 11, 1, 24, 16, 707, DateTimeKind.Local).AddTicks(5994), "Sleek Cotton Shirt" },
                    { 10L, "Rubber", "Irvin Weimann", 237L, new DateTime(2022, 4, 12, 19, 47, 5, 29, DateTimeKind.Local).AddTicks(7587), "Generic Steel Pizza" },
                    { 11L, "Granite", "Elena Schuppe", 117L, new DateTime(2022, 2, 26, 23, 4, 11, 454, DateTimeKind.Local).AddTicks(9757), "Licensed Soft Tuna" },
                    { 12L, "Soft", "Clara Gleichner", 158L, new DateTime(2021, 10, 17, 9, 43, 52, 485, DateTimeKind.Local).AddTicks(8809), "Tasty Plastic Shirt" },
                    { 13L, "Rubber", "Gloria Kutch", 105L, new DateTime(2015, 11, 8, 1, 36, 24, 364, DateTimeKind.Local).AddTicks(3281), "Practical Frozen Computer" },
                    { 14L, "Fresh", "Tracy Harris", 124L, new DateTime(2023, 4, 27, 12, 25, 12, 881, DateTimeKind.Local).AddTicks(1338), "Sleek Frozen Mouse" },
                    { 15L, "Rubber", "Alexander Hoppe", 117L, new DateTime(2015, 5, 6, 6, 0, 34, 380, DateTimeKind.Local).AddTicks(676), "Rustic Plastic Car" },
                    { 16L, "Soft", "Jesse Bartell", 204L, new DateTime(2016, 9, 23, 9, 52, 39, 812, DateTimeKind.Local).AddTicks(4895), "Tasty Frozen Pants" },
                    { 17L, "Fresh", "Carroll Orn", 163L, new DateTime(2018, 9, 13, 20, 16, 43, 394, DateTimeKind.Local).AddTicks(6483), "Generic Steel Tuna" },
                    { 18L, "Steel", "Helen Pagac", 60L, new DateTime(2019, 2, 21, 9, 20, 4, 814, DateTimeKind.Local).AddTicks(9649), "Generic Metal Table" },
                    { 19L, "Wooden", "Antonio Predovic", 269L, new DateTime(2020, 9, 2, 3, 25, 42, 637, DateTimeKind.Local).AddTicks(6631), "Handmade Metal Gloves" },
                    { 20L, "Wooden", "Gerard Jast", 151L, new DateTime(2023, 2, 26, 16, 28, 35, 302, DateTimeKind.Local).AddTicks(8393), "Intelligent Concrete Chips" },
                    { 21L, "Metal", "Don Rau", 134L, new DateTime(2016, 8, 4, 16, 32, 47, 348, DateTimeKind.Local).AddTicks(6613), "Small Plastic Keyboard" },
                    { 22L, "Wooden", "Glenda Ortiz", 217L, new DateTime(2022, 6, 5, 12, 48, 16, 275, DateTimeKind.Local).AddTicks(3507), "Small Soft Chips" },
                    { 23L, "Frozen", "Traci McGlynn", 73L, new DateTime(2021, 5, 24, 10, 17, 44, 184, DateTimeKind.Local).AddTicks(437), "Awesome Plastic Gloves" },
                    { 24L, "Metal", "Lola Hudson", 101L, new DateTime(2023, 1, 3, 3, 59, 21, 8, DateTimeKind.Local).AddTicks(4805), "Handmade Rubber Car" },
                    { 25L, "Rubber", "Alberta Hickle", 128L, new DateTime(2020, 9, 26, 11, 7, 22, 819, DateTimeKind.Local).AddTicks(2626), "Small Concrete Hat" },
                    { 26L, "Plastic", "Terri Rippin", 96L, new DateTime(2021, 12, 27, 22, 20, 51, 511, DateTimeKind.Local).AddTicks(7559), "Gorgeous Granite Bacon" },
                    { 27L, "Steel", "Kelly Farrell", 188L, new DateTime(2014, 7, 26, 14, 19, 40, 212, DateTimeKind.Local).AddTicks(2558), "Practical Plastic Chips" },
                    { 28L, "Plastic", "Marta Rutherford", 45L, new DateTime(2016, 3, 10, 14, 54, 39, 219, DateTimeKind.Local).AddTicks(6183), "Refined Steel Gloves" },
                    { 29L, "Steel", "Yvette Bashirian", 181L, new DateTime(2017, 12, 13, 8, 50, 51, 650, DateTimeKind.Local).AddTicks(4225), "Handmade Rubber Pants" },
                    { 30L, "Soft", "Santos Tremblay", 35L, new DateTime(2022, 3, 27, 18, 24, 30, 742, DateTimeKind.Local).AddTicks(815), "Licensed Rubber Shirt" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
