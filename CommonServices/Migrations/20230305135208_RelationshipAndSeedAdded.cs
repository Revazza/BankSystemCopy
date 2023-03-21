using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommonServices.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipAndSeedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_UserEntityId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Accounts_AccountId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_UserEntityId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Accounts");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Currencies",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Diff",
                table: "Currencies",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Cards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_UserId",
                table: "Accounts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Accounts_AccountId",
                table: "Cards",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_UserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Accounts_AccountId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Accounts");

            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "Currencies",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Diff",
                table: "Currencies",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Cards",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserEntityId",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserEntityId",
                table: "Accounts",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_UserEntityId",
                table: "Accounts",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Accounts_AccountId",
                table: "Cards",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
