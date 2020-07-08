using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2.Data.Migrations
{
    public partial class ver3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Address_IdAdress",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Students_IdAdress",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AddressDetails",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Students",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "AddressDetails",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Commune = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    District = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdAdress",
                table: "Students",
                column: "IdAdress");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Address_IdAdress",
                table: "Students",
                column: "IdAdress",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
