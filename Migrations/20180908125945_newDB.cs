using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NeighborFoodBackend.Migrations
{
    public partial class newDB : Migration
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
                name: "Flats",
                columns: table => new
                {
                    FlatID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FlatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apartmentID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.FlatID);
                    table.ForeignKey(
                        name: "FK_Flats_Apartments_apartmentID",
                        column: x => x.apartmentID,
                        principalTable: "Apartments",
                        principalColumn: "apartmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userUid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    apartmentID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    flatID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating = table.Column<float>(type: "real", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userUid);
                    table.ForeignKey(
                        name: "FK_Users_Apartments_apartmentID",
                        column: x => x.apartmentID,
                        principalTable: "Apartments",
                        principalColumn: "apartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Flats_flatID",
                        column: x => x.flatID,
                        principalTable: "Flats",
                        principalColumn: "FlatID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SellerItems",
                columns: table => new
                {
                    SellerItemID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    flatID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isAvailable = table.Column<bool>(type: "bit", nullable: false),
                    itemDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<float>(type: "real", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    sellerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    servedFor = table.Column<int>(type: "int", nullable: false),
                    userUid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    veg = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerItems", x => x.SellerItemID);
                    table.ForeignKey(
                        name: "FK_SellerItems_Flats_flatID",
                        column: x => x.flatID,
                        principalTable: "Flats",
                        principalColumn: "FlatID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellerItems_FoodItems_itemID",
                        column: x => x.itemID,
                        principalTable: "FoodItems",
                        principalColumn: "itemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellerItems_Users_userUid",
                        column: x => x.userUid,
                        principalTable: "Users",
                        principalColumn: "userUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    createTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orderID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    sellerItemId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    userPlacedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPlacedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userUid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_SellerItems_sellerItemId",
                        column: x => x.sellerItemId,
                        principalTable: "SellerItems",
                        principalColumn: "SellerItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_userUid",
                        column: x => x.userUid,
                        principalTable: "Users",
                        principalColumn: "userUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flats_apartmentID",
                table: "Flats",
                column: "apartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_sellerItemId",
                table: "Orders",
                column: "sellerItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userUid",
                table: "Orders",
                column: "userUid");

            migrationBuilder.CreateIndex(
                name: "IX_SellerItems_flatID",
                table: "SellerItems",
                column: "flatID");

            migrationBuilder.CreateIndex(
                name: "IX_SellerItems_itemID",
                table: "SellerItems",
                column: "itemID");

            migrationBuilder.CreateIndex(
                name: "IX_SellerItems_userUid",
                table: "SellerItems",
                column: "userUid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_apartmentID",
                table: "Users",
                column: "apartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_flatID",
                table: "Users",
                column: "flatID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "SellerItems");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "Apartments");
        }
    }
}
