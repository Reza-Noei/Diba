using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diba.Core.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Constraints");

            migrationBuilder.CreateTable(
                name: "ProductConstraints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    MaxLength = table.Column<long>(nullable: true),
                    Format = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductConstraints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductConstraints_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectiveConstraintId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Key = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Option_ProductConstraints_SelectiveConstraintId",
                        column: x => x.SelectiveConstraintId,
                        principalTable: "ProductConstraints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Creation",
                value: new DateTime(2020, 12, 7, 23, 4, 30, 946, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Creation",
                value: new DateTime(2020, 12, 7, 23, 4, 30, 938, DateTimeKind.Local).AddTicks(7387));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Creation",
                value: new DateTime(2020, 12, 7, 23, 4, 30, 943, DateTimeKind.Local).AddTicks(5425));

            migrationBuilder.CreateIndex(
                name: "IX_Option_SelectiveConstraintId",
                table: "Option",
                column: "SelectiveConstraintId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductConstraints_ProductId",
                table: "ProductConstraints",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "ProductConstraints");

            migrationBuilder.CreateTable(
                name: "Constraints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constraints", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Creation",
                value: new DateTime(2020, 12, 4, 19, 15, 32, 487, DateTimeKind.Local).AddTicks(6548));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Creation",
                value: new DateTime(2020, 12, 4, 19, 15, 32, 481, DateTimeKind.Local).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Creation",
                value: new DateTime(2020, 12, 4, 19, 15, 32, 485, DateTimeKind.Local).AddTicks(1428));
        }
    }
}
