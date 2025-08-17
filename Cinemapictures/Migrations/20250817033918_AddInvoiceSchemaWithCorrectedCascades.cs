using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinemapictures.Migrations
{
    
    public partial class AddInvoiceSchemaWithCorrectedCascades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Clients_ClientId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Employee_EmployeeId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Movies_MovieId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Rent_RentId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Rent_RentId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rent",
                table: "Rent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Rent",
                newName: "Rents");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_RentId",
                table: "Invoices",
                newName: "IX_Invoices_RentId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_MovieId",
                table: "Invoices",
                newName: "IX_Invoices_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_EmployeeId",
                table: "Invoices",
                newName: "IX_Invoices_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_ClientId",
                table: "Invoices",
                newName: "IX_Invoices_ClientId");

            migrationBuilder.AddColumn<int>(
                name: "KindId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoviesId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rents",
                table: "Rents",
                column: "RentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    InvoiceDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.InvoiceDetailId);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MoviesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kinds",
                columns: table => new
                {
                    KindId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KindName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Movies = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kinds", x => x.KindId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_KindId",
                table: "Movies",
                column: "KindId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_MoviesId",
                table: "Invoices",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_MovieId",
                table: "InvoiceDetails",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Clients_ClientId",
                table: "Invoices",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Employees_EmployeeId",
                table: "Invoices",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Movies_MovieId",
                table: "Invoices",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MoviesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Movies_MoviesId",
                table: "Invoices",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Rents_RentId",
                table: "Invoices",
                column: "RentId",
                principalTable: "Rents",
                principalColumn: "RentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Kinds_KindId",
                table: "Movies",
                column: "KindId",
                principalTable: "Kinds",
                principalColumn: "KindId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Rents_RentId",
                table: "Movies",
                column: "RentId",
                principalTable: "Rents",
                principalColumn: "RentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Clients_ClientId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Employees_EmployeeId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Movies_MovieId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Movies_MoviesId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Rents_RentId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Kinds_KindId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Rents_RentId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Kinds");

            migrationBuilder.DropIndex(
                name: "IX_Movies_KindId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rents",
                table: "Rents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_MoviesId",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "KindId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                table: "Invoices");

            migrationBuilder.RenameTable(
                name: "Rents",
                newName: "Rent");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_RentId",
                table: "Invoice",
                newName: "IX_Invoice_RentId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_MovieId",
                table: "Invoice",
                newName: "IX_Invoice_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_EmployeeId",
                table: "Invoice",
                newName: "IX_Invoice_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ClientId",
                table: "Invoice",
                newName: "IX_Invoice_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rent",
                table: "Rent",
                column: "RentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Clients_ClientId",
                table: "Invoice",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Employee_EmployeeId",
                table: "Invoice",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Movies_MovieId",
                table: "Invoice",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MoviesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Rent_RentId",
                table: "Invoice",
                column: "RentId",
                principalTable: "Rent",
                principalColumn: "RentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Rent_RentId",
                table: "Movies",
                column: "RentId",
                principalTable: "Rent",
                principalColumn: "RentId");
        }
    }
}
