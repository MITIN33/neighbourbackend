using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NeighborFoodBackend.Migrations
{
    public partial class asd2 : Migration
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
                name: "Orders",
                columns: table => new
                {
                    orderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    orderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPlacedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPlacedTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderID);
                });

            migrationBuilder.CreateTable(
                name: "SellerItems",
                columns: table => new
                {
                    SellerItemID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    itemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    sellerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    servedFor = table.Column<int>(type: "int", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerItems", x => x.SellerItemID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userUid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    apartmentID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    flatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userUid);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    FlatNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    apartmentID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.FlatNumber);
                    table.ForeignKey(
                        name: "FK_Flats_Apartments_FlatNumber",
                        column: x => x.FlatNumber,
                        principalTable: "Apartments",
                        principalColumn: "apartmentID",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_FoodItems_Orders_itemID",
                        column: x => x.itemID,
                        principalTable: "Orders",
                        principalColumn: "orderID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "SellerItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
