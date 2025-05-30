using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedVillaToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "VillaId", "VillaCreatedDate", "VillaDescription", "VillaImageUrl", "VillaName", "VillaOccupancy", "VillaPrice", "VillaSizeInSquareFeet", "VillaUpdatedDate" },
                values: new object[,]
                {
                    { new Guid("18198d77-55fb-4d9a-b14d-e8f9f3f6fa28"), null, "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://placehold.co/600x400", "Royal Villa", 4, 200.0, 550, null },
                    { new Guid("3a0ba39a-21c1-4f88-8a41-cad14d244f2c"), null, "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://placehold.co/600x401", "Premium Pool Villa", 4, 300.0, 550, null },
                    { new Guid("83698710-a57a-4c23-bb22-bee22a86a173"), null, "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://placehold.co/600x402", "Luxury Pool Villa", 4, 400.0, 750, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: new Guid("18198d77-55fb-4d9a-b14d-e8f9f3f6fa28"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: new Guid("3a0ba39a-21c1-4f88-8a41-cad14d244f2c"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: new Guid("83698710-a57a-4c23-bb22-bee22a86a173"));
        }
    }
}
