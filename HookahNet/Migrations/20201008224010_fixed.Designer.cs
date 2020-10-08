﻿// <auto-generated />
using System;
using HookahNet.Controllers.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HookahNet.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20201008224010_fixed")]
    partial class @fixed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HookahNet.Models.Catalog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId")
                        .IsUnique();

                    b.ToTable("catalogTable");
                });

            modelBuilder.Entity("HookahNet.Models.GuestUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("guestUserTable");
                });

            modelBuilder.Entity("HookahNet.Models.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SKU")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("organizationTable");
                });

            modelBuilder.Entity("HookahNet.Models.Products.Price", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Price");
                });

            modelBuilder.Entity("HookahNet.Models.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CatalogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("HookahProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("HookahProductId");

                    b.ToTable("productTable");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("HookahNet.Models.FlaskFluidProduct", b =>
                {
                    b.HasBaseType("HookahNet.Models.Products.Product");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("FlaskFluidProductTable");

                    b.HasDiscriminator().HasValue("FlaskFluidProduct");
                });

            modelBuilder.Entity("HookahNet.Models.HookahProduct", b =>
                {
                    b.HasBaseType("HookahNet.Models.Products.Product");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("HookahProductTable");

                    b.HasDiscriminator().HasValue("HookahProduct");
                });

            modelBuilder.Entity("HookahNet.Models.Catalog", b =>
                {
                    b.HasOne("HookahNet.Models.Organization", null)
                        .WithOne("Catalog")
                        .HasForeignKey("HookahNet.Models.Catalog", "OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HookahNet.Models.Products.Price", b =>
                {
                    b.HasOne("HookahNet.Models.Products.Product", null)
                        .WithOne("Price")
                        .HasForeignKey("HookahNet.Models.Products.Price", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HookahNet.Models.Products.Product", b =>
                {
                    b.HasOne("HookahNet.Models.HookahProduct", null)
                        .WithMany("products")
                        .HasForeignKey("HookahProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
