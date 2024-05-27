using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSemVer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SemVer",
                table: "Workflows",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SemVer",
                schema: "transfer",
                table: "TransferHistories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SemVer",
                table: "PageComponents",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SemanticVersions",
                schema: "transfer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectName = table.Column<string>(type: "text", nullable: false),
                    JsonBody = table.Column<string>(type: "text", nullable: false),
                    SemVer = table.Column<string>(type: "text", nullable: false),
                    VersionTable = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemanticVersions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SemanticVersions",
                schema: "transfer");

            migrationBuilder.DropColumn(
                name: "SemVer",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "SemVer",
                schema: "transfer",
                table: "TransferHistories");

            migrationBuilder.DropColumn(
                name: "SemVer",
                table: "PageComponents");
        }
    }
}
