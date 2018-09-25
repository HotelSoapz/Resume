﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ResumeBuilderContext.Data;
using System;

namespace ResumeBuilderContext.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180915160437_fix5")]
    partial class fix5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.Applicant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("StreedAddress")
                        .IsRequired();

                    b.Property<string>("Summary")
                        .IsRequired();

                    b.Property<string>("ZipCode")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Applicant");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.Duties", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("JobHistoryID");

                    b.Property<int?>("PositionID");

                    b.HasKey("ID");

                    b.HasIndex("JobHistoryID");

                    b.HasIndex("PositionID");

                    b.ToTable("Duties");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.Education", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApplicantID");

                    b.Property<string>("Degree");

                    b.Property<string>("FieldOfStudy")
                        .IsRequired();

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("School")
                        .IsRequired();

                    b.Property<string>("gradMonth");

                    b.Property<string>("gradYear")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ApplicantID");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.JobHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApplicantID");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<bool>("CurrentlyEmployed");

                    b.Property<string>("Employer")
                        .IsRequired();

                    b.Property<string>("EndMonth");

                    b.Property<string>("EndYear");

                    b.Property<string>("StartMonth");

                    b.Property<string>("StartYear")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ApplicantID");

                    b.ToTable("JobHistory");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.Portfolio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApplicantID");

                    b.Property<string>("Link1");

                    b.Property<string>("Link2");

                    b.Property<string>("Link3");

                    b.HasKey("ID");

                    b.HasIndex("ApplicantID");

                    b.ToTable("Portfolio");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.Position", b =>
                {
                    b.Property<int>("PositionID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CurrentPosition");

                    b.Property<DateTime>("EndDate");

                    b.Property<int?>("JobHistoriesID");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title");

                    b.HasKey("PositionID");

                    b.HasIndex("JobHistoriesID");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.References", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApplicantID");

                    b.Property<string>("CompanyName");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("RefferenceName")
                        .IsRequired();

                    b.Property<string>("Relation")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ApplicantID");

                    b.ToTable("References");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.Skills", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApplicantID");

                    b.Property<string>("Function");

                    b.Property<string>("Source");

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.HasIndex("ApplicantID");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ResumeBuilderContext.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ResumeBuilderContext.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ResumeBuilderContext.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ResumeBuilderContext.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.Duties", b =>
                {
                    b.HasOne("ResumeBuilderContext.Models.JobHistory")
                        .WithMany("Duties")
                        .HasForeignKey("JobHistoryID");

                    b.HasOne("ResumeBuilderContext.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionID");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.Education", b =>
                {
                    b.HasOne("ResumeBuilderContext.Models.Applicant", "Applicant")
                        .WithMany("Education")
                        .HasForeignKey("ApplicantID");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.JobHistory", b =>
                {
                    b.HasOne("ResumeBuilderContext.Models.Applicant", "Applicant")
                        .WithMany("JobHistory")
                        .HasForeignKey("ApplicantID");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.Portfolio", b =>
                {
                    b.HasOne("ResumeBuilderContext.Models.Applicant", "Applicant")
                        .WithMany("Portfolio")
                        .HasForeignKey("ApplicantID");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.Position", b =>
                {
                    b.HasOne("ResumeBuilderContext.Models.JobHistory", "JobHistories")
                        .WithMany("Positions")
                        .HasForeignKey("JobHistoriesID");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.References", b =>
                {
                    b.HasOne("ResumeBuilderContext.Models.Applicant", "Applicant")
                        .WithMany("References")
                        .HasForeignKey("ApplicantID");
                });

            modelBuilder.Entity("ResumeBuilderContext.Models.Skills", b =>
                {
                    b.HasOne("ResumeBuilderContext.Models.Applicant", "Applicant")
                        .WithMany("Skills")
                        .HasForeignKey("ApplicantID");
                });
#pragma warning restore 612, 618
        }
    }
}
