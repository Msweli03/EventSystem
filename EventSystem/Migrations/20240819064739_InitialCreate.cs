using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 29, 8, 47, 39, 569, DateTimeKind.Local).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 3, 8, 47, 39, 569, DateTimeKind.Local).AddTicks(7088));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 9, 8, 8, 47, 39, 569, DateTimeKind.Local).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 9, 13, 8, 47, 39, 569, DateTimeKind.Local).AddTicks(7090));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Duration", "StartTime" },
                values: new object[] { new DateTime(2024, 8, 29, 5, 20, 21, 589, DateTimeKind.Local).AddTicks(8163), new TimeSpan(0, 4, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Duration", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 20, 21, 589, DateTimeKind.Local).AddTicks(8180), new TimeSpan(0, 2, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Duration", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 8, 5, 20, 21, 589, DateTimeKind.Local).AddTicks(8181), new TimeSpan(0, 3, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Duration", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 13, 5, 20, 21, 589, DateTimeKind.Local).AddTicks(8182), new TimeSpan(0, 6, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) });
        }
    }
}
