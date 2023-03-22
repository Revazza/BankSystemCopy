using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Common.Migrations
{
    /// <inheritdoc />
    public partial class RemovedNullableFromAccountFromId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AccountFromId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt" },
                values: new object[] { new DateTime(2013, 3, 20, 16, 2, 25, 54, DateTimeKind.Local).AddTicks(1627), "353b960a-0156-4430-9d92-1eec34c61285", "ANla6veSyp8y3i3EfmrrC7KhJSQROshaiRqB0kq3iQYXPMLdXxJnQy/effUv/vEEkg==", "128704450", new DateTime(2023, 3, 20, 16, 2, 25, 54, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "PersonalNumber", "RegisteredAt" },
                values: new object[] { new DateTime(2013, 3, 20, 16, 2, 25, 53, DateTimeKind.Local).AddTicks(2938), "e42da717-6b3c-4d67-b970-93465f87845e", "AHzl5SqDc7obXHV0WNEoODHBgG8tH5qVRqJg/TvfACrdILwYEu/E/v7cxwdpkG0jkg==", "520756712", new DateTime(2023, 3, 20, 16, 2, 25, 53, DateTimeKind.Local).AddTicks(2961) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "210183209919421023", new DateTime(2023, 3, 20, 16, 2, 25, 55, DateTimeKind.Local).AddTicks(585), new DateTime(2028, 3, 20, 16, 2, 25, 55, DateTimeKind.Local).AddTicks(577) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"),
                columns: new[] { "CardNumber", "CreatedAt", "ExpiresAt" },
                values: new object[] { "92783385625049042", new DateTime(2023, 3, 20, 16, 2, 25, 55, DateTimeKind.Local).AddTicks(594), new DateTime(2028, 3, 20, 16, 2, 25, 55, DateTimeKind.Local).AddTicks(593) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AccountFromId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
    }
}
