using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NeighborFoodBackend.Migrations
{
    public partial class asd4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "apartmentID",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "flatNumber",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "itemID",
                table: "SellerItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userUid",
                table: "SellerItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_flatNumber",
                table: "Users",
                column: "flatNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SellerItems_itemID",
                table: "SellerItems",
                column: "itemID");

            migrationBuilder.CreateIndex(
                name: "IX_SellerItems_userUid",
                table: "SellerItems",
                column: "userUid");

            migrationBuilder.AddForeignKey(
                name: "FK_SellerItems_FoodItems_itemID",
                table: "SellerItems",
                column: "itemID",
                principalTable: "FoodItems",
                principalColumn: "itemID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerItems_Users_userUid",
                table: "SellerItems",
                column: "userUid",
                principalTable: "Users",
                principalColumn: "userUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Flats_flatNumber",
                table: "Users",
                column: "flatNumber",
                principalTable: "Flats",
                principalColumn: "FlatNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellerItems_FoodItems_itemID",
                table: "SellerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerItems_Users_userUid",
                table: "SellerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Flats_flatNumber",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_flatNumber",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_SellerItems_itemID",
                table: "SellerItems");

            migrationBuilder.DropIndex(
                name: "IX_SellerItems_userUid",
                table: "SellerItems");

            migrationBuilder.DropColumn(
                name: "userUid",
                table: "SellerItems");

            migrationBuilder.AlterColumn<string>(
                name: "flatNumber",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "apartmentID",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "itemID",
                table: "SellerItems",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
