using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NeighborFoodBackend.Migrations
{
    public partial class wert1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_Orders_itemID",
                table: "FoodItems",
                column: "itemID",
                principalTable: "Orders",
                principalColumn: "orderID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_Orders_itemID",
                table: "FoodItems");
        }
    }
}
