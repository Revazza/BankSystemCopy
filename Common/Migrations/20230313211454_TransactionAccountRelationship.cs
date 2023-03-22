using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Common.Migrations
{
    /// <inheritdoc />
    public partial class TransactionAccountRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountFromId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountFromId",
                table: "Transactions");
        }
    }
}
