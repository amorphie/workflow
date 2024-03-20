using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class StateManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StateName",
                table: "Translation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Kind",
                table: "States",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "PageId",
                table: "States",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "States",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeofUi",
                table: "States",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "requireData",
                table: "States",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "transitionButtonType",
                table: "States",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StateToStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StateName = table.Column<string>(type: "text", nullable: false),
                    ToStateName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateToStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateToStates_States_StateName",
                        column: x => x.StateName,
                        principalTable: "States",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateToStates_States_ToStateName",
                        column: x => x.ToStateName,
                        principalTable: "States",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translation_StateName",
                table: "Translation",
                column: "StateName");

            migrationBuilder.CreateIndex(
                name: "IX_States_PageId",
                table: "States",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_StateToStates_StateName",
                table: "StateToStates",
                column: "StateName");

            migrationBuilder.CreateIndex(
                name: "IX_StateToStates_ToStateName",
                table: "StateToStates",
                column: "ToStateName");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Pages_PageId",
                table: "States",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_States_StateName",
                table: "Translation",
                column: "StateName",
                principalTable: "States",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Pages_PageId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_States_StateName",
                table: "Translation");

            migrationBuilder.DropTable(
                name: "StateToStates");

            migrationBuilder.DropIndex(
                name: "IX_Translation_StateName",
                table: "Translation");

            migrationBuilder.DropIndex(
                name: "IX_States_PageId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "StateName",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "Kind",
                table: "States");

            migrationBuilder.DropColumn(
                name: "PageId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "States");

            migrationBuilder.DropColumn(
                name: "TypeofUi",
                table: "States");

            migrationBuilder.DropColumn(
                name: "requireData",
                table: "States");

            migrationBuilder.DropColumn(
                name: "transitionButtonType",
                table: "States");
        }
    }
}
