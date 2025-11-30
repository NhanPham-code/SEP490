using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingAPI.Migrations
{
    /// <inheritdoc />
    public partial class newDataBookingV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 2, 35, new DateTime(2025, 1, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 3, new DateTime(2025, 1, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 4, 35, new DateTime(2025, 1, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 5, 18, new DateTime(2025, 2, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 6, 18, new DateTime(2025, 2, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 7, 18, new DateTime(2025, 2, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 8, 18, new DateTime(2025, 2, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 9, 18, new DateTime(2025, 3, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 10, 18, new DateTime(2025, 3, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 11, 18, new DateTime(2025, 3, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 12, 18, new DateTime(2025, 3, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 13, 26, new DateTime(2025, 4, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 14, 26, new DateTime(2025, 4, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 15, 26, new DateTime(2025, 4, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 16, 26, new DateTime(2025, 4, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 17, 26, new DateTime(2025, 5, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 18, 26, new DateTime(2025, 5, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 19, 26, new DateTime(2025, 5, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, 26, new DateTime(2025, 5, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, 24, new DateTime(2025, 6, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 22, 24, new DateTime(2025, 6, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 23, 24, new DateTime(2025, 6, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 24, 24, new DateTime(2025, 6, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 25, 37, new DateTime(2025, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 26, 37, new DateTime(2025, 7, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 27, 37, new DateTime(2025, 7, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 28, 37, new DateTime(2025, 7, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 29, 18, new DateTime(2025, 8, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 30, 18, new DateTime(2025, 8, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 31, 18, new DateTime(2025, 8, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 32, 18, new DateTime(2025, 8, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 33, 20, new DateTime(2025, 9, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 33, 21, new DateTime(2025, 9, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 34, 20, new DateTime(2025, 9, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 34, 21, new DateTime(2025, 9, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, 20, new DateTime(2025, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, 21, new DateTime(2025, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, 20, new DateTime(2025, 9, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, 21, new DateTime(2025, 9, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 37, 37, new DateTime(2025, 10, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 38, 37, new DateTime(2025, 10, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, 37, new DateTime(2025, 10, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, 37, new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 41, 36, new DateTime(2025, 11, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 42, 36, new DateTime(2025, 11, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 43, 36, new DateTime(2025, 11, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 44, 36, new DateTime(2025, 11, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 45, 11, new DateTime(2025, 12, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 46, 11, new DateTime(2025, 12, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 47, 11, new DateTime(2025, 12, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 48, 11, new DateTime(2025, 12, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 49, 20, new DateTime(2026, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 50, 20, new DateTime(2026, 1, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 51, 20, new DateTime(2026, 1, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 52, 20, new DateTime(2026, 1, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 53, 18, new DateTime(2026, 2, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 54, 18, new DateTime(2026, 2, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 55, 18, new DateTime(2026, 2, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 56, 18, new DateTime(2026, 2, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 57, 11, new DateTime(2025, 12, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 58, 24, new DateTime(2025, 12, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 59, 11, new DateTime(2025, 11, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 17, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 60, 38, new DateTime(2025, 9, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 61, 39, new DateTime(2025, 10, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 27, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 62, 24, new DateTime(2025, 12, 29, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 63, new DateTime(2025, 12, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 21, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 64, 40, new DateTime(2025, 9, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 65, 21, new DateTime(2025, 9, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 21, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 66, 26, new DateTime(2025, 12, 11, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 11, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 67, 27, new DateTime(2025, 9, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 4, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 68, 11, new DateTime(2025, 9, 6, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 6, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 69, 25, new DateTime(2025, 9, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 19, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 70, 21, new DateTime(2025, 9, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 2, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 71, 39, new DateTime(2026, 1, 6, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 6, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 72, 35, new DateTime(2025, 10, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 72, 36, new DateTime(2025, 10, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 73, 20, new DateTime(2025, 12, 28, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 73, 21, new DateTime(2025, 12, 28, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 74, 20, new DateTime(2025, 11, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 23, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 74, 21, new DateTime(2025, 11, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 23, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 75, 35, new DateTime(2025, 11, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 75, 36, new DateTime(2025, 11, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 76, 25, new DateTime(2026, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 77, new DateTime(2025, 12, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 18, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 78, 24, new DateTime(2026, 1, 24, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 24, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 79, 21, new DateTime(2026, 1, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 21, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 80, 20, new DateTime(2025, 12, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 31, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 81, new DateTime(2025, 10, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 82, 17, new DateTime(2026, 1, 11, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 11, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 83, 40, new DateTime(2026, 1, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 84, 20, new DateTime(2025, 12, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 16, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 84, 21, new DateTime(2025, 12, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 16, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 85, 21, new DateTime(2025, 10, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 86, 27, new DateTime(2025, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 87, 21, new DateTime(2025, 10, 11, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 88, 24, new DateTime(2025, 12, 10, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 10, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 89, 38, new DateTime(2026, 1, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 20, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 90, 24, new DateTime(2025, 11, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 91, 39, new DateTime(2025, 9, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 3, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 92, 11, new DateTime(2025, 12, 12, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 12, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 93, 21, new DateTime(2025, 9, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 94, 11, new DateTime(2025, 10, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 26, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 95, 35, new DateTime(2025, 10, 19, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 19, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 95, 36, new DateTime(2025, 10, 19, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 19, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 96, 18, new DateTime(2026, 1, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 26, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 97, 27, new DateTime(2025, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 28, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 98, 40, new DateTime(2025, 10, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 99, 38, new DateTime(2025, 11, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 3, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 100, new DateTime(2025, 12, 11, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 11, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 101, 40, new DateTime(2025, 10, 18, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 18, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 102, 35, new DateTime(2025, 12, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 103, 26, new DateTime(2025, 11, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 104, 27, new DateTime(2026, 1, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 105, 26, new DateTime(2025, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 106, 25, new DateTime(2025, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 107, 39, new DateTime(2026, 1, 6, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 6, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 108, 17, new DateTime(2025, 12, 4, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 4, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 109, 18, new DateTime(2025, 10, 27, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 110, 35, new DateTime(2026, 1, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 17, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 111, 24, new DateTime(2025, 12, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 112, 11, new DateTime(2025, 9, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 113, 26, new DateTime(2025, 12, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 12, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 114, 24, new DateTime(2026, 1, 6, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 6, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 115, 35, new DateTime(2026, 1, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 20, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 116, 36, new DateTime(2026, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 117, 20, new DateTime(2026, 1, 18, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 18, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 117, 21, new DateTime(2026, 1, 18, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 18, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 118, 17, new DateTime(2026, 2, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 119, 18, new DateTime(2026, 2, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 120, 21, new DateTime(2026, 2, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 121, 24, new DateTime(2026, 2, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 8, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 122, 35, new DateTime(2026, 1, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 28, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, new DateTime(2026, 1, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 28, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2026, 1, 26, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 26, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 38, new DateTime(2026, 2, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 25, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 18, new DateTime(2026, 1, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 24, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2026, 1, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 4, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 21, new DateTime(2026, 1, 20, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 20, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 37, new DateTime(2026, 1, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 17, new DateTime(2026, 1, 24, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 24, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, new DateTime(2026, 1, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2026, 2, 11, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 11, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, new DateTime(2026, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, new DateTime(2026, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 2, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 20, new DateTime(2026, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 28, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 134, 21, new DateTime(2026, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 28, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 135, 11, new DateTime(2026, 1, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 18, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 136, 38, new DateTime(2026, 2, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 25, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 137, 40, new DateTime(2025, 12, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 12, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 138, 20, new DateTime(2025, 12, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 28, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 139, 26, new DateTime(2025, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 25, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 140, 14, new DateTime(2025, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 141, 14, new DateTime(2025, 1, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 142, 14, new DateTime(2025, 1, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 143, 14, new DateTime(2025, 1, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 144, 15, new DateTime(2025, 2, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 145, 15, new DateTime(2025, 2, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 146, 15, new DateTime(2025, 2, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 147, 15, new DateTime(2025, 2, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 148, 13, new DateTime(2025, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 149, 13, new DateTime(2025, 3, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 13, new DateTime(2025, 3, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 13, new DateTime(2025, 3, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 15, new DateTime(2025, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 15, new DateTime(2025, 4, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 15, new DateTime(2025, 4, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 15, new DateTime(2025, 4, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 4, new DateTime(2025, 5, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 4, new DateTime(2025, 5, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 4, new DateTime(2025, 5, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 159, 4, new DateTime(2025, 5, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 160, 28, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 161, 28, new DateTime(2025, 6, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 162, 28, new DateTime(2025, 6, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 163, new DateTime(2025, 6, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 164, 3, new DateTime(2025, 7, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 165, 3, new DateTime(2025, 7, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 166, new DateTime(2025, 7, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 167, 3, new DateTime(2025, 7, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 168, new DateTime(2025, 8, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 169, new DateTime(2025, 8, 8, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 170, 3, new DateTime(2025, 8, 15, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 171, 3, new DateTime(2025, 8, 22, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 172, 3, new DateTime(2025, 9, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 173, 3, new DateTime(2025, 9, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 174, 3, new DateTime(2025, 9, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 175, new DateTime(2025, 9, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 176, 3, new DateTime(2025, 10, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 177, 3, new DateTime(2025, 10, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 178, new DateTime(2025, 10, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 179, 3, new DateTime(2025, 10, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 180, 12, new DateTime(2025, 11, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 181, 12, new DateTime(2025, 11, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 182, 12, new DateTime(2025, 11, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 183, 12, new DateTime(2025, 11, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 184, 29, new DateTime(2025, 12, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 185, 29, new DateTime(2025, 12, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 186, 29, new DateTime(2025, 12, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 187, 29, new DateTime(2025, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 188, 2, new DateTime(2026, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 188, 3, new DateTime(2026, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 189, 2, new DateTime(2026, 1, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 189, 3, new DateTime(2026, 1, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 190, 2, new DateTime(2026, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 190, 3, new DateTime(2026, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 191, 2, new DateTime(2026, 1, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 3, new DateTime(2026, 1, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 192, 33, new DateTime(2026, 2, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 193, 33, new DateTime(2026, 2, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 194, 33, new DateTime(2026, 2, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 195, 33, new DateTime(2026, 2, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 196, 28, new DateTime(2025, 9, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 197, 16, new DateTime(2025, 12, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 24, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 198, 28, new DateTime(2025, 11, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 21, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 199, 22, new DateTime(2025, 12, 22, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 200, 12, new DateTime(2025, 12, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 201, 14, new DateTime(2025, 12, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 21, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 202, 15, new DateTime(2026, 1, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 203, 15, new DateTime(2026, 1, 11, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 11, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 204, 15, new DateTime(2025, 10, 27, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 27, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 205, 12, new DateTime(2026, 1, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 206, 33, new DateTime(2026, 1, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 2, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 207, 12, new DateTime(2025, 12, 24, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 24, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 208, 33, new DateTime(2026, 1, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 209, 14, new DateTime(2025, 11, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 210, 4, new DateTime(2025, 12, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 211, 2, new DateTime(2025, 12, 19, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 19, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 211, 3, new DateTime(2025, 12, 19, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 19, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 212, 16, new DateTime(2025, 9, 27, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 27, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 213, 4, new DateTime(2025, 9, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 14, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 214, 2, new DateTime(2025, 10, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 18, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 214, 3, new DateTime(2025, 10, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 18, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 215, 29, new DateTime(2026, 1, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 23, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 216, 2, new DateTime(2025, 12, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 17, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 3, new DateTime(2025, 12, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 17, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 33, new DateTime(2025, 11, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 29, new DateTime(2025, 12, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 12, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 16, new DateTime(2025, 12, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 10, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 2, new DateTime(2025, 11, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 4, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 16, new DateTime(2026, 1, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 15, new DateTime(2026, 1, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 33, new DateTime(2025, 12, 11, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 11, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 4, new DateTime(2025, 12, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 12, new DateTime(2025, 9, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 28, new DateTime(2025, 10, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 2, new DateTime(2025, 10, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 24, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 227, 3, new DateTime(2025, 10, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 24, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 228, 3, new DateTime(2025, 11, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 20, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 229, 3, new DateTime(2025, 10, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 24, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 230, 3, new DateTime(2026, 1, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 3, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 231, 14, new DateTime(2025, 9, 7, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 7, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 232, 28, new DateTime(2025, 9, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 21, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 233, 22, new DateTime(2025, 12, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 234, 12, new DateTime(2025, 9, 10, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 235, 28, new DateTime(2025, 12, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 236, 29, new DateTime(2025, 11, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 237, 28, new DateTime(2025, 10, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 238, 12, new DateTime(2026, 1, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 7, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 239, 14, new DateTime(2025, 9, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 2, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 240, 2, new DateTime(2025, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 25, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 241, 5, new DateTime(2026, 1, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 242, 28, new DateTime(2025, 11, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 23, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 243, 15, new DateTime(2025, 12, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 7, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 244, 5, new DateTime(2025, 9, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 21, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 245, 2, new DateTime(2025, 9, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 4, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 246, 29, new DateTime(2025, 10, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 247, 14, new DateTime(2025, 11, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 13, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 248, 2, new DateTime(2025, 10, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 249, 13, new DateTime(2026, 1, 12, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 12, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 250, 14, new DateTime(2026, 1, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 17, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 251, 14, new DateTime(2025, 12, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 21, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 252, 12, new DateTime(2025, 11, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 253, 33, new DateTime(2025, 12, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 3, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 254, 28, new DateTime(2025, 11, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 14, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 255, 14, new DateTime(2025, 11, 27, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 256, 22, new DateTime(2026, 1, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 30, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 257, 12, new DateTime(2026, 2, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 7, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 258, 5, new DateTime(2026, 2, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 13, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 259, 16, new DateTime(2026, 2, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 260, 3, new DateTime(2026, 2, 11, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 11, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 261, 14, new DateTime(2026, 2, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 17, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 262, 29, new DateTime(2026, 1, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 6, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 263, 29, new DateTime(2026, 1, 27, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 27, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 264, 14, new DateTime(2026, 2, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 3, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 265, 16, new DateTime(2026, 2, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 6, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 266, 4, new DateTime(2026, 2, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 21, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 267, 3, new DateTime(2026, 2, 19, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 19, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 268, 15, new DateTime(2026, 2, 11, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 11, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 269, 16, new DateTime(2026, 2, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 270, 2, new DateTime(2026, 2, 6, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 6, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 271, 15, new DateTime(2026, 1, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 272, 14, new DateTime(2026, 1, 6, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 6, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 273, 13, new DateTime(2026, 2, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 274, 15, new DateTime(2026, 2, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 3, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 275, 15, new DateTime(2026, 1, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 13, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 276, 3, new DateTime(2025, 12, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 6, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 277, 3, new DateTime(2025, 12, 4, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 4, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 278, 3, new DateTime(2025, 12, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 279, 6, new DateTime(2025, 1, 1, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 280, 6, new DateTime(2025, 1, 8, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 281, 6, new DateTime(2025, 1, 15, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 282, 6, new DateTime(2025, 1, 22, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 283, 42, new DateTime(2025, 2, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 284, 42, new DateTime(2025, 2, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 306,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 285, 42, new DateTime(2025, 2, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 307,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 286, 42, new DateTime(2025, 2, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 308,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 287, 8, new DateTime(2025, 3, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 288, 8, new DateTime(2025, 3, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 8, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 310,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 289, 8, new DateTime(2025, 3, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 290, new DateTime(2025, 3, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 22, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 312,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 291, 42, new DateTime(2025, 4, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 313,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 292, 42, new DateTime(2025, 4, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 314,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 293, 42, new DateTime(2025, 4, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 315,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 294, 42, new DateTime(2025, 4, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 295, 8, new DateTime(2025, 5, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 317,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 296, 8, new DateTime(2025, 5, 8, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 8, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 318,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 297, 8, new DateTime(2025, 5, 15, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 319,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 298, 8, new DateTime(2025, 5, 22, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 320,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 299, 23, new DateTime(2025, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 321, 300, 23, new DateTime(2025, 6, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 600000m, "completed", 600000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 600000m, "completed", 600000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 600000m, "completed", 600000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 600000m, "completed", 600000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 150000m, 13, 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 150000m, 13, 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 150000m, 13, 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 150000m, 13, 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 150000m, 13, 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 150000m, 13, 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 150000m, 13, 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 150000m, 13, 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 500000m, 18, 500000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 500000m, 18, 500000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 500000m, 18, 500000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 500000m, 18, 500000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 500000m, 18, 500000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 500000m, 18, 500000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 500000m, 18, 500000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 500000m, 18, 500000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 100000m, 17, 100000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 100000m, 17, 100000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 100000m, 17, 100000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 100000m, 17, 100000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 240000m, 26, 240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 240000m, 26, 240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 240000m, 26, 240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 240000m, 26, 240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 150000m, 13, 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 150000m, 13, 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 150000m, 13, 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 150000m, 13, 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 560000m, 14, "completed", 560000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 560000m, 14, "completed", 560000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 560000m, 14, "completed", 560000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 560000m, 14, "completed", 560000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "CreatedById", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, "cancelled", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "CreatedById", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, "cancelled", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "CreatedById", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, "cancelled", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "CreatedById", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, "cancelled", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "CreatedById", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, "completed", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "CreatedById", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, "completed", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "CreatedById", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, "completed", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 1000000m, 6, 1000000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 1000000m, 6, 1000000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 1000000m, 6, 1000000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, 1000000m, 6, 1000000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Lịch con của booking tháng", 360000m, 14, "accepted", 360000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Lịch con của booking tháng", 360000m, 14, "accepted", 360000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Lịch con của booking tháng", 360000m, 14, "accepted", 360000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Lịch con của booking tháng", 360000m, 14, "accepted", 360000m, 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Lịch con của booking tháng", 150000m, 13, "accepted", 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Lịch con của booking tháng", 150000m, 13, "accepted", 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Lịch con của booking tháng", 150000m, 13, 150000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Lịch con của booking tháng", "accepted", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 1000000m, 6, "accepted", 1000000m, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 100000m, 17, "accepted", 100000m, new DateTime(2025, 12, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 1000000m, 6, 1000000m, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 240000m, 26, 240000m, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 100000m, 17, 100000m, new DateTime(2025, 12, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 12, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 360000m, 14, "cancelled", 360000m, new DateTime(2025, 12, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 240000m, 26, "completed", 240000m, new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 360000m, 14, 360000m, new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 12, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 500000m, 18, "accepted", 500000m, new DateTime(2025, 12, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 9, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 300000m, 18, "cancelled", 300000m, new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 1000000m, 6, 1000000m, new DateTime(2025, 9, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 140000m, 17, "completed", 140000m, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 360000m, 14, "cancelled", 360000m, new DateTime(2025, 9, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2026, 1, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 240000m, 26, 240000m, new DateTime(2026, 1, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 900000m, 25, "completed", 900000m, new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 12, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 560000m, 14, "cancelled", 560000m, new DateTime(2025, 12, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 560000m, 14, "completed", 560000m, new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 900000m, 25, "cancelled", 900000m, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 140000m, 17, "accepted", 140000m, new DateTime(2025, 12, 31, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 12, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 1000000m, 6, "accepted", 1000000m, new DateTime(2025, 12, 17, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2026, 1, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 100000m, 17, 100000m, new DateTime(2026, 1, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2026, 1, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 360000m, 14, 360000m, new DateTime(2026, 1, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 12, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 360000m, 14, "cancelled", 360000m, new DateTime(2025, 12, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 160000m, 11, "cancelled", 160000m, new DateTime(2026, 1, 10, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 240000m, 26, "accepted", 240000m, new DateTime(2026, 1, 24, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 12, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 560000m, 14, "cancelled", 560000m, new DateTime(2025, 12, 15, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 360000m, 14, 360000m, new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 300000m, 18, 300000m, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 360000m, 14, 360000m, new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 12, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 100000m, 17, 100000m, new DateTime(2025, 12, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2026, 1, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 240000m, 26, 240000m, new DateTime(2026, 1, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 100000m, 17, 100000m, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 8, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", "completed", new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 1000000m, 6, "cancelled", 1000000m, new DateTime(2025, 12, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 8, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 9, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 360000m, 14, "completed", 360000m, new DateTime(2025, 9, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", "completed", new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 900000m, 25, 900000m, new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 150000m, 13, "accepted", 150000m, new DateTime(2026, 1, 25, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 300000m, 18, "completed", 300000m, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 240000m, 26, "completed", 240000m, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 12, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 240000m, 26, 240000m, new DateTime(2025, 12, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 240000m, 26, "cancelled", 240000m, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 12, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 600000m, 25, "cancelled", 600000m, new DateTime(2025, 12, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 500000m, 18, 500000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2026, 1, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 300000m, 18, "accepted", 300000m, new DateTime(2026, 1, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 500000m, 18, "completed", 500000m, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 140000m, 17, 140000m, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2026, 1, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 240000m, 26, "accepted", 240000m, new DateTime(2026, 1, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 160000m, 11, "accepted", 160000m, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 150000m, 13, 150000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2026, 1, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 600000m, 25, "cancelled", 600000m, new DateTime(2026, 1, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "StadiumId", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 17, "accepted", new DateTime(2025, 12, 28, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 1000000m, 6, 1000000m, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 12, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 500000m, 18, "accepted", 500000m, new DateTime(2025, 12, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2026, 1, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 17, "cancelled", new DateTime(2026, 1, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2026, 1, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 600000m, 25, "accepted", 600000m, new DateTime(2026, 1, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 600000m, 25, "cancelled", 600000m, new DateTime(2025, 12, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 560000m, 14, "waiting", 560000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 160000m, 11, "waiting", 160000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 150000m, 13, "accepted", 150000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 360000m, 14, "accepted", 360000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 100000m, 17, "accepted", 100000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 900000m, 25, "waiting", 900000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 240000m, 26, "accepted", 240000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 240000m, 26, "waiting", 240000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 150000m, 13, "accepted", 150000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 360000m, 14, "accepted", 360000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 360000m, 14, "accepted", 360000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 240000m, 26, "accepted", 240000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 160000m, 11, "accepted", 160000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 26, "accepted", new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 26, "accepted", new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 26, "accepted", new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 600000m, 25, "accepted", 600000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 560000m, 14, "accepted", 560000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 1000000m, 6, "waiting", 1000000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 240000m, 26, "accepted", 240000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 240000m, 26, "accepted", 240000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 12, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Đặt qua điện thoại", 360000m, 14, "accepted", 360000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 12, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Đặt qua điện thoại", 500000m, 18, "accepted", 500000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "completed", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 120000m, 9, 120000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 120000m, 9, "completed", 120000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 120000m, 9, "completed", 120000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 120000m, 9, "cancelled", 120000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 120000m, 9, "cancelled", 120000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 120000m, 9, "cancelled", 120000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 120000m, 9, "cancelled", 120000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 240000m, 8, "completed", 240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Lịch con của booking tháng", 240000m, 8, "completed", 240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Lịch con của booking tháng", 240000m, 8, "completed", 240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Lịch con của booking tháng", 240000m, 8, 240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "Lịch con của booking tháng", 120000m, 9, 120000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "Lịch con của booking tháng", 120000m, 9, "completed", 120000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "Lịch con của booking tháng", 120000m, 9, "completed", 120000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "Lịch con của booking tháng", 120000m, 9, "completed", 120000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, "Lịch con của booking tháng", 100000m, 2, 100000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, "Lịch con của booking tháng", 100000m, 2, "completed", 100000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, "Lịch con của booking tháng", 100000m, 2, "completed", 100000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, "Lịch con của booking tháng", 100000m, 2, "completed", 100000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Lịch con của booking tháng", 180000m, 19, "cancelled", 180000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Lịch con của booking tháng", 180000m, 19, "cancelled", 180000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Lịch con của booking tháng", "cancelled", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Lịch con của booking tháng", 180000m, 19, "cancelled", 180000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Lịch con của booking tháng", 400000m, "completed", 400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Lịch con của booking tháng", 400000m, 1, "completed", 400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Lịch con của booking tháng", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Lịch con của booking tháng", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, "Lịch con của booking tháng", 400000m, 1, 400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, "Lịch con của booking tháng", 400000m, 1, 400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, "Lịch con của booking tháng", 400000m, 1, 400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, "Lịch con của booking tháng", 400000m, 1, 400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, "Lịch con của booking tháng", 400000m, 400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, "Lịch con của booking tháng", 400000m, 1, "completed", 400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, "Lịch con của booking tháng", 400000m, 1, "completed", 400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, "Lịch con của booking tháng", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, "Lịch con của booking tháng", 400000m, 1, "completed", 400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, "Lịch con của booking tháng", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, "Lịch con của booking tháng", 400000m, 1, 400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, "Lịch con của booking tháng", 400000m, 1, "completed", 400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Lịch con của booking tháng", 240000m, 8, 240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Lịch con của booking tháng", 240000m, 8, "completed", 240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Lịch con của booking tháng", 240000m, 8, "completed", 240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Lịch con của booking tháng", 240000m, 8, "completed", 240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, "Lịch con của booking tháng", 160000m, 20, "accepted", 160000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, "Lịch con của booking tháng", 160000m, 20, 160000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, "Lịch con của booking tháng", 160000m, 20, "accepted", 160000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, "Lịch con của booking tháng", 160000m, 20, "accepted", 160000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, "Lịch con của booking tháng", 600000m, 1, "cancelled", 600000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, "Lịch con của booking tháng", 600000m, 1, "cancelled", 600000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, "Lịch con của booking tháng", 600000m, 1, "cancelled", 600000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, "Lịch con của booking tháng", "cancelled", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, "Lịch con của booking tháng", 300000m, 24, "accepted", 300000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, "Lịch con của booking tháng", 300000m, 24, "accepted", 300000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, "Lịch con của booking tháng", 300000m, 24, "accepted", 300000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, "Lịch con của booking tháng", 300000m, 24, 300000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 180000m, 19, "completed", 180000m, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 12, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 300000m, 10, 300000m, new DateTime(2025, 12, 23, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 180000m, 19, 180000m, new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 220000m, 15, 220000m, new DateTime(2025, 12, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 240000m, 8, 240000m, new DateTime(2025, 12, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 12, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 120000m, 9, "accepted", 120000m, new DateTime(2025, 12, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 1, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 120000m, 9, "accepted", 120000m, new DateTime(2026, 1, 21, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2026, 1, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 1, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 120000m, 9, "accepted", 120000m, new DateTime(2026, 1, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 120000m, 9, 120000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2026, 1, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 240000m, 8, "cancelled", 240000m, new DateTime(2026, 1, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 1, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 300000m, 24, "accepted", 300000m, new DateTime(2026, 1, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 12, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 240000m, 8, "accepted", 240000m, new DateTime(2025, 12, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 300000m, 24, "accepted", 300000m, new DateTime(2026, 1, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 120000m, 9, 120000m, new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 100000m, 2, "accepted", 100000m, new DateTime(2025, 12, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 12, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 600000m, 1, "accepted", 600000m, new DateTime(2025, 12, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 300000m, 10, 300000m, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 100000m, 2, 100000m, new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 600000m, 1, 600000m, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2026, 1, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 1, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 160000m, 20, "accepted", 160000m, new DateTime(2026, 1, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 12, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 600000m, 1, "accepted", 600000m, new DateTime(2025, 12, 16, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 300000m, 24, "completed", 300000m, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 160000m, 20, "accepted", 160000m, new DateTime(2025, 12, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 12, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 300000m, 10, "accepted", 300000m, new DateTime(2025, 12, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 400000m, 1, "completed", 400000m, new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 300000m, 10, "accepted", 300000m, new DateTime(2026, 1, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 120000m, 9, "accepted", 120000m, new DateTime(2026, 1, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 300000m, 24, 300000m, new DateTime(2025, 12, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 100000m, 2, "accepted", 100000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 240000m, 8, 240000m, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 180000m, 19, 180000m, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 600000m, 1, 600000m, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 400000m, 1, 400000m, new DateTime(2025, 11, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 400000m, 1, 400000m, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 400000m, 1, "accepted", 400000m, new DateTime(2026, 1, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 120000m, 9, 120000m, new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 180000m, 19, 180000m, new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 220000m, 15, "accepted", 220000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 240000m, 8, 240000m, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 180000m, 19, "accepted", 180000m, new DateTime(2025, 12, 19, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 160000m, 20, 160000m, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 180000m, 19, 180000m, new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 1, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 240000m, 8, "accepted", 240000m, new DateTime(2026, 1, 6, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 120000m, 9, 120000m, new DateTime(2025, 9, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 12, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 400000m, 1, "accepted", 400000m, new DateTime(2025, 12, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 1, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 100000m, 2, "accepted", 100000m, new DateTime(2026, 1, 14, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 180000m, 19, "completed", 180000m, new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Khách đặt online", 120000m, 9, 120000m, new DateTime(2025, 12, 6, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 100000m, 2, "completed", 100000m, new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 9, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 400000m, 1, "completed", 400000m, new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 160000m, 20, "completed", 160000m, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 120000m, 9, "completed", 120000m, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "Chủ sân tạo hộ", 400000m, 1, "completed", 400000m, new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2026, 1, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 1, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 240000m, 8, "accepted", 240000m, new DateTime(2026, 1, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2026, 1, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 1, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 120000m, 9, "accepted", 120000m, new DateTime(2026, 1, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 12, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 12, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 120000m, 9, "accepted", 120000m, new DateTime(2025, 12, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 240000m, 8, "completed", 240000m, new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 300000m, 24, "accepted", 300000m, new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), "Khách đặt online", 180000m, 19, "cancelled", 180000m, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 120000m, 9, "cancelled", 120000m, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 220000m, 15, "accepted", 220000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 240000m, 8, "accepted", 240000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 100000m, 2, "accepted", 100000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khách đặt online", 300000m, 10, "waiting", 300000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khách đặt online", 400000m, 1, "accepted", 400000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khách đặt online", 120000m, 9, "accepted", 120000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 160000m, 20, "accepted", 160000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 160000m, 20, "accepted", 160000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 120000m, 9, 120000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khách đặt online", 300000m, 10, "waiting", 300000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 100000m, 2, "waiting", 100000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 400000m, 1, "accepted", 400000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 120000m, 9, "waiting", 120000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 10, "accepted", new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khách đặt online", 400000m, 1, "accepted", 400000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khách đặt online", 120000m, 9, "accepted", 120000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khách đặt online", 120000m, 9, "accepted", 120000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khách đặt online", 240000m, 8, "accepted", 240000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khách đặt online", 120000m, 9, "accepted", 120000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chủ sân tạo hộ", 120000m, 9, "waiting", 120000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, "waiting", 400000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { 3, new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), "Đặt qua điện thoại", 400000m, 1, 400000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 400000m, 1, "accepted", 400000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, "Lịch con của booking tháng", 200000m, 3, "completed", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, "Lịch con của booking tháng", 200000m, 3, 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, "Lịch con của booking tháng", 200000m, 3, "completed", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, "Lịch con của booking tháng", 200000m, 3, 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Lịch con của booking tháng", 190000m, 27, "completed", 190000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Lịch con của booking tháng", 190000m, 27, 190000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Lịch con của booking tháng", "completed", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Lịch con của booking tháng", 190000m, 27, 190000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, "Lịch con của booking tháng", 300000m, 4, 300000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, "Lịch con của booking tháng", 300000m, 4, "completed", 300000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, "Lịch con của booking tháng", 300000m, 4, 300000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, "Lịch con của booking tháng", 300000m, 4, "completed", 300000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, "Lịch con của booking tháng", 190000m, 27, 190000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, "Lịch con của booking tháng", 190000m, 27, 190000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, "Lịch con của booking tháng", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, "Lịch con của booking tháng", 190000m, 27, 190000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, "Lịch con của booking tháng", 300000m, 4, 300000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, "Lịch con của booking tháng", 300000m, 4, "completed", 300000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, "Lịch con của booking tháng", 300000m, 4, 300000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, "Lịch con của booking tháng", 300000m, 4, 300000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, "Lịch con của booking tháng", 200000m, 16, "completed", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, "Lịch con của booking tháng", 200000m, 16, "completed", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Date", "DiscountId", "MonthlyBookingId", "Note", "OriginalPrice", "PaymentMethod", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 301, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 34, "Lịch con của booking tháng", 200000m, "vnpay_100", 16, "completed", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 302, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 34, "Lịch con của booking tháng", 200000m, "vnpay_100", 16, "completed", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 303, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 35, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 304, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 35, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 305, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 35, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 306, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 35, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 307, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 36, "Lịch con của booking tháng", 140000m, "vnpay_100", 5, "completed", 140000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 308, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 36, "Lịch con của booking tháng", 140000m, "vnpay_100", 5, "completed", 140000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 309, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 36, "Lịch con của booking tháng", 140000m, "vnpay_100", 5, "completed", 140000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 310, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 36, "Lịch con của booking tháng", 140000m, "vnpay_100", 5, "completed", 140000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 335, new DateTime(2025, 12, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 23, "accepted", 140000m, new DateTime(2025, 12, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 336, new DateTime(2025, 12, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 5, "cancelled", 140000m, new DateTime(2025, 12, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 337, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 5, "completed", 140000m, new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 338, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 140000m, "vnpay_100", 23, "completed", 140000m, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 339, new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 340, new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 190000m, "vnpay_100", 27, "cancelled", 190000m, new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 341, new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 23, "completed", 140000m, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 342, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 343, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 3, "cancelled", 200000m, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 344, new DateTime(2026, 1, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 300000m, "vnpay_100", 4, "accepted", 300000m, new DateTime(2026, 1, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 345, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 346, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 190000m, "vnpay_100", 27, "completed", 190000m, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 347, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 140000m, "vnpay_100", 5, "completed", 140000m, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 348, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 349, new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 140000m, "vnpay_100", 23, "completed", 140000m, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 350, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 5, "cancelled", 140000m, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 351, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 22, "completed", 200000m, new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 352, new DateTime(2025, 12, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 1, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 140000m, "vnpay_100", 5, "accepted", 140000m, new DateTime(2025, 12, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 353, new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 354, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 355, new DateTime(2026, 1, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 1, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 22, "accepted", 200000m, new DateTime(2026, 1, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 356, new DateTime(2026, 1, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 1, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 3, "accepted", 200000m, new DateTime(2026, 1, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 357, new DateTime(2025, 12, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 12, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 140000m, "vnpay_100", 23, "accepted", 140000m, new DateTime(2025, 12, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 358, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 190000m, "vnpay_100", 27, "completed", 190000m, new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 359, new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 22, "completed", 200000m, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 360, new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 190000m, "vnpay_100", 27, "completed", 190000m, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 361, new DateTime(2025, 8, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 22, "completed", 200000m, new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 362, new DateTime(2026, 1, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 1, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 22, "accepted", 200000m, new DateTime(2026, 1, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 363, new DateTime(2025, 12, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 23, "cancelled", 140000m, new DateTime(2025, 12, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 364, new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 12, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 22, "accepted", 200000m, new DateTime(2025, 12, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 365, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 23, "completed", 140000m, new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 366, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 190000m, "vnpay_100", 27, "completed", 190000m, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 367, new DateTime(2026, 1, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 5, "accepted", 140000m, new DateTime(2026, 1, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 368, new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 22, "cancelled", 200000m, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 369, new DateTime(2026, 1, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 3, "accepted", 200000m, new DateTime(2026, 1, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 370, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 140000m, "vnpay_100", 5, "completed", 140000m, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 371, new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 22, "completed", 200000m, new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 372, new DateTime(2025, 12, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 5, "accepted", 140000m, new DateTime(2025, 12, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 373, new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 22, "completed", 200000m, new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 374, new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 375, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 376, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 16, "completed", 200000m, new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 377, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 300000m, "vnpay_100", 4, "completed", 300000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 378, new DateTime(2025, 12, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 23, "accepted", 140000m, new DateTime(2025, 12, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 379, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 300000m, "vnpay_100", 4, "cancelled", 300000m, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 380, new DateTime(2025, 12, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 12, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 3, "accepted", 200000m, new DateTime(2025, 12, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 381, new DateTime(2026, 1, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 3, "cancelled", 200000m, new DateTime(2026, 1, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 382, new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 23, "completed", 140000m, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 383, new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 300000m, "vnpay_100", 4, "cancelled", 300000m, new DateTime(2025, 12, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 384, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 22, "completed", 200000m, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 385, new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 5, "accepted", 140000m, new DateTime(2025, 12, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 386, new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 190000m, "vnpay_100", 27, "cancelled", 190000m, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 387, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 388, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 140000m, "vnpay_100", 23, "completed", 140000m, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 389, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 12, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 16, "cancelled", 200000m, new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 390, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 16, "cancelled", 200000m, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 391, new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 22, "completed", 200000m, new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 392, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 23, "completed", 140000m, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 393, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 23, "accepted", 140000m, new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 394, new DateTime(2025, 8, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 395, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 300000m, "vnpay_100", 4, "accepted", 300000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 396, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 23, "accepted", 140000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 397, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 22, "waiting", 200000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 398, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 3, "accepted", 200000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 399, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 3, "accepted", 200000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 400, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 3, "waiting", 200000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 401, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 300000m, "vnpay_100", 4, "accepted", 300000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 402, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 23, "accepted", 140000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 403, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 16, "waiting", 200000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 404, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 190000m, "vnpay_100", 27, "accepted", 190000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 405, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 200000m, "vnpay_100", 3, "waiting", 200000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 406, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 300000m, "vnpay_100", 4, "accepted", 300000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 407, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 190000m, "vnpay_100", 27, "accepted", 190000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 408, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 140000m, "vnpay_100", 23, "accepted", 140000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 409, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 3, "accepted", 200000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 410, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 22, "accepted", 200000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 411, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 140000m, "vnpay_100", 23, "accepted", 140000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 412, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 190000m, "vnpay_100", 27, "accepted", 190000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 413, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Khách đặt online", 300000m, "vnpay_100", 4, "accepted", 300000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 414, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Chủ sân tạo hộ", 200000m, "vnpay_100", 3, "accepted", 200000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 415, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, null, 190000m, "vnpay_100", 27, "accepted", 190000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 416, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 12, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "Đặt qua điện thoại", 190000m, "vnpay_100", 27, "waiting", 190000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 417, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, null, 300000m, "vnpay_100", 4, "waiting", 300000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), 2400000m, new TimeSpan(0, 8, 0, 0, 0), "completed", 2400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 19, 0, 0, 0), 600000m, 13, new TimeSpan(0, 17, 0, 0, 0), 600000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0), 600000m, 13, new TimeSpan(0, 11, 0, 0, 0), 600000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0), 2000000m, 18, new TimeSpan(0, 11, 0, 0, 0), 2000000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 20, 0, 0, 0), 2000000m, 18, new TimeSpan(0, 18, 0, 0, 0), 2000000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 0, 0, 0), 400000m, 17, new TimeSpan(0, 9, 0, 0, 0), 400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 0, 0, 0), 960000m, 26, new TimeSpan(0, 7, 0, 0, 0), 960000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 19, 0, 0, 0), 600000m, 13, new TimeSpan(0, 17, 0, 0, 0), 600000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0), 2240000m, 14, new TimeSpan(0, 11, 0, 0, 0), "completed", 2240000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EndTime", "StartTime", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0), "cancelled", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EndTime", "StartTime", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 4000000m, 6, 4000000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EndTime", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "Year" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0), "Lịch đặt tháng 1/2026", 1440000m, 14, new TimeSpan(0, 11, 0, 0, 0), "accepted", 1440000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 2026 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "Year" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), "Lịch đặt tháng 2/2026", 600000m, 13, "accepted", 600000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 2026 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 21, 0, 0, 0), 1, "Lịch đặt tháng 1/2025", 480000m, 9, new TimeSpan(0, 19, 0, 0, 0), 480000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 20, 0, 0, 0), 2, "Lịch đặt tháng 2/2025", 480000m, 9, new TimeSpan(0, 18, 0, 0, 0), "cancelled", 480000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), 3, "Lịch đặt tháng 3/2025", 960000m, 8, new TimeSpan(0, 10, 0, 0, 0), 960000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "StartTime", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), 4, "Lịch đặt tháng 4/2025", new TimeSpan(0, 8, 0, 0, 0), new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 0, 0, 0), 5, "Lịch đặt tháng 5/2025", 400000m, 2, new TimeSpan(0, 14, 0, 0, 0), "completed", 400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), 6, "Lịch đặt tháng 6/2025", 720000m, 19, new TimeSpan(0, 10, 0, 0, 0), 720000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 19, 0, 0, 0), 7, "Lịch đặt tháng 7/2025", 1600000m, 1, new TimeSpan(0, 17, 0, 0, 0), "completed", 1600000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 22, 0, 0, 0), 8, "Lịch đặt tháng 8/2025", 1600000m, 1, new TimeSpan(0, 20, 0, 0, 0), "completed", 1600000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Month", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 9, "Lịch đặt tháng 9/2025", 1600000m, 1, "completed", 1600000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Month", "Note", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 10, "Lịch đặt tháng 10/2025", "completed", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "Month", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 11, "Lịch đặt tháng 11/2025", 960000m, 8, "accepted", 960000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), 12, "Lịch đặt tháng 12/2025", 640000m, 20, new TimeSpan(0, 8, 0, 0, 0), "accepted", 640000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "Year" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 0, 0, 0), 1, "Lịch đặt tháng 1/2026", 2400000m, 1, new TimeSpan(0, 14, 0, 0, 0), "cancelled", 2400000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 2026 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId", "Year" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 0, 0, 0), 2, "Lịch đặt tháng 2/2026", 1200000m, 24, new TimeSpan(0, 16, 0, 0, 0), "accepted", 1200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 2026 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 23, 0, 0, 0), 1, "Lịch đặt tháng 1/2025", 800000m, 3, new TimeSpan(0, 21, 0, 0, 0), "completed", 800000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), 2, "Lịch đặt tháng 2/2025", 760000m, 27, new TimeSpan(0, 10, 0, 0, 0), "completed", 760000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 19, 0, 0, 0), 3, "Lịch đặt tháng 3/2025", 1200000m, 4, new TimeSpan(0, 17, 0, 0, 0), 1200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 14, 0, 0, 0), 4, "Lịch đặt tháng 4/2025", 760000m, 27, new TimeSpan(0, 12, 0, 0, 0), 760000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 22, 0, 0, 0), 5, "Lịch đặt tháng 5/2025", 1200000m, 4, new TimeSpan(0, 20, 0, 0, 0), 1200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 14, 0, 0, 0), 6, "Lịch đặt tháng 6/2025", 800000m, 16, new TimeSpan(0, 12, 0, 0, 0), 800000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "StartTime", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 15, 0, 0, 0), 7, "Lịch đặt tháng 7/2025", new TimeSpan(0, 13, 0, 0, 0), "completed", new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), 8, "Lịch đặt tháng 8/2025", 560000m, 5, new TimeSpan(0, 15, 0, 0, 0), "completed", 560000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.InsertData(
                table: "MonthlyBookings",
                columns: new[] { "Id", "CreatedAt", "DiscountId", "EndTime", "Month", "Note", "OriginalPrice", "PaymentMethod", "StadiumId", "StartTime", "Status", "TotalHour", "TotalPrice", "UpdatedAt", "UserId", "Year" },
                values: new object[,]
                {
                    { 37, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), null, new TimeSpan(0, 14, 0, 0, 0), 9, "Lịch đặt tháng 9/2025", 560000m, "vnpay_100", 23, new TimeSpan(0, 12, 0, 0, 0), "completed", 8, 560000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, 2025 },
                    { 38, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), null, new TimeSpan(0, 15, 0, 0, 0), 10, "Lịch đặt tháng 10/2025", 800000m, "vnpay_100", 3, new TimeSpan(0, 13, 0, 0, 0), "completed", 8, 800000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, 2025 },
                    { 39, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), null, new TimeSpan(0, 16, 0, 0, 0), 11, "Lịch đặt tháng 11/2025", 760000m, "vnpay_100", 27, new TimeSpan(0, 14, 0, 0, 0), "accepted", 8, 760000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, 2025 },
                    { 40, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), null, new TimeSpan(0, 11, 0, 0, 0), 12, "Lịch đặt tháng 12/2025", 800000m, "vnpay_100", 3, new TimeSpan(0, 9, 0, 0, 0), "cancelled", 8, 800000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, 2025 },
                    { 41, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), null, new TimeSpan(0, 16, 0, 0, 0), 1, "Lịch đặt tháng 1/2026", 800000m, "vnpay_100", 3, new TimeSpan(0, 14, 0, 0, 0), "cancelled", 8, 800000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, 2026 },
                    { 42, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), null, new TimeSpan(0, 23, 0, 0, 0), 2, "Lịch đặt tháng 2/2026", 800000m, "vnpay_100", 3, new TimeSpan(0, 21, 0, 0, 0), "cancelled", 8, 800000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 2026 }
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 322, 301, 23, new DateTime(2025, 6, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 323, 302, 23, new DateTime(2025, 6, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 324, 303, 6, new DateTime(2025, 7, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 325, 304, 6, new DateTime(2025, 7, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 326, 305, 6, new DateTime(2025, 7, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 327, 306, 6, new DateTime(2025, 7, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 328, 307, 9, new DateTime(2025, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 329, 308, 9, new DateTime(2025, 8, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 330, 309, 9, new DateTime(2025, 8, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 331, 310, 9, new DateTime(2025, 8, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 356, 335, 32, new DateTime(2025, 12, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 18, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 357, 336, 10, new DateTime(2025, 12, 12, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 12, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 358, 337, 10, new DateTime(2025, 10, 9, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 9, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 359, 338, 31, new DateTime(2025, 9, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 360, 339, 7, new DateTime(2025, 10, 5, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 361, 340, 42, new DateTime(2025, 11, 4, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 4, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 362, 341, 32, new DateTime(2025, 11, 9, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 9, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 363, 342, 6, new DateTime(2025, 9, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 364, 343, 6, new DateTime(2025, 10, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 365, 344, 8, new DateTime(2026, 1, 14, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 14, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 366, 345, 7, new DateTime(2025, 11, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 367, 346, 42, new DateTime(2025, 10, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 368, 347, 10, new DateTime(2025, 9, 23, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 369, 348, 7, new DateTime(2025, 9, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 370, 349, 32, new DateTime(2025, 9, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 371, 350, 9, new DateTime(2025, 9, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 372, 351, 30, new DateTime(2025, 9, 14, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 14, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 373, 352, 9, new DateTime(2026, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 374, 353, 7, new DateTime(2025, 9, 24, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 24, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 375, 354, 6, new DateTime(2025, 10, 10, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 376, 355, 30, new DateTime(2026, 1, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 21, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 377, 356, 7, new DateTime(2026, 1, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 10, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 378, 357, 31, new DateTime(2025, 12, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 29, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 379, 358, 42, new DateTime(2025, 9, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 380, 359, 30, new DateTime(2025, 11, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 12, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 381, 360, 42, new DateTime(2025, 11, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 14, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 382, 361, 30, new DateTime(2025, 9, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 3, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 383, 362, 30, new DateTime(2026, 1, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 384, 363, 32, new DateTime(2025, 12, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 12, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 385, 364, 30, new DateTime(2025, 12, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 7, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 386, 365, 31, new DateTime(2025, 11, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 387, 366, 41, new DateTime(2025, 11, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 388, 367, 10, new DateTime(2026, 1, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 7, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 389, 368, 30, new DateTime(2025, 10, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 7, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 390, 369, 7, new DateTime(2026, 1, 15, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 15, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 391, 370, 9, new DateTime(2025, 9, 16, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 16, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 392, 371, 30, new DateTime(2025, 10, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 19, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 393, 372, 9, new DateTime(2025, 12, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 20, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 394, 373, 30, new DateTime(2025, 10, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 23, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 395, 374, 7, new DateTime(2025, 10, 16, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 16, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 396, 375, 7, new DateTime(2025, 10, 28, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 397, 376, 23, new DateTime(2025, 10, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 3, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 398, 377, 8, new DateTime(2025, 11, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 399, 378, 32, new DateTime(2025, 12, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 400, 379, 8, new DateTime(2025, 10, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 6, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 401, 380, 6, new DateTime(2025, 12, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 23, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 402, 381, 6, new DateTime(2026, 1, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 403, 382, 31, new DateTime(2025, 10, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 404, 383, 8, new DateTime(2025, 12, 9, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 9, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 405, 384, 30, new DateTime(2025, 9, 12, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 406, 385, 9, new DateTime(2025, 12, 6, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 6, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 407, 386, 42, new DateTime(2025, 11, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 3, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 408, 387, 6, new DateTime(2025, 9, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 409, 388, 32, new DateTime(2025, 9, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 410, 389, 23, new DateTime(2025, 12, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 411, 390, 23, new DateTime(2025, 10, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 412, 391, 30, new DateTime(2025, 11, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 4, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 413, 392, 31, new DateTime(2025, 11, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 13, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 414, 393, 32, new DateTime(2025, 12, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 3, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 415, 394, 7, new DateTime(2025, 9, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 416, 395, 8, new DateTime(2026, 1, 29, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 417, 396, 32, new DateTime(2026, 2, 3, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 3, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 418, 397, 30, new DateTime(2026, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 2, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 419, 398, 7, new DateTime(2026, 2, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 25, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 420, 399, 6, new DateTime(2026, 2, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 26, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 421, 400, 6, new DateTime(2026, 2, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 23, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 422, 401, 8, new DateTime(2026, 1, 26, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 26, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 423, 402, 32, new DateTime(2026, 2, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 4, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 424, 403, 23, new DateTime(2026, 1, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 28, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 425, 404, 41, new DateTime(2026, 1, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 10, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 426, 405, 7, new DateTime(2026, 1, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 23, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 427, 406, 8, new DateTime(2026, 1, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 19, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 428, 407, 41, new DateTime(2026, 2, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 429, 408, 31, new DateTime(2026, 2, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 430, 409, 6, new DateTime(2026, 2, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 24, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 431, 410, 30, new DateTime(2026, 1, 31, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 31, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 432, 411, 31, new DateTime(2026, 1, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 25, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 433, 412, 41, new DateTime(2026, 2, 3, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 3, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 434, 413, 8, new DateTime(2026, 1, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 27, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 435, 414, 7, new DateTime(2026, 2, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 21, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 436, 415, 42, new DateTime(2025, 12, 25, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 25, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 437, 416, 42, new DateTime(2025, 12, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 28, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 438, 417, 8, new DateTime(2025, 12, 24, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 24, 17, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Date", "DiscountId", "MonthlyBookingId", "Note", "OriginalPrice", "PaymentMethod", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 311, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 37, "Lịch con của booking tháng", 140000m, "vnpay_100", 23, "completed", 140000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 312, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 37, "Lịch con của booking tháng", 140000m, "vnpay_100", 23, "completed", 140000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 313, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 37, "Lịch con của booking tháng", 140000m, "vnpay_100", 23, "completed", 140000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 314, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 37, "Lịch con của booking tháng", 140000m, "vnpay_100", 23, "completed", 140000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 315, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 38, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 316, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 38, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 317, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 38, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 318, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 38, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "completed", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 },
                    { 319, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 39, "Lịch con của booking tháng", 190000m, "vnpay_100", 27, "completed", 190000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 320, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 39, "Lịch con của booking tháng", 190000m, "vnpay_100", 27, "completed", 190000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 321, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 39, "Lịch con của booking tháng", 190000m, "vnpay_100", 27, "completed", 190000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 322, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 39, "Lịch con của booking tháng", 190000m, "vnpay_100", 27, "completed", 190000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 323, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 40, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "cancelled", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 324, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 40, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "cancelled", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 325, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 40, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "cancelled", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 326, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 40, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "cancelled", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 },
                    { 327, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 41, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "cancelled", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 328, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 41, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "cancelled", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 329, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 41, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "cancelled", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 330, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 41, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "cancelled", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 },
                    { 331, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 42, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "cancelled", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 332, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 42, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "cancelled", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 333, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 42, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "cancelled", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 },
                    { 334, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 0, new DateTime(2026, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 42, "Lịch con của booking tháng", 200000m, "vnpay_100", 3, "cancelled", 200000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 }
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 332, 311, 32, new DateTime(2025, 9, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 333, 312, 32, new DateTime(2025, 9, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 334, 313, 32, new DateTime(2025, 9, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 335, 314, 32, new DateTime(2025, 9, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 336, 315, 6, new DateTime(2025, 10, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 337, 316, 6, new DateTime(2025, 10, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 338, 317, 6, new DateTime(2025, 10, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 339, 318, 6, new DateTime(2025, 10, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 340, 319, 42, new DateTime(2025, 11, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 341, 320, 42, new DateTime(2025, 11, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 342, 321, 42, new DateTime(2025, 11, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 343, 322, 42, new DateTime(2025, 11, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 344, 323, 6, new DateTime(2025, 12, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 345, 324, 6, new DateTime(2025, 12, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 346, 325, 6, new DateTime(2025, 12, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 347, 326, 6, new DateTime(2025, 12, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 348, 327, 7, new DateTime(2026, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 349, 328, 7, new DateTime(2026, 1, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 350, 329, 7, new DateTime(2026, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 351, 330, 7, new DateTime(2026, 1, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 352, 331, 7, new DateTime(2026, 2, 1, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 1, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 353, 332, 7, new DateTime(2026, 2, 8, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 8, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 354, 333, 7, new DateTime(2026, 2, 15, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 15, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 355, 334, 7, new DateTime(2026, 2, 22, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 22, 21, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 435);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 437);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 42);

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 1, 36, new DateTime(2025, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 2, new DateTime(2025, 1, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 2, 36, new DateTime(2025, 1, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 3, 35, new DateTime(2025, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 3, 36, new DateTime(2025, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 4, 35, new DateTime(2025, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 4, 36, new DateTime(2025, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 5, 38, new DateTime(2025, 2, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 24, 36, new DateTime(2025, 6, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 25, 27, new DateTime(2025, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 26, 27, new DateTime(2025, 7, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 27, 27, new DateTime(2025, 7, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 28, 27, new DateTime(2025, 7, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 29, 25, new DateTime(2025, 8, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 30, 25, new DateTime(2025, 8, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 31, 25, new DateTime(2025, 8, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 32, 25, new DateTime(2025, 8, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 33, 26, new DateTime(2025, 9, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 34, 26, new DateTime(2025, 9, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 35, 26, new DateTime(2025, 9, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 36, 26, new DateTime(2025, 9, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 37, 40, new DateTime(2025, 10, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 38, 40, new DateTime(2025, 10, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 39, 40, new DateTime(2025, 10, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 40, 40, new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 41, 36, new DateTime(2025, 11, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 42, 36, new DateTime(2025, 11, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 43, 36, new DateTime(2025, 11, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 44, 36, new DateTime(2025, 11, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 45, 25, new DateTime(2025, 12, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 46, 25, new DateTime(2025, 12, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 47, 25, new DateTime(2025, 12, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 48, 25, new DateTime(2025, 12, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 49, 24, new DateTime(2025, 10, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 50, 36, new DateTime(2025, 10, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 51, 40, new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 52, 40, new DateTime(2025, 11, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 30, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 53, 27, new DateTime(2025, 10, 17, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 54, 35, new DateTime(2025, 10, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 25, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 55, 20, new DateTime(2025, 11, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 56, 18, new DateTime(2025, 10, 16, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 16, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 57, 20, new DateTime(2025, 11, 6, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 6, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 58, 20, new DateTime(2025, 9, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 58, new DateTime(2025, 9, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 60, 20, new DateTime(2025, 9, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 61, 38, new DateTime(2025, 11, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 62, 38, new DateTime(2025, 11, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 20, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 63, 17, new DateTime(2025, 9, 16, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 16, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 64, 21, new DateTime(2025, 11, 11, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 65, 36, new DateTime(2025, 9, 27, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 27, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 66, 36, new DateTime(2025, 9, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 67, 17, new DateTime(2025, 11, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 68, 35, new DateTime(2025, 10, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 28, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 69, 11, new DateTime(2025, 11, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 70, 25, new DateTime(2025, 11, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 14, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 71, 26, new DateTime(2025, 11, 12, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 12, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 72, 20, new DateTime(2025, 11, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 76, new DateTime(2025, 10, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 26, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 77, 20, new DateTime(2025, 10, 4, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 21, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 80, new DateTime(2025, 11, 26, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 26, 18, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 89, 36, new DateTime(2025, 11, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 7, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 90, 27, new DateTime(2025, 10, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 23, 7, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 98, new DateTime(2025, 9, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 105, 2, new DateTime(2025, 2, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 107, 2, new DateTime(2025, 2, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 15, new DateTime(2025, 6, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 15, new DateTime(2025, 6, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 15, new DateTime(2025, 6, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 22, new DateTime(2025, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 22, new DateTime(2025, 7, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 22, new DateTime(2025, 7, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 22, new DateTime(2025, 7, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 12, new DateTime(2025, 8, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 12, new DateTime(2025, 8, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 12, new DateTime(2025, 8, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 12, new DateTime(2025, 8, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 29, new DateTime(2025, 9, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 29, new DateTime(2025, 9, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 3, new DateTime(2025, 9, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 2, new DateTime(2025, 10, 6, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 6, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 22, new DateTime(2025, 9, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 16, new DateTime(2025, 11, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 13, new DateTime(2025, 10, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 14, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 29, new DateTime(2025, 11, 27, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 16, new DateTime(2025, 9, 16, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 16, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 15, new DateTime(2025, 11, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 2, new DateTime(2025, 10, 21, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 158, 3, new DateTime(2025, 10, 21, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 14, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 162, new DateTime(2025, 10, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 13, 15, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 164, new DateTime(2025, 11, 18, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 20, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 166, new DateTime(2025, 9, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 21, 19, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 170, 5, new DateTime(2025, 9, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 7, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 172, new DateTime(2025, 10, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 30, 13, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 175, new DateTime(2025, 10, 21, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 178, 4, new DateTime(2025, 10, 4, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 12, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 190, 28, new DateTime(2025, 10, 24, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 24, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 2, new DateTime(2025, 10, 27, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 27, 12, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 197, 3, new DateTime(2025, 11, 26, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 26, 20, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 10, new DateTime(2025, 4, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 31, new DateTime(2025, 5, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 31, new DateTime(2025, 5, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 8, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 31, new DateTime(2025, 5, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 31, new DateTime(2025, 5, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 6, new DateTime(2025, 6, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 6, new DateTime(2025, 6, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 6, new DateTime(2025, 6, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 6, new DateTime(2025, 6, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 42, new DateTime(2025, 7, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 42, new DateTime(2025, 7, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "CourtId", "EndTime", "StartTime" },
                values: new object[] { 42, new DateTime(2025, 7, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 228, 42, new DateTime(2025, 7, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 256, 8, new DateTime(2025, 11, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 11, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 267, 6, new DateTime(2025, 10, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 281, 10, new DateTime(2025, 10, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 282, 31, new DateTime(2025, 9, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 288, 42, new DateTime(2025, 9, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 29, 10, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "BookingId", "CourtId", "EndTime", "StartTime" },
                values: new object[] { 290, 32, new DateTime(2025, 11, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 2, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "BookingId", "EndTime", "StartTime" },
                values: new object[] { 291, new DateTime(2025, 9, 10, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 900000m, "cancelled", 900000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 900000m, "cancelled", 900000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 900000m, "cancelled", 900000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 900000m, "cancelled", 900000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 240000m, 26, 240000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 240000m, 26, 240000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 240000m, 26, 240000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 240000m, 26, 240000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, 100000m, 17, 100000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, 100000m, 17, 100000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, 100000m, 17, 100000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, 100000m, 17, 100000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 1000000m, 6, 1000000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 1000000m, 6, 1000000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 1000000m, 6, 1000000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 1000000m, 6, 1000000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, 240000m, 26, 240000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, 240000m, 26, 240000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, 240000m, 26, 240000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, 240000m, 26, 240000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, 900000m, 25, 900000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, 900000m, 25, 900000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, 900000m, 25, 900000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, 900000m, 25, 900000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 300000m, 18, 300000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 300000m, 18, 300000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 300000m, 18, 300000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 300000m, 18, 300000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 140000m, 17, 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 140000m, 17, 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 140000m, 17, 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 140000m, 17, 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, 500000m, 18, "cancelled", 500000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, 500000m, 18, "cancelled", 500000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, 500000m, 18, "cancelled", 500000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, 500000m, 18, "cancelled", 500000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "CreatedById", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, "completed", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "CreatedById", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, "completed", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "CreatedById", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, "completed", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "CreatedById", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, "completed", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "CreatedById", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, "accepted", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "CreatedById", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, "accepted", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "CreatedById", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, "accepted", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 140000m, 17, 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 140000m, 17, 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 140000m, 17, 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "CreatedById", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, 140000m, 17, 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 100000m, 17, "cancelled", 100000m, new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 600000m, 25, "cancelled", 600000m, new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 240000m, 26, "completed", 240000m, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UserId" },
                values: new object[] { new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 240000m, 26, "cancelled", 240000m, 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 300000m, 18, "completed", 300000m, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 600000m, 25, "completed", 600000m, new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 360000m, 14, 360000m, new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "completed", new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 360000m, 14, "cancelled", 360000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 560000m, 14, "completed", 560000m, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 240000m, 26, 240000m, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 360000m, 14, 360000m, new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 240000m, 26, 240000m, new DateTime(2025, 11, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 160000m, 11, "completed", 160000m, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 360000m, 14, "accepted", 360000m, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 600000m, 25, 600000m, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 600000m, 25, "cancelled", 600000m, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 160000m, 11, "completed", 160000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 600000m, 25, 600000m, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 1000000m, 6, "accepted", 1000000m, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 140000m, 17, "accepted", 140000m, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 500000m, 18, 500000m, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 360000m, 14, "accepted", 360000m, new DateTime(2025, 11, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 240000m, 26, "accepted", 240000m, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 600000m, 25, "accepted", 600000m, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 360000m, 14, "completed", 360000m, new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 1000000m, 6, "completed", 1000000m, new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 360000m, 14, "completed", 360000m, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 1000000m, 6, 1000000m, new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 1000000m, 6, 1000000m, new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 900000m, 25, "accepted", 900000m, new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 600000m, 25, "completed", 600000m, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 150000m, 13, "completed", 150000m, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 600000m, 25, "completed", 600000m, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 600000m, 25, 600000m, new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 560000m, 14, 560000m, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 240000m, 26, 240000m, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 150000m, 13, 150000m, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 900000m, 25, 900000m, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 300000m, 18, 300000m, new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "accepted", new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 300000m, 18, "completed", 300000m, new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 140000m, 17, "accepted", 140000m, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), null, "accepted", new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 360000m, 14, 360000m, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 240000m, 26, "completed", 240000m, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 1000000m, 6, "cancelled", 1000000m, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 100000m, 17, "accepted", 100000m, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 300000m, 18, 300000m, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Lịch con của booking tháng", 100000m, 2, "completed", 100000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Lịch con của booking tháng", 100000m, 2, "completed", 100000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Lịch con của booking tháng", 100000m, 2, 100000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Lịch con của booking tháng", 100000m, 2, "completed", 100000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Lịch con của booking tháng", 400000m, 1, "cancelled", 400000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Lịch con của booking tháng", 400000m, 1, 400000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Lịch con của booking tháng", 400000m, 1, "cancelled", 400000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Lịch con của booking tháng", 400000m, 1, "cancelled", 400000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Lịch con của booking tháng", 100000m, 2, 100000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Lịch con của booking tháng", 100000m, 2, "completed", 100000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "StadiumId", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Lịch con của booking tháng", 2, "completed", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Lịch con của booking tháng", 100000m, 2, 100000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Lịch con của booking tháng", 100000m, 2, "completed", 100000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Lịch con của booking tháng", 2, "completed", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Lịch con của booking tháng", 100000m, 2, "completed", 100000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Lịch con của booking tháng", 100000m, 2, "completed", 100000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Lịch con của booking tháng", 220000m, 15, "completed", 220000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Lịch con của booking tháng", 220000m, 15, "completed", 220000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Lịch con của booking tháng", 220000m, 15, "completed", 220000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Lịch con của booking tháng", 220000m, 15, "completed", 220000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "Lịch con của booking tháng", 120000m, 9, "completed", 120000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "Lịch con của booking tháng", 120000m, 9, "completed", 120000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "Lịch con của booking tháng", 120000m, 9, "completed", 120000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "Lịch con của booking tháng", 120000m, 9, "completed", 120000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, "Lịch con của booking tháng", 220000m, 15, "cancelled", 220000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, "Lịch con của booking tháng", 220000m, 15, "cancelled", 220000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, "Lịch con của booking tháng", 220000m, 15, "cancelled", 220000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, "Lịch con của booking tháng", 220000m, 15, "cancelled", 220000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Lịch con của booking tháng", 240000m, 8, "cancelled", 240000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Lịch con của booking tháng", 8, "cancelled", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Lịch con của booking tháng", 8, "cancelled", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Lịch con của booking tháng", 8, "cancelled", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Lịch con của booking tháng", 160000m, 20, "cancelled", 160000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Lịch con của booking tháng", 160000m, 20, "cancelled", 160000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Lịch con của booking tháng", 160000m, 20, "cancelled", 160000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Lịch con của booking tháng", 160000m, 20, "cancelled", 160000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, "Lịch con của booking tháng", 120000m, 9, "cancelled", 120000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, "Lịch con của booking tháng", 120000m, 9, "cancelled", 120000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, "Lịch con của booking tháng", 120000m, 9, "cancelled", 120000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, "cancelled", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 300000m, 24, 300000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 300000m, 24, "accepted", 300000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 300000m, 24, "accepted", 300000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 300000m, 24, "accepted", 300000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 400000m, 1, "accepted", 400000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 400000m, 1, "accepted", 400000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 400000m, 1, "accepted", 400000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 400000m, 1, "accepted", 400000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 100000m, 2, "cancelled", 100000m, new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 600000m, 1, "cancelled", 600000m, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 400000m, 1, 400000m, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 220000m, 15, 220000m, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 300000m, 10, "accepted", 300000m, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 240000m, 8, "cancelled", 240000m, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 160000m, 20, "accepted", 160000m, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 300000m, 10, 300000m, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 120000m, 9, "accepted", 120000m, new DateTime(2025, 11, 7, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 600000m, 1, "cancelled", 600000m, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 160000m, 20, "accepted", 160000m, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 120000m, 9, "completed", 120000m, new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 300000m, 24, "completed", 300000m, new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "completed", new DateTime(2025, 10, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 12, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 220000m, 15, "accepted", 220000m, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 600000m, "accepted", 600000m, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 300000m, 10, "accepted", 300000m, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 120000m, 9, 120000m, new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 120000m, 9, 120000m, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 100000m, 2, 100000m, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 240000m, 8, 240000m, new DateTime(2025, 10, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 600000m, 600000m, new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 240000m, 8, "accepted", 240000m, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 120000m, 9, "cancelled", 120000m, new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 300000m, 24, "accepted", 300000m, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 100000m, 2, 100000m, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 300000m, 24, "accepted", 300000m, new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 600000m, 1, 600000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 100000m, 2, "accepted", 100000m, new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 100000m, 2, "cancelled", 100000m, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 120000m, 9, "accepted", 120000m, new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 400000m, 1, "completed", 400000m, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 120000m, 9, 120000m, new DateTime(2025, 11, 24, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 240000m, 8, "completed", 240000m, new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 100000m, 2, "cancelled", 100000m, new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 160000m, 20, "completed", 160000m, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 300000m, 10, "completed", 300000m, new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 180000m, 19, "completed", 180000m, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "completed", new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 220000m, 15, "completed", 220000m, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 100000m, 2, "cancelled", 100000m, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 160000m, 20, "completed", 160000m, new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 240000m, 8, 240000m, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 400000m, 1, "accepted", 400000m, new DateTime(2025, 12, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 600000m, 1, 600000m, new DateTime(2025, 11, 25, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 220000m, 15, 220000m, new DateTime(2025, 10, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 600000m, 1, 600000m, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 300000m, 24, 300000m, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Lịch con của booking tháng", 200000m, 16, "completed", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Lịch con của booking tháng", 200000m, 16, "completed", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Lịch con của booking tháng", 200000m, 16, "completed", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Lịch con của booking tháng", 200000m, 16, 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, "Lịch con của booking tháng", 200000m, 16, "completed", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, "Lịch con của booking tháng", 200000m, 16, "completed", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, "Lịch con của booking tháng", 200000m, 16, "completed", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, "Lịch con của booking tháng", 200000m, 16, "completed", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, "Lịch con của booking tháng", 140000m, 5, 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, "Lịch con của booking tháng", 140000m, 5, "completed", 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, "Lịch con của booking tháng", 140000m, 5, "completed", 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, "Lịch con của booking tháng", 140000m, 5, 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, "Lịch con của booking tháng", 140000m, 5, 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, "Lịch con của booking tháng", 140000m, 5, 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, "Lịch con của booking tháng", 140000m, 5, "completed", 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, "Lịch con của booking tháng", 140000m, 5, "completed", 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, "Lịch con của booking tháng", 140000m, 23, "cancelled", 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, "Lịch con của booking tháng", 140000m, 23, "cancelled", 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, "Lịch con của booking tháng", 140000m, 23, "cancelled", 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, "Lịch con của booking tháng", 140000m, 23, "cancelled", 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Lịch con của booking tháng", 200000m, 3, "cancelled", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Lịch con của booking tháng", 200000m, 3, "cancelled", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Lịch con của booking tháng", 200000m, 3, 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Lịch con của booking tháng", 200000m, 3, "cancelled", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, "Lịch con của booking tháng", 190000m, 27, 190000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, "Lịch con của booking tháng", 190000m, 27, 190000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, "Lịch con của booking tháng", 190000m, 27, 190000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, "Lịch con của booking tháng", 190000m, 27, 190000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, "Lịch con của booking tháng", 300000m, 4, 300000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, "Lịch con của booking tháng", 300000m, 4, "completed", 300000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, "Lịch con của booking tháng", 300000m, 4, 300000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, "Lịch con của booking tháng", 300000m, 4, 300000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, "Lịch con của booking tháng", 190000m, 27, "completed", 190000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, "Lịch con của booking tháng", 190000m, 27, 190000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, "Lịch con của booking tháng", 190000m, 27, "completed", 190000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, "Lịch con của booking tháng", 190000m, 27, 190000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, "Lịch con của booking tháng", 140000m, 23, 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, "Lịch con của booking tháng", 140000m, 23, "completed", 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, "Lịch con của booking tháng", 140000m, 23, 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, "Lịch con của booking tháng", 140000m, 23, "completed", 140000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, "Lịch con của booking tháng", 200000m, 3, "completed", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, "Lịch con của booking tháng", 200000m, 3, "accepted", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, "Lịch con của booking tháng", 200000m, 3, 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, "Lịch con của booking tháng", 200000m, 3, "accepted", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, "Lịch con của booking tháng", 200000m, 3, "accepted", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, "Lịch con của booking tháng", 200000m, 3, "accepted", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, "Lịch con của booking tháng", 200000m, 3, "accepted", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, "Lịch con của booking tháng", 200000m, 3, "accepted", 200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 200000m, 22, "completed", 200000m, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 200000m, 3, "cancelled", 200000m, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 140000m, 23, "completed", 140000m, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 200000m, 22, "cancelled", 200000m, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 200000m, 22, "cancelled", 200000m, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 200000m, 22, "completed", 200000m, new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 190000m, 27, "completed", 190000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 300000m, 4, "completed", 300000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 300000m, 4, "completed", 300000m, new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 200000m, 16, "completed", 200000m, new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 190000m, 27, "completed", 190000m, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 200000m, 16, "completed", 200000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 31, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 190000m, 27, "completed", 190000m, new DateTime(2025, 10, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 200000m, 16, "cancelled", 200000m, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 190000m, 27, "completed", 190000m, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 140000m, 5, 140000m, new DateTime(2025, 11, 21, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 200000m, 16, "accepted", 200000m, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 23, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 200000m, 16, "completed", 200000m, new DateTime(2025, 10, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 200000m, 3, "completed", 200000m, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 190000m, 27, "completed", 190000m, new DateTime(2025, 10, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "StadiumId", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 4, "completed", new DateTime(2025, 10, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 140000m, 5, "completed", 140000m, new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 200000m, 3, "completed", 200000m, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 140000m, 23, "completed", 140000m, new DateTime(2025, 9, 17, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 140000m, 23, "completed", 140000m, new DateTime(2025, 10, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 140000m, 5, "cancelled", 140000m, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 200000m, 3, "completed", 200000m, new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 22, "completed", 200000m, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "CreatedById", "Date", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { 5, new DateTime(2025, 12, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), null, 140000m, 23, 140000m, new DateTime(2025, 12, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 18, 10, 41, 13, 0, DateTimeKind.Unspecified), 200000m, 3, "cancelled", 200000m, new DateTime(2025, 11, 17, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 140000m, 23, "accepted", 140000m, new DateTime(2025, 11, 13, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 21, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 190000m, 27, 190000m, new DateTime(2025, 9, 25, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 16, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 140000m, 5, "cancelled", 140000m, new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 140000m, 23, 140000m, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 140000m, 5, "accepted", 140000m, new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 3, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 9, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 200000m, 3, 200000m, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 4, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, "cancelled", new DateTime(2025, 11, 8, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 20, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 200000m, 22, 200000m, new DateTime(2025, 10, 19, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 140000m, 23, 140000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 9, 29, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 190000m, 27, "cancelled", 190000m, new DateTime(2025, 9, 28, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 190000m, 27, 190000m, new DateTime(2025, 9, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 140000m, 23, "cancelled", 140000m, new DateTime(2025, 11, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 300000m, 4, 300000m, new DateTime(2025, 9, 9, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 200000m, 16, 200000m, new DateTime(2025, 10, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 22, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 140000m, 5, 140000m, new DateTime(2025, 9, 26, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 27, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 200000m, 3, 200000m, new DateTime(2025, 10, 1, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 11, 11, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 140000m, 23, "accepted", 140000m, new DateTime(2025, 11, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 10, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 9, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 200000m, 3, 200000m, new DateTime(2025, 9, 14, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 2, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 140000m, 5, 140000m, new DateTime(2025, 10, 6, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 11, 15, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 140000m, 23, "accepted", 140000m, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "CreatedAt", "CreatedById", "Date", "MonthlyBookingId", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 11, 12, 10, 41, 13, 0, DateTimeKind.Unspecified), null, null, 190000m, 27, "accepted", 190000m, new DateTime(2025, 11, 6, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0), 3600000m, new TimeSpan(0, 6, 0, 0, 0), "cancelled", 3600000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), 960000m, 26, new TimeSpan(0, 8, 0, 0, 0), 960000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 0, 0, 0), 400000m, 17, new TimeSpan(0, 14, 0, 0, 0), 400000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 0, 0, 0), 4000000m, 6, new TimeSpan(0, 9, 0, 0, 0), 4000000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), 960000m, 26, new TimeSpan(0, 8, 0, 0, 0), 960000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0), 3600000m, 25, new TimeSpan(0, 6, 0, 0, 0), 3600000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 0, 0, 0), 1200000m, 18, new TimeSpan(0, 16, 0, 0, 0), 1200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 14, 0, 0, 0), 560000m, 17, new TimeSpan(0, 12, 0, 0, 0), 560000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EndTime", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 0, 0, 0), 2000000m, 18, new TimeSpan(0, 16, 0, 0, 0), "cancelled", 2000000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EndTime", "StartTime", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 16, 0, 0, 0), "completed", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EndTime", "StartTime", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 15, 0, 0, 0), new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "OriginalPrice", "StadiumId", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 560000m, 17, 560000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EndTime", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "Year" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 20, 0, 0, 0), "Lịch đặt tháng 1/2025", 400000m, 2, new TimeSpan(0, 18, 0, 0, 0), "completed", 400000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 2025 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "Year" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), "Lịch đặt tháng 2/2025", 1600000m, 1, "cancelled", 1600000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 2025 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 0, 0, 0), 3, "Lịch đặt tháng 3/2025", 400000m, 2, new TimeSpan(0, 14, 0, 0, 0), 400000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 0, 0, 0), 4, "Lịch đặt tháng 4/2025", 400000m, 2, new TimeSpan(0, 7, 0, 0, 0), "completed", 400000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), 5, "Lịch đặt tháng 5/2025", 880000m, 15, new TimeSpan(0, 8, 0, 0, 0), 880000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "StartTime", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), 6, "Lịch đặt tháng 6/2025", new TimeSpan(0, 15, 0, 0, 0), new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), 7, "Lịch đặt tháng 7/2025", 880000m, 15, new TimeSpan(0, 8, 0, 0, 0), "cancelled", 880000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0), 8, "Lịch đặt tháng 8/2025", 960000m, 8, new TimeSpan(0, 11, 0, 0, 0), 960000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0), 9, "Lịch đặt tháng 9/2025", 640000m, 20, new TimeSpan(0, 11, 0, 0, 0), "cancelled", 640000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 0, 0, 0), 10, "Lịch đặt tháng 10/2025", 480000m, 9, new TimeSpan(0, 9, 0, 0, 0), "cancelled", 480000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Month", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 11, "Lịch đặt tháng 11/2025", 1200000m, 24, "accepted", 1200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Month", "Note", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 12, "Lịch đặt tháng 12/2025", "accepted", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "Month", "Note", "OriginalPrice", "StadiumId", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), 1, "Lịch đặt tháng 1/2025", 800000m, 16, "completed", 800000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 14, 0, 0, 0), 2, "Lịch đặt tháng 2/2025", 800000m, 16, new TimeSpan(0, 12, 0, 0, 0), "completed", 800000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "Year" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 19, 0, 0, 0), 3, "Lịch đặt tháng 3/2025", 560000m, 5, new TimeSpan(0, 17, 0, 0, 0), "completed", 560000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 2025 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId", "Year" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 20, 0, 0, 0), 4, "Lịch đặt tháng 4/2025", 560000m, 5, new TimeSpan(0, 18, 0, 0, 0), "completed", 560000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8, 2025 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 0, 0, 0), 5, "Lịch đặt tháng 5/2025", 560000m, 23, new TimeSpan(0, 14, 0, 0, 0), "cancelled", 560000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0), 6, "Lịch đặt tháng 6/2025", 800000m, 3, new TimeSpan(0, 11, 0, 0, 0), "cancelled", 800000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 15, 0, 0, 0), 7, "Lịch đặt tháng 7/2025", 760000m, 27, new TimeSpan(0, 13, 0, 0, 0), 760000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), 8, "Lịch đặt tháng 8/2025", 1200000m, 4, new TimeSpan(0, 8, 0, 0, 0), 1200000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 0, 0, 0), 9, "Lịch đặt tháng 9/2025", 760000m, 27, new TimeSpan(0, 16, 0, 0, 0), 760000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "TotalPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 0, 0, 0), 10, "Lịch đặt tháng 10/2025", 560000m, 23, new TimeSpan(0, 9, 0, 0, 0), 560000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "StartTime", "Status", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0), 11, "Lịch đặt tháng 11/2025", new TimeSpan(0, 11, 0, 0, 0), "accepted", new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "MonthlyBookings",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "EndTime", "Month", "Note", "OriginalPrice", "StadiumId", "StartTime", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 10, 7, 10, 41, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 0, 0, 0), 12, "Lịch đặt tháng 12/2025", 800000m, 3, new TimeSpan(0, 9, 0, 0, 0), "accepted", 800000m, new DateTime(2025, 11, 5, 10, 41, 13, 0, DateTimeKind.Unspecified), 8 });
        }
    }
}
