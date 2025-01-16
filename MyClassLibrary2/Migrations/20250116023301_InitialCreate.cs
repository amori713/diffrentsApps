using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyClassLibrary2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShapeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Perimeter = table.Column<double>(type: "float", nullable: false),
                    CalculatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Base = table.Column<double>(type: "float", nullable: true),
                    Parallelogram_Height = table.Column<double>(type: "float", nullable: true),
                    Parallelogram_SideLength = table.Column<double>(type: "float", nullable: true),
                    Width = table.Column<double>(type: "float", nullable: true),
                    Rectangle_Height = table.Column<double>(type: "float", nullable: true),
                    SideLength = table.Column<double>(type: "float", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true),
                    Triangle_Base = table.Column<double>(type: "float", nullable: true),
                    Triangle_Height = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shapes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Operand1 = table.Column<double>(type: "float", nullable: false),
                    Operand2 = table.Column<double>(type: "float", nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<double>(type: "float", nullable: false),
                    PerformedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShapeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calculations_Shapes_ShapeId",
                        column: x => x.ShapeId,
                        principalTable: "Shapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RockPaperScissorsResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerChoice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComputerChoice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShapeId = table.Column<int>(type: "int", nullable: true),
                    CalculationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RockPaperScissorsResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RockPaperScissorsResults_Calculations_CalculationId",
                        column: x => x.CalculationId,
                        principalTable: "Calculations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RockPaperScissorsResults_Shapes_ShapeId",
                        column: x => x.ShapeId,
                        principalTable: "Shapes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Shapes",
                columns: new[] { "Id", "Area", "CalculatedOn", "Rectangle_Height", "Perimeter", "ShapeType", "Width" },
                values: new object[] { 1, 50.0, new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(5784), 10.0, 30.0, "Rectangle", 5.0 });

            migrationBuilder.InsertData(
                table: "Shapes",
                columns: new[] { "Id", "Area", "Base", "CalculatedOn", "Parallelogram_Height", "Perimeter", "ShapeType", "Parallelogram_SideLength" },
                values: new object[] { 2, 28.0, 4.0, new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(6763), 7.0, 18.0, "Parallelogram", 5.0 });

            migrationBuilder.InsertData(
                table: "Shapes",
                columns: new[] { "Id", "Area", "Triangle_Base", "CalculatedOn", "Triangle_Height", "Perimeter", "ShapeType" },
                values: new object[] { 3, 9.0, 3.0, new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(6877), 6.0, 12.0, "Triangle" });

            migrationBuilder.InsertData(
                table: "Shapes",
                columns: new[] { "Id", "Area", "CalculatedOn", "Height", "Perimeter", "ShapeType", "SideLength" },
                values: new object[] { 4, 48.0, new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(6941), 8.0, 24.0, "Rhombus", 6.0 });

            migrationBuilder.InsertData(
                table: "Calculations",
                columns: new[] { "Id", "Operand1", "Operand2", "Operator", "PerformedOn", "Result", "ShapeId" },
                values: new object[,]
                {
                    { 1, 10.0, 5.0, "+", new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(7106), 15.0, 1 },
                    { 2, 20.0, 4.0, "/", new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(7116), 5.0, 2 },
                    { 3, 7.0, 3.0, "-", new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(7121), 4.0, 3 }
                });

            migrationBuilder.InsertData(
                table: "RockPaperScissorsResults",
                columns: new[] { "Id", "CalculationId", "ComputerChoice", "PlayedOn", "PlayerChoice", "Result", "ShapeId" },
                values: new object[,]
                {
                    { 1, 1, "sax", new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(7250), "sten", "Vinst", 1 },
                    { 2, 2, "sten", new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(7269), "påse", "Vinst", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculations_ShapeId",
                table: "Calculations",
                column: "ShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_RockPaperScissorsResults_CalculationId",
                table: "RockPaperScissorsResults",
                column: "CalculationId");

            migrationBuilder.CreateIndex(
                name: "IX_RockPaperScissorsResults_ShapeId",
                table: "RockPaperScissorsResults",
                column: "ShapeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RockPaperScissorsResults");

            migrationBuilder.DropTable(
                name: "Calculations");

            migrationBuilder.DropTable(
                name: "Shapes");
        }
    }
}
