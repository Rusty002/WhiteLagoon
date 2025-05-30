using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVillasTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    VillaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VillaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VillaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillaPrice = table.Column<double>(type: "float", nullable: false),
                    VillaSizeInSquareFeet = table.Column<int>(type: "int", nullable: false),
                    VillaOccupancy = table.Column<int>(type: "int", nullable: false),
                    VillaImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillaCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VillaUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.VillaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
