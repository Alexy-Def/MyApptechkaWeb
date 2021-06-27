using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApptechkaWeb.Migrations
{
    public partial class RemoveConfirmPassAndAddPhoneToUserDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfirmedPassword",
                table: "Users",
                newName: "Phone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "ConfirmedPassword");
        }
    }
}
