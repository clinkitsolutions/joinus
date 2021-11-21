using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fleet.Api.Migrations
{
    public partial class RemoveLastKnownLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastKnownLocation_Latitude",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "LastKnownLocation_Longitude",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "LastKnownLocation_Timestamp",
                table: "Vehicles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "LastKnownLocation_Latitude",
                table: "Vehicles",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LastKnownLocation_Longitude",
                table: "Vehicles",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastKnownLocation_Timestamp",
                table: "Vehicles",
                type: "TEXT",
                nullable: true);
        }
    }
}
