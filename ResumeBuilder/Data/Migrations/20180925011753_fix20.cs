using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResumeBuilderContext.Data.Migrations
{
    public partial class fix20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Position");

            migrationBuilder.AddColumn<string>(
                name: "EndYear",
                table: "Position",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartYear",
                table: "Position",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndYear",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "StartYear",
                table: "Position");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Position",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Position",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
