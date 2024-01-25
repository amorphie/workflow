using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class _01182024_ExporterTablesChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RedisId",
                schema: "exporter",
                table: "MessageSubscriptions");

            migrationBuilder.DropColumn(
                name: "Retries",
                schema: "exporter",
                table: "Incidents");

            migrationBuilder.RenameColumn(
                name: "JobType",
                schema: "exporter",
                table: "Incidents",
                newName: "ErrorType");

            migrationBuilder.RenameColumn(
                name: "ErrorMessageName",
                schema: "exporter",
                table: "Incidents",
                newName: "ErrorMessage");

            migrationBuilder.AddColumn<long>(
                name: "ElementInstanceKey",
                schema: "exporter",
                table: "Incidents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProcessDefinitionKey",
                schema: "exporter",
                table: "Incidents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProcessInstanceKey",
                schema: "exporter",
                table: "Incidents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElementInstanceKey",
                schema: "exporter",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "ProcessDefinitionKey",
                schema: "exporter",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "ProcessInstanceKey",
                schema: "exporter",
                table: "Incidents");

            migrationBuilder.RenameColumn(
                name: "ErrorType",
                schema: "exporter",
                table: "Incidents",
                newName: "JobType");

            migrationBuilder.RenameColumn(
                name: "ErrorMessage",
                schema: "exporter",
                table: "Incidents",
                newName: "ErrorMessageName");

            migrationBuilder.AddColumn<string>(
                name: "RedisId",
                schema: "exporter",
                table: "MessageSubscriptions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Retries",
                schema: "exporter",
                table: "Incidents",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
