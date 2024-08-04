using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sign_up_api.Migrations
{
    /// <inheritdoc />
    public partial class SeedIndustryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyId", "Name" },
                values: new object[,]
                {
                    { new Guid("5ce89290-6ba9-4263-a8d6-1549de9fc6a3"), null, "Telecommunications" },
                    { new Guid("a81e933c-c75c-4cf2-bd88-12f802d1f6e0"), null, "Finance and Banking" },
                    { new Guid("af0ab3be-f51d-43fa-84e2-358eaa6adb9e"), null, "Manufacturing" },
                    { new Guid("dd684a75-8015-4d48-908c-bad475c96568"), null, "Retail and E-commerce" },
                    { new Guid("eac151a3-4f75-4f5a-bd74-324196cdb406"), null, "Healthcare" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("5ce89290-6ba9-4263-a8d6-1549de9fc6a3"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a81e933c-c75c-4cf2-bd88-12f802d1f6e0"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("af0ab3be-f51d-43fa-84e2-358eaa6adb9e"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("dd684a75-8015-4d48-908c-bad475c96568"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("eac151a3-4f75-4f5a-bd74-324196cdb406"));
        }
    }
}
