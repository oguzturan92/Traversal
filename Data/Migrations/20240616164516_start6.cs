﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class start6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DestinationId",
                table: "Reservations",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Destinations_DestinationId",
                table: "Reservations",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Destinations_DestinationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_DestinationId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Reservations");
        }
    }
}
