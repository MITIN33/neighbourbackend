using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NeighborFoodBackend.Migrations
{
    public partial class newdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    apartmentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    apartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.apartmentID);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    itemID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    itemDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.itemID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    orderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    sellerItemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPlacedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPlacedTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderID);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    FlatNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    apartmentID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.FlatNumber);
                    table.ForeignKey(
                        name: "FK_Flats_Apartments_apartmentID",
                        column: x => x.apartmentID,
                        principalTable: "Apartments",
                        principalColumn: "apartmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SellerItems",
                columns: table => new
                {
                    SellerItemID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    itemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orderID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    sellerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    servedFor = table.Column<int>(type: "int", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerItems", x => x.SellerItemID);
                    table.ForeignKey(
                        name: "FK_SellerItems_Orders_orderID",
                        column: x => x.orderID,
                        principalTable: "Orders",
                        principalColumn: "orderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userUid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    flatNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userUid);
                    table.ForeignKey(
                        name: "FK_Users_Flats_flatNumber",
                        column: x => x.flatNumber,
                        principalTable: "Flats",
                        principalColumn: "FlatNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flats_apartmentID",
                table: "Flats",
                column: "apartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_SellerItems_orderID",
                table: "SellerItems",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_flatNumber",
                table: "Users",
                column: "flatNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "SellerItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "Apartments");
        }
    }
}
