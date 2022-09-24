using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLoanManagementSystem.Migrations
{
    public partial class AddedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Mobile",
                table: "Applications",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_Mobile",
                table: "Applications",
                column: "Mobile");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_Mobile",
                table: "Applications",
                column: "Mobile",
                principalTable: "Users",
                principalColumn: "Mobile",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_Mobile",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_Mobile",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Applications");
        }
    }
}
