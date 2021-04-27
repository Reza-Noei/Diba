﻿// <auto-generated />
using System;
using Diba.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diba.Core.Data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Diba.Core.Domain.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Diba.Core.Domain.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");
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

                    b.Property<long?>("CollectorId")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<long?>("DeliveryId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("InvoiceId")
                        .HasColumnType("bigint");

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

                    b.HasIndex("CollectorId");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ServiceTypeId");

                    b.HasIndex("UnitId");

                    b.ToTable("CustomerOrders");
                });

            modelBuilder.Entity("Diba.Core.Domain.Invoice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("EarnestMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Reception")
                        .HasColumnType("datetime2");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Diba.Core.Domain.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
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
                });

            modelBuilder.Entity("Diba.Core.Domain.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scope")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Diba.Core.Domain.Products.ProductClass", b =>
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

            modelBuilder.Entity("Diba.Core.Domain.Brand", b =>
                {
                    b.HasOne("Diba.Core.Domain.Company", "Company")
                        .WithMany("Brands")
                        .HasForeignKey("CompanyId")
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
                    b.HasOne("Diba.Core.Domain.Collector", "Collector")
                        .WithMany()
                        .HasForeignKey("CollectorId");

                    b.HasOne("Diba.Core.Domain.Delivery", "Delivery")
                        .WithMany()
                        .HasForeignKey("DeliveryId");

                    b.HasOne("Diba.Core.Domain.Invoice", null)
                        .WithMany("Orders")
                        .HasForeignKey("InvoiceId");

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

            modelBuilder.Entity("Diba.Core.Domain.Order", b =>
                {
                    b.HasOne("Diba.Core.Domain.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Diba.Core.Domain.CollectionInfo", "CollectionInfo", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime?>("CollectionDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CollectionLocation")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int?>("CollectorId")
                                .HasColumnType("int");

                            b1.HasKey("OrderId");

                            b1.ToTable("Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("Diba.Core.Domain.DeliveryInfo", "DeliveryInfo", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int?>("DelivelerId")
                                .HasColumnType("int");

                            b1.Property<DateTime?>("DeliveryDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("DeliveryLocation")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsMany("Diba.Core.Domain.OrderItem", "OrderItems", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<long>("ServiceId")
                                .HasColumnType("bigint");

                            b1.Property<decimal>("UnitPrice")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("Units")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("OrderId");

                            b1.ToTable("OrderItems");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("Diba.Core.Domain.Request", "Request", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("AnnouncedPrice")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Items")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });
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
                    b.HasOne("Diba.Core.Domain.Products.ProductClass", "Product")
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
