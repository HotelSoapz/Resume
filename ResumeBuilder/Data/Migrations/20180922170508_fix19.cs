using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResumeBuilderContext.Data.Migrations
{
    public partial class fix19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Position_JobHistory_JobHistoriesID",
            //    table: "Position");

            migrationBuilder.RenameColumn(
                name: "JobHistoriesID",
                table: "Position",
                newName: "JobHistoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Position_JobHistoriesID",
                table: "Position",
                newName: "IX_Position_JobHistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_JobHistory_JobHistoryID",
                table: "Position",
                column: "JobHistoryID",
                principalTable: "JobHistory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_JobHistory_JobHistoryID",
                table: "Position");

            migrationBuilder.RenameColumn(
                name: "JobHistoryID",
                table: "Position",
                newName: "JobHistoriesID");

            migrationBuilder.RenameIndex(
                name: "IX_Position_JobHistoryID",
                table: "Position",
                newName: "IX_Position_JobHistoriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_JobHistory_JobHistoriesID",
                table: "Position",
                column: "JobHistoriesID",
                principalTable: "JobHistory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
