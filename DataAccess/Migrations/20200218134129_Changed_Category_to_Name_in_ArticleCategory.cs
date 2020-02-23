using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Changed_Category_to_Name_in_ArticleCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleCategory",
                table: "ArticleCategory");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "ArticleCategory");

            migrationBuilder.RenameTable(
                name: "ArticleCategory",
                newName: "ArticleCategories");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ArticleCategories",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleCategories",
                table: "ArticleCategories",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleCategories",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ArticleCategories");

            migrationBuilder.RenameTable(
                name: "ArticleCategories",
                newName: "ArticleCategory");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ArticleCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleCategory",
                table: "ArticleCategory",
                column: "Id");
        }
    }
}
