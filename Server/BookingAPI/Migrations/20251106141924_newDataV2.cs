using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingAPI.Migrations
{
    /// <inheritdoc />
    public partial class newDataV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 1, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, new DateTime(2025, 1, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 1, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, new DateTime(2025, 1, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 1, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, new DateTime(2025, 1, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 9,
                column: "CourtId",
                value: 35);

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 24, 24, new DateTime(2025, 6, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 25, 18, new DateTime(2025, 7, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 26, 18, new DateTime(2025, 7, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 27, 18, new DateTime(2025, 7, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 28, 18, new DateTime(2025, 7, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 29, 40, new DateTime(2025, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 30, 40, new DateTime(2025, 8, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 31, 40, new DateTime(2025, 8, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 32, 40, new DateTime(2025, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 33, 40, new DateTime(2025, 9, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 34, 40, new DateTime(2025, 9, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, 40, new DateTime(2025, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, 40, new DateTime(2025, 9, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 37, 35, new DateTime(2025, 10, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 38, 35, new DateTime(2025, 10, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, 35, new DateTime(2025, 10, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, 35, new DateTime(2025, 10, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 41, 11, new DateTime(2025, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 42, 11, new DateTime(2025, 11, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 43, 11, new DateTime(2025, 11, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 53, 40, new DateTime(2025, 10, 11, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 54, 35, new DateTime(2025, 11, 15, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 14, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 55, 35, new DateTime(2025, 11, 22, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 21, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 56, 11, new DateTime(2025, 10, 6, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 57, 18, new DateTime(2025, 9, 27, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 27, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 58, new DateTime(2025, 10, 28, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 1, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 61, 20, new DateTime(2025, 11, 10, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 61, 21, new DateTime(2025, 11, 10, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 62, 17, new DateTime(2025, 10, 17, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 63, 39, new DateTime(2025, 10, 6, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 64, 37, new DateTime(2025, 11, 11, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 65, 39, new DateTime(2025, 10, 28, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 66, 11, new DateTime(2025, 10, 24, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 23, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 67, new DateTime(2025, 10, 6, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 68, 17, new DateTime(2025, 9, 24, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 24, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 69, 17, new DateTime(2025, 10, 22, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 70, 20, new DateTime(2025, 9, 20, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 19, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 71, 35, new DateTime(2025, 10, 18, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 72, 35, new DateTime(2025, 11, 17, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 17, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, new DateTime(2025, 11, 17, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 17, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, new DateTime(2025, 10, 29, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 29, 1, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 76, 20, new DateTime(2025, 11, 18, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, new DateTime(2025, 11, 18, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 11, 8, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 4, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 81, new DateTime(2025, 10, 6, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 3, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 88, 36, new DateTime(2025, 9, 14, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 14, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 89, 27, new DateTime(2025, 11, 9, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 9, 18, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 101, new DateTime(2025, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 102, 2, new DateTime(2025, 1, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 103, 2, new DateTime(2025, 1, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 120, new DateTime(2025, 5, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 121, new DateTime(2025, 6, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 121, new DateTime(2025, 6, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 122, new DateTime(2025, 6, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 122, new DateTime(2025, 6, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 123, new DateTime(2025, 6, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 123, new DateTime(2025, 6, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 129, new DateTime(2025, 8, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 130, new DateTime(2025, 8, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 145, 2, new DateTime(2025, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 145, 3, new DateTime(2025, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 147, new DateTime(2025, 12, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 147, new DateTime(2025, 12, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 148, new DateTime(2025, 12, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 148, new DateTime(2025, 12, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 151, 3, new DateTime(2025, 10, 28, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 20, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 154, 5, new DateTime(2025, 12, 7, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 7, 3, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 157, new DateTime(2025, 9, 29, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 29, 4, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 160, new DateTime(2025, 11, 18, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 4, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 163, 4, new DateTime(2025, 9, 18, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 164, new DateTime(2025, 11, 14, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 13, 22, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 175, 28, new DateTime(2025, 10, 6, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 176, new DateTime(2025, 10, 30, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 30, 5, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 181, new DateTime(2025, 10, 26, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 26, 20, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 184, 3, new DateTime(2025, 11, 11, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 21, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 213, 42, new DateTime(2025, 4, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 214, 42, new DateTime(2025, 4, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 215, 42, new DateTime(2025, 4, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 216, 42, new DateTime(2025, 4, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 237, new DateTime(2025, 10, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 238, new DateTime(2025, 10, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 244, 8, new DateTime(2025, 11, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 255, 6, new DateTime(2025, 10, 10, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 9, 22, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 263, new DateTime(2025, 11, 21, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 21, 21, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 269, 10, new DateTime(2025, 10, 4, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 270, 31, new DateTime(2025, 10, 30, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 30, 20, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 276, 42, new DateTime(2025, 10, 7, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 7, 20, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 278, 32, new DateTime(2025, 11, 16, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 16, 5, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 280, new DateTime(2025, 9, 12, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 11, 23, 41, 13, 0, DateTimeKind.Unspecified) });

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

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 321,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 289, 41, new DateTime(2025, 10, 14, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 14, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 322,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 290, new DateTime(2025, 12, 5, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 5, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[,]
                {
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
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 900000m, 25, "cancelled", 900000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 900000m, 25, "cancelled", 900000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 900000m, 25, "cancelled", 900000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 900000m, 25, "cancelled", 900000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 900000m, 25, 900000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 900000m, 25, 900000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 900000m, 25, 900000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 900000m, 25, 900000m });

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
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 7, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 7, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 7, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 7, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 100000m, 17, "cancelled", 100000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 100000m, 17, "cancelled", 100000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 100000m, 17, "cancelled", 100000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 100000m, 17, "cancelled", 100000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 150000m, 13, 150000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 150000m, 13, 150000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 150000m, 13, 150000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 150000m, 13, 150000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 240000m, 26, 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 240000m, 26, 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 240000m, 26, 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 240000m, 26, 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 240000m, 26, 240000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 240000m, 26, 240000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 240000m, 26, 240000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 240000m, 26, 240000m, 5 });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, 240000m, new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "cancelled", 600000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, "completed", 360000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "completed", 240000m, new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "cancelled", 600000m, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "accepted", 600000m, new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 150000m, 13, "completed", 150000m, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), "cancelled", new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "completed", 240000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, 240000m, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, 240000m, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 1000000m, 6, 1000000m, new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

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
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 11, 160000m, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 900000m, 25, "accepted", 900000m, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, 240000m, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 150000m, 13, "cancelled", 150000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

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
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 900000m, 25, "cancelled", 900000m, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 150000m, 13, "accepted", 150000m, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 18, "completed", 300000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CreatedAt", "Date", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), "accepted", new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 17, "completed", 140000m, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "completed", 600000m, new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, 600000m, new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 900000m, 25, "completed", 900000m, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, 600000m, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 18, "accepted", 300000m, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 500000m, 18, 500000m, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "cancelled", 600000m, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, "completed", 600000m, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 18, 300000m, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, "accepted", 300000m, new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CreatedById", "Date", "UserId" },
                values: new object[] { 6, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Date", "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 900000m, 25, 900000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, "completed", 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, "completed", 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, "completed", 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, "completed", 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 1, "cancelled", 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 1, "cancelled", 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 1, "cancelled", 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 1, "cancelled", 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 400000m, 1, 400000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 400000m, 1, 400000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 400000m, 1, 400000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 400000m, 1, 400000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 8, "completed", 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 8, "completed", 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 8, "completed", 240000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 240000m, 8, "completed", 240000m, 7 });

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
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 600000m, 1, 600000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 600000m, 1, 600000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 600000m, 1, 600000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 600000m, 1, 600000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 8, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 8, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 8, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 8, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 120000m, 9, 120000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 120000m, 9, 120000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 120000m, 9, 120000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 120000m, 9, 120000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 300000m, 24, 300000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 300000m, 24, 300000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 300000m, 24, 300000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 300000m, 24, 300000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 100000m, 2, 100000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 100000m, 2, 100000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 100000m, 2, 100000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 100000m, 2, 100000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 220000m, 15, 220000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 220000m, 15, 220000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 220000m, 15, 220000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 220000m, 15, 220000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 600000m, 1, 600000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 600000m, 1, 600000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 600000m, 1, 600000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 600000m, 1, 600000m, 8 });

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
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, 240000m, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 1, 600000m, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), "accepted", new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 12, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, "accepted", 100000m, new DateTime(2025, 12, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, "accepted", 400000m, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, 400000m, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "cancelled", 240000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 20, 160000m, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 10, "accepted", 300000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "completed", 120000m, new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), "cancelled", new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "accepted", 240000m, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 20, 160000m, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, 240000m, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

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
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, 120000m, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 180000m, 19, "cancelled", 180000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 220000m, 15, 220000m, 5 });

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
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 220000m, 15, "accepted", 220000m, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, "completed", 400000m, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 24, "completed", 300000m, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 24, "cancelled", 300000m, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

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
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "completed", 120000m, new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, 100000m, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "completed", 120000m, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, "accepted", 400000m, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, 400000m, new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 24, "completed", 300000m, new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 24, 300000m, new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, 400000m, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, "completed", 100000m, new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "completed", 240000m, new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 10, 300000m, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "CreatedById", "Date", "OriginalPrice", "TotalPrice", "UserId" },
                values: new object[] { 5, new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 400000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, new DateTime(2025, 12, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 24, "accepted", 300000m, 5 });

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
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 7, 3, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 7, 3, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 7, 3, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 7, 3, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 4, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 4, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 4, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 4, 300000m });

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
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 3, "cancelled", 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 3, "cancelled", 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 3, "cancelled", 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 3, "cancelled", 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 221,
                column: "StadiumId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 222,
                column: "StadiumId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 223,
                column: "StadiumId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 224,
                column: "StadiumId",
                value: 23);

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
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 190000m, 27, 190000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 190000m, 27, 190000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 190000m, 27, 190000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 190000m, 27, 190000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 4, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 4, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 4, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 4, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 22, 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 22, 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 22, 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 22, 200000m, 7 });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, "cancelled", new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, "cancelled", 140000m, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "completed", 200000m, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, "completed", 140000m, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "completed", 200000m, new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "completed", 200000m, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 16, "accepted", 200000m, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, "completed", 300000m, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, "cancelled", 140000m, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "CreatedAt", "Date", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), "accepted", new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 22, "accepted", new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, 140000m, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, "completed", 140000m, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, "cancelled", 140000m, new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, "completed", new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 23, "completed", new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, "cancelled", 140000m, new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), "cancelled", new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, "completed", new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "completed", 200000m, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, "completed", 300000m, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 22, "completed", 200000m, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, "completed", 140000m, new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, "cancelled", 140000m, new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

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
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), "accepted", new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "accepted", 200000m, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

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
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 16, "cancelled", 200000m, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 300000m, 4, 300000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 16, new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, "accepted", 190000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 5, 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 10, 0, 0, 0), 3600000m, 25, new TimeSpan(0, 8, 0, 0, 0), "cancelled", 3600000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 3600000m, 25, 3600000m });

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
                columns: new[] { "EndTime", "StartTime", "UserId" },
                values: new object[] { new TimeSpan(0, 19, 0, 0, 0), new TimeSpan(0, 17, 0, 0, 0), 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 21, 0, 0, 0), 400000m, 17, new TimeSpan(0, 19, 0, 0, 0), "cancelled", 400000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 20, 0, 0, 0), 600000m, 13, new TimeSpan(0, 18, 0, 0, 0), 600000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 9, 0, 0, 0), 960000m, 26, new TimeSpan(0, 7, 0, 0, 0), 960000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 12, 0, 0, 0), 960000m, 26, new TimeSpan(0, 10, 0, 0, 0), 960000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 2400000m, 25, 2400000m, 5 });

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
                columns: new[] { "EndTime", "OriginalPrice", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 11, 0, 0, 0), 2400000m, new TimeSpan(0, 9, 0, 0, 0), "completed", 2400000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 18, 0, 0, 0), 2400000m, 1, new TimeSpan(0, 16, 0, 0, 0), "cancelled", 2400000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), 1600000m, 1, new TimeSpan(0, 12, 0, 0, 0), 1600000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), 960000m, 8, new TimeSpan(0, 12, 0, 0, 0), "completed", 960000m, 7 });

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
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 16, 0, 0, 0), 2400000m, 1, new TimeSpan(0, 14, 0, 0, 0), 2400000m, 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 12, 0, 0, 0), 960000m, 8, new TimeSpan(0, 10, 0, 0, 0), 960000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 20, 0, 0, 0), 480000m, 9, new TimeSpan(0, 18, 0, 0, 0), 480000m, 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 10, 0, 0, 0), 1200000m, 24, new TimeSpan(0, 8, 0, 0, 0), 1200000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 10, 0, 0, 0), 400000m, 2, new TimeSpan(0, 8, 0, 0, 0), 400000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 21, 0, 0, 0), 880000m, 15, new TimeSpan(0, 19, 0, 0, 0), 880000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 16, 0, 0, 0), 2400000m, 1, new TimeSpan(0, 14, 0, 0, 0), 2400000m, 8 });

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
                columns: new[] { "EndTime", "StadiumId", "StartTime", "UserId" },
                values: new object[] { new TimeSpan(0, 19, 0, 0, 0), 3, new TimeSpan(0, 17, 0, 0, 0), 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 13, 0, 0, 0), 1200000m, 4, new TimeSpan(0, 11, 0, 0, 0), 1200000m });

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
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 13, 0, 0, 0), 800000m, 3, new TimeSpan(0, 11, 0, 0, 0), "cancelled", 800000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "EndTime", "StadiumId", "StartTime" },
                values: new object[] { new TimeSpan(0, 19, 0, 0, 0), 23, new TimeSpan(0, 17, 0, 0, 0) });

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
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 15, 0, 0, 0), 760000m, 27, new TimeSpan(0, 13, 0, 0, 0), 760000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 16, 0, 0, 0), 1200000m, 4, new TimeSpan(0, 14, 0, 0, 0), 1200000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 800000m, 22, 800000m, 7 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2025, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, new DateTime(2025, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2025, 1, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, new DateTime(2025, 1, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2025, 1, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, new DateTime(2025, 1, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2025, 1, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, new DateTime(2025, 1, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 9,
                column: "CourtId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 6, 25, new DateTime(2025, 2, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 7, 25, new DateTime(2025, 2, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 8, 25, new DateTime(2025, 2, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 9, 20, new DateTime(2025, 3, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 10, 20, new DateTime(2025, 3, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 11, 20, new DateTime(2025, 3, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 12, 20, new DateTime(2025, 3, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 13, 37, new DateTime(2025, 4, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 14, 37, new DateTime(2025, 4, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 15, 37, new DateTime(2025, 4, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 16, 37, new DateTime(2025, 4, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 17, 27, new DateTime(2025, 5, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 18, 27, new DateTime(2025, 5, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 19, 27, new DateTime(2025, 5, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, 27, new DateTime(2025, 5, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, 26, new DateTime(2025, 6, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 22, 26, new DateTime(2025, 6, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 23, 26, new DateTime(2025, 6, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 24, 26, new DateTime(2025, 6, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 25, 17, new DateTime(2025, 7, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 26, 17, new DateTime(2025, 7, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 27, 17, new DateTime(2025, 7, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 28, 17, new DateTime(2025, 7, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 29, 11, new DateTime(2025, 8, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 30, 11, new DateTime(2025, 8, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 31, 11, new DateTime(2025, 8, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 32, 11, new DateTime(2025, 8, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 33, 27, new DateTime(2025, 9, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 34, 27, new DateTime(2025, 9, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, 27, new DateTime(2025, 9, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, 27, new DateTime(2025, 9, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 37, 25, new DateTime(2025, 10, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 38, 25, new DateTime(2025, 10, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, 25, new DateTime(2025, 10, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, 25, new DateTime(2025, 10, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 41, 20, new DateTime(2025, 11, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 41, 21, new DateTime(2025, 11, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 42, 20, new DateTime(2025, 11, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 42, 21, new DateTime(2025, 11, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 43, 20, new DateTime(2025, 11, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 43, 21, new DateTime(2025, 11, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 44, 20, new DateTime(2025, 11, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, new DateTime(2025, 11, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2025, 12, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2025, 12, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2025, 12, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2025, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 26, new DateTime(2025, 9, 8, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 26, new DateTime(2025, 10, 30, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 29, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, new DateTime(2025, 10, 3, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 3, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2025, 9, 27, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 27, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 52, 21, new DateTime(2025, 9, 27, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 27, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 53, 25, new DateTime(2025, 11, 21, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 21, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 54, 18, new DateTime(2025, 11, 17, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 16, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 55, 21, new DateTime(2025, 12, 2, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 56, 26, new DateTime(2025, 12, 6, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 6, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 57, new DateTime(2025, 9, 14, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 13, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 58, 35, new DateTime(2025, 11, 15, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 58, 36, new DateTime(2025, 11, 15, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 59, 11, new DateTime(2025, 10, 23, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 23, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 60, 37, new DateTime(2025, 11, 16, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 16, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 61, 36, new DateTime(2025, 11, 4, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 4, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 62, 18, new DateTime(2025, 9, 27, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 27, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 63, 36, new DateTime(2025, 9, 11, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 11, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 64, 24, new DateTime(2025, 12, 1, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 65, 26, new DateTime(2025, 10, 29, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 29, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 66, new DateTime(2025, 10, 1, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 67, 27, new DateTime(2025, 9, 15, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 68, 24, new DateTime(2025, 10, 31, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 31, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 69, 25, new DateTime(2025, 9, 25, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 70, 24, new DateTime(2025, 11, 25, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 24, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 71, 36, new DateTime(2025, 10, 29, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 29, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, new DateTime(2025, 9, 19, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 19, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2025, 10, 17, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 73, 36, new DateTime(2025, 10, 17, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 74, 36, new DateTime(2025, 11, 1, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 31, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 75, 24, new DateTime(2025, 12, 4, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 4, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 9, 9, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 9, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2025, 9, 15, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 78, 17, new DateTime(2025, 10, 24, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 24, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 79, 35, new DateTime(2025, 11, 1, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 80, 21, new DateTime(2025, 9, 27, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 27, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 81, 40, new DateTime(2025, 9, 23, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 82, new DateTime(2025, 10, 21, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 83, 17, new DateTime(2025, 10, 21, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 84, 39, new DateTime(2025, 9, 29, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 29, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 85, 21, new DateTime(2025, 12, 6, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 6, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 86, 26, new DateTime(2025, 11, 9, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 9, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 87, 38, new DateTime(2025, 12, 1, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 88, 26, new DateTime(2025, 11, 5, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 4, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 89, 21, new DateTime(2025, 11, 28, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 28, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 90, 39, new DateTime(2025, 10, 31, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 31, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 91, 38, new DateTime(2025, 11, 3, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 92, 38, new DateTime(2025, 11, 8, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 93, 39, new DateTime(2025, 11, 6, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 6, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 94, 39, new DateTime(2025, 11, 12, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 12, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 95, 35, new DateTime(2025, 11, 21, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 21, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 95, 36, new DateTime(2025, 11, 21, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 21, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 96, 18, new DateTime(2025, 9, 23, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 97, 26, new DateTime(2025, 9, 14, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 14, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 98, 25, new DateTime(2025, 9, 17, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 17, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 99, 40, new DateTime(2025, 11, 21, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 21, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 100, 17, new DateTime(2025, 11, 13, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 12, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 101, 3, new DateTime(2025, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 102, 3, new DateTime(2025, 1, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 103, 3, new DateTime(2025, 1, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 104, new DateTime(2025, 1, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 105, 28, new DateTime(2025, 2, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 106, 28, new DateTime(2025, 2, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 107, 28, new DateTime(2025, 2, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 108, 28, new DateTime(2025, 2, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 109, 14, new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 110, 14, new DateTime(2025, 3, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 111, 14, new DateTime(2025, 3, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 112, 14, new DateTime(2025, 3, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 113, 29, new DateTime(2025, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 114, 29, new DateTime(2025, 4, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 115, 29, new DateTime(2025, 4, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 116, 29, new DateTime(2025, 4, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 117, 33, new DateTime(2025, 5, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 118, 33, new DateTime(2025, 5, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 119, 33, new DateTime(2025, 5, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 120, 33, new DateTime(2025, 5, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 121, 4, new DateTime(2025, 6, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 122, 4, new DateTime(2025, 6, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 123, 4, new DateTime(2025, 6, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 124, 4, new DateTime(2025, 6, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 125, 33, new DateTime(2025, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 126, 33, new DateTime(2025, 7, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 127, 33, new DateTime(2025, 7, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 128, 33, new DateTime(2025, 7, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 129, 2, new DateTime(2025, 8, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 129, new DateTime(2025, 8, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 130, new DateTime(2025, 8, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 130, new DateTime(2025, 8, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 131, new DateTime(2025, 8, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 131, new DateTime(2025, 8, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 132, new DateTime(2025, 8, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 132, new DateTime(2025, 8, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 133, 15, new DateTime(2025, 9, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 134, 15, new DateTime(2025, 9, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 135, 15, new DateTime(2025, 9, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 136, 15, new DateTime(2025, 9, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 137, 14, new DateTime(2025, 10, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 138, 14, new DateTime(2025, 10, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 139, new DateTime(2025, 10, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 140, new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 141, 13, new DateTime(2025, 11, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 142, 13, new DateTime(2025, 11, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 143, 13, new DateTime(2025, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 144, 13, new DateTime(2025, 11, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 145, 14, new DateTime(2025, 12, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 146, 14, new DateTime(2025, 12, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 147, 14, new DateTime(2025, 12, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 148, 14, new DateTime(2025, 12, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 149, 2, new DateTime(2025, 11, 11, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 150, 29, new DateTime(2025, 11, 11, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 151, 12, new DateTime(2025, 10, 21, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 152, 28, new DateTime(2025, 10, 2, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 2, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 153, 3, new DateTime(2025, 12, 4, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 4, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 154, 16, new DateTime(2025, 11, 2, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 155, 4, new DateTime(2025, 9, 18, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 156, 12, new DateTime(2025, 9, 24, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 24, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 157, 33, new DateTime(2025, 9, 10, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 158, 14, new DateTime(2025, 10, 17, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 159, new DateTime(2025, 11, 23, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 23, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 159, new DateTime(2025, 11, 23, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 23, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 160, new DateTime(2025, 11, 13, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 13, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 160, new DateTime(2025, 11, 13, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 13, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 161, 12, new DateTime(2025, 10, 7, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 162, 2, new DateTime(2025, 11, 12, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 12, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 163, 4, new DateTime(2025, 10, 3, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 3, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 164, 5, new DateTime(2025, 11, 5, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 5, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 165, 13, new DateTime(2025, 9, 12, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 166, 2, new DateTime(2025, 9, 17, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 17, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 166, 3, new DateTime(2025, 9, 17, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 17, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 167, 33, new DateTime(2025, 9, 19, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 19, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 168, 22, new DateTime(2025, 9, 16, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 16, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 169, new DateTime(2025, 9, 10, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 169, 3, new DateTime(2025, 9, 10, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 170, 13, new DateTime(2025, 11, 29, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 28, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 171, new DateTime(2025, 9, 17, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 16, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 172, 13, new DateTime(2025, 9, 15, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 173, 33, new DateTime(2025, 10, 25, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 25, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 174, 12, new DateTime(2025, 10, 17, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 175, new DateTime(2025, 9, 23, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 176, 22, new DateTime(2025, 10, 4, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 3, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 177, 5, new DateTime(2025, 10, 2, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 2, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 178, 14, new DateTime(2025, 10, 19, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 19, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 179, 14, new DateTime(2025, 9, 9, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 180, 3, new DateTime(2025, 9, 23, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 181, 13, new DateTime(2025, 11, 30, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 30, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 182, 2, new DateTime(2025, 10, 18, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 18, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 183, 3, new DateTime(2025, 9, 16, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 16, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 184, 16, new DateTime(2025, 11, 28, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 185, 16, new DateTime(2025, 9, 13, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 13, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 186, 12, new DateTime(2025, 11, 9, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 187, 2, new DateTime(2025, 10, 9, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 9, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 187, new DateTime(2025, 10, 9, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 9, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 188, 14, new DateTime(2025, 10, 29, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 29, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 189, 3, new DateTime(2025, 10, 13, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 13, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 190, 4, new DateTime(2025, 10, 7, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 7, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 191, 12, new DateTime(2025, 10, 12, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 12, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 192, new DateTime(2025, 11, 3, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 3, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 193, 33, new DateTime(2025, 12, 1, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 30, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 194, 29, new DateTime(2025, 12, 4, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 3, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 195, 33, new DateTime(2025, 10, 2, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 2, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 196, 22, new DateTime(2025, 10, 12, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 12, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 197, 12, new DateTime(2025, 10, 14, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 14, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 198, 12, new DateTime(2025, 12, 3, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 2, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 199, 2, new DateTime(2025, 11, 7, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 199, 3, new DateTime(2025, 11, 7, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 200, 29, new DateTime(2025, 11, 11, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 201, 10, new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 202, 10, new DateTime(2025, 1, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 203, 10, new DateTime(2025, 1, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 204, 10, new DateTime(2025, 1, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 205, 23, new DateTime(2025, 2, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 206, 23, new DateTime(2025, 2, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 207, 23, new DateTime(2025, 2, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 208, 23, new DateTime(2025, 2, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 209, 23, new DateTime(2025, 3, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 210, 23, new DateTime(2025, 3, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 8, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 211, 23, new DateTime(2025, 3, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 212, 23, new DateTime(2025, 3, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 213, 31, new DateTime(2025, 4, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 214, 31, new DateTime(2025, 4, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 215, 31, new DateTime(2025, 4, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 216, 31, new DateTime(2025, 4, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 217, 9, new DateTime(2025, 5, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 218, 9, new DateTime(2025, 5, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 8, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 219, 9, new DateTime(2025, 5, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 220, 9, new DateTime(2025, 5, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 221, 10, new DateTime(2025, 6, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 222, 10, new DateTime(2025, 6, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 223, 10, new DateTime(2025, 6, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 224, 10, new DateTime(2025, 6, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 225, 31, new DateTime(2025, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 226, 31, new DateTime(2025, 7, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 227, 31, new DateTime(2025, 7, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 228, 31, new DateTime(2025, 7, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 229, 10, new DateTime(2025, 8, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 230, 10, new DateTime(2025, 8, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 231, 10, new DateTime(2025, 8, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 232, 10, new DateTime(2025, 8, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 233, 42, new DateTime(2025, 9, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 234, 42, new DateTime(2025, 9, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 235, 42, new DateTime(2025, 9, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 236, 42, new DateTime(2025, 9, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 237, 8, new DateTime(2025, 10, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 238, 8, new DateTime(2025, 10, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 239, 8, new DateTime(2025, 10, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 240, 8, new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 241, 41, new DateTime(2025, 11, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 242, 41, new DateTime(2025, 11, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 243, 41, new DateTime(2025, 11, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 244, 41, new DateTime(2025, 11, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 245, 41, new DateTime(2025, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 246, 41, new DateTime(2025, 12, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 247, new DateTime(2025, 12, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 248, new DateTime(2025, 12, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 249, 9, new DateTime(2025, 9, 11, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 11, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 250, 23, new DateTime(2025, 10, 6, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 251, 7, new DateTime(2025, 9, 24, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 24, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 252, 31, new DateTime(2025, 11, 14, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 14, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 253, 23, new DateTime(2025, 10, 28, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 254, 41, new DateTime(2025, 12, 6, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 6, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 255, 42, new DateTime(2025, 10, 28, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 256, 41, new DateTime(2025, 11, 7, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 257, 41, new DateTime(2025, 10, 19, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 19, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 258, 6, new DateTime(2025, 10, 12, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 12, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 259, 30, new DateTime(2025, 11, 15, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 260, 8, new DateTime(2025, 10, 18, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 18, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 261, 31, new DateTime(2025, 11, 7, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 262, 7, new DateTime(2025, 10, 21, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 263, 32, new DateTime(2025, 10, 12, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 12, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 264, 32, new DateTime(2025, 9, 25, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 265, 23, new DateTime(2025, 10, 16, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 16, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 266, 8, new DateTime(2025, 9, 19, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 19, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 267, 8, new DateTime(2025, 11, 13, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 13, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 268, 41, new DateTime(2025, 9, 28, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 28, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 269, 7, new DateTime(2025, 11, 19, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 19, 4, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 270, 42, new DateTime(2025, 11, 6, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 6, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 271, 30, new DateTime(2025, 11, 27, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 272, 42, new DateTime(2025, 10, 15, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 273, new DateTime(2025, 11, 20, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 20, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 274, 8, new DateTime(2025, 11, 16, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 16, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 275, 9, new DateTime(2025, 11, 27, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 276, 7, new DateTime(2025, 10, 20, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 20, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 277, 8, new DateTime(2025, 9, 30, 19, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 17, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 278, 31, new DateTime(2025, 11, 10, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 9, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 279, 31, new DateTime(2025, 12, 2, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 2, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 280, 23, new DateTime(2025, 10, 23, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 23, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 281, 6, new DateTime(2025, 11, 6, 20, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 6, 18, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 282, 32, new DateTime(2025, 11, 27, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 283, 7, new DateTime(2025, 11, 26, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 26, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 306,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 284, 41, new DateTime(2025, 11, 7, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 307,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 285, 8, new DateTime(2025, 11, 21, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 21, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 308,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 286, 9, new DateTime(2025, 11, 28, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 287, 7, new DateTime(2025, 11, 8, 5, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 310,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 288, 23, new DateTime(2025, 11, 14, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 14, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 289, 41, new DateTime(2025, 9, 23, 23, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 21, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 312,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 290, new DateTime(2025, 10, 1, 0, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 22, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 313,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 291, 41, new DateTime(2025, 11, 14, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 14, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 314,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 292, 41, new DateTime(2025, 10, 11, 2, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 315,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 293, 42, new DateTime(2025, 10, 4, 7, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 5, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 294, 31, new DateTime(2025, 10, 29, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 29, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 317,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 295, 9, new DateTime(2025, 10, 20, 4, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 20, 2, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 318,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 296, 8, new DateTime(2025, 9, 30, 22, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 20, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 319,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 297, 7, new DateTime(2025, 10, 21, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 320,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 298, 6, new DateTime(2025, 10, 15, 3, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 1, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 321,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 299, 31, new DateTime(2025, 11, 19, 1, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 23, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 322,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 300, new DateTime(2025, 11, 20, 21, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 20, 19, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 560000m, 14, "completed", 560000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 560000m, 14, "completed", 560000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 560000m, 14, "completed", 560000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 560000m, 14, "completed", 560000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 140000m, 17, 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 140000m, 17, 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 140000m, 17, 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 140000m, 17, 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 360000m, 14, 360000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 360000m, 14, 360000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 360000m, 14, 360000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 360000m, 14, 360000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 26, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 26, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 26, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 240000m, 26, 240000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 6, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 6, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 6, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedById", "UserId" },
                values: new object[] { 6, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 500000m, 18, "completed", 500000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 500000m, 18, "completed", 500000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 500000m, 18, "completed", 500000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "OriginalPrice", "StadiumId", "Status", "TotalPrice" },
                values: new object[] { 500000m, 18, "completed", 500000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 160000m, 11, 160000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 160000m, 11, 160000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 160000m, 11, 160000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 160000m, 11, 160000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 1000000m, 6, 1000000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 1000000m, 6, 1000000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 1000000m, 6, 1000000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 1000000m, 6, 1000000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 18, 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 18, 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 18, 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 18, 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 140000m, 17, 140000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 140000m, 17, 140000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 140000m, 17, 140000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 140000m, 17, 140000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 560000m, 14, 560000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 560000m, 14, 560000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 560000m, 14, 560000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 560000m, 14, 560000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 360000m, 14, 360000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 360000m, 14, 360000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 360000m, 14, 360000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 360000m, 14, 360000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 500000m, 18, 500000m, new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 500000m, 18, "completed", 500000m, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "completed", 240000m, new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 560000m, "cancelled", 560000m, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 17, "accepted", 140000m, new DateTime(2025, 11, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 150000m, 13, "accepted", 150000m, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, 14, "cancelled", 360000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 500000m, 18, "accepted", 500000m, new DateTime(2025, 12, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "cancelled", 240000m, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 900000m, 25, "accepted", 900000m, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 1000000m, 6, "cancelled", 1000000m, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), "accepted", new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "completed", 600000m, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 150000m, 13, "cancelled", 150000m, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "cancelled", 600000m, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 17, 100000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 500000m, 18, 500000m, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, 240000m, new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 18, "completed", 300000m, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 17, "completed", 100000m, new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 17, 140000m, new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 17, "cancelled", 100000m, new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "cancelled", 240000m, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 900000m, 25, 900000m, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "completed", 600000m, new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 17, "cancelled", 100000m, new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "cancelled", 240000m, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "completed", 240000m, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 11, "completed", 160000m, new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 25, "cancelled", 600000m, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "cancelled", 240000m, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 18, "cancelled", 300000m, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "Date", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "cancelled", 240000m, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, 14, "accepted", 360000m, new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 500000m, 18, 500000m, new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "accepted", 240000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 500000m, 18, 500000m, new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 360000m, 14, "cancelled", 360000m, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "completed", 240000m, new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, 240000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), "accepted", new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 26, "accepted", 240000m, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 900000m, "cancelled", 900000m, new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 150000m, 13, 150000m, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 500000m, "completed", 500000m, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 17, 140000m, new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedById", "Date", "UserId" },
                values: new object[] { 5, new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Date", "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 11, 160000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 400000m, "cancelled", 400000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 400000m, "cancelled", 400000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 400000m, "cancelled", 400000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 400000m, "cancelled", 400000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 180000m, 19, "completed", 180000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 180000m, 19, "completed", 180000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 180000m, 19, "completed", 180000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, 180000m, 19, "completed", 180000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 120000m, 9, 120000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 120000m, 9, 120000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 120000m, 9, 120000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 120000m, 9, 120000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 160000m, 20, "cancelled", 160000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 160000m, 20, "cancelled", 160000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 160000m, 20, "cancelled", 160000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 8, 160000m, 20, "cancelled", 160000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 24, 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 24, 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 24, 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 300000m, 24, 300000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 100000m, 2, 100000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 100000m, 2, 100000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 100000m, 2, 100000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 100000m, 2, 100000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 300000m, 24, 300000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 300000m, 24, 300000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 300000m, 24, 300000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 300000m, 24, 300000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 1, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 1, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 1, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 600000m, 1, 600000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 120000m, 9, 120000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 120000m, 9, 120000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 120000m, 9, 120000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 6, 120000m, 9, 120000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 120000m, 9, 120000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 120000m, 9, 120000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 120000m, 9, 120000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 120000m, 9, 120000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 240000m, 8, 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 240000m, 8, 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 240000m, 8, 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 240000m, 8, 240000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 120000m, 9, 120000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 120000m, 9, 120000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 120000m, 9, 120000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 120000m, 9, 120000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, 400000m, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 20, 160000m, new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, 240000m, new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, "accepted", 400000m, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 10, "completed", 300000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, "completed", 100000m, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, 240000m, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 24, 300000m, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "completed", 120000m, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 1, "accepted", 600000m, new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 1, 600000m, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "cancelled", 240000m, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, "accepted", 400000m, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, "completed", 100000m, new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, 240000m, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 1, 600000m, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 24, 300000m, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 220000m, 15, 220000m, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 1, 600000m, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "accepted", 240000m, new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 160000m, 20, 160000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "completed", 240000m, new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 24, "cancelled", 300000m, new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "completed", 240000m, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "completed", 240000m, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 220000m, 15, "cancelled", 220000m, new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), "cancelled", new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "cancelled", 120000m, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, "completed", 120000m, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, 400000m, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "accepted", 240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, 400000m, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, "cancelled", 400000m, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 10, "cancelled", 300000m, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 10, 300000m, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "accepted", 240000m, new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 1, "completed", 600000m, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, 120000m, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, 400000m, new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 100000m, 2, 100000m, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, 240000m, new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 120000m, 9, 120000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 24, "accepted", 300000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 20, "accepted", 160000m, new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 24, "cancelled", 300000m, new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 220000m, 15, "cancelled", 220000m, new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, "completed", 240000m, new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 240000m, 8, 240000m, new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "CreatedById", "Date", "OriginalPrice", "TotalPrice", "UserId" },
                values: new object[] { 7, new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 600000m, 600000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 7, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 160000m, 20, "pending", 160000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 140000m, 5, 140000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 140000m, 5, 140000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 140000m, 5, 140000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 140000m, 5, 140000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 5, 16, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 5, 16, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 5, 16, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "CreatedById", "StadiumId", "UserId" },
                values: new object[] { 5, 16, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 200000m, 16, 200000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 200000m, 16, 200000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 200000m, 16, 200000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 200000m, 16, 200000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 140000m, 23, 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 140000m, 23, 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 140000m, 23, 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 140000m, 23, 140000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 5, "completed", 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 5, "completed", 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 5, "completed", 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 6, 140000m, 5, "completed", 140000m, 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 221,
                column: "StadiumId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 222,
                column: "StadiumId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 223,
                column: "StadiumId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 224,
                column: "StadiumId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 140000m, 23, 140000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 140000m, 23, 140000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 140000m, 23, 140000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 140000m, 23, 140000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 140000m, 5, 140000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 140000m, 5, 140000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 140000m, 5, 140000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 140000m, 5, 140000m, 5 });

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
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 4, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 4, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 4, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 300000m, 4, 300000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 190000m, 27, 190000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 190000m, 27, 190000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 190000m, 27, 190000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 190000m, 27, 190000m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 190000m, 27, 190000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 190000m, 27, 190000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 190000m, 27, 190000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 8, 190000m, 27, 190000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, "completed", 140000m, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 16, "completed", new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "completed", 200000m, new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, "cancelled", 140000m, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 16, "cancelled", 200000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 12, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, "accepted", 190000m, new DateTime(2025, 12, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, "cancelled", 190000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, "accepted", 190000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, "completed", 190000m, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "completed", 200000m, new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 22, "accepted", 200000m, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, 300000m, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, "accepted", 140000m, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "completed", 200000m, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "CreatedAt", "Date", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), "completed", new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, 140000m, new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 16, "completed", new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, 300000m, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, 300000m, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "accepted", 200000m, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, "accepted", 190000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 22, "cancelled", 200000m, new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 23, "cancelled", new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, 300000m, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, "accepted", new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, 200000m, new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, "completed", 300000m, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), "accepted", new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 23, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 16, "cancelled", new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), "accepted", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, "accepted", 140000m, new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, "accepted", 190000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, "accepted", 140000m, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "accepted", 200000m, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 16, "accepted", 200000m, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), "cancelled", new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, "completed", 190000m, new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 190000m, 27, 190000m, new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "CreatedAt", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, "completed", 140000m, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 5, 140000m, new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 300000m, 4, 300000m, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 7, 200000m, 3, 200000m, 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "StadiumId", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { 5, new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 140000m, 23, "pending", 140000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 5, 200000m, 3, 200000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 17, 0, 0, 0), 2240000m, 14, new TimeSpan(0, 15, 0, 0, 0), "completed", 2240000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice" },
                values: new object[] { 560000m, 17, 560000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 11, 0, 0, 0), 1440000m, 14, new TimeSpan(0, 9, 0, 0, 0), 1440000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 16, 0, 0, 0), 960000m, 26, new TimeSpan(0, 14, 0, 0, 0), 960000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndTime", "StartTime", "UserId" },
                values: new object[] { new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 15, 0, 0, 0), 2000000m, 18, new TimeSpan(0, 13, 0, 0, 0), "completed", 2000000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 15, 0, 0, 0), 640000m, 11, new TimeSpan(0, 13, 0, 0, 0), 640000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 21, 0, 0, 0), 4000000m, 6, new TimeSpan(0, 19, 0, 0, 0), 4000000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), 1200000m, 18, new TimeSpan(0, 12, 0, 0, 0), 1200000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 560000m, 17, 560000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 19, 0, 0, 0), 2240000m, 14, new TimeSpan(0, 17, 0, 0, 0), 2240000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 10, 0, 0, 0), 1440000m, 14, new TimeSpan(0, 8, 0, 0, 0), 1440000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EndTime", "OriginalPrice", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 17, 0, 0, 0), 1600000m, new TimeSpan(0, 15, 0, 0, 0), "cancelled", 1600000m, 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 16, 0, 0, 0), 720000m, 19, new TimeSpan(0, 14, 0, 0, 0), "completed", 720000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 9, 0, 0, 0), 480000m, 9, new TimeSpan(0, 7, 0, 0, 0), 480000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 12, 0, 0, 0), 640000m, 20, new TimeSpan(0, 10, 0, 0, 0), "cancelled", 640000m, 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 9, 0, 0, 0), 1200000m, 24, new TimeSpan(0, 7, 0, 0, 0), 1200000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 18, 0, 0, 0), 400000m, 2, new TimeSpan(0, 16, 0, 0, 0), 400000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 9, 0, 0, 0), 1200000m, 24, new TimeSpan(0, 7, 0, 0, 0), 1200000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 15, 0, 0, 0), 2400000m, 1, new TimeSpan(0, 13, 0, 0, 0), 2400000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), 480000m, 9, new TimeSpan(0, 12, 0, 0, 0), 480000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), 480000m, 9, new TimeSpan(0, 12, 0, 0, 0), 480000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 9, 0, 0, 0), 960000m, 8, new TimeSpan(0, 7, 0, 0, 0), 960000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 19, 0, 0, 0), 480000m, 9, new TimeSpan(0, 17, 0, 0, 0), 480000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 10, 0, 0, 0), 560000m, 5, new TimeSpan(0, 8, 0, 0, 0), 560000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "EndTime", "StadiumId", "StartTime", "UserId" },
                values: new object[] { new TimeSpan(0, 11, 0, 0, 0), 16, new TimeSpan(0, 9, 0, 0, 0), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 21, 0, 0, 0), 800000m, 16, new TimeSpan(0, 19, 0, 0, 0), 800000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 13, 0, 0, 0), 560000m, 23, new TimeSpan(0, 11, 0, 0, 0), 560000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 21, 0, 0, 0), 560000m, 5, new TimeSpan(0, 19, 0, 0, 0), "completed", 560000m, 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "EndTime", "StadiumId", "StartTime" },
                values: new object[] { new TimeSpan(0, 18, 0, 0, 0), 5, new TimeSpan(0, 16, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 18, 0, 0, 0), 560000m, 23, new TimeSpan(0, 16, 0, 0, 0), 560000m, 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UserId" },
                values: new object[] { new TimeSpan(0, 21, 0, 0, 0), 560000m, 5, new TimeSpan(0, 19, 0, 0, 0), 560000m, 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "EndTime", "StartTime", "Status", "UserId" },
                values: new object[] { new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), "completed", 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 16, 0, 0, 0), 1200000m, 4, new TimeSpan(0, 14, 0, 0, 0), 1200000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice" },
                values: new object[] { new TimeSpan(0, 20, 0, 0, 0), 760000m, 27, new TimeSpan(0, 18, 0, 0, 0), 760000m });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "OriginalPrice", "StadiumId", "TotalPrice", "UserId" },
                values: new object[] { 760000m, 27, 760000m, 8 });
        }
    }
}
