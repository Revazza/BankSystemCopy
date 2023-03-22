using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Common.Migrations
{
    /// <inheritdoc />
    public partial class operatorAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Operators",
                keyColumn: "Id",
                keyValue: new Guid("8f5f5990-2d11-455f-8b40-5767c7a5545d"));

            migrationBuilder.InsertData(
                table: "Operators",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f84fe304-72c9-4513-8c46-f9da7529f1f7"), "ana" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Operators",
                keyColumn: "Id",
                keyValue: new Guid("f84fe304-72c9-4513-8c46-f9da7529f1f7"));

            migrationBuilder.InsertData(
                table: "Operators",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8f5f5990-2d11-455f-8b40-5767c7a5545d"), "ana" });
        }
    }
}
