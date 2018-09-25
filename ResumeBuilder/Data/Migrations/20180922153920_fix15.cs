using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResumeBuilderContext.Data.Migrations
{
    public partial class fix15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Function",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Skills",
                newName: "Skill");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Skill",
                table: "Skills",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Function",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Skills",
                nullable: true);
        }
    }
}
