using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProject.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Count", "Description", "Image", "Name" },
                values: new object[] { 2, 3596, 2, "With its large size and quality edge stitching, this gaming mouse pad turns your gaming setup into a professional gaming station ready for Dota, CSGO, and more. Don’t worry about jerky mouse movements ever again, as the under layer features a reliable non-slip surface that keeps the entire mat firmly rooted to your table.", "\\img\\ChibiMirana_Mousepad", "ChibiMirana_Mousepad" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
