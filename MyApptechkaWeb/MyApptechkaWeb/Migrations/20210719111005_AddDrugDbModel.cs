using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApptechkaWeb.Migrations
{
    public partial class AddDrugDbModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Form = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Residue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AptechkaOwnerId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drugs_Aptechkas_AptechkaOwnerId",
                        column: x => x.AptechkaOwnerId,
                        principalTable: "Aptechkas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_AptechkaOwnerId",
                table: "Drugs",
                column: "AptechkaOwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drugs");
        }
    }
}
