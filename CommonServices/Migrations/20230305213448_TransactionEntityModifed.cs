using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommonServices.Migrations
{
    /// <inheritdoc />
    public partial class TransactionEntityModifed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountFromId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountToId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountFromId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountToId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Transactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Transactions",
                type: "decimal(18,3)",
                precision: 18,
                scale: 3,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountFromId",
                table: "Transactions",
                column: "AccountFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountToId",
                table: "Transactions",
                column: "AccountToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountFromId",
                table: "Transactions",
                column: "AccountFromId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountToId",
                table: "Transactions",
                column: "AccountToId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
