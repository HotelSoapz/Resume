using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResumeBuilderContext.Data.Migrations
{
    public partial class fix9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Duties_JobHistory_JobHistoryID",
            //    table: "Duties");

            //migrationBuilder.DropColumn(
            //    name: "JobHistoryID",
            //    table: "Duties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "JobHistoryID",
            //    table: "Duties",
            //    nullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Duties_JobHistory_JobHistoryID",
            //    table: "Duties",
            //    column: "JobHistoryID",
            //    principalTable: "JobHistory",
            //    principalColumn: "ID",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
