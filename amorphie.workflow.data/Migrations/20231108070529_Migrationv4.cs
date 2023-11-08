using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class Migrationv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PageName",
                table: "PageComponents",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
            migrationBuilder.AlterColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "PageComponents",
                type: "tsvector",
                nullable: false,
                computedColumnSql: "to_tsvector('english', coalesce(\"PageName\", ''))",
                stored: true,
                oldClrType: typeof(NpgsqlTsVector),
                oldType: "tsvector",
                oldComputedColumnSql: "to_tsvector('english', coalesce(\"type\", '') || ' ' || coalesce(\"componentName\", '') || ' ' || coalesce(\"PageName\", '') || ' ' || coalesce(\"transitionName\", ''))",
                oldStored: true);
            migrationBuilder.RenameColumn(
                name: "componentJson",
                table: "PageComponents",
                newName: "ComponentJson");
            migrationBuilder.DropForeignKey(
                name: "FK_PageComponents_PageComponentUiModels_uiModelId",
                table: "PageComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_PageComponents_PageComponents_parentComponentId",
                table: "PageComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_PageComponents_Transitions_transitionName",
                table: "PageComponents");

            migrationBuilder.DropIndex(
                name: "IX_PageComponents_parentComponentId",
                table: "PageComponents");

            migrationBuilder.DropIndex(
                name: "IX_PageComponents_transitionName",
                table: "PageComponents");

            migrationBuilder.DropIndex(
                name: "IX_PageComponents_uiModelId",
                table: "PageComponents");

            migrationBuilder.DropColumn(
                name: "componentName",
                table: "PageComponents");

            migrationBuilder.DropColumn(
                name: "parentComponentId",
                table: "PageComponents");

            migrationBuilder.DropColumn(
                name: "transitionName",
                table: "PageComponents");

            migrationBuilder.DropColumn(
                name: "type",
                table: "PageComponents");

            migrationBuilder.DropColumn(
                name: "uiModelId",
                table: "PageComponents");

            migrationBuilder.DropColumn(
                name: "visibility",
                table: "PageComponents");






        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ComponentJson",
                table: "PageComponents",
                newName: "componentJson");

            migrationBuilder.AlterColumn<string>(
                name: "PageName",
                table: "PageComponents",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "componentName",
                table: "PageComponents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "parentComponentId",
                table: "PageComponents",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "transitionName",
                table: "PageComponents",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "PageComponents",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "uiModelId",
                table: "PageComponents",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "visibility",
                table: "PageComponents",
                type: "boolean",
                nullable: true);

            migrationBuilder.AlterColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "PageComponents",
                type: "tsvector",
                nullable: false,
                computedColumnSql: "to_tsvector('english', coalesce(\"type\", '') || ' ' || coalesce(\"componentName\", '') || ' ' || coalesce(\"PageName\", '') || ' ' || coalesce(\"transitionName\", ''))",
                stored: true,
                oldClrType: typeof(NpgsqlTsVector),
                oldType: "tsvector",
                oldComputedColumnSql: "to_tsvector('english', coalesce(\"PageName\", ''))",
                oldStored: true);

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_parentComponentId",
                table: "PageComponents",
                column: "parentComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_transitionName",
                table: "PageComponents",
                column: "transitionName");

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_uiModelId",
                table: "PageComponents",
                column: "uiModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PageComponents_PageComponentUiModels_uiModelId",
                table: "PageComponents",
                column: "uiModelId",
                principalTable: "PageComponentUiModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PageComponents_PageComponents_parentComponentId",
                table: "PageComponents",
                column: "parentComponentId",
                principalTable: "PageComponents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PageComponents_Transitions_transitionName",
                table: "PageComponents",
                column: "transitionName",
                principalTable: "Transitions",
                principalColumn: "Name");
        }
    }
}
