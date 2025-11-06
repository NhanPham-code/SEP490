using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingAPI.Migrations
{
    /// <inheritdoc />
    public partial class newDataV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 38, new DateTime(2025, 2, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 6, 38, new DateTime(2025, 2, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 7, 38, new DateTime(2025, 2, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 8, 38, new DateTime(2025, 2, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 9, 24, new DateTime(2025, 3, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 10, 24, new DateTime(2025, 3, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 11, 24, new DateTime(2025, 3, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 12, 24, new DateTime(2025, 3, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 13, 11, new DateTime(2025, 4, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 14, 11, new DateTime(2025, 4, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 15, 11, new DateTime(2025, 4, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 16, 11, new DateTime(2025, 4, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 17, 37, new DateTime(2025, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 18, 37, new DateTime(2025, 5, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 19, 37, new DateTime(2025, 5, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, 37, new DateTime(2025, 5, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, 35, new DateTime(2025, 6, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, 36, new DateTime(2025, 6, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 22, 35, new DateTime(2025, 6, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 22, 36, new DateTime(2025, 6, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 23, 35, new DateTime(2025, 6, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 23, 36, new DateTime(2025, 6, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 24, 35, new DateTime(2025, 6, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, new DateTime(2025, 6, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 27, new DateTime(2025, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 27, new DateTime(2025, 7, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 27, new DateTime(2025, 7, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 27, new DateTime(2025, 7, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 25, new DateTime(2025, 8, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 25, new DateTime(2025, 8, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 25, new DateTime(2025, 8, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 25, new DateTime(2025, 8, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 26, new DateTime(2025, 9, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 26, new DateTime(2025, 9, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 26, new DateTime(2025, 9, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 26, new DateTime(2025, 9, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 10, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 10, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 10, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, new DateTime(2025, 11, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, new DateTime(2025, 11, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, new DateTime(2025, 11, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, new DateTime(2025, 11, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 25, new DateTime(2025, 12, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 25, new DateTime(2025, 12, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 25, new DateTime(2025, 12, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 25, new DateTime(2025, 12, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 24, new DateTime(2025, 10, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, new DateTime(2025, 10, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 11, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 30, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 27, new DateTime(2025, 10, 17, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 10, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 25, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2025, 11, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 18, new DateTime(2025, 10, 16, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 16, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2025, 11, 6, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 6, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2025, 9, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 58, 21, new DateTime(2025, 9, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 59, 37, new DateTime(2025, 10, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 7, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 60, new DateTime(2025, 9, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 38, new DateTime(2025, 11, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 38, new DateTime(2025, 11, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 20, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 17, new DateTime(2025, 9, 16, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 16, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, new DateTime(2025, 11, 11, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, new DateTime(2025, 9, 27, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 27, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, new DateTime(2025, 9, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 17, new DateTime(2025, 11, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 10, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 11, new DateTime(2025, 11, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 25, new DateTime(2025, 11, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 14, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 26, new DateTime(2025, 11, 12, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 12, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2025, 11, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 73, 37, new DateTime(2025, 11, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 74, 35, new DateTime(2025, 12, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 75, 20, new DateTime(2025, 10, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 2, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 76, 11, new DateTime(2025, 10, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 26, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 77, new DateTime(2025, 10, 4, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 78, 11, new DateTime(2025, 11, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 25, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 79, 11, new DateTime(2025, 11, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 80, 35, new DateTime(2025, 11, 26, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 26, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 80, 36, new DateTime(2025, 11, 26, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 26, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 81, 36, new DateTime(2025, 11, 5, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 5, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 82, 36, new DateTime(2025, 9, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 28, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 83, 18, new DateTime(2025, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 84, 36, new DateTime(2025, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 85, 35, new DateTime(2025, 10, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 19, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 86, 20, new DateTime(2025, 9, 11, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 11, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 86, 21, new DateTime(2025, 9, 11, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 11, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 87, 39, new DateTime(2025, 9, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 11, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 88, 18, new DateTime(2025, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 89, 35, new DateTime(2025, 11, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 89, new DateTime(2025, 11, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 90, new DateTime(2025, 10, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 23, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 91, 37, new DateTime(2025, 11, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 28, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 92, 27, new DateTime(2025, 10, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 93, 25, new DateTime(2025, 11, 9, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 9, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 94, 11, new DateTime(2025, 11, 13, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 13, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 95, 20, new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 96, 38, new DateTime(2025, 10, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 97, 11, new DateTime(2025, 11, 30, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 30, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 98, 37, new DateTime(2025, 9, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 99, 24, new DateTime(2025, 11, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 28, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 100, 27, new DateTime(2025, 12, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 3, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 101, 5, new DateTime(2025, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 102, 5, new DateTime(2025, 1, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 103, 5, new DateTime(2025, 1, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 104, 5, new DateTime(2025, 1, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 105, new DateTime(2025, 2, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 106, 2, new DateTime(2025, 2, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 107, new DateTime(2025, 2, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 108, 2, new DateTime(2025, 2, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 109, 5, new DateTime(2025, 3, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 110, 5, new DateTime(2025, 3, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 111, 5, new DateTime(2025, 3, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 112, 5, new DateTime(2025, 3, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 113, 5, new DateTime(2025, 4, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 114, 5, new DateTime(2025, 4, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 115, 5, new DateTime(2025, 4, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 116, 5, new DateTime(2025, 4, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 117, 22, new DateTime(2025, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 118, 22, new DateTime(2025, 5, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 119, 22, new DateTime(2025, 5, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 120, 22, new DateTime(2025, 5, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 121, 15, new DateTime(2025, 6, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 122, 15, new DateTime(2025, 6, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 123, 15, new DateTime(2025, 6, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 124, 15, new DateTime(2025, 6, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 125, 22, new DateTime(2025, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 126, 22, new DateTime(2025, 7, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 127, 22, new DateTime(2025, 7, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 128, 22, new DateTime(2025, 7, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 129, 12, new DateTime(2025, 8, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 130, 12, new DateTime(2025, 8, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 131, 12, new DateTime(2025, 8, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 132, 12, new DateTime(2025, 8, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 133, 29, new DateTime(2025, 9, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 134, 29, new DateTime(2025, 9, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 135, 29, new DateTime(2025, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 136, 29, new DateTime(2025, 9, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 137, 15, new DateTime(2025, 10, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 138, 15, new DateTime(2025, 10, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 139, 15, new DateTime(2025, 10, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 140, 15, new DateTime(2025, 10, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 141, 33, new DateTime(2025, 11, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 142, 33, new DateTime(2025, 11, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 143, 33, new DateTime(2025, 11, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 144, 33, new DateTime(2025, 11, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 145, 2, new DateTime(2025, 12, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 146, 2, new DateTime(2025, 12, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 147, 2, new DateTime(2025, 12, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 148, 2, new DateTime(2025, 12, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 149, 5, new DateTime(2025, 10, 13, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 13, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 150, 2, new DateTime(2025, 9, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 150, 3, new DateTime(2025, 9, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 151, 2, new DateTime(2025, 10, 6, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 152, 22, new DateTime(2025, 9, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 153, 16, new DateTime(2025, 11, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 154, 13, new DateTime(2025, 10, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 14, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 155, 29, new DateTime(2025, 11, 27, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 156, 16, new DateTime(2025, 9, 16, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 16, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 157, 15, new DateTime(2025, 11, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 158, new DateTime(2025, 10, 21, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 158, new DateTime(2025, 10, 21, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 159, 29, new DateTime(2025, 12, 4, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 4, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 160, 14, new DateTime(2025, 9, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 7, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 161, 33, new DateTime(2025, 9, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 162, 28, new DateTime(2025, 10, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 13, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 163, 22, new DateTime(2025, 12, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 164, 2, new DateTime(2025, 11, 18, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 164, 3, new DateTime(2025, 11, 18, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 165, 16, new DateTime(2025, 11, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 166, 3, new DateTime(2025, 9, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 21, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 167, new DateTime(2025, 9, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 168, 14, new DateTime(2025, 9, 25, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 169, 15, new DateTime(2025, 10, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 170, new DateTime(2025, 9, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 171, 13, new DateTime(2025, 10, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 172, 2, new DateTime(2025, 10, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 30, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 172, 3, new DateTime(2025, 10, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 30, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 173, 12, new DateTime(2025, 11, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 16, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 174, 15, new DateTime(2025, 9, 21, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 21, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 175, 3, new DateTime(2025, 10, 21, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 176, 33, new DateTime(2025, 11, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 177, 3, new DateTime(2025, 10, 16, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 16, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 178, new DateTime(2025, 10, 4, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 179, 33, new DateTime(2025, 11, 29, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 180, 2, new DateTime(2025, 11, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 180, 3, new DateTime(2025, 11, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 181, 5, new DateTime(2025, 12, 3, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 3, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 182, 4, new DateTime(2025, 10, 16, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 16, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 183, 14, new DateTime(2025, 11, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 184, 3, new DateTime(2025, 9, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 185, 15, new DateTime(2025, 11, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 25, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 186, 12, new DateTime(2025, 10, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 187, 5, new DateTime(2025, 11, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 23, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 188, 29, new DateTime(2025, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 28, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 189, 16, new DateTime(2025, 9, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 190, new DateTime(2025, 10, 24, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 24, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 191, 2, new DateTime(2025, 10, 27, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 27, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 191, 3, new DateTime(2025, 10, 27, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 27, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 192, 22, new DateTime(2025, 9, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 193, 4, new DateTime(2025, 9, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 194, 29, new DateTime(2025, 10, 10, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 10, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 195, 12, new DateTime(2025, 11, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 14, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 196, 2, new DateTime(2025, 12, 3, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 3, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 197, 2, new DateTime(2025, 11, 26, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 26, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 197, new DateTime(2025, 11, 26, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 26, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 198, 22, new DateTime(2025, 10, 26, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 26, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 199, 2, new DateTime(2025, 11, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 199, 3, new DateTime(2025, 11, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 200, 33, new DateTime(2025, 11, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 30, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 201, 23, new DateTime(2025, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 202, 23, new DateTime(2025, 1, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 203, 23, new DateTime(2025, 1, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 204, 23, new DateTime(2025, 1, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 205, 23, new DateTime(2025, 2, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 206, 23, new DateTime(2025, 2, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 207, 23, new DateTime(2025, 2, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 208, 23, new DateTime(2025, 2, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 209, 9, new DateTime(2025, 3, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 210, 9, new DateTime(2025, 3, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 211, 9, new DateTime(2025, 3, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 212, 9, new DateTime(2025, 3, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 213, 10, new DateTime(2025, 4, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 214, 10, new DateTime(2025, 4, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 215, 10, new DateTime(2025, 4, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 216, 10, new DateTime(2025, 4, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 217, 31, new DateTime(2025, 5, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 218, 31, new DateTime(2025, 5, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 219, 31, new DateTime(2025, 5, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 220, 31, new DateTime(2025, 5, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 221, 6, new DateTime(2025, 6, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 222, 6, new DateTime(2025, 6, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 223, 6, new DateTime(2025, 6, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 224, 6, new DateTime(2025, 6, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 225, new DateTime(2025, 7, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 226, new DateTime(2025, 7, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 227, new DateTime(2025, 7, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 228, new DateTime(2025, 7, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 229, 8, new DateTime(2025, 8, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 230, 8, new DateTime(2025, 8, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 231, 8, new DateTime(2025, 8, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 232, 8, new DateTime(2025, 8, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 233, 41, new DateTime(2025, 9, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 234, 41, new DateTime(2025, 9, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 235, 41, new DateTime(2025, 9, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 236, 41, new DateTime(2025, 9, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 237, 32, new DateTime(2025, 10, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 238, 32, new DateTime(2025, 10, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 239, 32, new DateTime(2025, 10, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 240, 32, new DateTime(2025, 10, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 241, 7, new DateTime(2025, 11, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 242, 7, new DateTime(2025, 11, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 243, 7, new DateTime(2025, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 244, 7, new DateTime(2025, 11, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 245, 7, new DateTime(2025, 12, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 246, 7, new DateTime(2025, 12, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 247, 7, new DateTime(2025, 12, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 248, 7, new DateTime(2025, 12, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 249, 30, new DateTime(2025, 9, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 26, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 250, 6, new DateTime(2025, 9, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 251, 32, new DateTime(2025, 9, 12, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 252, 30, new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 253, 30, new DateTime(2025, 9, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 28, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 254, 30, new DateTime(2025, 9, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 255, 42, new DateTime(2025, 11, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 256, new DateTime(2025, 11, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 257, 8, new DateTime(2025, 9, 7, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 7, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 258, 23, new DateTime(2025, 10, 27, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 27, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 259, 42, new DateTime(2025, 9, 9, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 9, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 260, 23, new DateTime(2025, 10, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 261, 42, new DateTime(2025, 10, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 31, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 262, 23, new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 263, 41, new DateTime(2025, 9, 16, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 16, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 264, 10, new DateTime(2025, 11, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 265, 23, new DateTime(2025, 11, 11, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 266, 23, new DateTime(2025, 10, 23, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 267, new DateTime(2025, 10, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 268, 41, new DateTime(2025, 10, 4, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 269, 8, new DateTime(2025, 10, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 270, 10, new DateTime(2025, 10, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 2, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 271, 7, new DateTime(2025, 9, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 272, 32, new DateTime(2025, 9, 18, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 273, 32, new DateTime(2025, 10, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 14, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 274, 9, new DateTime(2025, 11, 16, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 16, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 275, 7, new DateTime(2025, 10, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 29, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 276, 30, new DateTime(2025, 9, 29, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 29, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 277, 32, new DateTime(2025, 12, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 278, 7, new DateTime(2025, 11, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 279, 32, new DateTime(2025, 11, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 14, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 280, 42, new DateTime(2025, 9, 26, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 26, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 281, new DateTime(2025, 10, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 282, new DateTime(2025, 9, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 283, 10, new DateTime(2025, 11, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 284, 6, new DateTime(2025, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 285, 41, new DateTime(2025, 11, 9, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 9, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 306,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 286, 30, new DateTime(2025, 10, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 20, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 307,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 287, 31, new DateTime(2025, 11, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 308,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 288, new DateTime(2025, 9, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 29, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 289, 42, new DateTime(2025, 9, 7, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 7, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 310,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 290, new DateTime(2025, 11, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 291, 8, new DateTime(2025, 9, 10, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 312,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 292, 23, new DateTime(2025, 10, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 313,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 293, 41, new DateTime(2025, 9, 27, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 27, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 314,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 294, 9, new DateTime(2025, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 27, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 315,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 295, 6, new DateTime(2025, 10, 2, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 2, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 296, 32, new DateTime(2025, 11, 11, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 317,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 297, 7, new DateTime(2025, 9, 15, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 318,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 298, 9, new DateTime(2025, 10, 7, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 7, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 319,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 299, 32, new DateTime(2025, 11, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 320,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 300, 41, new DateTime(2025, 11, 12, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 12, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 6, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 6, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 6, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 6, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 26, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 26, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 26, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 26, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 100000m, 17, 100000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 100000m, 17, 100000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 100000m, 17, 100000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 100000m, 17, 100000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 1000000m, 6, 1000000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 1000000m, 6, 1000000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 1000000m, 6, 1000000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 1000000m, 6, 1000000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 240000m, 26, 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 240000m, 26, 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 240000m, 26, 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 240000m, 26, 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 900000m, 25, "completed", 900000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 900000m, 25, "completed", 900000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 900000m, 25, "completed", 900000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 900000m, 25, "completed", 900000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 18, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 18, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 18, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 18, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 17, "completed", 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 17, "completed", 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 17, "completed", 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 17, "completed", 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 500000m, 18, "cancelled", 500000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 500000m, 18, "cancelled", 500000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 500000m, 18, "cancelled", 500000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 500000m, 18, "cancelled", 500000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 26, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 26, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 26, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 26, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 25, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 25, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 25, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 25, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 17, 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 17, 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 17, 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 17, 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 17, "cancelled", 100000m, new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "completed", 240000m, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "cancelled", 240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 18, 300000m, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, 14, 360000m, new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 150000m, 13, "completed", 150000m, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, 14, "cancelled", 360000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 560000m, 14, "completed", 560000m, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, 240000m, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, 14, "completed", 360000m, new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "completed", 240000m, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "accepted", 240000m, new DateTime(2025, 11, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 11, 160000m, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 360000m, 14, 360000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "completed", 600000m, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "cancelled", 600000m, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 11, "completed", 160000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "completed", 600000m, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 1000000m, 6, "accepted", 1000000m, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 17, "accepted", 140000m, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 500000m, 18, "accepted", 500000m, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, 14, 360000m, new DateTime(2025, 11, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), "accepted", new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "accepted", 600000m, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, 14, "completed", 360000m, new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 1000000m, 6, "completed", 1000000m, new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, 14, "completed", 360000m, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 1000000m, 6, "accepted", 1000000m, new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 1000000m, 6, 1000000m, new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 900000m, 25, "accepted", 900000m, new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, 600000m, new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "completed", 600000m, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 150000m, 13, "completed", 150000m, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, 600000m, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 560000m, 14, "completed", 560000m, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, 240000m, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 150000m, 13, "accepted", 150000m, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 900000m, 25, 900000m, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 18, "completed", 300000m, new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "accepted", 240000m, new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 18, 300000m, new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 17, "accepted", 140000m, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 1000000m, 6, "accepted", 1000000m, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, 14, 360000m, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, 240000m, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 1000000m, 6, "cancelled", 1000000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, 240000m, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 17, 100000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 18, 300000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 100000m, 2, 100000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 100000m, 2, 100000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 100000m, 2, 100000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 100000m, 2, 100000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 400000m, 400000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 400000m, 400000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 400000m, 400000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 400000m, 400000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 100000m, 2, 100000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 100000m, 2, 100000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 100000m, 2, 100000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 100000m, 2, 100000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 100000m, 2, 100000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 100000m, 2, 100000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 100000m, 2, 100000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 100000m, 2, 100000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 220000m, 15, 220000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 220000m, 15, 220000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 220000m, 15, 220000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 220000m, 15, 220000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 120000m, 9, 120000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 120000m, 9, 120000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 120000m, 9, 120000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 120000m, 9, 120000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 220000m, 15, "cancelled", 220000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 220000m, 15, "cancelled", 220000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 220000m, 15, "cancelled", 220000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 220000m, 15, "cancelled", 220000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 8, "cancelled", 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 8, "cancelled", 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 8, "cancelled", 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 8, "cancelled", 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 160000m, 20, "cancelled", 160000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 160000m, 20, "cancelled", 160000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 160000m, 20, "cancelled", 160000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 160000m, 20, "cancelled", 160000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 120000m, 9, "cancelled", 120000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 120000m, 9, "cancelled", 120000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 120000m, 9, "cancelled", 120000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 120000m, 9, "cancelled", 120000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 300000m, 24, "completed", 300000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 300000m, 24, "accepted", 300000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 300000m, 24, "accepted", 300000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 300000m, 24, "accepted", 300000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 400000m, 400000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 400000m, 400000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 400000m, 400000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 400000m, 400000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, 100000m, new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 1, "cancelled", 600000m, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 400000m, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 220000m, 15, "completed", 220000m, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 10, "accepted", 300000m, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "cancelled", 240000m, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 20, 160000m, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 10, 300000m, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "accepted", 120000m, new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 1, 600000m, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 20, "accepted", 160000m, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "completed", 120000m, new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "CreatedAt", "Date", "StadiumId", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 24, "completed", new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 180000m, 19, 180000m, new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 220000m, 15, "accepted", 220000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 1, 600000m, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 10, "accepted", 300000m, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, 400000m, new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, 400000m, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, 120000m, new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, "completed", 100000m, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, 240000m, new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 1, "completed", 600000m, new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "accepted", 240000m, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "cancelled", 120000m, new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, "completed", 400000m, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 24, "accepted", 300000m, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, 400000m, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, 100000m, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), "accepted", new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 1, 600000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, "accepted", 100000m, new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), "cancelled", new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), "accepted", new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "accepted", 120000m, new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, 240000m, new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, "cancelled", 100000m, new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 20, 160000m, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 10, new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 180000m, 19, 180000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 1, 600000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 220000m, 15, 220000m, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, "cancelled", 100000m, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 20, 160000m, new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "CreatedAt", "Date", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), "accepted", new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, "accepted", 400000m, new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 1, "accepted", 600000m, new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 220000m, 15, "completed", 220000m, new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 600000m, 600000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "CreatedById", "Date", "UserId" },
                values: new object[] { 8, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 16, 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 16, 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 16, 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 16, 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 205,
                column: "StadiumId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 206,
                column: "StadiumId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 207,
                column: "StadiumId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 208,
                column: "StadiumId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 5, "completed", 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 5, "completed", 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 5, "completed", 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 5, "completed", 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 140000m, 5, 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 140000m, 5, 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 140000m, 5, 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 140000m, 5, 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 140000m, 23, 140000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 140000m, 23, 140000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 140000m, 23, 140000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 140000m, 23, 140000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 200000m, 3, "cancelled", 200000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 200000m, 3, "cancelled", 200000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 200000m, 3, "cancelled", 200000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 200000m, 3, "cancelled", 200000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 190000m, 27, 190000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 190000m, 27, 190000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 190000m, 27, 190000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 190000m, 27, 190000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 4, 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 4, 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 4, 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 4, 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "CreatedById", "Status", "UserId" },
                values: new object[] { 6, "completed", 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "CreatedById", "Status", "UserId" },
                values: new object[] { 6, "completed", 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "CreatedById", "Status", "UserId" },
                values: new object[] { 6, "completed", 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "CreatedById", "Status", "UserId" },
                values: new object[] { 6, "completed", 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 140000m, 23, 140000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 140000m, 23, 140000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 140000m, 23, 140000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 140000m, 23, 140000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 200000m, 3, 200000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 200000m, 3, 200000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 200000m, 3, 200000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 200000m, 3, 200000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 8, 3, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 8, 3, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 8, 3, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 8, 3, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 22, "completed", 200000m, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "CreatedAt", "Date", "StadiumId", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 22, "cancelled", new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 22, "cancelled", 200000m, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 22, 200000m, new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, 300000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, "completed", 300000m, new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 16, "completed", 200000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, "completed", 190000m, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 16, 200000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m, new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 16, 200000m, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, "completed", 190000m, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, "accepted", 140000m, new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 16, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 16, 200000m, new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, 300000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, "completed", new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "completed", 200000m, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, 140000m, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 23, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, "cancelled", 140000m, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 22, 200000m, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 12, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 23, "accepted", new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 23, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, "cancelled", 140000m, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, 140000m, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, 140000m, new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, "cancelled", 190000m, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 23, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, "cancelled", 140000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, "completed", 300000m, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 16, "completed", new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, "completed", 140000m, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, "accepted", 140000m, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, 140000m, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "Date", "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime", "UserId" },
                values: new object[] { new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 6, 0, 0, 0), 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 10, 0, 0, 0), 960000m, 26, new TimeSpan(0, 8, 0, 0, 0), 960000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 16, 0, 0, 0), 400000m, 17, new TimeSpan(0, 14, 0, 0, 0), 400000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 11, 0, 0, 0), 4000000m, 6, new TimeSpan(0, 9, 0, 0, 0), 4000000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 10, 0, 0, 0), 960000m, 26, new TimeSpan(0, 8, 0, 0, 0), 960000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 8, 0, 0, 0), 3600000m, 25, new TimeSpan(0, 6, 0, 0, 0), "completed", 3600000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 18, 0, 0, 0), 1200000m, 18, new TimeSpan(0, 16, 0, 0, 0), 1200000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), 560000m, 17, new TimeSpan(0, 12, 0, 0, 0), "completed", 560000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 18, 0, 0, 0), 2000000m, 18, new TimeSpan(0, 16, 0, 0, 0), "cancelled", 2000000m, 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 18, 0, 0, 0), 960000m, 26, new TimeSpan(0, 16, 0, 0, 0), 960000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 17, 0, 0, 0), 2400000m, 25, new TimeSpan(0, 15, 0, 0, 0), 2400000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 18, 0, 0, 0), 560000m, 17, new TimeSpan(0, 16, 0, 0, 0), 560000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 20, 0, 0, 0), 400000m, 2, new TimeSpan(0, 18, 0, 0, 0), 400000m, 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EndTime", "OriginalPrice", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 17, 0, 0, 0), 1600000m, new TimeSpan(0, 15, 0, 0, 0), 1600000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 16, 0, 0, 0), 400000m, 2, new TimeSpan(0, 14, 0, 0, 0), 400000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 9, 0, 0, 0), 400000m, 2, new TimeSpan(0, 7, 0, 0, 0), 400000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 10, 0, 0, 0), 880000m, 15, new TimeSpan(0, 8, 0, 0, 0), 880000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 17, 0, 0, 0), 480000m, 9, new TimeSpan(0, 15, 0, 0, 0), 480000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 10, 0, 0, 0), 880000m, 15, new TimeSpan(0, 8, 0, 0, 0), "cancelled", 880000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 13, 0, 0, 0), 960000m, 8, new TimeSpan(0, 11, 0, 0, 0), "cancelled", 960000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 13, 0, 0, 0), 640000m, 20, new TimeSpan(0, 11, 0, 0, 0), "cancelled", 640000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 11, 0, 0, 0), 480000m, 9, new TimeSpan(0, 9, 0, 0, 0), "cancelled", 480000m, 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), 1200000m, 24, new TimeSpan(0, 12, 0, 0, 0), "accepted", 1200000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "EndTime", "OriginalPrice", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 19, 0, 0, 0), 1600000m, new TimeSpan(0, 17, 0, 0, 0), 1600000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 18, 0, 0, 0), 800000m, 16, new TimeSpan(0, 16, 0, 0, 0), 800000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "EndTime", "StadiumId", "StartTime" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), 16, new TimeSpan(0, 12, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 19, 0, 0, 0), 560000m, 5, new TimeSpan(0, 17, 0, 0, 0), "completed", 560000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 20, 0, 0, 0), 560000m, 5, new TimeSpan(0, 18, 0, 0, 0), 560000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 16, 0, 0, 0), 560000m, 23, new TimeSpan(0, 14, 0, 0, 0), 560000m, 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 13, 0, 0, 0), 800000m, 3, new TimeSpan(0, 11, 0, 0, 0), "cancelled", 800000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 15, 0, 0, 0), 760000m, 27, new TimeSpan(0, 13, 0, 0, 0), 760000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 10, 0, 0, 0), 1200000m, 4, new TimeSpan(0, 8, 0, 0, 0), 1200000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "EndTime", "StartTime", "Status", "UserId" },
                values: new object[] { new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 16, 0, 0, 0), "completed", 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 11, 0, 0, 0), 560000m, 23, new TimeSpan(0, 9, 0, 0, 0), 560000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 13, 0, 0, 0), 800000m, 3, new TimeSpan(0, 11, 0, 0, 0), 800000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "EndTime", "StadiumId", "StartTime", "UserId" },
                values: new object[] { new TimeSpan(0, 11, 0, 0, 0), 3, new TimeSpan(0, 9, 0, 0, 0), 8 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 1, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 2, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 5, 36, new DateTime(2025, 2, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 6, 35, new DateTime(2025, 2, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 6, 36, new DateTime(2025, 2, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 7, 35, new DateTime(2025, 2, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 7, 36, new DateTime(2025, 2, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 8, 35, new DateTime(2025, 2, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 8, 36, new DateTime(2025, 2, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 9, 26, new DateTime(2025, 3, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 10, 26, new DateTime(2025, 3, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 11, 26, new DateTime(2025, 3, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 12, 26, new DateTime(2025, 3, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 13, 36, new DateTime(2025, 4, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 14, 36, new DateTime(2025, 4, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 15, 36, new DateTime(2025, 4, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 16, 36, new DateTime(2025, 4, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 17, 27, new DateTime(2025, 5, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 18, 27, new DateTime(2025, 5, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 19, 27, new DateTime(2025, 5, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, 27, new DateTime(2025, 5, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, 24, new DateTime(2025, 6, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 22, 24, new DateTime(2025, 6, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 23, 24, new DateTime(2025, 6, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 24, new DateTime(2025, 6, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 18, new DateTime(2025, 7, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 18, new DateTime(2025, 7, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 18, new DateTime(2025, 7, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 18, new DateTime(2025, 7, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 8, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 8, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 9, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 9, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 9, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 10, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 10, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 10, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 10, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 11, new DateTime(2025, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 11, new DateTime(2025, 11, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 11, new DateTime(2025, 11, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 11, new DateTime(2025, 11, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, new DateTime(2025, 12, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, new DateTime(2025, 12, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, new DateTime(2025, 12, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, new DateTime(2025, 12, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 37, new DateTime(2025, 9, 18, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 10, 5, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 9, 19, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, new DateTime(2025, 10, 6, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 10, 11, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 11, 15, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 14, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 11, 22, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 21, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 11, new DateTime(2025, 10, 6, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 18, new DateTime(2025, 9, 27, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 27, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, new DateTime(2025, 10, 28, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 59, 18, new DateTime(2025, 10, 1, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 60, 39, new DateTime(2025, 11, 17, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 17, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 61, new DateTime(2025, 11, 10, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, new DateTime(2025, 11, 10, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 17, new DateTime(2025, 10, 17, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, new DateTime(2025, 10, 6, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 37, new DateTime(2025, 11, 11, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, new DateTime(2025, 10, 28, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 11, new DateTime(2025, 10, 24, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 23, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 37, new DateTime(2025, 10, 6, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 17, new DateTime(2025, 9, 24, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 24, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 17, new DateTime(2025, 10, 22, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2025, 9, 20, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 19, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 10, 18, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 11, 17, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 17, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 72, 36, new DateTime(2025, 11, 17, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 17, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 73, 39, new DateTime(2025, 10, 29, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 29, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 74, 18, new DateTime(2025, 10, 28, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 75, 35, new DateTime(2025, 11, 13, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 13, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 76, new DateTime(2025, 11, 18, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 76, 21, new DateTime(2025, 11, 18, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 77, 35, new DateTime(2025, 11, 8, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 77, 36, new DateTime(2025, 11, 8, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 78, 37, new DateTime(2025, 11, 1, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 31, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 79, 18, new DateTime(2025, 11, 13, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 13, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 80, 20, new DateTime(2025, 10, 21, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 20, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 81, 27, new DateTime(2025, 10, 6, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 82, 40, new DateTime(2025, 11, 29, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 29, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 83, 17, new DateTime(2025, 11, 16, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 16, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 84, 25, new DateTime(2025, 10, 30, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 30, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 85, 35, new DateTime(2025, 10, 13, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 12, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 86, 36, new DateTime(2025, 11, 24, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 24, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 87, 35, new DateTime(2025, 10, 14, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 14, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 87, 36, new DateTime(2025, 10, 14, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 14, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 88, new DateTime(2025, 9, 14, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 14, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 89, new DateTime(2025, 11, 9, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 9, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 90, 20, new DateTime(2025, 11, 7, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 91, 26, new DateTime(2025, 10, 24, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 24, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 92, 40, new DateTime(2025, 10, 4, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 93, 40, new DateTime(2025, 9, 13, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 13, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 94, 35, new DateTime(2025, 11, 28, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 28, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 95, 35, new DateTime(2025, 9, 18, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 96, 27, new DateTime(2025, 9, 14, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 14, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 97, 27, new DateTime(2025, 11, 10, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 98, 18, new DateTime(2025, 10, 29, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 29, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 99, 37, new DateTime(2025, 11, 12, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 12, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 100, 35, new DateTime(2025, 12, 5, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 5, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 100, 36, new DateTime(2025, 12, 5, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 5, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 101, 2, new DateTime(2025, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 101, 3, new DateTime(2025, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 102, new DateTime(2025, 1, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 102, 3, new DateTime(2025, 1, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 103, new DateTime(2025, 1, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 103, 3, new DateTime(2025, 1, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 104, 2, new DateTime(2025, 1, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 104, 3, new DateTime(2025, 1, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 105, 2, new DateTime(2025, 2, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 105, 3, new DateTime(2025, 2, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 106, 2, new DateTime(2025, 2, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 106, 3, new DateTime(2025, 2, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 107, 2, new DateTime(2025, 2, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 107, 3, new DateTime(2025, 2, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 108, 2, new DateTime(2025, 2, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 108, 3, new DateTime(2025, 2, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 109, 2, new DateTime(2025, 3, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 110, 2, new DateTime(2025, 3, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 111, 2, new DateTime(2025, 3, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 112, 2, new DateTime(2025, 3, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 113, 12, new DateTime(2025, 4, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 114, 12, new DateTime(2025, 4, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 115, 12, new DateTime(2025, 4, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 116, 12, new DateTime(2025, 4, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 117, 3, new DateTime(2025, 5, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 118, 3, new DateTime(2025, 5, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 119, 3, new DateTime(2025, 5, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 120, 3, new DateTime(2025, 5, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 121, 2, new DateTime(2025, 6, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 121, 3, new DateTime(2025, 6, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 122, 2, new DateTime(2025, 6, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 122, 3, new DateTime(2025, 6, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 123, 2, new DateTime(2025, 6, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 123, 3, new DateTime(2025, 6, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 124, 2, new DateTime(2025, 6, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 124, 3, new DateTime(2025, 6, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 125, 12, new DateTime(2025, 7, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 126, 12, new DateTime(2025, 7, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 127, 12, new DateTime(2025, 7, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 128, 12, new DateTime(2025, 7, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 129, 14, new DateTime(2025, 8, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 130, 14, new DateTime(2025, 8, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 131, 14, new DateTime(2025, 8, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 132, 14, new DateTime(2025, 8, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 133, 33, new DateTime(2025, 9, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 134, 33, new DateTime(2025, 9, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 135, 33, new DateTime(2025, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 136, 33, new DateTime(2025, 9, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 137, 5, new DateTime(2025, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 138, 5, new DateTime(2025, 10, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 139, 5, new DateTime(2025, 10, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 140, 5, new DateTime(2025, 10, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 141, 22, new DateTime(2025, 11, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 142, 22, new DateTime(2025, 11, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 143, 22, new DateTime(2025, 11, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 144, 22, new DateTime(2025, 11, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 145, new DateTime(2025, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 145, new DateTime(2025, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 146, 2, new DateTime(2025, 12, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 146, 3, new DateTime(2025, 12, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 147, 2, new DateTime(2025, 12, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 147, 3, new DateTime(2025, 12, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 148, 2, new DateTime(2025, 12, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 148, 3, new DateTime(2025, 12, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 149, 28, new DateTime(2025, 11, 22, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 21, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 150, 13, new DateTime(2025, 11, 18, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 151, 2, new DateTime(2025, 10, 28, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 151, new DateTime(2025, 10, 28, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 152, 28, new DateTime(2025, 12, 2, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 2, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 153, 14, new DateTime(2025, 10, 10, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 10, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 154, new DateTime(2025, 12, 7, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 7, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 155, 2, new DateTime(2025, 11, 19, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 19, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 156, 28, new DateTime(2025, 10, 2, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 2, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 157, 2, new DateTime(2025, 9, 29, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 29, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 158, 13, new DateTime(2025, 10, 6, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 159, 14, new DateTime(2025, 10, 6, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 160, 29, new DateTime(2025, 11, 18, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 161, 16, new DateTime(2025, 11, 6, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 6, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 162, 14, new DateTime(2025, 11, 5, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 5, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 163, new DateTime(2025, 9, 18, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 164, 12, new DateTime(2025, 11, 14, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 13, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 165, 29, new DateTime(2025, 9, 18, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 166, 29, new DateTime(2025, 9, 12, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 167, 13, new DateTime(2025, 10, 1, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 168, 2, new DateTime(2025, 9, 8, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 7, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 169, 15, new DateTime(2025, 9, 11, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 11, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 170, 28, new DateTime(2025, 10, 27, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 27, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 171, 22, new DateTime(2025, 9, 17, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 16, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 172, 14, new DateTime(2025, 11, 18, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 173, 2, new DateTime(2025, 10, 21, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 173, 3, new DateTime(2025, 10, 21, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 174, 22, new DateTime(2025, 11, 18, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 17, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 175, new DateTime(2025, 10, 6, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 176, 3, new DateTime(2025, 10, 30, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 30, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 177, 4, new DateTime(2025, 10, 20, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 19, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 178, 33, new DateTime(2025, 9, 30, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 29, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 179, 33, new DateTime(2025, 9, 19, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 19, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 180, 4, new DateTime(2025, 10, 30, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 30, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 181, 15, new DateTime(2025, 10, 26, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 26, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 182, 5, new DateTime(2025, 11, 3, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 3, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 183, 15, new DateTime(2025, 9, 19, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 19, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 184, new DateTime(2025, 11, 11, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 185, 3, new DateTime(2025, 10, 20, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 20, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 186, 33, new DateTime(2025, 10, 15, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 187, 15, new DateTime(2025, 11, 10, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 9, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 188, 22, new DateTime(2025, 10, 17, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 189, 33, new DateTime(2025, 10, 27, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 27, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 190, 2, new DateTime(2025, 10, 25, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 25, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 191, 5, new DateTime(2025, 10, 19, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 19, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 192, 2, new DateTime(2025, 10, 28, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 27, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 193, 13, new DateTime(2025, 10, 18, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 18, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 194, 5, new DateTime(2025, 10, 12, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 12, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 195, 12, new DateTime(2025, 11, 6, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 6, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 196, 14, new DateTime(2025, 9, 25, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 24, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 197, 14, new DateTime(2025, 11, 2, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 198, 16, new DateTime(2025, 11, 13, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 13, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 199, 3, new DateTime(2025, 11, 23, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 23, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 200, 33, new DateTime(2025, 12, 6, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 6, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 201, 41, new DateTime(2025, 1, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 202, 41, new DateTime(2025, 1, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 203, 41, new DateTime(2025, 1, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 204, 41, new DateTime(2025, 1, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 205, 6, new DateTime(2025, 2, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 206, 6, new DateTime(2025, 2, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 207, 6, new DateTime(2025, 2, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 208, 6, new DateTime(2025, 2, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 209, 8, new DateTime(2025, 3, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 210, 8, new DateTime(2025, 3, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 211, 8, new DateTime(2025, 3, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 212, 8, new DateTime(2025, 3, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 213, new DateTime(2025, 4, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 214, new DateTime(2025, 4, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 215, new DateTime(2025, 4, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 216, new DateTime(2025, 4, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 217, 6, new DateTime(2025, 5, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 218, 6, new DateTime(2025, 5, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 219, 6, new DateTime(2025, 5, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 220, 6, new DateTime(2025, 5, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 221, 32, new DateTime(2025, 6, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 222, 32, new DateTime(2025, 6, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 223, 32, new DateTime(2025, 6, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 224, 32, new DateTime(2025, 6, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 225, 23, new DateTime(2025, 7, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 226, 23, new DateTime(2025, 7, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 227, 23, new DateTime(2025, 7, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 228, 23, new DateTime(2025, 7, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 229, 23, new DateTime(2025, 8, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 230, 23, new DateTime(2025, 8, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 231, 23, new DateTime(2025, 8, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 232, 23, new DateTime(2025, 8, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 233, 42, new DateTime(2025, 9, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 234, 42, new DateTime(2025, 9, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 235, 42, new DateTime(2025, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 236, 42, new DateTime(2025, 9, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 237, 41, new DateTime(2025, 10, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 238, 41, new DateTime(2025, 10, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 239, 41, new DateTime(2025, 10, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 240, 41, new DateTime(2025, 10, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 241, 8, new DateTime(2025, 11, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 242, 8, new DateTime(2025, 11, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 243, 8, new DateTime(2025, 11, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 244, new DateTime(2025, 11, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 245, 30, new DateTime(2025, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 246, 30, new DateTime(2025, 12, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 247, 30, new DateTime(2025, 12, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 248, 30, new DateTime(2025, 12, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 249, 8, new DateTime(2025, 11, 30, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 30, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 250, 6, new DateTime(2025, 11, 24, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 24, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 251, 32, new DateTime(2025, 10, 5, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 252, 6, new DateTime(2025, 10, 8, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 253, 9, new DateTime(2025, 9, 25, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 254, 9, new DateTime(2025, 9, 19, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 19, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 255, new DateTime(2025, 10, 10, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 9, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 256, 6, new DateTime(2025, 9, 13, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 13, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 257, 23, new DateTime(2025, 11, 28, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 258, 9, new DateTime(2025, 11, 28, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 259, 10, new DateTime(2025, 10, 12, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 12, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 260, 9, new DateTime(2025, 11, 1, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 31, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 261, 8, new DateTime(2025, 10, 7, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 7, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 262, 10, new DateTime(2025, 11, 29, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 29, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 263, 32, new DateTime(2025, 11, 21, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 21, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 264, 42, new DateTime(2025, 10, 27, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 27, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 265, 30, new DateTime(2025, 12, 4, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 3, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 266, 42, new DateTime(2025, 9, 23, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 267, 7, new DateTime(2025, 11, 19, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 19, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 268, 32, new DateTime(2025, 10, 9, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 9, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 269, new DateTime(2025, 10, 4, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 270, new DateTime(2025, 10, 30, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 30, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 271, 42, new DateTime(2025, 11, 10, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 272, 30, new DateTime(2025, 9, 24, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 24, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 273, 9, new DateTime(2025, 10, 19, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 19, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 306,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 274, 7, new DateTime(2025, 11, 18, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 307,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 275, 32, new DateTime(2025, 9, 16, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 16, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 308,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 276, new DateTime(2025, 10, 7, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 7, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 277, 9, new DateTime(2025, 10, 14, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 14, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 310,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 278, new DateTime(2025, 11, 16, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 16, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 279, 9, new DateTime(2025, 11, 18, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 312,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 280, 7, new DateTime(2025, 9, 12, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 11, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 313,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 281, 7, new DateTime(2025, 11, 3, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 3, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 314,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 282, 6, new DateTime(2025, 11, 2, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 315,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 283, 7, new DateTime(2025, 12, 3, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 3, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 284, 8, new DateTime(2025, 9, 9, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 9, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 317,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 285, 8, new DateTime(2025, 11, 28, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 318,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 286, 30, new DateTime(2025, 10, 17, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 319,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 287, 9, new DateTime(2025, 10, 12, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 12, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 320,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 288, 32, new DateTime(2025, 9, 8, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 321, 289, 41, new DateTime(2025, 10, 14, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 14, 3, 41, 13, 0, DateTimeKind.Unspecified) },
                    { 322, 290, 7, new DateTime(2025, 12, 5, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 5, 2, 41, 13, 0, DateTimeKind.Unspecified) },
                    { 323, 291, 6, new DateTime(2025, 12, 1, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 5, 41, 13, 0, DateTimeKind.Unspecified) },
                    { 324, 292, 7, new DateTime(2025, 11, 30, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 29, 23, 41, 13, 0, DateTimeKind.Unspecified) },
                    { 325, 293, 7, new DateTime(2025, 10, 1, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 19, 41, 13, 0, DateTimeKind.Unspecified) },
                    { 326, 294, 23, new DateTime(2025, 9, 28, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 28, 20, 41, 13, 0, DateTimeKind.Unspecified) },
                    { 327, 295, 6, new DateTime(2025, 10, 11, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 21, 41, 13, 0, DateTimeKind.Unspecified) },
                    { 328, 296, 7, new DateTime(2025, 9, 27, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 26, 23, 41, 13, 0, DateTimeKind.Unspecified) },
                    { 329, 297, 8, new DateTime(2025, 10, 22, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 1, 41, 13, 0, DateTimeKind.Unspecified) },
                    { 330, 298, 23, new DateTime(2025, 11, 6, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 6, 2, 41, 13, 0, DateTimeKind.Unspecified) },
                    { 331, 299, 42, new DateTime(2025, 11, 29, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 29, 0, 41, 13, 0, DateTimeKind.Unspecified) },
                    { 332, 300, 9, new DateTime(2025, 11, 20, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 20, 18, 41, 13, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 5, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 5, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 5, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 5, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 900000m, 25, 900000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 900000m, 25, 900000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 900000m, 25, 900000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 900000m, 25, 900000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 500000m, 18, 500000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 500000m, 18, 500000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 500000m, 18, 500000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 500000m, 18, 500000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 600000m, 25, 600000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 600000m, 25, 600000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 600000m, 25, 600000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 600000m, 25, 600000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 18, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 18, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 18, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 18, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 100000m, 17, "cancelled", 100000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 100000m, 17, "cancelled", 100000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 100000m, 17, "cancelled", 100000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 100000m, 17, "cancelled", 100000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 150000m, 13, 150000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 150000m, 13, 150000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 150000m, 13, 150000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 150000m, 13, 150000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 26, "cancelled", 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 26, "cancelled", 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 26, "cancelled", 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 26, "cancelled", 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 240000m, 26, "completed", 240000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 240000m, 26, "completed", 240000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 240000m, 26, "completed", 240000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 240000m, 26, "completed", 240000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 25, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 25, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 25, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 25, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 1000000m, 6, 1000000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 1000000m, 6, 1000000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 1000000m, 6, 1000000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 1000000m, 6, 1000000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 240000m, 26, 240000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 240000m, 26, 240000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 240000m, 26, 240000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 240000m, 26, 240000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "completed", 240000m, new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "cancelled", 600000m, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, 14, "completed", 360000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, 240000m, new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), "cancelled", new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, 600000m, new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 1000000m, 6, "cancelled", 1000000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 150000m, 13, "completed", 150000m, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "cancelled", 240000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 150000m, 13, 150000m, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "cancelled", 240000m, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 560000m, 14, "accepted", 560000m, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 11, "completed", 160000m, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, 240000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 26, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "cancelled", 240000m, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 1000000m, 6, "completed", 1000000m, new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "cancelled", 240000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 11, "cancelled", 160000m, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 11, "completed", 160000m, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, 14, "completed", 360000m, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "completed", 600000m, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 900000m, 25, 900000m, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 150000m, 13, "cancelled", 150000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "accepted", 600000m, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 560000m, 14, "accepted", 560000m, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 900000m, 25, "cancelled", 900000m, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "cancelled", 240000m, new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 150000m, 13, 150000m, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, 14, "completed", 360000m, new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 18, 300000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "accepted", 240000m, new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 11, "accepted", 160000m, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 17, 140000m, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "accepted", 600000m, new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 900000m, 25, 900000m, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "cancelled", 600000m, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 18, 300000m, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, 14, "accepted", 360000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 500000m, 18, "completed", 500000m, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, 240000m, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "completed", 240000m, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "cancelled", 600000m, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, 600000m, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 18, 300000m, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 18, "accepted", 300000m, new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 150000m, 13, 150000m, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 900000m, 25, 900000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 1, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 1, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 1, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 1, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 600000m, 600000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 600000m, 600000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 600000m, 600000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 600000m, 600000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 400000m, 1, 400000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 400000m, 1, 400000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 400000m, 1, 400000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 400000m, 1, 400000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 8, 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 8, 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 8, 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 8, 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 400000m, 1, 400000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 400000m, 1, 400000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 400000m, 1, 400000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 400000m, 1, 400000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 600000m, 1, 600000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 600000m, 1, 600000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 600000m, 1, 600000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 600000m, 1, 600000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 240000m, 8, "completed", 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 240000m, 8, "completed", 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 240000m, 8, "completed", 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 240000m, 8, "completed", 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 120000m, 9, "completed", 120000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 120000m, 9, "completed", 120000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 120000m, 9, "completed", 120000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 120000m, 9, "completed", 120000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 300000m, 24, "completed", 300000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 300000m, 24, "completed", 300000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 300000m, 24, "completed", 300000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 300000m, 24, "completed", 300000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 100000m, 2, "completed", 100000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 100000m, 2, "completed", 100000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 100000m, 2, "completed", 100000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 100000m, 2, "completed", 100000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 220000m, 15, "cancelled", 220000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 220000m, 15, "cancelled", 220000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 220000m, 15, "cancelled", 220000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 220000m, 15, "cancelled", 220000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 600000m, 600000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 600000m, 600000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 600000m, 600000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 600000m, 600000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 180000m, 19, 180000m, new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "accepted", 240000m, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 600000m, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 180000m, 19, "accepted", 180000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "completed", 120000m, new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, "accepted", 100000m, new DateTime(2025, 12, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, 400000m, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 180000m, 19, 180000m, new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, "completed", 400000m, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, 240000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "cancelled", 120000m, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 20, "accepted", 160000m, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "CreatedAt", "Date", "StadiumId", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 10, "accepted", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, 120000m, new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, "cancelled", 100000m, new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, 240000m, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 20, "cancelled", 160000m, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 20, 160000m, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, 240000m, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, 400000m, new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 180000m, 19, "cancelled", 180000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 220000m, 15, 220000m, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "accepted", 120000m, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 1, "completed", 600000m, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 220000m, 15, "accepted", 220000m, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 180000m, 19, "cancelled", 180000m, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, "completed", 400000m, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, 100000m, new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 24, 300000m, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), "cancelled", new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, 100000m, new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "completed", 120000m, new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), "accepted", new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, "completed", 400000m, new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 24, 300000m, new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "accepted", 120000m, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 220000m, 15, 220000m, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 24, new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 400000m, 1, 400000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, 100000m, new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, 400000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "completed", 240000m, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, 100000m, new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "CreatedAt", "Date", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "completed", 120000m, new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "cancelled", 120000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 10, "accepted", 300000m, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "OriginalPrice", "TotalPrice" },
                values: new object[] { 400000m, 400000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "CreatedById", "Date", "UserId" },
                values: new object[] { 5, new DateTime(2025, 12, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 190000m, 27, 190000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 190000m, 27, 190000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 190000m, 27, 190000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 190000m, 27, 190000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 205,
                column: "StadiumId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 206,
                column: "StadiumId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 207,
                column: "StadiumId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 208,
                column: "StadiumId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 4, "cancelled", 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 4, "cancelled", 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 4, "cancelled", 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 4, "cancelled", 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 190000m, 27, 190000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 190000m, 27, 190000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 190000m, 27, 190000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 190000m, 27, 190000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 3, 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 3, 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 3, 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 3, 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 140000m, 23, "completed", 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 140000m, 23, "completed", 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 140000m, 23, "completed", 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 140000m, 23, "completed", 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 200000m, 16, 200000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 200000m, 16, 200000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 200000m, 16, 200000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 200000m, 16, 200000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 200000m, 16, 200000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 200000m, 16, 200000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 200000m, 16, 200000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 200000m, 16, 200000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "CreatedById", "Status", "UserId" },
                values: new object[] { 8, "cancelled", 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "CreatedById", "Status", "UserId" },
                values: new object[] { 8, "cancelled", 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "CreatedById", "Status", "UserId" },
                values: new object[] { 8, "cancelled", 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "CreatedById", "Status", "UserId" },
                values: new object[] { 8, "cancelled", 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 190000m, 27, 190000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 190000m, 27, 190000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 190000m, 27, 190000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 190000m, 27, 190000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 300000m, 4, 300000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 300000m, 4, 300000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 300000m, 4, 300000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 300000m, 4, 300000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 7, 22, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 7, 22, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 7, 22, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 7, 22, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, "cancelled", 300000m, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), "cancelled", new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "CreatedAt", "Date", "StadiumId", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, "completed", new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, "completed", 140000m, new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, 140000m, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 16, "accepted", 200000m, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, "accepted", 140000m, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, "cancelled", 140000m, new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, 140000m, new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, 300000m, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, 140000m, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, "accepted", 140000m, new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, "completed", 190000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 22, new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), "accepted", new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, 140000m, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, 140000m, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 23, "cancelled", new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, "accepted", 190000m, new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 22, 200000m, new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "accepted", 200000m, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, 140000m, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, "cancelled", new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, 140000m, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "completed", 200000m, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, 300000m, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, "accepted", 300000m, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, 140000m, new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "accepted", 200000m, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "accepted", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, "accepted", new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 16, "cancelled", 200000m, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "completed", 200000m, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, 300000m, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 16, 200000m, new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "Date", "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime", "UserId" },
                values: new object[] { new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 9, 0, 0, 0), 3600000m, 25, new TimeSpan(0, 7, 0, 0, 0), 3600000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 15, 0, 0, 0), 2000000m, 18, new TimeSpan(0, 13, 0, 0, 0), 2000000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 17, 0, 0, 0), 2400000m, 25, new TimeSpan(0, 15, 0, 0, 0), 2400000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 19, 0, 0, 0), 1200000m, 18, new TimeSpan(0, 17, 0, 0, 0), 1200000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 21, 0, 0, 0), 400000m, 17, new TimeSpan(0, 19, 0, 0, 0), "cancelled", 400000m, 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 20, 0, 0, 0), 600000m, 13, new TimeSpan(0, 18, 0, 0, 0), 600000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 9, 0, 0, 0), 960000m, 26, new TimeSpan(0, 7, 0, 0, 0), "cancelled", 960000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 12, 0, 0, 0), 960000m, 26, new TimeSpan(0, 10, 0, 0, 0), "completed", 960000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 19, 0, 0, 0), 2400000m, 25, new TimeSpan(0, 17, 0, 0, 0), 2400000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 12, 0, 0, 0), 4000000m, 6, new TimeSpan(0, 10, 0, 0, 0), 4000000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 15, 0, 0, 0), 960000m, 26, new TimeSpan(0, 13, 0, 0, 0), 960000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 11, 0, 0, 0), 2400000m, 1, new TimeSpan(0, 9, 0, 0, 0), 2400000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EndTime", "OriginalPrice", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 18, 0, 0, 0), 2400000m, new TimeSpan(0, 16, 0, 0, 0), 2400000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), 1600000m, 1, new TimeSpan(0, 12, 0, 0, 0), 1600000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), 960000m, 8, new TimeSpan(0, 12, 0, 0, 0), 960000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 17, 0, 0, 0), 1600000m, 1, new TimeSpan(0, 15, 0, 0, 0), 1600000m, 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 16, 0, 0, 0), 2400000m, 1, new TimeSpan(0, 14, 0, 0, 0), 2400000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 12, 0, 0, 0), 960000m, 8, new TimeSpan(0, 10, 0, 0, 0), "completed", 960000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 20, 0, 0, 0), 480000m, 9, new TimeSpan(0, 18, 0, 0, 0), "completed", 480000m, 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 10, 0, 0, 0), 1200000m, 24, new TimeSpan(0, 8, 0, 0, 0), "completed", 1200000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 10, 0, 0, 0), 400000m, 2, new TimeSpan(0, 8, 0, 0, 0), "completed", 400000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 21, 0, 0, 0), 880000m, 15, new TimeSpan(0, 19, 0, 0, 0), "cancelled", 880000m, 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "EndTime", "OriginalPrice", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 16, 0, 0, 0), 2400000m, new TimeSpan(0, 14, 0, 0, 0), 2400000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 19, 0, 0, 0), 760000m, 27, new TimeSpan(0, 17, 0, 0, 0), 760000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "EndTime", "StadiumId", "StartTime" },
                values: new object[] { new TimeSpan(0, 19, 0, 0, 0), 3, new TimeSpan(0, 17, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 13, 0, 0, 0), 1200000m, 4, new TimeSpan(0, 11, 0, 0, 0), "cancelled", 1200000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 17, 0, 0, 0), 760000m, 27, new TimeSpan(0, 15, 0, 0, 0), 760000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 13, 0, 0, 0), 800000m, 3, new TimeSpan(0, 11, 0, 0, 0), 800000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 19, 0, 0, 0), 560000m, 23, new TimeSpan(0, 17, 0, 0, 0), "completed", 560000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), 800000m, 16, new TimeSpan(0, 12, 0, 0, 0), 800000m, 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 11, 0, 0, 0), 800000m, 16, new TimeSpan(0, 9, 0, 0, 0), 800000m, 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "EndTime", "StartTime", "Status", "UserId" },
                values: new object[] { new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "cancelled", 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 15, 0, 0, 0), 760000m, 27, new TimeSpan(0, 13, 0, 0, 0), 760000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 16, 0, 0, 0), 1200000m, 4, new TimeSpan(0, 14, 0, 0, 0), 1200000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "EndTime", "StadiumId", "StartTime", "UserId" },
                values: new object[] { new TimeSpan(0, 16, 0, 0, 0), 22, new TimeSpan(0, 14, 0, 0, 0), 7 });
        }
    }
}
