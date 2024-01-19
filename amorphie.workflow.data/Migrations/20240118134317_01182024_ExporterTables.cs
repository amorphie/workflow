using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class _01182024_ExporterTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessInstances",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "CreatedByBehalfOf",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
               name: "InstanceId",
               table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "ModifiedByBehalfOf",
                table: "ProcessInstances");

            migrationBuilder.EnsureSchema(
                name: "exporter");

            migrationBuilder.RenameTable(
                name: "ProcessInstances",
                newName: "ProcessInstances",
                newSchema: "exporter");

            migrationBuilder.RenameTable(
                name: "MessageSubscriptions",
                newName: "MessageSubscriptions",
                newSchema: "exporter");

            migrationBuilder.AlterColumn<long>(
                name: "Key",
                schema: "exporter",
                table: "ProcessInstances",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "EndTimestamp",
                schema: "exporter",
                table: "ProcessInstances",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessInstances",
                schema: "exporter",
                table: "ProcessInstances",
                column: "Key");

            migrationBuilder.CreateTable(
                name: "Deployments",
                schema: "exporter",
                columns: table => new
                {
                    Key = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BpmnProcessId = table.Column<string>(type: "text", nullable: false),
                    ResourceName = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    Duplicate = table.Column<bool>(type: "boolean", nullable: false),
                    Intent = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deployments", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                schema: "exporter",
                columns: table => new
                {
                    Key = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BpmnProcessId = table.Column<string>(type: "text", nullable: true),
                    ElementId = table.Column<string>(type: "text", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false),
                    Retries = table.Column<int>(type: "integer", nullable: false),
                    RejectionReason = table.Column<string>(type: "text", nullable: true),
                    ErrorMessageName = table.Column<string>(type: "text", nullable: true),
                    JobType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                schema: "exporter",
                columns: table => new
                {
                    Key = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RedisId = table.Column<string>(type: "text", nullable: false),
                    InstanceId = table.Column<string>(type: "text", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false),
                    Retries = table.Column<int>(type: "integer", nullable: false),
                    ErrorMessageName = table.Column<string>(type: "text", nullable: true),
                    JobType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "exporter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RedisId = table.Column<string>(type: "text", nullable: false),
                    InstanceId = table.Column<string>(type: "text", nullable: true),
                    Deadline = table.Column<long>(type: "bigint", nullable: false),
                    Key = table.Column<long>(type: "bigint", nullable: false),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    ValueType = table.Column<string>(type: "text", nullable: true),
                    SourceRecordPosition = table.Column<int>(type: "integer", nullable: false),
                    Intent = table.Column<string>(type: "text", nullable: true),
                    RejectionType = table.Column<string>(type: "text", nullable: true),
                    RejectionReason = table.Column<string>(type: "text", nullable: true),
                    RecordVersion = table.Column<int>(type: "integer", nullable: false),
                    BrokerVersion = table.Column<string>(type: "text", nullable: true),
                    RecordType = table.Column<string>(type: "text", nullable: true),
                    Variables = table.Column<string>(type: "jsonb", nullable: true),
                    ProcessInstanceKey = table.Column<long>(type: "bigint", nullable: false),
                    ProcessDefinitionKey = table.Column<long>(type: "bigint", nullable: false),
                    ElementId = table.Column<string>(type: "text", nullable: true),
                    MessageName = table.Column<string>(type: "text", nullable: true),
                    MessageKey = table.Column<long>(type: "bigint", nullable: false),
                    CorrelationKey = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Process",
                schema: "exporter",
                columns: table => new
                {
                    Key = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RedisId = table.Column<string>(type: "text", nullable: false),
                    InstanceId = table.Column<string>(type: "text", nullable: true),
                    BpmnProcessId = table.Column<string>(type: "text", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    ResourceName = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Variables",
                schema: "exporter",
                columns: table => new
                {
                    Key = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false),
                    BpmnProcessId = table.Column<string>(type: "text", nullable: true),
                    ProcessInstanceKey = table.Column<long>(type: "bigint", nullable: false),
                    ProcessDefinitionKey = table.Column<long>(type: "bigint", nullable: false),
                    ScopeKey = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variables", x => x.Key);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deployments",
                schema: "exporter");

            migrationBuilder.DropTable(
                name: "Incidents",
                schema: "exporter");

            migrationBuilder.DropTable(
                name: "Jobs",
                schema: "exporter");

            migrationBuilder.DropTable(
                name: "Messages",
                schema: "exporter");

            migrationBuilder.DropTable(
                name: "Process",
                schema: "exporter");

            migrationBuilder.DropTable(
                name: "Variables",
                schema: "exporter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessInstances",
                schema: "exporter",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "EndTimestamp",
                schema: "exporter",
                table: "ProcessInstances");

            migrationBuilder.RenameTable(
                name: "ProcessInstances",
                schema: "exporter",
                newName: "ProcessInstances");

            migrationBuilder.RenameTable(
                name: "MessageSubscriptions",
                schema: "exporter",
                newName: "MessageSubscriptions");

            migrationBuilder.AlterColumn<long>(
                name: "Key",
                table: "ProcessInstances",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProcessInstances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ProcessInstances",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "ProcessInstances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByBehalfOf",
                table: "ProcessInstances",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstanceId",
                table: "ProcessInstances",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ProcessInstances",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "ProcessInstances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedByBehalfOf",
                table: "ProcessInstances",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessInstances",
                table: "ProcessInstances",
                column: "Id");
        }
    }
}
