using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResumeBuilderContext.Data.Migrations
{
    public partial class fix11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "gradYear",
                table: "Education",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "gradYear",
                table: "Education",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
