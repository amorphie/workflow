using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class ExporterReconfigure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deployments",
                schema: "exporter");

            migrationBuilder.DropColumn(
                name: "BrokerVersion",
                schema: "exporter",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "Position",
                schema: "exporter",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "RecordType",
                schema: "exporter",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "RejectionReason",
                schema: "exporter",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "RejectionType",
                schema: "exporter",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "SourceRecordPosition",
                schema: "exporter",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "ValueType",
                schema: "exporter",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "InstanceId",
                schema: "exporter",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "BrokerVersion",
                schema: "exporter",
                table: "MessageSubscriptions");

            migrationBuilder.DropColumn(
                name: "ProcessDefinitionKey",
                schema: "exporter",
                table: "MessageSubscriptions");

            migrationBuilder.DropColumn(
                name: "RecordType",
                schema: "exporter",
                table: "MessageSubscriptions");

            migrationBuilder.DropColumn(
                name: "RecordVersion",
                schema: "exporter",
                table: "MessageSubscriptions");

            migrationBuilder.DropColumn(
                name: "RejectionReason",
                schema: "exporter",
                table: "MessageSubscriptions");

            migrationBuilder.DropColumn(
                name: "RejectionType",
                schema: "exporter",
                table: "MessageSubscriptions");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "exporter",
                table: "MessageSubscriptions");

            migrationBuilder.DropColumn(
                name: "BrokerVersion",
                schema: "exporter",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RecordType",
                schema: "exporter",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RecordVersion",
                schema: "exporter",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RejectionReason",
                schema: "exporter",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RejectionType",
                schema: "exporter",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ResourceName",
                schema: "exporter",
                table: "Process",
                newName: "Resource");

            migrationBuilder.AlterColumn<long>(
                name: "Position",
                schema: "exporter",
                table: "MessageSubscriptions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Resource",
                schema: "exporter",
                table: "Process",
                newName: "ResourceName");

            migrationBuilder.AddColumn<string>(
                name: "BrokerVersion",
                schema: "exporter",
                table: "ProcessInstances",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                schema: "exporter",
                table: "ProcessInstances",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RecordType",
                schema: "exporter",
                table: "ProcessInstances",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                schema: "exporter",
                table: "ProcessInstances",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RejectionType",
                schema: "exporter",
                table: "ProcessInstances",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SourceRecordPosition",
                schema: "exporter",
                table: "ProcessInstances",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ValueType",
                schema: "exporter",
                table: "ProcessInstances",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstanceId",
                schema: "exporter",
                table: "Process",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                schema: "exporter",
                table: "MessageSubscriptions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "BrokerVersion",
                schema: "exporter",
                table: "MessageSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProcessDefinitionKey",
                schema: "exporter",
                table: "MessageSubscriptions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "RecordType",
                schema: "exporter",
                table: "MessageSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordVersion",
                schema: "exporter",
                table: "MessageSubscriptions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                schema: "exporter",
                table: "MessageSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectionType",
                schema: "exporter",
                table: "MessageSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                schema: "exporter",
                table: "MessageSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrokerVersion",
                schema: "exporter",
                table: "Messages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordType",
                schema: "exporter",
                table: "Messages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordVersion",
                schema: "exporter",
                table: "Messages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                schema: "exporter",
                table: "Messages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectionType",
                schema: "exporter",
                table: "Messages",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Deployments",
                schema: "exporter",
                columns: table => new
                {
                    ResourceName = table.Column<string>(type: "text", nullable: false),
                    BpmnProcessId = table.Column<string>(type: "text", nullable: false),
                    Duplicate = table.Column<bool>(type: "boolean", nullable: false),
                    Intent = table.Column<string>(type: "text", nullable: true),
                    Resource = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deployments", x => x.ResourceName);
                });
        }
    }
}
