using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalCompany.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddActivityInstancesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "ReceiptForms");

            migrationBuilder.CreateTable(
                name: "ActivitiesInstances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitiesInstances_ReceiptForms_ReceiptFormId",
                        column: x => x.ReceiptFormId,
                        principalTable: "ReceiptForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesInstances_ReceiptFormId",
                table: "ActivitiesInstances",
                column: "ReceiptFormId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitiesInstances");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ReceiptForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
