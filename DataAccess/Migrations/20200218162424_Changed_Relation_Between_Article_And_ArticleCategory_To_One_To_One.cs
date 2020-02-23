using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Changed_Relation_Between_Article_And_ArticleCategory_To_One_To_One : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_Articles_ArticleId",
                table: "ArticleCategories");

            migrationBuilder.DropIndex(
                name: "IX_ArticleCategories_ArticleId",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "ArticleCategories");

            migrationBuilder.AddColumn<int>(
                name: "ArticleCategoryId",
                table: "Articles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleCategories_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId",
                principalTable: "ArticleCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleCategories_ArticleCategoryId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ArticleCategoryId",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "ArticleCategories",
                type: "int",
                nullable: true);

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
        }
    }
}
