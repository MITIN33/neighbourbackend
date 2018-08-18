using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NeighborFoodBackend.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "flatNumber",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "apartmentID",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "flatID",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "rating",
                table: "Users",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "flatID",
                table: "SellerItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isAvailable",
                table: "SellerItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "SellerItems",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "userUid",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FlatNumber",
                table: "Flats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "FlatID",
                table: "Flats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flats",
                table: "Flats",
                column: "FlatID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_apartmentID",
                table: "Users",
                column: "apartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_flatID",
                table: "Users",
                column: "flatID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userUid",
                table: "Orders",
                column: "userUid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_userUid",
                table: "Orders",
                column: "userUid",
                principalTable: "Users",
                principalColumn: "userUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Apartments_apartmentID",
                table: "Users",
                column: "apartmentID",
                principalTable: "Apartments",
                principalColumn: "apartmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Flats_flatID",
                table: "Users",
                column: "flatID",
                principalTable: "Flats",
                principalColumn: "FlatID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_userUid",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Apartments_apartmentID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Flats_flatID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_apartmentID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_flatID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_userUid",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flats",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "flatID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "flatID",
                table: "SellerItems");

            migrationBuilder.DropColumn(
                name: "isAvailable",
                table: "SellerItems");

            migrationBuilder.DropColumn(
                name: "price",
                table: "SellerItems");

            migrationBuilder.DropColumn(
                name: "userUid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FlatID",
                table: "Flats");

            migrationBuilder.AlterColumn<string>(
                name: "apartmentID",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "flatNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FlatNumber",
                table: "Flats",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flats",
                table: "Flats",
                column: "FlatNumber");
        }
    }
}
