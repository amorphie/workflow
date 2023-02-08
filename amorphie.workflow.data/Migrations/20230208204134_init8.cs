using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gateway",
                table: "Workflows",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Process",
                table: "Workflows",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Workflows",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gateway",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "Process",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Workflows");
        }
    }
}
