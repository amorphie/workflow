using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class Migrationv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UiForm_Id",
                table: "Translation",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UiForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    transitionName = table.Column<string>(type: "text", nullable: true),
                    stateName = table.Column<string>(type: "text", nullable: true),
                    typeofUiEnum = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UiForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UiForms_States_stateName",
                        column: x => x.stateName,
                        principalTable: "States",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_UiForms_Transitions_transitionName",
                        column: x => x.transitionName,
                        principalTable: "Transitions",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translation_UiForm_Id",
                table: "Translation",
                column: "UiForm_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UiForms_stateName",
                table: "UiForms",
                column: "stateName");

            migrationBuilder.CreateIndex(
                name: "IX_UiForms_transitionName",
                table: "UiForms",
                column: "transitionName");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_UiForms_UiForm_Id",
                table: "Translation",
                column: "UiForm_Id",
                principalTable: "UiForms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translation_UiForms_UiForm_Id",
                table: "Translation");

            migrationBuilder.DropTable(
                name: "UiForms");

            migrationBuilder.DropIndex(
                name: "IX_Translation_UiForm_Id",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "UiForm_Id",
                table: "Translation");
        }
    }
}
