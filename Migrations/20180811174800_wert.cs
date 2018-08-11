using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NeighborFoodBackend.Migrations
{
    public partial class wert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "apartmentID",
                table: "Flats",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
