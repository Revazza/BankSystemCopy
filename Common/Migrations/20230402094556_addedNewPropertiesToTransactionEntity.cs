using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankSystem.Common.Migrations
{
    /// <inheritdoc />
    public partial class addedNewPropertiesToTransactionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"));

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

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f66ed5d-b94b-46a7-a9c3-9a564241708f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5c38744-072b-4785-9c6d-db48ac043b7f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountFromId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "AccountFromIban",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountToIban",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pin",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cvv",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountFromIban",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountToIban",
                table: "Transactions");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountFromId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pin",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cvv",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3f66ed5d-b94b-46a7-a9c3-9a564241708f"), null, "api-operator", "API-OPERATOR" },
                    { new Guid("f5c38744-072b-4785-9c6d-db48ac043b7f"), null, "api-user", "API-USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalNumber", "PhoneNumber", "PhoneNumberConfirmed", "RegisteredAt", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"), 0, new DateTime(2013, 3, 27, 18, 19, 36, 315, DateTimeKind.Local).AddTicks(9233), "e09fba1b-f60c-4c34-9bfa-5297d6db9c61", "sandro.revazishviliii@gmail.com", false, "Sandro", "Revazishvili", false, null, "SANDRO.REVAZISHVILIII@GMAIL.COM", null, "AMIdasCnqn6y6rfwCUB2RpPHeuQv6eAPnEcDJgsLtX//sr2Az9Nf6X1MbgdAQ2z6CQ==", "442728524", null, false, new DateTime(2023, 3, 27, 18, 19, 36, 315, DateTimeKind.Local).AddTicks(9238), "7e00a07f-da75-4c2b-9006-fd1c5fa04673", false, "sandro" },
                    { new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"), 0, new DateTime(2013, 3, 27, 18, 19, 36, 315, DateTimeKind.Local).AddTicks(2102), "ff1e264b-e6d1-4983-b4b7-f305ecaf7a54", "anamklavashvili@gmail.com", false, "Ana", "Mklavashvili", false, null, "ANAMKLAVASHVILI@GMAIL.COM", null, "AARGy2attN7V3kfnZnj562Jt7H4DGuvzFEsP5lGP9joOV//NbarWPZCE8T56rC3rKQ==", "674584629", null, false, new DateTime(2023, 3, 27, 18, 19, 36, 315, DateTimeKind.Local).AddTicks(2115), "6819cdab-a4b6-4b56-a34a-25fbaf1989ad", false, "ana" }
                });

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
                    { new Guid("e9ddce10-c2a5-4aad-924a-3725ec46a89f"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 637.90m, new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, 31.50m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Amount", "Currency", "Iban", "UserId" },
                values: new object[,]
                {
                    { new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"), 14318m, 0, "Ana's Iban", new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187") },
                    { new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"), 17924m, 0, "Sandro's Iban", new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f5c38744-072b-4785-9c6d-db48ac043b7f"), new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4") },
                    { new Guid("3f66ed5d-b94b-46a7-a9c3-9a564241708f"), new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187") }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "AccountId", "CardNumber", "CreatedAt", "Cvv", "ExpiresAt", "FullName", "Pin" },
                values: new object[,]
                {
                    { new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"), new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"), "601912989918641835", new DateTime(2023, 3, 27, 18, 19, 36, 316, DateTimeKind.Local).AddTicks(6778), "931", new DateTime(2028, 3, 27, 18, 19, 36, 316, DateTimeKind.Local).AddTicks(6771), "Ana Mklavashvili", "1234" },
                    { new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"), new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"), "784506287657360615", new DateTime(2023, 3, 27, 18, 19, 36, 316, DateTimeKind.Local).AddTicks(6786), "931", new DateTime(2028, 3, 27, 18, 19, 36, 316, DateTimeKind.Local).AddTicks(6785), "Sandro Revazishvili", "1234" }
                });
        }
    }
}
