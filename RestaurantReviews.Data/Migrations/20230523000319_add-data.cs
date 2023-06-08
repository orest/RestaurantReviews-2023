using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReviews.Data.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "CuisineCode", "CssClass", "Description", "DisplayName" },
                values: new object[,]
                {
                    { "American", null, "American", "American" },
                    { "Chinese", null, "Chinese", "Chinese" },
                    { "French", null, "French", "French" },
                    { "Healthy", null, "Healthy", "Healthy" },
                    { "Indian", null, "Indian Food", "Indian" },
                    { "Italian", null, "Italian Food", "Italian" },
                    { "Mexican", null, "Mexican", "Mexican" },
                    { "Pizza", null, "Pizza", "Pizza" },
                    { "Russian", null, "Russian", "Russian" },
                    { "Ukrainian", null, "Ukrainian", "Ukrainian" }
                });
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineCode",
                keyValue: "American");

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineCode",
                keyValue: "Chinese");

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineCode",
                keyValue: "French");

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineCode",
                keyValue: "Healthy");

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineCode",
                keyValue: "Indian");

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineCode",
                keyValue: "Italian");

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineCode",
                keyValue: "Mexican");

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineCode",
                keyValue: "Pizza");

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineCode",
                keyValue: "Russian");

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineCode",
                keyValue: "Ukrainian");
        }
    }
}
