using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyClassLibrary2.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 1,
                column: "PerformedOn",
                value: new DateTime(2025, 1, 16, 3, 34, 46, 988, DateTimeKind.Local).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 2,
                column: "PerformedOn",
                value: new DateTime(2025, 1, 16, 3, 34, 46, 988, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 3,
                column: "PerformedOn",
                value: new DateTime(2025, 1, 16, 3, 34, 46, 988, DateTimeKind.Local).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "RockPaperScissorsResults",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayedOn",
                value: new DateTime(2025, 1, 16, 3, 34, 46, 988, DateTimeKind.Local).AddTicks(5326));

            migrationBuilder.UpdateData(
                table: "RockPaperScissorsResults",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlayedOn",
                value: new DateTime(2025, 1, 16, 3, 34, 46, 988, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 16, 3, 34, 46, 988, DateTimeKind.Local).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 16, 3, 34, 46, 988, DateTimeKind.Local).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 16, 3, 34, 46, 988, DateTimeKind.Local).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 16, 3, 34, 46, 988, DateTimeKind.Local).AddTicks(5268));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 1,
                column: "PerformedOn",
                value: new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 2,
                column: "PerformedOn",
                value: new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(7116));

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 3,
                column: "PerformedOn",
                value: new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(7121));

            migrationBuilder.UpdateData(
                table: "RockPaperScissorsResults",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayedOn",
                value: new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(7250));

            migrationBuilder.UpdateData(
                table: "RockPaperScissorsResults",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlayedOn",
                value: new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 16, 3, 33, 0, 926, DateTimeKind.Local).AddTicks(6941));
        }
    }
}
