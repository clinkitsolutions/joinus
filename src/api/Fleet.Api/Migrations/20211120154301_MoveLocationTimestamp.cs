using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fleet.Api.Migrations
{
    public partial class MoveLocationTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "VehicleLogItems",
                newName: "Location_Timestamp");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastKnownLocation_Timestamp",
                table: "Vehicles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 1, "Truck#1", "Truck" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "LastKnownLocation_Timestamp",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "Location_Timestamp",
                table: "VehicleLogItems",
                newName: "Timestamp");
        }
    }
}
