using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("050732a9-a713-4a04-8d5e-bbea1071d2ba"), "Medium" },
                    { new Guid("5545d75c-c7b9-46f0-8cdc-da8ba031834e"), "Hard" },
                    { new Guid("f48e5244-7c7d-4b6f-bb03-b733aafe2d8b"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0c94d031-048e-4c8a-8ec8-193e1d00efda"), "NZ-NL", "Northland", "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/northland/northland-forest.jpg" },
                    { new Guid("b608b9cf-f90b-4890-993d-bca73b0e3a0e"), "NZ-WK", "Waikato", "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/waikato/waikato-forest.jpg" },
                    { new Guid("c290cdd9-dff8-40b3-b714-f1eaae755b9a"), "NZ-AK", "Auckland", "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-forest.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("050732a9-a713-4a04-8d5e-bbea1071d2ba"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5545d75c-c7b9-46f0-8cdc-da8ba031834e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f48e5244-7c7d-4b6f-bb03-b733aafe2d8b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0c94d031-048e-4c8a-8ec8-193e1d00efda"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b608b9cf-f90b-4890-993d-bca73b0e3a0e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c290cdd9-dff8-40b3-b714-f1eaae755b9a"));
        }
    }
}
