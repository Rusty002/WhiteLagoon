using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VillaName",
                table: "Villas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    Villa_Number = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.Villa_Number);
                    table.ForeignKey(
                        name: "FK_VillaNumbers_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "VillaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VillaNumbers",
                columns: new[] { "Villa_Number", "SpecialDetails", "VillaId" },
                values: new object[,]
                {
                    { 101, null, new Guid("18198d77-55fb-4d9a-b14d-e8f9f3f6fa28") },
                    { 102, null, new Guid("18198d77-55fb-4d9a-b14d-e8f9f3f6fa28") },
                    { 103, null, new Guid("18198d77-55fb-4d9a-b14d-e8f9f3f6fa28") },
                    { 201, null, new Guid("3a0ba39a-21c1-4f88-8a41-cad14d244f2c") },
                    { 202, null, new Guid("3a0ba39a-21c1-4f88-8a41-cad14d244f2c") },
                    { 203, null, new Guid("3a0ba39a-21c1-4f88-8a41-cad14d244f2c") },
                    { 301, null, new Guid("83698710-a57a-4c23-bb22-bee22a86a173") },
                    { 302, null, new Guid("83698710-a57a-4c23-bb22-bee22a86a173") },
                    { 303, null, new Guid("83698710-a57a-4c23-bb22-bee22a86a173") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.AlterColumn<string>(
                name: "VillaName",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
