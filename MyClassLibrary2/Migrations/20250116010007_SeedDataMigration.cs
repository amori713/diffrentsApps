using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyClassLibrary2.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shapes",
                columns: new[] { "Id", "Area", "CalculatedOn", "Rectangle_Height", "Perimeter", "ShapeType", "Width" },
                values: new object[] { 1, 50.0, new DateTime(2025, 1, 16, 2, 0, 6, 444, DateTimeKind.Local).AddTicks(3020), 10.0, 30.0, "Rectangle", 5.0 });

            migrationBuilder.InsertData(
                table: "Shapes",
                columns: new[] { "Id", "Area", "Base", "CalculatedOn", "Parallelogram_Height", "Perimeter", "ShapeType", "Parallelogram_SideLength" },
                values: new object[] { 2, 28.0, 4.0, new DateTime(2025, 1, 16, 2, 0, 6, 444, DateTimeKind.Local).AddTicks(3301), 7.0, 18.0, "Parallelogram", 5.0 });

            migrationBuilder.InsertData(
                table: "Shapes",
                columns: new[] { "Id", "Area", "Triangle_Base", "CalculatedOn", "Triangle_Height", "Perimeter", "ShapeType" },
                values: new object[] { 3, 9.0, 3.0, new DateTime(2025, 1, 16, 2, 0, 6, 444, DateTimeKind.Local).AddTicks(3328), 6.0, 12.0, "Triangle" });

            migrationBuilder.InsertData(
                table: "Shapes",
                columns: new[] { "Id", "Area", "CalculatedOn", "Height", "Perimeter", "ShapeType", "SideLength" },
                values: new object[] { 4, 48.0, new DateTime(2025, 1, 16, 2, 0, 6, 444, DateTimeKind.Local).AddTicks(3354), 8.0, 24.0, "Rhombus", 6.0 });

            migrationBuilder.InsertData(
                table: "Calculations",
                columns: new[] { "Id", "Operand1", "Operand2", "Operator", "PerformedOn", "Result", "ShapeId" },
                values: new object[,]
                {
                    { 1, 10.0, 5.0, "+", new DateTime(2025, 1, 16, 2, 0, 6, 444, DateTimeKind.Local).AddTicks(3381), 15.0, 1 },
                    { 2, 20.0, 4.0, "/", new DateTime(2025, 1, 16, 2, 0, 6, 444, DateTimeKind.Local).AddTicks(3386), 5.0, 2 },
                    { 3, 7.0, 3.0, "-", new DateTime(2025, 1, 16, 2, 0, 6, 444, DateTimeKind.Local).AddTicks(3389), 4.0, 3 }
                });

            migrationBuilder.InsertData(
                table: "RockPaperScissorsResults",
                columns: new[] { "Id", "CalculationId", "ComputerChoice", "PlayedOn", "PlayerChoice", "Result", "ShapeId" },
                values: new object[,]
                {
                    { 1, 1, "sax", new DateTime(2025, 1, 16, 2, 0, 6, 444, DateTimeKind.Local).AddTicks(3417), "sten", "Vinst", 1 },
                    { 2, 2, "sten", new DateTime(2025, 1, 16, 2, 0, 6, 444, DateTimeKind.Local).AddTicks(3421), "påse", "Vinst", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RockPaperScissorsResults",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RockPaperScissorsResults",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
