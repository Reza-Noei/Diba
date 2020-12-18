using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diba.Core.Data.Migrations
{
    public partial class UpdateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Creation",
                value: new DateTime(2020, 12, 4, 19, 14, 41, 975, DateTimeKind.Local).AddTicks(202));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Creation",
                value: new DateTime(2020, 12, 4, 19, 14, 41, 965, DateTimeKind.Local).AddTicks(8068));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Creation",
                value: new DateTime(2020, 12, 4, 19, 14, 41, 971, DateTimeKind.Local).AddTicks(4649));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Creation",
                value: new DateTime(2020, 12, 4, 19, 14, 19, 843, DateTimeKind.Local).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Creation",
                value: new DateTime(2020, 12, 4, 19, 14, 19, 835, DateTimeKind.Local).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Creation",
                value: new DateTime(2020, 12, 4, 19, 14, 19, 840, DateTimeKind.Local).AddTicks(5669));
        }
    }
}
