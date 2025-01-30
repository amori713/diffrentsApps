using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyClassLibrary2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWinPercentageField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 1,
                column: "PerformedOn",
                value: new DateTime(2025, 1, 31, 0, 3, 48, 439, DateTimeKind.Local).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 2,
                column: "PerformedOn",
                value: new DateTime(2025, 1, 31, 0, 3, 48, 439, DateTimeKind.Local).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 3,
                column: "PerformedOn",
                value: new DateTime(2025, 1, 31, 0, 3, 48, 439, DateTimeKind.Local).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "RockPaperScissorsResults",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayedOn",
                value: new DateTime(2025, 1, 31, 0, 3, 48, 439, DateTimeKind.Local).AddTicks(7767));

            migrationBuilder.UpdateData(
                table: "RockPaperScissorsResults",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlayedOn",
                value: new DateTime(2025, 1, 31, 0, 3, 48, 439, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 31, 0, 3, 48, 439, DateTimeKind.Local).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 31, 0, 3, 48, 439, DateTimeKind.Local).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 31, 0, 3, 48, 439, DateTimeKind.Local).AddTicks(7615));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 31, 0, 3, 48, 439, DateTimeKind.Local).AddTicks(7640));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 1,
                column: "PerformedOn",
                value: new DateTime(2025, 1, 19, 6, 11, 13, 361, DateTimeKind.Local).AddTicks(7008));

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 2,
                column: "PerformedOn",
                value: new DateTime(2025, 1, 19, 6, 11, 13, 361, DateTimeKind.Local).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 3,
                column: "PerformedOn",
                value: new DateTime(2025, 1, 19, 6, 11, 13, 361, DateTimeKind.Local).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "RockPaperScissorsResults",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayedOn",
                value: new DateTime(2025, 1, 19, 6, 11, 13, 361, DateTimeKind.Local).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "RockPaperScissorsResults",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlayedOn",
                value: new DateTime(2025, 1, 19, 6, 11, 13, 361, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 19, 6, 11, 13, 361, DateTimeKind.Local).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 19, 6, 11, 13, 361, DateTimeKind.Local).AddTicks(6799));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 19, 6, 11, 13, 361, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CalculatedOn",
                value: new DateTime(2025, 1, 19, 6, 11, 13, 361, DateTimeKind.Local).AddTicks(6944));
        }
    }
}
