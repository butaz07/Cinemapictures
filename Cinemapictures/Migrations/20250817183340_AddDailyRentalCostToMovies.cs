using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinemapictures.Migrations
{
    /// <inheritdoc />
    public partial class AddDailyRentalCostToMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Rents_RentId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Movies",
                table: "Kinds");

            migrationBuilder.AddColumn<decimal>(
                name: "DailyRentalCost",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "RentId",
                table: "Invoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Rents_RentId",
                table: "Invoices",
                column: "RentId",
                principalTable: "Rents",
                principalColumn: "RentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Rents_RentId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "DailyRentalCost",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "Movies",
                table: "Kinds",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "RentId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Rents_RentId",
                table: "Invoices",
                column: "RentId",
                principalTable: "Rents",
                principalColumn: "RentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
