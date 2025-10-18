using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Added_BusWidth_and_CudaCores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusWidth",
                table: "Gpus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CudaCores",
                table: "Gpus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusWidth",
                table: "Gpus");

            migrationBuilder.DropColumn(
                name: "CudaCores",
                table: "Gpus");
        }
    }
}
