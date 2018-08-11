using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NeighborFoodBackend.Migrations
{
    public partial class wert2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Apartments_apartmentID",
                table: "Flats");

            migrationBuilder.DropIndex(
                name: "IX_Flats_apartmentID",
                table: "Flats");

            migrationBuilder.AlterColumn<string>(
                name: "apartmentID",
                table: "Flats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Apartments_flatID",
                table: "Flats",
                column: "flatID",
                principalTable: "Apartments",
                principalColumn: "apartmentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Apartments_flatID",
                table: "Flats");

            migrationBuilder.AlterColumn<string>(
                name: "apartmentID",
                table: "Flats",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flats_apartmentID",
                table: "Flats",
                column: "apartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Apartments_apartmentID",
                table: "Flats",
                column: "apartmentID",
                principalTable: "Apartments",
                principalColumn: "apartmentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
