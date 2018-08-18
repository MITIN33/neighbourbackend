﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApplication1.Data;

namespace NeighborFoodBackend.Migrations
{
    [DbContext(typeof(FoodserviceContext))]
    partial class FoodserviceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodService.Models.Apartment", b =>
                {
                    b.Property<string>("apartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("apartmentName");

                    b.HasKey("apartmentID");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("FoodService.Models.Flat", b =>
                {
                    b.Property<string>("FlatID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FlatNumber");

                    b.Property<string>("apartmentID");

                    b.HasKey("FlatID");

                    b.HasIndex("apartmentID");

                    b.ToTable("Flats");
                });

            modelBuilder.Entity("FoodService.Models.FoodItem", b =>
                {
                    b.Property<string>("itemID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("itemDesc");

                    b.Property<string>("itemName");

                    b.HasKey("itemID");

                    b.ToTable("FoodItems");
                });

            modelBuilder.Entity("FoodService.Models.Order", b =>
                {
                    b.Property<string>("orderID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("createTime");

                    b.Property<string>("orderStatus");

                    b.Property<int>("quantity");

                    b.Property<string>("sellerItemId");

                    b.Property<string>("userPlacedBy");

                    b.Property<string>("userPlacedTo");

                    b.Property<string>("userUid");

                    b.HasKey("orderID");

                    b.HasIndex("sellerItemId");

                    b.HasIndex("userUid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodService.Models.SellerItem", b =>
                {
                    b.Property<string>("SellerItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("flatID");

                    b.Property<bool>("isAvailable");

                    b.Property<string>("itemID");

                    b.Property<float>("price");

                    b.Property<int>("quantity");

                    b.Property<string>("sellerID");

                    b.Property<int>("servedFor");

                    b.Property<string>("userUid");

                    b.HasKey("SellerItemID");

                    b.HasIndex("flatID");

                    b.HasIndex("itemID");

                    b.HasIndex("userUid");

                    b.ToTable("SellerItems");
                });

            modelBuilder.Entity("FoodService.Models.User", b =>
                {
                    b.Property<string>("userUid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("apartmentID");

                    b.Property<string>("flatID");

                    b.Property<string>("fname");

                    b.Property<string>("lname");

                    b.Property<string>("phoneNo");

                    b.Property<float>("rating");

                    b.Property<string>("status");

                    b.Property<string>("userName");

                    b.HasKey("userUid");

                    b.HasIndex("apartmentID");

                    b.HasIndex("flatID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FoodService.Models.Flat", b =>
                {
                    b.HasOne("FoodService.Models.Apartment")
                        .WithMany("Flats")
                        .HasForeignKey("apartmentID");
                });

            modelBuilder.Entity("FoodService.Models.Order", b =>
                {
                    b.HasOne("FoodService.Models.SellerItem")
                        .WithMany("Orders")
                        .HasForeignKey("sellerItemId");

                    b.HasOne("FoodService.Models.User")
                        .WithMany("Orders")
                        .HasForeignKey("userUid");
                });

            modelBuilder.Entity("FoodService.Models.SellerItem", b =>
                {
                    b.HasOne("FoodService.Models.Flat")
                        .WithMany("sellerItems")
                        .HasForeignKey("flatID");

                    b.HasOne("FoodService.Models.FoodItem")
                        .WithMany("SellerItems")
                        .HasForeignKey("itemID");

                    b.HasOne("FoodService.Models.User")
                        .WithMany("SellerItems")
                        .HasForeignKey("userUid");
                });

            modelBuilder.Entity("FoodService.Models.User", b =>
                {
                    b.HasOne("FoodService.Models.Apartment")
                        .WithMany("Users")
                        .HasForeignKey("apartmentID");

                    b.HasOne("FoodService.Models.Flat")
                        .WithMany("Users")
                        .HasForeignKey("flatID");
                });
#pragma warning restore 612, 618
        }
    }
}
