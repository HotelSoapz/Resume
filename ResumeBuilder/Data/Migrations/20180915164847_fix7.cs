using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResumeBuilderContext.Data.Migrations
{
    public partial class fix7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionID",
                table: "Duties",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Duties_PositionID",
                table: "Duties",
                column: "PositionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "PositionID",
               table: "Duties");

            migrationBuilder.DropIndex(
                name: "IX_Duties_PositionID",
                table: "Duties");
        }
    }
}
