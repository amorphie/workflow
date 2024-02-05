using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationForbiddenData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsForbiddenData",
                table: "Workflows",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsForbiddenData",
                table: "Workflows");
        }
    }
}
