using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankSystem.Common.Migrations
{
    /// <inheritdoc />
    public partial class deletedOperatorEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.AlterColumn<string>(
                name: "Pin",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "Cvv",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim<string>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                columns: new[] { "BirthDate", "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "PersonalNumber", "RegisteredAt" },
                values: new object[] { new DateTime(2013, 3, 24, 11, 45, 48, 436, DateTimeKind.Local).AddTicks(9525), "9f5f5e3c-71ec-42c3-b696-4f97a66f4d68", "SANDRO.REVAZISHVILIII@GMAIL.COM", "AN8AbpZy/FKEyyleN4rBLJjaq2ycIKOC0SoBBQgtLIhEDA5oDqEFtsFW+twTKVJ3+w==", "402731798", new DateTime(2023, 3, 24, 11, 45, 48, 436, DateTimeKind.Local).AddTicks(9527) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "PersonalNumber", "RegisteredAt" },
                values: new object[] { new DateTime(2013, 3, 24, 11, 45, 48, 436, DateTimeKind.Local).AddTicks(3016), "4bf84c48-eccf-48a2-a602-9f5a5752b369", "ANAMKLAVASHVILI@GMAIL.COM", "ADWrbQTVB9/iBdaYtcX1HjtBdrilpgaitaYza/tPI1adg13F9HfUhdYeR22YOhesXg==", "221281388", new DateTime(2023, 3, 24, 11, 45, 48, 436, DateTimeKind.Local).AddTicks(3054) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"),
                columns: new[] { "CardNumber", "CreatedAt", "Cvv", "ExpiresAt", "Pin" },
                values: new object[] { "380555904985575874", new DateTime(2023, 3, 24, 11, 45, 48, 437, DateTimeKind.Local).AddTicks(5765), "931", new DateTime(2028, 3, 24, 11, 45, 48, 437, DateTimeKind.Local).AddTicks(5762), "1234" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"),
                columns: new[] { "CardNumber", "CreatedAt", "Cvv", "ExpiresAt", "Pin" },
                values: new object[] { "66644372658638451", new DateTime(2023, 3, 24, 11, 45, 48, 437, DateTimeKind.Local).AddTicks(5779), "931", new DateTime(2028, 3, 24, 11, 45, 48, 437, DateTimeKind.Local).AddTicks(5778), "1234" });

            migrationBuilder.InsertData(
                table: "IdentityUserClaim<string>",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "role", "api-user", "0eb288d0-c7cd-4749-ad29-92a9d59e8bf4" },
                    { 2, "role", "api-admin", "0eb288d0-c7cd-4749-ad29-92a9d59e8bf4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserClaim<string>");

            migrationBuilder.AlterColumn<short>(
                name: "Pin",
                table: "Cards",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<short>(
                name: "Cvv",
                table: "Cards",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"),
                column: "Amount",
                value: 14406m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                column: "Amount",
                value: 15081m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "PersonalNumber", "RegisteredAt" },
                values: new object[] { new DateTime(2013, 3, 20, 16, 2, 25, 54, DateTimeKind.Local).AddTicks(1627), "353b960a-0156-4430-9d92-1eec34c61285", null, "ANla6veSyp8y3i3EfmrrC7KhJSQROshaiRqB0kq3iQYXPMLdXxJnQy/effUv/vEEkg==", "128704450", new DateTime(2023, 3, 20, 16, 2, 25, 54, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "PersonalNumber", "RegisteredAt" },
                values: new object[] { new DateTime(2013, 3, 20, 16, 2, 25, 53, DateTimeKind.Local).AddTicks(2938), "e42da717-6b3c-4d67-b970-93465f87845e", null, "AHzl5SqDc7obXHV0WNEoODHBgG8tH5qVRqJg/TvfACrdILwYEu/E/v7cxwdpkG0jkg==", "520756712", new DateTime(2023, 3, 20, 16, 2, 25, 53, DateTimeKind.Local).AddTicks(2961) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"),
                columns: new[] { "CardNumber", "CreatedAt", "Cvv", "ExpiresAt", "Pin" },
                values: new object[] { "210183209919421023", new DateTime(2023, 3, 20, 16, 2, 25, 55, DateTimeKind.Local).AddTicks(585), (short)931, new DateTime(2028, 3, 20, 16, 2, 25, 55, DateTimeKind.Local).AddTicks(577), (short)1234 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"),
                columns: new[] { "CardNumber", "CreatedAt", "Cvv", "ExpiresAt", "Pin" },
                values: new object[] { "92783385625049042", new DateTime(2023, 3, 20, 16, 2, 25, 55, DateTimeKind.Local).AddTicks(594), (short)931, new DateTime(2028, 3, 20, 16, 2, 25, 55, DateTimeKind.Local).AddTicks(593), (short)1234 });

            migrationBuilder.InsertData(
                table: "Operators",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8f5f5990-2d11-455f-8b40-5767c7a5545d"), "ana" });
        }
    }
}
