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
                name: "endTime",
                table: "SellerItems");

            migrationBuilder.DropColumn(
                name: "startTime",
                table: "SellerItems");

            migrationBuilder.AlterColumn<string>(
                name: "flatID",
                table: "SellerItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellerItems_flatID",
                table: "SellerItems",
                column: "flatID");

            migrationBuilder.AddForeignKey(
                name: "FK_SellerItems_Flats_flatID",
                table: "SellerItems",
                column: "flatID",
                principalTable: "Flats",
                principalColumn: "FlatID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellerItems_Flats_flatID",
                table: "SellerItems");

            migrationBuilder.DropIndex(
                name: "IX_SellerItems_flatID",
                table: "SellerItems");

            migrationBuilder.AlterColumn<string>(
                name: "flatID",
                table: "SellerItems",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "endTime",
                table: "SellerItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "startTime",
                table: "SellerItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
