using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Added_ArticleCategory_in_Article : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "ArticleCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_ArticleId",
                table: "ArticleCategories",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategories_Articles_ArticleId",
                table: "ArticleCategories",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleCategories_CategoryId",
                table: "Articles",
                column: "CategoryId",
                principalTable: "ArticleCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_Articles_ArticleId",
                table: "ArticleCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleCategories_CategoryId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_ArticleCategories_ArticleId",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "ArticleCategories");
        }
    }
}
