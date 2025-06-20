using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snap.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addFoodDetectionResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_weightCalorieRecords",
                table: "weightCalorieRecords");

            migrationBuilder.RenameTable(
                name: "weightCalorieRecords",
                newName: "WeightCalorieRecords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeightCalorieRecords",
                table: "WeightCalorieRecords",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FoodDetectionResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetectedObjects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FreshnessStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDetectionResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodDetectionResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeightCalorieRecords",
                table: "WeightCalorieRecords");

            migrationBuilder.RenameTable(
                name: "WeightCalorieRecords",
                newName: "weightCalorieRecords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_weightCalorieRecords",
                table: "weightCalorieRecords",
                column: "Id");
        }
    }
}
