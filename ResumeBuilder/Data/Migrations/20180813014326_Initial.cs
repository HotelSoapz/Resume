using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResumeBuilderContext.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    StreedAddress = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicantID = table.Column<int>(nullable: true),
                    Degree = table.Column<string>(nullable: false),
                    FieldOfStudy = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    School = table.Column<string>(nullable: false),
                    gradMonth = table.Column<DateTime>(nullable: true),
                    gradYear = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Education_Applicant_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobHistory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicantID = table.Column<int>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    CurrentlyEmployed = table.Column<bool>(nullable: false),
                    Employer = table.Column<string>(nullable: false),
                    EndMonth = table.Column<DateTime>(nullable: true),
                    EndYear = table.Column<DateTime>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    StartMonth = table.Column<DateTime>(nullable: true),
                    StartYear = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JobHistory_Applicant_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicantID = table.Column<int>(nullable: true),
                    Link1 = table.Column<string>(nullable: true),
                    Link2 = table.Column<string>(nullable: true),
                    Link3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Portfolio_Applicant_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicantID = table.Column<int>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    RefferenceName = table.Column<string>(nullable: false),
                    Relation = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.ID);
                    table.ForeignKey(
                        name: "FK_References_Applicant_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicantID = table.Column<int>(nullable: true),
                    Function = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Skills_Applicant_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Education_ApplicantID",
                table: "Education",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistory_ApplicantID",
                table: "JobHistory",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_ApplicantID",
                table: "Portfolio",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_References_ApplicantID",
                table: "References",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ApplicantID",
                table: "Skills",
                column: "ApplicantID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "JobHistory");

            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Applicant");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
