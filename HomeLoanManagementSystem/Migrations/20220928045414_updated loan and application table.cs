using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLoanManagementSystem.Migrations
{
    public partial class updatedloanandapplicationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ApprovedAmount",
                table: "Loans",
                type: "Decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,6)");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Applications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Applications");

            migrationBuilder.AlterColumn<decimal>(
                name: "ApprovedAmount",
                table: "Loans",
                type: "Decimal(10,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,2)");
        }
    }
}
