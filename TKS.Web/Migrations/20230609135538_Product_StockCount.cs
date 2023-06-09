using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKS.Web.Migrations
{
    /// <inheritdoc />
    public partial class Product_StockCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockCount",
                table: "Product",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockCount",
                table: "Product");
        }
    }
}
