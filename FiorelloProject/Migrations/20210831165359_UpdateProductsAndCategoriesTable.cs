using Microsoft.EntityFrameworkCore.Migrations;

namespace FiorelloProject.Migrations
{
    public partial class UpdateProductsAndCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Products",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Products",
                newName: "title");
        }
    }
}
