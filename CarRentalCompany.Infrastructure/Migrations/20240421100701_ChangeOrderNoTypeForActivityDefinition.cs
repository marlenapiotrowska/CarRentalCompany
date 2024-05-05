using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalCompany.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrderNoTypeForActivityDefinition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "OrderNo",
                table: "ActivitiesDefinitions",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderNo",
                table: "ActivitiesDefinitions",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
