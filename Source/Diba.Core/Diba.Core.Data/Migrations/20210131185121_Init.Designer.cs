﻿// <auto-generated />
using System;
using Diba.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diba.Core.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210131185121_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Diba.Core.Domain.Authority", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Modification")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModifierId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.ToTable("Authorities");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Active = true,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Modification = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2L,
                            Active = true,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Modification = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Diba.Core.Domain.AuthorityPermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Action")
                        .HasColumnType("int");

                    b.Property<long>("AuthorityId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsGranted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AuthorityId");

                    b.ToTable("AuthorityPermissions");
                });

            modelBuilder.Entity("Diba.Core.Domain.ContactInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("Diba.Core.Domain.CustomerOrder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ServiceDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ServiceTypeId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("UnitId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ServiceTypeId");

                    b.HasIndex("UnitId");

                    b.ToTable("CustomerOrders");
                });

            modelBuilder.Entity("Diba.Core.Domain.Organization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Modification")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModifierId")
                        .HasColumnType("bigint");

                    b.Property<string>("Prefix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Creation = new DateTime(2021, 1, 31, 18, 51, 20, 578, DateTimeKind.Utc).AddTicks(1925),
                            CreatorId = 1L,
                            Modification = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Prefix = "935",
                            Title = "Default Organization"
                        });
                });

            modelBuilder.Entity("Diba.Core.Domain.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Diba.Core.Domain.Products.ProductConstraints.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Key")
                        .HasColumnType("int");

                    b.Property<int>("SelectiveConstraintId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SelectiveConstraintId");

                    b.ToTable("Option");
                });

            modelBuilder.Entity("Diba.Core.Domain.Products.ProductConstraints.ProductConstraint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductConstraints");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ProductConstraint");
                });

            modelBuilder.Entity("Diba.Core.Domain.QName", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("QuickAccessListId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuickAccessListId");

                    b.ToTable("QNames");
                });

            modelBuilder.Entity("Diba.Core.Domain.QuickAccessList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("QuickAccessLists");
                });

            modelBuilder.Entity("Diba.Core.Domain.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Role");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Role");
                });

            modelBuilder.Entity("Diba.Core.Domain.RolePermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Action")
                        .HasColumnType("int");

                    b.Property<bool>("IsGranted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("Diba.Core.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Creation = new DateTime(2021, 1, 31, 22, 21, 20, 573, DateTimeKind.Local).AddTicks(670),
                            Password = "123456",
                            Username = "SuperAdmin"
                        },
                        new
                        {
                            Id = 2L,
                            Creation = new DateTime(2021, 1, 31, 22, 21, 20, 577, DateTimeKind.Local).AddTicks(553),
                            Password = "123456",
                            Username = "Secretary"
                        });
                });

            modelBuilder.Entity("Diba.Core.Domain.Products.ProductConstraints.SelectiveConstraint", b =>
                {
                    b.HasBaseType("Diba.Core.Domain.Products.ProductConstraints.ProductConstraint");

                    b.HasDiscriminator().HasValue("SelectiveConstraint");
                });

            modelBuilder.Entity("Diba.Core.Domain.Products.ProductConstraints.StringConstraint", b =>
                {
                    b.HasBaseType("Diba.Core.Domain.Products.ProductConstraints.ProductConstraint");

                    b.Property<string>("Format")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxLength")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("StringConstraint");
                });

            modelBuilder.Entity("Diba.Core.Domain.Admin", b =>
                {
                    b.HasBaseType("Diba.Core.Domain.Role");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Diba.Core.Domain.Collector", b =>
                {
                    b.HasBaseType("Diba.Core.Domain.Role");

                    b.HasDiscriminator().HasValue("Collector");
                });

            modelBuilder.Entity("Diba.Core.Domain.Customer", b =>
                {
                    b.HasBaseType("Diba.Core.Domain.Role");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EconomicCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OrganizationId")
                        .HasColumnType("bigint");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("OrganizationId");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("Diba.Core.Domain.Delivery", b =>
                {
                    b.HasBaseType("Diba.Core.Domain.Role");

                    b.HasDiscriminator().HasValue("Delivery");
                });

            modelBuilder.Entity("Diba.Core.Domain.Secretary", b =>
                {
                    b.HasBaseType("Diba.Core.Domain.Role");

                    b.HasDiscriminator().HasValue("Secretary");
                });

            modelBuilder.Entity("Diba.Core.Domain.SuperAdmin", b =>
                {
                    b.HasBaseType("Diba.Core.Domain.Role");

                    b.HasDiscriminator().HasValue("SuperAdmin");
                });

            modelBuilder.Entity("Diba.Core.Domain.Authority", b =>
                {
                    b.HasOne("Diba.Core.Domain.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Diba.Core.Domain.User", "Modifier")
                        .WithMany()
                        .HasForeignKey("ModifierId");
                });

            modelBuilder.Entity("Diba.Core.Domain.AuthorityPermission", b =>
                {
                    b.HasOne("Diba.Core.Domain.Authority", "Authority")
                        .WithMany("Permissions")
                        .HasForeignKey("AuthorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diba.Core.Domain.ContactInfo", b =>
                {
                    b.HasOne("Diba.Core.Domain.User", "User")
                        .WithMany("ContactInfos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diba.Core.Domain.CustomerOrder", b =>
                {
                    b.HasOne("Diba.Core.Domain.QName", "ServiceType")
                        .WithMany()
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Diba.Core.Domain.QName", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Diba.Core.Domain.Organization", b =>
                {
                    b.HasOne("Diba.Core.Domain.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Diba.Core.Domain.User", "Modifier")
                        .WithMany()
                        .HasForeignKey("ModifierId");
                });

            modelBuilder.Entity("Diba.Core.Domain.Products.ProductConstraints.Option", b =>
                {
                    b.HasOne("Diba.Core.Domain.Products.ProductConstraints.SelectiveConstraint", "SelectiveConstraint")
                        .WithMany("Options")
                        .HasForeignKey("SelectiveConstraintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diba.Core.Domain.Products.ProductConstraints.ProductConstraint", b =>
                {
                    b.HasOne("Diba.Core.Domain.Products.Product", "Product")
                        .WithMany("Constraints")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diba.Core.Domain.QName", b =>
                {
                    b.HasOne("Diba.Core.Domain.QuickAccessList", null)
                        .WithMany("Items")
                        .HasForeignKey("QuickAccessListId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Diba.Core.Domain.Role", b =>
                {
                    b.HasOne("Diba.Core.Domain.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diba.Core.Domain.User", b =>
                {
                    b.HasOne("Diba.Core.Domain.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");
                });

            modelBuilder.Entity("Diba.Core.Domain.Customer", b =>
                {
                    b.HasOne("Diba.Core.Domain.Organization", "Organization")
                        .WithMany("Customers")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
