using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankSystem.Common.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("028fd49a-22a4-4b5b-b500-81db87680e73"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("0740567e-966e-4169-a614-1cb0f4fd1b51"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("0d3340ed-ccd4-48d2-959f-9847e92151ed"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("1a9b225a-c7fe-4b10-9116-0e100786877f"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("352506de-3da2-4a79-8d80-9f28d7ef0e61"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("61755345-037b-45b1-82ef-e04c5f1c6646"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("e2ef25c6-fb3d-474d-8233-194870c5d119"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("e7e3d51d-7178-446e-875b-92a5e3d7251e"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("e9dab853-44e1-47dd-a1f9-30558d6f98f8"));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"),
                column: "Amount",
                value: 18483m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                column: "Amount",
                value: 13134m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt", "SecurityStamp" },
                values: new object[] { new DateTime(2013, 4, 4, 0, 17, 13, 160, DateTimeKind.Local).AddTicks(6328), "6c96acaf-fb53-420a-961d-92e2ab8c37af", "ANuqLVemFwXnkLTCOYTwL3xNm9mwyikE+JfQ6MBPcmyvm/FD01jmAcdK1fKWMESZKA==", "955903007", new DateTime(2023, 4, 4, 0, 17, 13, 160, DateTimeKind.Local).AddTicks(6330), "68acc943-a174-47f4-9305-639cb574c086" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt", "SecurityStamp" },
                values: new object[] { new DateTime(2013, 4, 4, 0, 17, 13, 159, DateTimeKind.Local).AddTicks(9750), "4dc8a08d-70e3-47c6-abd7-e2ee8dad622f", "ACqBS0tlqvaEvLXcmdM1hAJEuwsCtOXc1eTGTpSNgKJITPrE6LkL+nfUBZKDcNdXPQ==", "686367743", new DateTime(2023, 4, 4, 0, 17, 13, 159, DateTimeKind.Local).AddTicks(9788), "583a221f-fad8-44cf-b007-2f6060c0b047" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "714388007953249323", new DateTime(2023, 4, 4, 0, 17, 13, 161, DateTimeKind.Local).AddTicks(2745), new DateTime(2028, 4, 4, 0, 17, 13, 161, DateTimeKind.Local).AddTicks(2740) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "468416914218937572", new DateTime(2023, 4, 4, 0, 17, 13, 161, DateTimeKind.Local).AddTicks(2760), new DateTime(2028, 4, 4, 0, 17, 13, 161, DateTimeKind.Local).AddTicks(2759) });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountFromIban", "AccountFromId", "AccountToIban", "AccountToId", "CreatedAt", "CurrencyFrom", "CurrencyTo", "Fee", "ReceivedAmount", "TransactionType", "WithDrawnAmount" },
                values: new object[,]
                {
                    { new Guid("03c5f4b4-2caf-4879-9865-b1bef5b16817"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 18.50m, 438.10m, 2, 0m },
                    { new Guid("15f12e0c-28d7-4edd-a4d7-c93a17713be2"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 16.20m, 312.70m, 2, 0m },
                    { new Guid("1dde388a-85e3-45b9-a2e0-af85b909a287"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 23.12m, 242.10m, 0, 0m },
                    { new Guid("33b1ac8c-77b3-44a7-b6d7-0134cdeb2097"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, 31.50m, 637.90m, 2, 0m },
                    { new Guid("3d67fad6-bbd8-4ec6-9257-3ece878d3605"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 27.80m, 573.40m, 0, 0m },
                    { new Guid("5b7e3adb-6029-4f74-8d37-420f128ec98f"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 22.40m, 489.80m, 1, 0m },
                    { new Guid("cd4c8e31-96b9-4e2a-9708-e20396ab8655"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 9.80m, 195.50m, 0, 0m },
                    { new Guid("d26accb2-2d25-403e-a139-829278714301"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 29.80m, 567.20m, 1, 0m },
                    { new Guid("ed4bb2ff-f941-43a3-ba20-5ea233a1133f"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 33.20m, 789.40m, 0, 0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("03c5f4b4-2caf-4879-9865-b1bef5b16817"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("15f12e0c-28d7-4edd-a4d7-c93a17713be2"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("1dde388a-85e3-45b9-a2e0-af85b909a287"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("33b1ac8c-77b3-44a7-b6d7-0134cdeb2097"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("3d67fad6-bbd8-4ec6-9257-3ece878d3605"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("5b7e3adb-6029-4f74-8d37-420f128ec98f"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("cd4c8e31-96b9-4e2a-9708-e20396ab8655"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("d26accb2-2d25-403e-a139-829278714301"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("ed4bb2ff-f941-43a3-ba20-5ea233a1133f"));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"),
                column: "Amount",
                value: 16694m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                column: "Amount",
                value: 17140m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt", "SecurityStamp" },
                values: new object[] { new DateTime(2013, 4, 2, 21, 57, 35, 507, DateTimeKind.Local).AddTicks(1847), "b49ca7da-06fe-4fd5-a969-30cd81413192", "AKowaa1XIwCQv0eIsXc7sJlZcG3MNdsOzA+C0/NGHK+StVog6ZtJYG9G1BviVpc4yw==", "114081139", new DateTime(2023, 4, 2, 21, 57, 35, 507, DateTimeKind.Local).AddTicks(1848), "3b8554bb-7c92-4800-a239-5e60deb94866" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt", "SecurityStamp" },
                values: new object[] { new DateTime(2013, 4, 2, 21, 57, 35, 506, DateTimeKind.Local).AddTicks(4956), "5346f2f1-aaa3-4cf9-9a09-2db46ce7574d", "AOk/EkVS+AS0ViyjZPZ2tv4bIJCMgiC2nf6ZUMJb4WZRFHYPElrgMgQRU4uXdqIF9g==", "682855567", new DateTime(2023, 4, 2, 21, 57, 35, 506, DateTimeKind.Local).AddTicks(4972), "354a7cbd-82c1-4ed7-abca-cef7f0756215" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "219711935828488849", new DateTime(2023, 4, 2, 21, 57, 35, 507, DateTimeKind.Local).AddTicks(8616), new DateTime(2028, 4, 2, 21, 57, 35, 507, DateTimeKind.Local).AddTicks(8615) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "958230543307670388", new DateTime(2023, 4, 2, 21, 57, 35, 507, DateTimeKind.Local).AddTicks(8624), new DateTime(2028, 4, 2, 21, 57, 35, 507, DateTimeKind.Local).AddTicks(8624) });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountFromIban", "AccountFromId", "AccountToIban", "AccountToId", "CreatedAt", "CurrencyFrom", "CurrencyTo", "Fee", "ReceivedAmount", "TransactionType", "WithDrawnAmount" },
                values: new object[,]
                {
                    { new Guid("028fd49a-22a4-4b5b-b500-81db87680e73"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 9.80m, 195.50m, 0, 0m },
                    { new Guid("0740567e-966e-4169-a614-1cb0f4fd1b51"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 22.40m, 489.80m, 1, 0m },
                    { new Guid("0d3340ed-ccd4-48d2-959f-9847e92151ed"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 33.20m, 789.40m, 0, 0m },
                    { new Guid("1a9b225a-c7fe-4b10-9116-0e100786877f"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 23.12m, 242.10m, 0, 0m },
                    { new Guid("352506de-3da2-4a79-8d80-9f28d7ef0e61"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 18.50m, 438.10m, 2, 0m },
                    { new Guid("61755345-037b-45b1-82ef-e04c5f1c6646"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 27.80m, 573.40m, 0, 0m },
                    { new Guid("e2ef25c6-fb3d-474d-8233-194870c5d119"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, 31.50m, 637.90m, 2, 0m },
                    { new Guid("e7e3d51d-7178-446e-875b-92a5e3d7251e"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 29.80m, 567.20m, 1, 0m },
                    { new Guid("e9dab853-44e1-47dd-a1f9-30558d6f98f8"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 16.20m, 312.70m, 2, 0m }
                });
        }
    }
}
