using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankSystem.Common.Migrations
{
    /// <inheritdoc />
    public partial class TransactionsSeederAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"),
                column: "Amount",
                value: 14318m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                column: "Amount",
                value: 17924m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt", "SecurityStamp" },
                values: new object[] { new DateTime(2013, 3, 27, 18, 19, 36, 315, DateTimeKind.Local).AddTicks(9233), "e09fba1b-f60c-4c34-9bfa-5297d6db9c61", "AMIdasCnqn6y6rfwCUB2RpPHeuQv6eAPnEcDJgsLtX//sr2Az9Nf6X1MbgdAQ2z6CQ==", "442728524", new DateTime(2023, 3, 27, 18, 19, 36, 315, DateTimeKind.Local).AddTicks(9238), "7e00a07f-da75-4c2b-9006-fd1c5fa04673" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt", "SecurityStamp" },
                values: new object[] { new DateTime(2013, 3, 27, 18, 19, 36, 315, DateTimeKind.Local).AddTicks(2102), "ff1e264b-e6d1-4983-b4b7-f305ecaf7a54", "AARGy2attN7V3kfnZnj562Jt7H4DGuvzFEsP5lGP9joOV//NbarWPZCE8T56rC3rKQ==", "674584629", new DateTime(2023, 3, 27, 18, 19, 36, 315, DateTimeKind.Local).AddTicks(2115), "6819cdab-a4b6-4b56-a34a-25fbaf1989ad" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "601912989918641835", new DateTime(2023, 3, 27, 18, 19, 36, 316, DateTimeKind.Local).AddTicks(6778), new DateTime(2028, 3, 27, 18, 19, 36, 316, DateTimeKind.Local).AddTicks(6771) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "784506287657360615", new DateTime(2023, 3, 27, 18, 19, 36, 316, DateTimeKind.Local).AddTicks(6786), new DateTime(2028, 3, 27, 18, 19, 36, 316, DateTimeKind.Local).AddTicks(6785) });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountFromId", "AccountToId", "Amount", "CreatedAt", "CurrencyFrom", "CurrencyTo", "Fee", "TransactionType" },
                values: new object[,]
                {
                    { new Guid("1b8edb87-782f-4acd-85f7-21638fadf963"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 573.40m, new DateTime(2022, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 27.80m, 0 },
                    { new Guid("35ad3cea-118f-4d35-bcc9-81a46d3c523a"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 312.70m, new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 16.20m, 2 },
                    { new Guid("451b33be-e3de-4c63-84d5-dd7c9f5f133a"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 242.10m, new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 23.12m, 0 },
                    { new Guid("79684d49-15eb-49d5-8ae2-764cf008fa71"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 489.80m, new DateTime(2022, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 22.40m, 1 },
                    { new Guid("93ccfacd-7ce0-4261-a177-d063d1c263c3"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 789.40m, new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 33.20m, 0 },
                    { new Guid("a14ea9f9-873a-4a6b-a38f-27a72d7a4892"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 438.10m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 18.50m, 2 },
                    { new Guid("a7e1c126-5b4a-4e8b-8b25-b61faaeef7f9"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 567.20m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 29.80m, 1 },
                    { new Guid("aa460937-2d7a-431a-8251-ec3068c323a3"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 195.50m, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 9.80m, 0 },
                    { new Guid("e9ddce10-c2a5-4aad-924a-3725ec46a89f"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 637.90m, new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, 31.50m, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("1b8edb87-782f-4acd-85f7-21638fadf963"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("35ad3cea-118f-4d35-bcc9-81a46d3c523a"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("451b33be-e3de-4c63-84d5-dd7c9f5f133a"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("79684d49-15eb-49d5-8ae2-764cf008fa71"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("93ccfacd-7ce0-4261-a177-d063d1c263c3"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("a14ea9f9-873a-4a6b-a38f-27a72d7a4892"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("a7e1c126-5b4a-4e8b-8b25-b61faaeef7f9"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("aa460937-2d7a-431a-8251-ec3068c323a3"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("e9ddce10-c2a5-4aad-924a-3725ec46a89f"));

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
    }
}
