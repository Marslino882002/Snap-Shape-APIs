using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snap.Repository.Migrations
{
    /// <inheritdoc />
    public partial class mergedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "foodDetectionResultV2s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foodDetectionResultV2s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "foodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Freshness = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WeightGrams = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    FoodDetectionResultV2Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_foodItems_foodDetectionResultV2s_FoodDetectionResultV2Id",
                        column: x => x.FoodDetectionResultV2Id,
                        principalTable: "foodDetectionResultV2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_foodItems_FoodDetectionResultV2Id",
                table: "foodItems",
                column: "FoodDetectionResultV2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "foodItems");

            migrationBuilder.DropTable(
                name: "foodDetectionResultV2s");
        }
    }
}
