using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Common.Migrations
{
    /// <inheritdoc />
    public partial class newMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountFromId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountFromId",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"),
                column: "Amount",
                value: 10771m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                column: "Amount",
                value: 14052m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt" },
                values: new object[] { new DateTime(2013, 3, 16, 23, 55, 41, 314, DateTimeKind.Local).AddTicks(1921), "e280b57c-e6f6-4ae7-af3a-cf3ef05f4e5c", "ABow13V1MlhYUmMTON+oJC47Pogj/FjAkUt9Ypr6fzo6g2ctxO4jXtLsV0tiojczlg==", "629541122", new DateTime(2023, 3, 16, 23, 55, 41, 314, DateTimeKind.Local).AddTicks(1923) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt" },
                values: new object[] { new DateTime(2013, 3, 16, 23, 55, 41, 313, DateTimeKind.Local).AddTicks(5501), "7578b361-0661-43ca-b068-62c81c2527f3", "AF87tWO19C0G3YLdqBG8Q9q78p+DsLKKcgC+YhoI+ex2KBdRjWJO4aK0WV/AYYVIyQ==", "348932282", new DateTime(2023, 3, 16, 23, 55, 41, 313, DateTimeKind.Local).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "289294909038760701", new DateTime(2023, 3, 16, 23, 55, 41, 314, DateTimeKind.Local).AddTicks(8440), new DateTime(2028, 3, 16, 23, 55, 41, 314, DateTimeKind.Local).AddTicks(8436) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "130157007132422334", new DateTime(2023, 3, 16, 23, 55, 41, 314, DateTimeKind.Local).AddTicks(8455), new DateTime(2028, 3, 16, 23, 55, 41, 314, DateTimeKind.Local).AddTicks(8454) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"),
                column: "Amount",
                value: 10991m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                column: "Amount",
                value: 17496m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt" },
                values: new object[] { new DateTime(2013, 3, 14, 23, 10, 30, 158, DateTimeKind.Local).AddTicks(3437), "e6502834-ea06-455c-9c38-7f07f3c62dc9", "AO1N5Hdi0o+JHBTa9ieWBb/XNFD/bvpmvD8luMFbBCMxsyrtE4n2L29/O1J/EfFhlA==", "673459665", new DateTime(2023, 3, 14, 23, 10, 30, 158, DateTimeKind.Local).AddTicks(3438) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt" },
                values: new object[] { new DateTime(2013, 3, 14, 23, 10, 30, 157, DateTimeKind.Local).AddTicks(6394), "2c351473-c838-4afa-9118-14612f1ee48c", "APayk8z1MtJ5VQ8hzQMDeAT3QOg2PucRll3kiyuxLwXfyJX7mXuVd6Xc/Zyt5JQ7Xw==", "434253014", new DateTime(2023, 3, 14, 23, 10, 30, 157, DateTimeKind.Local).AddTicks(6427) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "751414959291066312", new DateTime(2023, 3, 14, 23, 10, 30, 159, DateTimeKind.Local).AddTicks(1351), new DateTime(2028, 3, 14, 23, 10, 30, 159, DateTimeKind.Local).AddTicks(1345) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "889733157374379887", new DateTime(2023, 3, 14, 23, 10, 30, 159, DateTimeKind.Local).AddTicks(1359), new DateTime(2028, 3, 14, 23, 10, 30, 159, DateTimeKind.Local).AddTicks(1359) });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountFromId",
                table: "Transactions",
                column: "AccountFromId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountFromId",
                table: "Transactions",
                column: "AccountFromId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
