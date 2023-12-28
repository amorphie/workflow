using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class Migration10GatewayMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageSubscriptions",
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
                    TenantId = table.Column<string>(type: "text", nullable: true),
                    Variables = table.Column<string>(type: "jsonb", nullable: true),
                    BpmnProcessId = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_MessageSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessInstances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RedisId = table.Column<string>(type: "text", nullable: false),
                    InstanceId = table.Column<string>(type: "text", nullable: false),
                    PartitionId = table.Column<int>(type: "integer", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    BpmnProcessId = table.Column<string>(type: "text", nullable: false),
                    ProcessInstanceKey = table.Column<long>(type: "bigint", nullable: false),
                    ProcessDefinitionKey = table.Column<long>(type: "bigint", nullable: false),
                    ElementId = table.Column<string>(type: "text", nullable: false),
                    FlowScopeKey = table.Column<long>(type: "bigint", nullable: false),
                    BpmnElementType = table.Column<string>(type: "text", nullable: false),
                    BpmnEventType = table.Column<string>(type: "text", nullable: false),
                    ParentProcessInstanceKey = table.Column<long>(type: "bigint", nullable: false),
                    ParentElementInstanceKey = table.Column<long>(type: "bigint", nullable: false),
                    Key = table.Column<long>(type: "bigint", nullable: false),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false),
                    ValueType = table.Column<string>(type: "text", nullable: false),
                    BrokerVersion = table.Column<string>(type: "text", nullable: false),
                    SourceRecordPosition = table.Column<int>(type: "integer", nullable: false),
                    Intent = table.Column<string>(type: "text", nullable: false),
                    RecordType = table.Column<string>(type: "text", nullable: false),
                    RejectionType = table.Column<string>(type: "text", nullable: false),
                    RejectionReason = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessInstances", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageSubscriptions");

            migrationBuilder.DropTable(
                name: "ProcessInstances");
        }
    }
}
