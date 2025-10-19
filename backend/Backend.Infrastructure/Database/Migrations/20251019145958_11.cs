using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class _11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cpus_Products_Id",
                table: "Cpus");

            migrationBuilder.DropForeignKey(
                name: "FK_Gpus_Products_Id",
                table: "Gpus");

            migrationBuilder.DropForeignKey(
                name: "FK_Rams_Products_Id",
                table: "Rams");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rams",
                table: "Rams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gpus",
                table: "Gpus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cpus",
                table: "Cpus");

            migrationBuilder.RenameTable(
                name: "Rams",
                newName: "RAMs");

            migrationBuilder.RenameTable(
                name: "Gpus",
                newName: "GPUs");

            migrationBuilder.RenameTable(
                name: "Cpus",
                newName: "CPUs");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Countries",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RAMs",
                table: "RAMs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GPUs",
                table: "GPUs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CPUs",
                table: "CPUs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HDDs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CapacityInTb = table.Column<int>(type: "int", nullable: false),
                    Rpm = table.Column<int>(type: "int", nullable: false),
                    CacheInMb = table.Column<int>(type: "int", nullable: false),
                    Interface = table.Column<int>(type: "int", nullable: false),
                    FormFactor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HDDs_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SSDs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CapacityInGb = table.Column<int>(type: "int", nullable: false),
                    StorageInterface = table.Column<int>(type: "int", nullable: false),
                    FormFactor = table.Column<int>(type: "int", nullable: false),
                    ReadSpeed = table.Column<int>(type: "int", nullable: false),
                    WriteSpeed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SSDs_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_Products_Id",
                table: "CPUs",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Products_Id",
                table: "GPUs",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RAMs_Products_Id",
                table: "RAMs",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_Products_Id",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Products_Id",
                table: "GPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_RAMs_Products_Id",
                table: "RAMs");

            migrationBuilder.DropTable(
                name: "HDDs");

            migrationBuilder.DropTable(
                name: "SSDs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RAMs",
                table: "RAMs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GPUs",
                table: "GPUs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CPUs",
                table: "CPUs");

            migrationBuilder.RenameTable(
                name: "RAMs",
                newName: "Rams");

            migrationBuilder.RenameTable(
                name: "GPUs",
                newName: "Gpus");

            migrationBuilder.RenameTable(
                name: "CPUs",
                newName: "Cpus");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rams",
                table: "Rams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gpus",
                table: "Gpus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cpus",
                table: "Cpus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MemoryCapacity = table.Column<int>(type: "int", nullable: false),
                    MemoryFrequency = table.Column<int>(type: "int", nullable: false),
                    MemoryType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storages_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cpus_Products_Id",
                table: "Cpus",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gpus_Products_Id",
                table: "Gpus",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rams_Products_Id",
                table: "Rams",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
