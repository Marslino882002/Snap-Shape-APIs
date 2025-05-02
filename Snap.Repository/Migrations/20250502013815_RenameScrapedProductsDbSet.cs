using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snap.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RenameScrapedProductsDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_scrapedProducts",
                table: "scrapedProducts");

            migrationBuilder.RenameTable(
                name: "scrapedProducts",
                newName: "ScrapedProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScrapedProducts",
                table: "ScrapedProducts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ScrapedProducts",
                table: "ScrapedProducts");

            migrationBuilder.RenameTable(
                name: "ScrapedProducts",
                newName: "scrapedProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_scrapedProducts",
                table: "scrapedProducts",
                column: "Id");
        }
    }
}
