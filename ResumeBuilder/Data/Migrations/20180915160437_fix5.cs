using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResumeBuilderContext.Data.Migrations
{
    public partial class fix5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobHistoriesID",
                table: "Position",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Position_JobHistoriesID",
                table: "Position",
                column: "JobHistoriesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "JobHistoriesID",
               table: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Position_JobHistoriesID",
                table: "Position");
        }
    }
}
