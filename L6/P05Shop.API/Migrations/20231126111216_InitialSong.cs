using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P05Shop.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialSong : Migration
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
                    { 1L, "Fresh", "Ramon Lockman", 129L, new DateTime(2019, 1, 14, 18, 52, 26, 726, DateTimeKind.Local).AddTicks(1390), "Gorgeous Wooden Chair" },
                    { 2L, "Rubber", "Leonard Bailey", 101L, new DateTime(2022, 4, 21, 21, 46, 23, 987, DateTimeKind.Local).AddTicks(4310), "Sleek Cotton Shoes" },
                    { 3L, "Fresh", "Dan O'Hara", 265L, new DateTime(2021, 7, 18, 2, 50, 7, 798, DateTimeKind.Local).AddTicks(8057), "Incredible Rubber Bike" },
                    { 4L, "Rubber", "Luther Cruickshank", 50L, new DateTime(2014, 11, 24, 9, 58, 34, 647, DateTimeKind.Local).AddTicks(8463), "Generic Steel Chips" },
                    { 5L, "Concrete", "Alyssa Will", 101L, new DateTime(2014, 6, 4, 7, 56, 30, 319, DateTimeKind.Local).AddTicks(7809), "Generic Granite Shirt" },
                    { 6L, "Granite", "Jaime Veum", 191L, new DateTime(2020, 9, 30, 0, 59, 25, 113, DateTimeKind.Local).AddTicks(4814), "Ergonomic Rubber Bacon" },
                    { 7L, "Concrete", "Tommie Keeling", 281L, new DateTime(2016, 6, 5, 4, 39, 51, 792, DateTimeKind.Local).AddTicks(956), "Incredible Fresh Soap" },
                    { 8L, "Granite", "Toby Mitchell", 70L, new DateTime(2021, 5, 1, 14, 1, 7, 908, DateTimeKind.Local).AddTicks(312), "Fantastic Metal Salad" },
                    { 9L, "Steel", "Shari Pacocha", 40L, new DateTime(2021, 6, 19, 17, 49, 17, 605, DateTimeKind.Local).AddTicks(6152), "Sleek Cotton Shirt" },
                    { 10L, "Rubber", "Irvin Weimann", 237L, new DateTime(2022, 4, 21, 12, 12, 5, 927, DateTimeKind.Local).AddTicks(7743), "Generic Steel Pizza" },
                    { 11L, "Granite", "Elena Schuppe", 117L, new DateTime(2022, 3, 7, 15, 29, 12, 353, DateTimeKind.Local).AddTicks(23), "Licensed Soft Tuna" },
                    { 12L, "Soft", "Clara Gleichner", 158L, new DateTime(2021, 10, 26, 2, 8, 53, 383, DateTimeKind.Local).AddTicks(9041), "Tasty Plastic Shirt" },
                    { 13L, "Rubber", "Gloria Kutch", 105L, new DateTime(2015, 11, 16, 18, 1, 25, 262, DateTimeKind.Local).AddTicks(3559), "Practical Frozen Computer" },
                    { 14L, "Fresh", "Tracy Harris", 124L, new DateTime(2023, 5, 6, 4, 50, 13, 779, DateTimeKind.Local).AddTicks(1730), "Sleek Frozen Mouse" },
                    { 15L, "Rubber", "Alexander Hoppe", 117L, new DateTime(2015, 5, 14, 22, 25, 35, 278, DateTimeKind.Local).AddTicks(1041), "Rustic Plastic Car" },
                    { 16L, "Soft", "Jesse Bartell", 204L, new DateTime(2016, 10, 2, 2, 17, 40, 710, DateTimeKind.Local).AddTicks(5174), "Tasty Frozen Pants" },
                    { 17L, "Fresh", "Carroll Orn", 163L, new DateTime(2018, 9, 22, 12, 41, 44, 292, DateTimeKind.Local).AddTicks(6809), "Generic Steel Tuna" },
                    { 18L, "Steel", "Helen Pagac", 60L, new DateTime(2019, 3, 2, 1, 45, 5, 712, DateTimeKind.Local).AddTicks(9994), "Generic Metal Table" },
                    { 19L, "Wooden", "Antonio Predovic", 269L, new DateTime(2020, 9, 10, 19, 50, 43, 535, DateTimeKind.Local).AddTicks(6893), "Handmade Metal Gloves" },
                    { 20L, "Wooden", "Gerard Jast", 151L, new DateTime(2023, 3, 7, 8, 53, 36, 200, DateTimeKind.Local).AddTicks(8712), "Intelligent Concrete Chips" },
                    { 21L, "Metal", "Don Rau", 134L, new DateTime(2016, 8, 13, 8, 57, 48, 246, DateTimeKind.Local).AddTicks(6946), "Small Plastic Keyboard" },
                    { 22L, "Wooden", "Glenda Ortiz", 217L, new DateTime(2022, 6, 14, 5, 13, 17, 173, DateTimeKind.Local).AddTicks(3762), "Small Soft Chips" },
                    { 23L, "Frozen", "Traci McGlynn", 73L, new DateTime(2021, 6, 2, 2, 42, 45, 82, DateTimeKind.Local).AddTicks(785), "Awesome Plastic Gloves" },
                    { 24L, "Metal", "Lola Hudson", 101L, new DateTime(2023, 1, 11, 20, 24, 21, 906, DateTimeKind.Local).AddTicks(5156), "Handmade Rubber Car" },
                    { 25L, "Rubber", "Alberta Hickle", 128L, new DateTime(2020, 10, 5, 3, 32, 23, 717, DateTimeKind.Local).AddTicks(2937), "Small Concrete Hat" },
                    { 26L, "Plastic", "Terri Rippin", 96L, new DateTime(2022, 1, 5, 14, 45, 52, 409, DateTimeKind.Local).AddTicks(7966), "Gorgeous Granite Bacon" },
                    { 27L, "Steel", "Kelly Farrell", 188L, new DateTime(2014, 8, 4, 6, 44, 41, 110, DateTimeKind.Local).AddTicks(2922), "Practical Plastic Chips" },
                    { 28L, "Plastic", "Marta Rutherford", 45L, new DateTime(2016, 3, 19, 7, 19, 40, 117, DateTimeKind.Local).AddTicks(6634), "Refined Steel Gloves" },
                    { 29L, "Steel", "Yvette Bashirian", 181L, new DateTime(2017, 12, 22, 1, 15, 52, 548, DateTimeKind.Local).AddTicks(4617), "Handmade Rubber Pants" },
                    { 30L, "Soft", "Santos Tremblay", 35L, new DateTime(2022, 4, 5, 10, 49, 31, 640, DateTimeKind.Local).AddTicks(1162), "Licensed Rubber Shirt" }
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
