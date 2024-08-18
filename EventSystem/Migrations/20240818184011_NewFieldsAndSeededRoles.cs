using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSystem.Migrations
{
    public partial class NewFieldsAndSeededRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Registrations",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2024, 8, 28, 20, 40, 10, 929, DateTimeKind.Local).AddTicks(9680), "A festival for technology enthusiasts." });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2024, 9, 2, 20, 40, 10, 929, DateTimeKind.Local).AddTicks(9702), "An informative webinar on latest tech trends." });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2024, 9, 7, 20, 40, 10, 929, DateTimeKind.Local).AddTicks(9703), "A fun contest to see who can eat the most!" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2024, 9, 12, 20, 40, 10, 929, DateTimeKind.Local).AddTicks(9704), "A coding event to showcase your skills." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 27, 17, 5, 10, 67, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 1, 17, 5, 10, 67, DateTimeKind.Local).AddTicks(3862));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 9, 6, 17, 5, 10, 67, DateTimeKind.Local).AddTicks(3863));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 9, 11, 17, 5, 10, 67, DateTimeKind.Local).AddTicks(3864));
        }
    }
}
