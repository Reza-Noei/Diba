using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diba.Core.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Constraints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constraints", x => x.Id);
                });

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
                    Role = table.Column<int>(nullable: false),
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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collectors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collectors_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    EconomicCode = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    NationalIdentifier = table.Column<string>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    RefererId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Organizations_RefererId",
                        column: x => x.RefererId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Secretaries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secretaries_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuerAdmins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuerAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuerAdmins_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminMemberships",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(nullable: false),
                    AuthorityId = table.Column<long>(nullable: false),
                    AdminId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMemberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminMemberships_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminMemberships_Authorities_AuthorityId",
                        column: x => x.AuthorityId,
                        principalTable: "Authorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminMemberships_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CollectorMemberships",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(nullable: false),
                    AuthorityId = table.Column<long>(nullable: false),
                    CollectorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectorMemberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectorMemberships_Authorities_AuthorityId",
                        column: x => x.AuthorityId,
                        principalTable: "Authorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectorMemberships_Collectors_CollectorId",
                        column: x => x.CollectorId,
                        principalTable: "Collectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectorMemberships_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(nullable: false),
                    CalleeName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInfos_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMemberships",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(nullable: false),
                    AuthorityId = table.Column<long>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMemberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerMemberships_Authorities_AuthorityId",
                        column: x => x.AuthorityId,
                        principalTable: "Authorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerMemberships_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerMemberships_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMemberships",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(nullable: false),
                    AuthorityId = table.Column<long>(nullable: false),
                    DeliveryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMemberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryMemberships_Authorities_AuthorityId",
                        column: x => x.AuthorityId,
                        principalTable: "Authorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryMemberships_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryMemberships_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SecretaryMemberships",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(nullable: false),
                    AuthorityId = table.Column<long>(nullable: false),
                    SecretaryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretaryMemberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretaryMemberships_Authorities_AuthorityId",
                        column: x => x.AuthorityId,
                        principalTable: "Authorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecretaryMemberships_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SecretaryMemberships_Secretaries_SecretaryId",
                        column: x => x.SecretaryId,
                        principalTable: "Secretaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuperAdminMemberships",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(nullable: false),
                    AuthorityId = table.Column<long>(nullable: false),
                    SuperAdminId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAdminMemberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperAdminMemberships_Authorities_AuthorityId",
                        column: x => x.AuthorityId,
                        principalTable: "Authorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuperAdminMemberships_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SuperAdminMemberships_SuerAdmins_SuperAdminId",
                        column: x => x.SuperAdminId,
                        principalTable: "SuerAdmins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(nullable: true),
                    EarnestMoney = table.Column<decimal>(nullable: false),
                    Reception = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CustomerMembershipId = table.Column<long>(nullable: true),
                    SecretaryMembershipId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_CustomerMemberships_CustomerMembershipId",
                        column: x => x.CustomerMembershipId,
                        principalTable: "CustomerMemberships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_SecretaryMemberships_SecretaryMembershipId",
                        column: x => x.SecretaryMembershipId,
                        principalTable: "SecretaryMemberships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    DeliveryMembershipId = table.Column<long>(nullable: true),
                    CollectorMembershipId = table.Column<long>(nullable: true),
                    PaymentType = table.Column<int>(nullable: false),
                    InvoiceId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_CollectorMemberships_CollectorMembershipId",
                        column: x => x.CollectorMembershipId,
                        principalTable: "CollectorMemberships",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerOrders_DeliveryMemberships_DeliveryMembershipId",
                        column: x => x.DeliveryMembershipId,
                        principalTable: "DeliveryMemberships",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerOrders_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Authorities",
                columns: new[] { "Id", "Active", "Creation", "CreatorId", "Modification", "ModifierId" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Action", "IsGranted", "Role" },
                values: new object[,]
                {
                    { 1L, 2, true, 0 },
                    { 2L, 1, true, 0 },
                    { 3L, 3, true, 0 },
                    { 4L, 4, true, 0 },
                    { 5L, 1, true, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Creation", "CreatorId", "Password", "Username" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 12, 4, 19, 13, 9, 204, DateTimeKind.Local).AddTicks(3587), null, "123456", "SuperAdmin" },
                    { 2L, new DateTime(2020, 12, 4, 19, 13, 9, 209, DateTimeKind.Local).AddTicks(729), null, "123456", "Secretary" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Creation", "CreatorId", "Modification", "ModifierId", "Prefix", "Title" },
                values: new object[] { 1L, new DateTime(2020, 12, 4, 19, 13, 9, 211, DateTimeKind.Local).AddTicks(6994), 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "935", "Default Organization" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Title", "UserId" },
                values: new object[] { 2L, "SuperAdmin", 1L });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Title", "UserId" },
                values: new object[] { 1L, "Secretary", 2L });

            migrationBuilder.InsertData(
                table: "Secretaries",
                columns: new[] { "Id", "RoleId" },
                values: new object[] { 2L, 1L });

            migrationBuilder.InsertData(
                table: "SuerAdmins",
                columns: new[] { "Id", "RoleId" },
                values: new object[] { 1L, 2L });

            migrationBuilder.InsertData(
                table: "SecretaryMemberships",
                columns: new[] { "Id", "AuthorityId", "OrganizationId", "SecretaryId" },
                values: new object[] { 2L, 1L, 1L, 2L });

            migrationBuilder.InsertData(
                table: "SuperAdminMemberships",
                columns: new[] { "Id", "AuthorityId", "OrganizationId", "SuperAdminId" },
                values: new object[] { 1L, 2L, 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_AdminMemberships_AdminId",
                table: "AdminMemberships",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminMemberships_AuthorityId",
                table: "AdminMemberships",
                column: "AuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminMemberships_OrganizationId",
                table: "AdminMemberships",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_RoleId",
                table: "Admins",
                column: "RoleId",
                unique: true);

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
                name: "IX_CollectorMemberships_AuthorityId",
                table: "CollectorMemberships",
                column: "AuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectorMemberships_CollectorId",
                table: "CollectorMemberships",
                column: "CollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectorMemberships_OrganizationId",
                table: "CollectorMemberships",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Collectors_RoleId",
                table: "Collectors",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_CustomerId",
                table: "ContactInfos",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMemberships_AuthorityId",
                table: "CustomerMemberships",
                column: "AuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMemberships_CustomerId",
                table: "CustomerMemberships",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMemberships_OrganizationId",
                table: "CustomerMemberships",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_CollectorMembershipId",
                table: "CustomerOrders",
                column: "CollectorMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_DeliveryMembershipId",
                table: "CustomerOrders",
                column: "DeliveryMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_InvoiceId",
                table: "CustomerOrders",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_ServiceTypeId",
                table: "CustomerOrders",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_UnitId",
                table: "CustomerOrders",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RefererId",
                table: "Customers",
                column: "RefererId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RoleId",
                table: "Customers",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_RoleId",
                table: "Deliveries",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryMemberships_AuthorityId",
                table: "DeliveryMemberships",
                column: "AuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryMemberships_DeliveryId",
                table: "DeliveryMemberships",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryMemberships_OrganizationId",
                table: "DeliveryMemberships",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CustomerMembershipId",
                table: "Invoice",
                column: "CustomerMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SecretaryMembershipId",
                table: "Invoice",
                column: "SecretaryMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CreatorId",
                table: "Organizations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_ModifierId",
                table: "Organizations",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_QNames_QuickAccessListId",
                table: "QNames",
                column: "QuickAccessListId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Secretaries_RoleId",
                table: "Secretaries",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecretaryMemberships_AuthorityId",
                table: "SecretaryMemberships",
                column: "AuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretaryMemberships_OrganizationId",
                table: "SecretaryMemberships",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretaryMemberships_SecretaryId",
                table: "SecretaryMemberships",
                column: "SecretaryId");

            migrationBuilder.CreateIndex(
                name: "IX_SuerAdmins_RoleId",
                table: "SuerAdmins",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuperAdminMemberships_AuthorityId",
                table: "SuperAdminMemberships",
                column: "AuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperAdminMemberships_OrganizationId",
                table: "SuperAdminMemberships",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperAdminMemberships_SuperAdminId",
                table: "SuperAdminMemberships",
                column: "SuperAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatorId",
                table: "Users",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminMemberships");

            migrationBuilder.DropTable(
                name: "AuthorityPermissions");

            migrationBuilder.DropTable(
                name: "Constraints");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "CustomerOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "SuperAdminMemberships");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "CollectorMemberships");

            migrationBuilder.DropTable(
                name: "DeliveryMemberships");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "QNames");

            migrationBuilder.DropTable(
                name: "SuerAdmins");

            migrationBuilder.DropTable(
                name: "Collectors");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "CustomerMemberships");

            migrationBuilder.DropTable(
                name: "SecretaryMemberships");

            migrationBuilder.DropTable(
                name: "QuickAccessLists");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Authorities");

            migrationBuilder.DropTable(
                name: "Secretaries");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
