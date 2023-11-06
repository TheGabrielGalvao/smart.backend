﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Auth.Module", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Module", "auth");
                });

            modelBuilder.Entity("Domain.Entities.Auth.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ModuleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NeedSupervision")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Permission", "auth");
                });

            modelBuilder.Entity("Domain.Entities.Auth.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProfileId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<long?>("UserGroupId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users", "auth");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Email = "admin@teste.com",
                            Name = "Admin",
                            Password = "1234",
                            ProfileId = 1L,
                            Status = 1,
                            Uuid = new Guid("e706f218-97d8-4a20-b4f3-9e3de4c9e576")
                        });
                });

            modelBuilder.Entity("Domain.Entities.Auth.UserGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProfileId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long?>("UserProfileId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("UserGroup", "auth");
                });

            modelBuilder.Entity("Domain.Entities.Auth.UserProfile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserProfile", "auth");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Perfil de Administrador",
                            Name = "Admnistrador",
                            Status = 1,
                            Uuid = new Guid("d27f1c71-3470-417c-8f5f-b43e16c85d14")
                        });
                });

            modelBuilder.Entity("Domain.Entities.Contact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("CpfCnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocumentType")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Domain.Entities.Fiancial.FinancialRelease", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("ContactId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("FinancialReleaseTypeId")
                        .HasColumnType("bigint");

                    b.Property<int>("Operation")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("FinancialReleaseTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("FinancialRelease", "financial");
                });

            modelBuilder.Entity("Domain.Entities.Fiancial.FinancialReleaseType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Operation")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FinancialReleaseType", "financial");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Recebimento de salário",
                            Name = "Salário",
                            Operation = 0,
                            Status = 1,
                            Uuid = new Guid("9e015083-37b2-4fa3-a017-993ad5069ca8")
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Pagamento de Aluguel",
                            Name = "Aluguel",
                            Operation = 1,
                            Status = 1,
                            Uuid = new Guid("80a4db26-8161-4080-b987-6591cf4c0320")
                        },
                        new
                        {
                            Id = 3L,
                            Description = "Outras Receitas",
                            Name = "Outras Receitas",
                            Operation = 0,
                            Status = 1,
                            Uuid = new Guid("7f420e97-b563-4378-8088-edb359789ba1")
                        },
                        new
                        {
                            Id = 4L,
                            Description = "Outras Despesas",
                            Name = "Outras Despesas",
                            Operation = 1,
                            Status = 1,
                            Uuid = new Guid("ac72349e-3292-4468-84e3-63157cef3c63")
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product.ProductCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory", "product");
                });

            modelBuilder.Entity("Domain.Entities.Product.ProductEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("AffectsStock")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("MinimalStock")
                        .HasColumnType("decimal(19,9)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("ProductCategoryId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<long>("StockLocationId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("StockLocationId");

                    b.ToTable("Products", "product");
                });

            modelBuilder.Entity("Domain.Entities.Stock.InventoryAdjustmentEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(19,9)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(25)");

                    b.Property<int>("Flow")
                        .HasColumnType("int");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("StockLocationId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StockLocationId");

                    b.ToTable("InventoryAdjustment", "stock");
                });

            modelBuilder.Entity("Domain.Entities.Stock.StockBalanceEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<decimal?>("Balance")
                        .HasColumnType("decimal(19,9)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("StockLocationId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StockLocationId");

                    b.ToTable("StockBalance", "stock");
                });

            modelBuilder.Entity("Domain.Entities.Stock.StockLocationEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("StockLocation", "stock");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Local de Estoque Padrão",
                            Name = "Padrão",
                            Status = 1,
                            Uuid = new Guid("595980be-1635-4ca1-987d-eddbd1fb15d8")
                        });
                });

            modelBuilder.Entity("Domain.Entities.Stock.StockReleaseEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Flow")
                        .HasColumnType("int");

                    b.Property<decimal>("NextBalance")
                        .HasColumnType("decimal(19,9)");

                    b.Property<decimal?>("PreviousBalance")
                        .HasColumnType("decimal(19,9)");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("QuantityReleased")
                        .HasColumnType("decimal(19,9)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("StockLocationId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StockReleaseId")
                        .HasColumnType("bigint");

                    b.Property<int>("StockReleaseType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StockLocationId");

                    b.HasIndex("UserId");

                    b.ToTable("StockRelease", "stock");
                });

            modelBuilder.Entity("ProfilePermissions", b =>
                {
                    b.Property<long>("PermissionId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProfileId")
                        .HasColumnType("bigint");

                    b.HasKey("PermissionId", "ProfileId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfilePermissions", "auth");
                });

            modelBuilder.Entity("Domain.Entities.Auth.Permission", b =>
                {
                    b.HasOne("Domain.Entities.Auth.Module", "Module")
                        .WithMany("Permissions")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");
                });

            modelBuilder.Entity("Domain.Entities.Auth.User", b =>
                {
                    b.HasOne("Domain.Entities.Auth.UserProfile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Auth.UserGroup", "UserGroup")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Profile");

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("Domain.Entities.Auth.UserGroup", b =>
                {
                    b.HasOne("Domain.Entities.Auth.UserProfile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Auth.UserProfile", null)
                        .WithMany("UserGroups")
                        .HasForeignKey("UserProfileId");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Domain.Entities.Fiancial.FinancialRelease", b =>
                {
                    b.HasOne("Domain.Entities.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("Domain.Entities.Fiancial.FinancialReleaseType", "FinancialReleaseType")
                        .WithMany("FinancialReleases")
                        .HasForeignKey("FinancialReleaseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("FinancialReleaseType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Fiancial.FinancialReleaseType", b =>
                {
                    b.HasOne("Domain.Entities.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Product.ProductEntity", b =>
                {
                    b.HasOne("Domain.Entities.Product.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Stock.StockLocationEntity", "StockLocation")
                        .WithMany()
                        .HasForeignKey("StockLocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductCategory");

                    b.Navigation("StockLocation");
                });

            modelBuilder.Entity("Domain.Entities.Stock.InventoryAdjustmentEntity", b =>
                {
                    b.HasOne("Domain.Entities.Product.ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Stock.StockLocationEntity", "StockLocation")
                        .WithMany()
                        .HasForeignKey("StockLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("StockLocation");
                });

            modelBuilder.Entity("Domain.Entities.Stock.StockBalanceEntity", b =>
                {
                    b.HasOne("Domain.Entities.Product.ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Stock.StockLocationEntity", "StockLocation")
                        .WithMany("StockBalances")
                        .HasForeignKey("StockLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("StockLocation");
                });

            modelBuilder.Entity("Domain.Entities.Stock.StockReleaseEntity", b =>
                {
                    b.HasOne("Domain.Entities.Product.ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Stock.StockLocationEntity", "StockLocation")
                        .WithMany("StockReleases")
                        .HasForeignKey("StockLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("StockLocation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfilePermissions", b =>
                {
                    b.HasOne("Domain.Entities.Auth.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Auth.UserProfile", null)
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Auth.Module", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("Domain.Entities.Auth.UserGroup", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.Auth.UserProfile", b =>
                {
                    b.Navigation("UserGroups");
                });

            modelBuilder.Entity("Domain.Entities.Fiancial.FinancialReleaseType", b =>
                {
                    b.Navigation("FinancialReleases");
                });

            modelBuilder.Entity("Domain.Entities.Stock.StockLocationEntity", b =>
                {
                    b.Navigation("StockBalances");

                    b.Navigation("StockReleases");
                });
#pragma warning restore 612, 618
        }
    }
}
