using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLoanManagementSystem.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: false),
                    Answer = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Mobile = table.Column<long>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Mobile);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false),
                    Mobile = table.Column<long>(nullable: false),
                    PropertyType = table.Column<string>(nullable: false),
                    PropertyCost = table.Column<decimal>(type: "Decimal(10,6)", nullable: false),
                    Salary = table.Column<decimal>(type: "Decimal(10,6)", nullable: false),
                    EmployeeType = table.Column<string>(nullable: false),
                    PropertyAddress = table.Column<string>(nullable: false),
                    LoanAmount = table.Column<decimal>(type: "Decimal(10,6)", nullable: false),
                    EMI = table.Column<decimal>(type: "Decimal(10,6)", nullable: false),
                    Tenure = table.Column<float>(nullable: false),
                    ApplicationDate = table.Column<DateTime>(nullable: false),
                    ApplicationStatus = table.Column<string>(nullable: false),
                    PermanentAddress = table.Column<string>(nullable: false),
                    AadharNo = table.Column<long>(nullable: false),
                    RateOfInterest = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Applications_Users_Mobile",
                        column: x => x.Mobile,
                        principalTable: "Users",
                        principalColumn: "Mobile",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanNo = table.Column<int>(nullable: false),
                    ReqId = table.Column<int>(nullable: false),
                    LoanStatus = table.Column<string>(nullable: true),
                    ApprovedAmount = table.Column<decimal>(type: "Decimal(10,6)", nullable: false),
                    LoanStartDate = table.Column<DateTime>(nullable: false),
                    LoanEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanNo);
                    table.ForeignKey(
                        name: "FK_Loans_Applications_ReqId",
                        column: x => x.ReqId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_Mobile",
                table: "Applications",
                column: "Mobile");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ReqId",
                table: "Loans",
                column: "ReqId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
