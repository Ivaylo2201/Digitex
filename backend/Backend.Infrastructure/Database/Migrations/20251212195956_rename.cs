using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Currencies_IsoCode",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "IsoCode",
                table: "Currencies");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyIsoCode",
                table: "Currencies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyIsoCode",
                table: "Currencies");

            migrationBuilder.AddColumn<string>(
                name: "IsoCode",
                table: "Currencies",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_IsoCode",
                table: "Currencies",
                column: "IsoCode",
                unique: true);
        }
    }
}
