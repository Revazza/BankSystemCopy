using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankSystem.Common.Migrations
{
    /// <inheritdoc />
    public partial class seedMethodAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserClaim<string>");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3f66ed5d-b94b-46a7-a9c3-9a564241708f"), null, "api-operator", "API-OPERATOR" },
                    { new Guid("f5c38744-072b-4785-9c6d-db48ac043b7f"), null, "api-user", "API-USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt" },
                values: new object[] { new DateTime(2013, 3, 24, 12, 6, 14, 189, DateTimeKind.Local).AddTicks(9444), "6656017d-4104-452c-87f0-42753a84de18", "AAdAYZpWUuJntJr31Y0RoBno+4YndMgSj9Kj4KC0TdiHBPukhFpsB+kZSNyZrOSBOA==", "846309928", new DateTime(2023, 3, 24, 12, 6, 14, 189, DateTimeKind.Local).AddTicks(9446) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt" },
                values: new object[] { new DateTime(2013, 3, 24, 12, 6, 14, 189, DateTimeKind.Local).AddTicks(2966), "340637a9-0420-49c2-a35a-eb559a9218cd", "APx7ZC+Tek02kpltCXUU8sinrc/Q11SwTmIX7nbcdG76vR+qJS/5x9GVcNYVKb9ZLA==", "885498583", new DateTime(2023, 3, 24, 12, 6, 14, 189, DateTimeKind.Local).AddTicks(3005) });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f5c38744-072b-4785-9c6d-db48ac043b7f"), new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4") },
                    { new Guid("3f66ed5d-b94b-46a7-a9c3-9a564241708f"), new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f5c38744-072b-4785-9c6d-db48ac043b7f"), new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3f66ed5d-b94b-46a7-a9c3-9a564241708f"), new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f66ed5d-b94b-46a7-a9c3-9a564241708f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5c38744-072b-4785-9c6d-db48ac043b7f"));

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim<string>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"),
                column: "Amount",
                value: 16743m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                column: "Amount",
                value: 15029m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt" },
                values: new object[] { new DateTime(2013, 3, 24, 11, 45, 48, 436, DateTimeKind.Local).AddTicks(9525), "9f5f5e3c-71ec-42c3-b696-4f97a66f4d68", "AN8AbpZy/FKEyyleN4rBLJjaq2ycIKOC0SoBBQgtLIhEDA5oDqEFtsFW+twTKVJ3+w==", "402731798", new DateTime(2023, 3, 24, 11, 45, 48, 436, DateTimeKind.Local).AddTicks(9527) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt" },
                values: new object[] { new DateTime(2013, 3, 24, 11, 45, 48, 436, DateTimeKind.Local).AddTicks(3016), "4bf84c48-eccf-48a2-a602-9f5a5752b369", "ADWrbQTVB9/iBdaYtcX1HjtBdrilpgaitaYza/tPI1adg13F9HfUhdYeR22YOhesXg==", "221281388", new DateTime(2023, 3, 24, 11, 45, 48, 436, DateTimeKind.Local).AddTicks(3054) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "380555904985575874", new DateTime(2023, 3, 24, 11, 45, 48, 437, DateTimeKind.Local).AddTicks(5765), new DateTime(2028, 3, 24, 11, 45, 48, 437, DateTimeKind.Local).AddTicks(5762) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "66644372658638451", new DateTime(2023, 3, 24, 11, 45, 48, 437, DateTimeKind.Local).AddTicks(5779), new DateTime(2028, 3, 24, 11, 45, 48, 437, DateTimeKind.Local).AddTicks(5778) });

            migrationBuilder.InsertData(
                table: "IdentityUserClaim<string>",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "role", "api-user", "0eb288d0-c7cd-4749-ad29-92a9d59e8bf4" },
                    { 2, "role", "api-admin", "0eb288d0-c7cd-4749-ad29-92a9d59e8bf4" }
                });
        }
    }
}
