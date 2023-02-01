using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusPassManagementSystem.Migrations
{
    public partial class removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "ApplyPasses");

            migrationBuilder.DropColumn(
                name: "PassCreationDate",
                table: "ApplyPasses");

            migrationBuilder.DropColumn(
                name: "Todate",
                table: "ApplyPasses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "ApplyPasses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PassCreationDate",
                table: "ApplyPasses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Todate",
                table: "ApplyPasses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
