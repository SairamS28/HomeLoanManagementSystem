﻿// <auto-generated />
using System;
using HomeLoanManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeLoanManagementSystem.Migrations
{
    [DbContext(typeof(CodeFirstContext))]
    [Migration("20220926070108_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeLoanManagementSystem.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("HomeLoanManagementSystem.Models.Application", b =>
                {
                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<long>("AadharNo")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApplicationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("EMI")
                        .HasColumnType("Decimal(10,6)");

                    b.Property<string>("EmployeeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LoanAmount")
                        .HasColumnType("Decimal(10,6)");

                    b.Property<long>("Mobile")
                        .HasColumnType("bigint");

                    b.Property<string>("PermanentAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PropertyCost")
                        .HasColumnType("Decimal(10,6)");

                    b.Property<string>("PropertyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("RateOfInterest")
                        .HasColumnType("real");

                    b.Property<decimal>("Salary")
                        .HasColumnType("Decimal(10,6)");

                    b.Property<float>("Tenure")
                        .HasColumnType("real");

                    b.HasKey("ApplicationId");

                    b.HasIndex("Mobile");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("HomeLoanManagementSystem.Models.FAQ", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FAQs");
                });

            modelBuilder.Entity("HomeLoanManagementSystem.Models.Loan", b =>
                {
                    b.Property<int>("LoanNo")
                        .HasColumnType("int");

                    b.Property<decimal>("ApprovedAmount")
                        .HasColumnType("Decimal(10,6)");

                    b.Property<DateTime>("LoanEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LoanStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LoanStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReqId")
                        .HasColumnType("int");

                    b.HasKey("LoanNo");

                    b.HasIndex("ReqId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("HomeLoanManagementSystem.Models.User", b =>
                {
                    b.Property<long>("Mobile")
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Mobile");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HomeLoanManagementSystem.Models.Application", b =>
                {
                    b.HasOne("HomeLoanManagementSystem.Models.User", "user")
                        .WithMany("application")
                        .HasForeignKey("Mobile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomeLoanManagementSystem.Models.Loan", b =>
                {
                    b.HasOne("HomeLoanManagementSystem.Models.Application", "application")
                        .WithMany("loans")
                        .HasForeignKey("ReqId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
