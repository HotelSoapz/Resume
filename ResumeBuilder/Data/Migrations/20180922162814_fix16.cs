using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResumeBuilderContext.Data.Migrations
{
    public partial class fix16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Duties_Position_PositionID",
            //    table: "Duties");

            migrationBuilder.AlterColumn<int>(
                name: "PositionID",
                table: "Duties",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Duties_Position_PositionID",
                table: "Duties",
                column: "PositionID",
                principalTable: "Position",
                principalColumn: "PositionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duties_Position_PositionID",
                table: "Duties");

            migrationBuilder.AlterColumn<int>(
                name: "PositionID",
                table: "Duties",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Duties_Position_PositionID",
                table: "Duties",
                column: "PositionID",
                principalTable: "Position",
                principalColumn: "PositionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
