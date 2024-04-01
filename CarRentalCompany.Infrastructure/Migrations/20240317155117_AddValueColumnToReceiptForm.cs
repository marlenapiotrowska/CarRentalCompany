using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalCompany.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddValueColumnToReceiptForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ReceiptForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "ReceiptForms");
        }
    }
}
