using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommonServices.Migrations
{
    /// <inheritdoc />
    public partial class SeedRefactored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Operators",
                keyColumn: "Id",
                keyValue: new Guid("f84fe304-72c9-4513-8c46-f9da7529f1f7"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalNumber", "PhoneNumber", "PhoneNumberConfirmed", "RegisteredAt", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"), 0, new DateTime(2013, 3, 14, 23, 10, 30, 158, DateTimeKind.Local).AddTicks(3437), "e6502834-ea06-455c-9c38-7f07f3c62dc9", "sandro.revazishviliii@gmail.com", false, "Sandro", "Revazishvili", false, null, null, null, "AO1N5Hdi0o+JHBTa9ieWBb/XNFD/bvpmvD8luMFbBCMxsyrtE4n2L29/O1J/EfFhlA==", "673459665", null, false, new DateTime(2023, 3, 14, 23, 10, 30, 158, DateTimeKind.Local).AddTicks(3438), null, false, "sandro" },
                    { new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"), 0, new DateTime(2013, 3, 14, 23, 10, 30, 157, DateTimeKind.Local).AddTicks(6394), "2c351473-c838-4afa-9118-14612f1ee48c", "anamklavashvili@gmail.com", false, "Ana", "Mklavashvili", false, null, null, null, "APayk8z1MtJ5VQ8hzQMDeAT3QOg2PucRll3kiyuxLwXfyJX7mXuVd6Xc/Zyt5JQ7Xw==", "434253014", null, false, new DateTime(2023, 3, 14, 23, 10, 30, 157, DateTimeKind.Local).AddTicks(6427), null, false, "ana" }
                });

            migrationBuilder.InsertData(
                table: "Operators",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8f5f5990-2d11-455f-8b40-5767c7a5545d"), "ana" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Amount", "Currency", "Iban", "UserId" },
                values: new object[,]
                {
                    { new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"), 10991m, 0, "Ana's Iban", new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187") },
                    { new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"), 17496m, 0, "Sandro's Iban", new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4") }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "AccountId", "CardNumber", "CreatedAt", "Cvv", "ExpiresAt", "FullName", "Pin" },
                values: new object[,]
                {
                    { new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"), new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"), "751414959291066312", new DateTime(2023, 3, 14, 23, 10, 30, 159, DateTimeKind.Local).AddTicks(1351), (short)931, new DateTime(2028, 3, 14, 23, 10, 30, 159, DateTimeKind.Local).AddTicks(1345), "Ana Mklavashvili", (short)1234 },
                    { new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"), new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"), "889733157374379887", new DateTime(2023, 3, 14, 23, 10, 30, 159, DateTimeKind.Local).AddTicks(1359), (short)931, new DateTime(2028, 3, 14, 23, 10, 30, 159, DateTimeKind.Local).AddTicks(1359), "Sandro Revazishvili", (short)1234 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"));

            migrationBuilder.DeleteData(
                table: "Operators",
                keyColumn: "Id",
                keyValue: new Guid("8f5f5990-2d11-455f-8b40-5767c7a5545d"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"));

            migrationBuilder.InsertData(
                table: "Operators",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f84fe304-72c9-4513-8c46-f9da7529f1f7"), "ana" });
        }
    }
}
