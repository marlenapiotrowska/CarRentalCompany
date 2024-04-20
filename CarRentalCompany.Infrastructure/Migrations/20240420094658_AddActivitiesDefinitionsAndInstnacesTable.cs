using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalCompany.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddActivitiesDefinitionsAndInstnacesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceiptFormActivities");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.CreateTable(
                name: "ActivitiesDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivitiesInstances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ActivityDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitiesInstances_ActivitiesDefinitions_ActivityDefinitionId",
                        column: x => x.ActivityDefinitionId,
                        principalTable: "ActivitiesDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitiesInstances_ReceiptForms_ReceiptFormId",
                        column: x => x.ReceiptFormId,
                        principalTable: "ReceiptForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesInstances_ActivityDefinitionId",
                table: "ActivitiesInstances",
                column: "ActivityDefinitionId");

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

            migrationBuilder.DropTable(
                name: "ActivitiesDefinitions");

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptFormActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptFormActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiptFormActivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptFormActivities_ReceiptForms_ReceiptFormId",
                        column: x => x.ReceiptFormId,
                        principalTable: "ReceiptForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptFormActivities_ActivityId",
                table: "ReceiptFormActivities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptFormActivities_ReceiptFormId",
                table: "ReceiptFormActivities",
                column: "ReceiptFormId");
        }
    }
}
