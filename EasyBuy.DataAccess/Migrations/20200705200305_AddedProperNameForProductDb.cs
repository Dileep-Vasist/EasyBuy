using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBuy.DataAccess.Migrations
{
    public partial class AddedProperNameForProductDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desrcription",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Desrcription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
