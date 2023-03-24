using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Common.Migrations
{
    /// <inheritdoc />
    public partial class securityStampAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"),
                column: "Amount",
                value: 17482m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                column: "Amount",
                value: 16732m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt", "SecurityStamp" },
                values: new object[] { new DateTime(2013, 3, 24, 12, 34, 5, 297, DateTimeKind.Local).AddTicks(1912), "aca5b912-0208-41a1-a112-835e469401b6", "AJqxKiMsjo4xitKese4QCZ82lry14vK+Yqy0dt5w+Cx7SEYm00dIH8cknKL723cXew==", "988519492", new DateTime(2023, 3, 24, 12, 34, 5, 297, DateTimeKind.Local).AddTicks(1914), "efb46368-8318-4eee-898b-4f14c4b249c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt", "SecurityStamp" },
                values: new object[] { new DateTime(2013, 3, 24, 12, 34, 5, 296, DateTimeKind.Local).AddTicks(4792), "e8dbf110-ce8c-4539-8c18-c1448b812058", "AAgyze9KGcHSaRHWopupBuolEDj+Szu9v1hBNSptZdaBJAj0vc3uUKyi1MEzF+/QKg==", "513177349", new DateTime(2023, 3, 24, 12, 34, 5, 296, DateTimeKind.Local).AddTicks(4834), "8974ab31-17db-4493-88b9-32ad9427e9c3" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "897958892390395434", new DateTime(2023, 3, 24, 12, 34, 5, 297, DateTimeKind.Local).AddTicks(8313), new DateTime(2028, 3, 24, 12, 34, 5, 297, DateTimeKind.Local).AddTicks(8310) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "322185542286128424", new DateTime(2023, 3, 24, 12, 34, 5, 297, DateTimeKind.Local).AddTicks(8326), new DateTime(2028, 3, 24, 12, 34, 5, 297, DateTimeKind.Local).AddTicks(8325) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"),
                column: "Amount",
                value: 11973m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                column: "Amount",
                value: 13722m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt", "SecurityStamp" },
                values: new object[] { new DateTime(2013, 3, 24, 12, 6, 14, 189, DateTimeKind.Local).AddTicks(9444), "6656017d-4104-452c-87f0-42753a84de18", "AAdAYZpWUuJntJr31Y0RoBno+4YndMgSj9Kj4KC0TdiHBPukhFpsB+kZSNyZrOSBOA==", "846309928", new DateTime(2023, 3, 24, 12, 6, 14, 189, DateTimeKind.Local).AddTicks(9446), null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt", "SecurityStamp" },
                values: new object[] { new DateTime(2013, 3, 24, 12, 6, 14, 189, DateTimeKind.Local).AddTicks(2966), "340637a9-0420-49c2-a35a-eb559a9218cd", "APx7ZC+Tek02kpltCXUU8sinrc/Q11SwTmIX7nbcdG76vR+qJS/5x9GVcNYVKb9ZLA==", "885498583", new DateTime(2023, 3, 24, 12, 6, 14, 189, DateTimeKind.Local).AddTicks(3005), null });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "431672205737673841", new DateTime(2023, 3, 24, 12, 6, 14, 190, DateTimeKind.Local).AddTicks(7537), new DateTime(2028, 3, 24, 12, 6, 14, 190, DateTimeKind.Local).AddTicks(7524) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "603495188148140207", new DateTime(2023, 3, 24, 12, 6, 14, 190, DateTimeKind.Local).AddTicks(7560), new DateTime(2028, 3, 24, 12, 6, 14, 190, DateTimeKind.Local).AddTicks(7558) });
        }
    }
}
