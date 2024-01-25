using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class Exporter_Job_Modified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RedisId",
                schema: "exporter",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "JobType",
                schema: "exporter",
                table: "Jobs",
                newName: "Intent");

            migrationBuilder.RenameColumn(
                name: "InstanceId",
                schema: "exporter",
                table: "Jobs",
                newName: "ElementType");

            migrationBuilder.RenameColumn(
                name: "ErrorMessageName",
                schema: "exporter",
                table: "Jobs",
                newName: "BpmnProcessId");

            migrationBuilder.AddColumn<long>(
                name: "EndTimestamp",
                schema: "exporter",
                table: "Jobs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProcessInstanceKey",
                schema: "exporter",
                table: "Jobs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTimestamp",
                schema: "exporter",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ProcessInstanceKey",
                schema: "exporter",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "Intent",
                schema: "exporter",
                table: "Jobs",
                newName: "JobType");

            migrationBuilder.RenameColumn(
                name: "ElementType",
                schema: "exporter",
                table: "Jobs",
                newName: "InstanceId");

            migrationBuilder.RenameColumn(
                name: "BpmnProcessId",
                schema: "exporter",
                table: "Jobs",
                newName: "ErrorMessageName");

            migrationBuilder.AddColumn<string>(
                name: "RedisId",
                schema: "exporter",
                table: "Jobs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
