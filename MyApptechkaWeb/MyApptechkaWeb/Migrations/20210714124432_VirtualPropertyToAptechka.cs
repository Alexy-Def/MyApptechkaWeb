using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApptechkaWeb.Migrations
{
    public partial class VirtualPropertyToAptechka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OwnerId",
                table: "Aptechkas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aptechkas_OwnerId",
                table: "Aptechkas",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aptechkas_Users_OwnerId",
                table: "Aptechkas",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aptechkas_Users_OwnerId",
                table: "Aptechkas");

            migrationBuilder.DropIndex(
                name: "IX_Aptechkas_OwnerId",
                table: "Aptechkas");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Aptechkas");
        }
    }
}
