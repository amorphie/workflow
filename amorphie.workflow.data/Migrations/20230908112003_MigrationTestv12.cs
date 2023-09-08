using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationTestv12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PageComponentUiModelId",
                table: "Translation",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PageComponentUiModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageComponentUiModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageComponents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PageId = table.Column<Guid>(type: "uuid", nullable: true),
                    PageName = table.Column<string>(type: "text", nullable: true),
                    componentName = table.Column<string>(type: "text", nullable: false),
                    SearchVector = table.Column<NpgsqlTsVector>(type: "tsvector", nullable: false, computedColumnSql: "to_tsvector('english', coalesce(\"type\", '') || ' ' || coalesce(\"componentName\", '') || ' ' || coalesce(\"PageName\", '') || ' ' || coalesce(\"transitionName\", ''))", stored: true),
                    transitionName = table.Column<string>(type: "text", nullable: true),
                    visibility = table.Column<bool>(type: "boolean", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    uiModelId = table.Column<Guid>(type: "uuid", nullable: true),
                    parentComponentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageComponents_PageComponentUiModels_uiModelId",
                        column: x => x.uiModelId,
                        principalTable: "PageComponentUiModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PageComponents_PageComponents_parentComponentId",
                        column: x => x.parentComponentId,
                        principalTable: "PageComponents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PageComponents_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PageComponents_Transitions_transitionName",
                        column: x => x.transitionName,
                        principalTable: "Transitions",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translation_PageComponentUiModelId",
                table: "Translation",
                column: "PageComponentUiModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_PageId",
                table: "PageComponents",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_parentComponentId",
                table: "PageComponents",
                column: "parentComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_SearchVector",
                table: "PageComponents",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_transitionName",
                table: "PageComponents",
                column: "transitionName");

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_uiModelId",
                table: "PageComponents",
                column: "uiModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_PageComponentUiModels_PageComponentUiModelId",
                table: "Translation",
                column: "PageComponentUiModelId",
                principalTable: "PageComponentUiModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translation_PageComponentUiModels_PageComponentUiModelId",
                table: "Translation");

            migrationBuilder.DropTable(
                name: "PageComponents");

            migrationBuilder.DropTable(
                name: "PageComponentUiModels");

            migrationBuilder.DropIndex(
                name: "IX_Translation_PageComponentUiModelId",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "PageComponentUiModelId",
                table: "Translation");
        }
    }
}
