using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalCompany.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveActivityDefinition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivitiesInstances_ActivitiesDefinitions_ActivityDefinitionId",
                table: "ActivitiesInstances");

            migrationBuilder.DropTable(
                name: "ActivitiesDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_ActivitiesInstances_ActivityDefinitionId",
                table: "ActivitiesInstances");

            migrationBuilder.DropColumn(
                name: "ActivityDefinitionId",
                table: "ActivitiesInstances");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ActivitiesInstances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ActivitiesInstances");

            migrationBuilder.AddColumn<Guid>(
                name: "ActivityDefinitionId",
                table: "ActivitiesInstances",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ActivitiesDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNo = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesDefinitions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesInstances_ActivityDefinitionId",
                table: "ActivitiesInstances",
                column: "ActivityDefinitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitiesInstances_ActivitiesDefinitions_ActivityDefinitionId",
                table: "ActivitiesInstances",
                column: "ActivityDefinitionId",
                principalTable: "ActivitiesDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
