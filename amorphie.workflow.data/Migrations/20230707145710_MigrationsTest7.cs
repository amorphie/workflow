using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationsTest7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.AddColumn<Guid>(
                name: "PageId_Page",
                table: "Translation",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PageId",
                table: "Transitions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Operation = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Timeout = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translation_PageId_Page",
                table: "Translation",
                column: "PageId_Page");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_PageId",
                table: "Transitions",
                column: "PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transitions_Pages_PageId",
                table: "Transitions",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Pages_PageId_Page",
                table: "Translation",
                column: "PageId_Page",
                principalTable: "Pages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_Pages_PageId",
                table: "Transitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Pages_PageId_Page",
                table: "Translation");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Translation_PageId_Page",
                table: "Translation");

            migrationBuilder.DropIndex(
                name: "IX_Transitions_PageId",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "PageId_Page",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "PageId",
                table: "Transitions");

        }
    }
}
