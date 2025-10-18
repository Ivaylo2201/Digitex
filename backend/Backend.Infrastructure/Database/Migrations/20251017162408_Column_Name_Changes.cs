using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Column_Name_Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Products",
                newName: "ModelName");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Model",
                table: "Products",
                newName: "IX_Products_ModelName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brands",
                newName: "BrandName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModelName",
                table: "Products",
                newName: "Model");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ModelName",
                table: "Products",
                newName: "IX_Products_Model");

            migrationBuilder.RenameColumn(
                name: "BrandName",
                table: "Brands",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
