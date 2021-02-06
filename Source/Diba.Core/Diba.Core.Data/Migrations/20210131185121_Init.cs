using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diba.Core.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuickAccessLists",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickAccessLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<int>(nullable: false),
                    IsGranted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CreatorId = table.Column<long>(nullable: true),
                    Creation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductConstraints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    MaxLength = table.Column<int>(nullable: true),
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
                name: "QNames",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    QuickAccessListId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QNames_QuickAccessLists_QuickAccessListId",
                        column: x => x.QuickAccessListId,
                        principalTable: "QuickAccessLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Authorities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    ModifierId = table.Column<long>(nullable: true),
                    Modification = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<long>(nullable: true),
                    Creation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authorities_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Authorities_Users_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    ModifierId = table.Column<long>(nullable: true),
                    Modification = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<long>(nullable: true),
                    Creation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organizations_Users_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceDescription = table.Column<string>(nullable: true),
                    ServiceTypeId = table.Column<long>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    UnitId = table.Column<long>(nullable: false),
                    PricePerUnit = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Tax = table.Column<decimal>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_QNames_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "QNames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerOrders_QNames_UnitId",
                        column: x => x.UnitId,
                        principalTable: "QNames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuthorityPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorityId = table.Column<long>(nullable: false),
                    Action = table.Column<int>(nullable: false),
                    IsGranted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorityPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorityPermissions_Authorities_AuthorityId",
                        column: x => x.AuthorityId,
                        principalTable: "Authorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    EconomicCode = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    NationalIdentifier = table.Column<string>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authorities",
                columns: new[] { "Id", "Active", "Creation", "CreatorId", "Modification", "ModifierId" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Creation", "CreatorId", "Password", "Username" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 1, 31, 22, 21, 20, 573, DateTimeKind.Local).AddTicks(670), null, "123456", "SuperAdmin" },
                    { 2L, new DateTime(2021, 1, 31, 22, 21, 20, 577, DateTimeKind.Local).AddTicks(553), null, "123456", "Secretary" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Creation", "CreatorId", "Modification", "ModifierId", "Prefix", "Title" },
                values: new object[] { 1L, new DateTime(2021, 1, 31, 18, 51, 20, 578, DateTimeKind.Utc).AddTicks(1925), 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "935", "Default Organization" });

            migrationBuilder.CreateIndex(
                name: "IX_Authorities_CreatorId",
                table: "Authorities",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorities_ModifierId",
                table: "Authorities",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorityPermissions_AuthorityId",
                table: "AuthorityPermissions",
                column: "AuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_UserId",
                table: "ContactInfos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_ServiceTypeId",
                table: "CustomerOrders",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_UnitId",
                table: "CustomerOrders",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Option_SelectiveConstraintId",
                table: "Option",
                column: "SelectiveConstraintId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CreatorId",
                table: "Organizations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_ModifierId",
                table: "Organizations",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductConstraints_ProductId",
                table: "ProductConstraints",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_QNames_QuickAccessListId",
                table: "QNames",
                column: "QuickAccessListId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_OrganizationId",
                table: "Role",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserId",
                table: "Role",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatorId",
                table: "Users",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorityPermissions");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "CustomerOrders");

            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Authorities");

            migrationBuilder.DropTable(
                name: "QNames");

            migrationBuilder.DropTable(
                name: "ProductConstraints");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "QuickAccessLists");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
