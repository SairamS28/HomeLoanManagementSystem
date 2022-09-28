using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLoanManagementSystem.Migrations
{
    public partial class Decimaldatatypechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Applications",
                type: "Decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PropertyCost",
                table: "Applications",
                type: "Decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "LoanAmount",
                table: "Applications",
                type: "Decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EMI",
                table: "Applications",
                type: "Decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Applications",
                type: "Decimal(10,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PropertyCost",
                table: "Applications",
                type: "Decimal(10,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "LoanAmount",
                table: "Applications",
                type: "Decimal(10,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EMI",
                table: "Applications",
                type: "Decimal(10,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,2)");
        }
    }
}
