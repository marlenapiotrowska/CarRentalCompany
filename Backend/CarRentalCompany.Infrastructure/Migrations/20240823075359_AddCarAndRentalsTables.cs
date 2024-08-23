using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalCompany.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCarAndRentalsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormType",
                table: "ReceiptForms");

            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "ReceiptForms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ReceiptForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    AdditionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentalStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsEnded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptForms_CarId",
                table: "ReceiptForms",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_ClientId",
                table: "Rentals",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptForms_Cars_CarId",
                table: "ReceiptForms",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptForms_Cars_CarId",
                table: "ReceiptForms");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptForms_CarId",
                table: "ReceiptForms");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "ReceiptForms");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ReceiptForms");

            migrationBuilder.AddColumn<string>(
                name: "FormType",
                table: "ReceiptForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
