using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZeebeFlow",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Tags = table.Column<string[]>(type: "text[]", nullable: true),
                    IsAtomic = table.Column<bool>(type: "boolean", nullable: false),
                    Process = table.Column<string>(type: "text", nullable: false),
                    Gateway = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZeebeFlow", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Workflows",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Tags = table.Column<string[]>(type: "text[]", nullable: true),
                    ZeebeFlowName = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflows", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Workflows_ZeebeFlow_ZeebeFlowName",
                        column: x => x.ZeebeFlowName,
                        principalTable: "ZeebeFlow",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    WorkflowName = table.Column<string>(type: "text", nullable: true),
                    OnEntryFlowName = table.Column<string>(type: "text", nullable: true),
                    OnExitFlowName = table.Column<string>(type: "text", nullable: true),
                    BaseStatus = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Name);
                    table.ForeignKey(
                        name: "FK_State_Workflows_WorkflowName",
                        column: x => x.WorkflowName,
                        principalTable: "Workflows",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_State_ZeebeFlow_OnEntryFlowName",
                        column: x => x.OnEntryFlowName,
                        principalTable: "ZeebeFlow",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_State_ZeebeFlow_OnExitFlowName",
                        column: x => x.OnExitFlowName,
                        principalTable: "ZeebeFlow",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "WorkflowEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkflowName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsExclusive = table.Column<bool>(type: "boolean", nullable: false),
                    IsStateManager = table.Column<bool>(type: "boolean", nullable: false),
                    AvailableInStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowEntities_Workflows_WorkflowName",
                        column: x => x.WorkflowName,
                        principalTable: "Workflows",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transition",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    FromStateName = table.Column<string>(type: "text", nullable: false),
                    ToStateName = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    FlowName = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transition", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Transition_State_FromStateName",
                        column: x => x.FromStateName,
                        principalTable: "State",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transition_State_ToStateName",
                        column: x => x.ToStateName,
                        principalTable: "State",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Transition_ZeebeFlow_FlowName",
                        column: x => x.FlowName,
                        principalTable: "ZeebeFlow",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Instances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkflowName = table.Column<string>(type: "text", nullable: false),
                    ZeebeFlowName = table.Column<string>(type: "text", nullable: false),
                    WorkflowEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    StateName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instances_State_StateName",
                        column: x => x.StateName,
                        principalTable: "State",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instances_WorkflowEntities_WorkflowEntityId",
                        column: x => x.WorkflowEntityId,
                        principalTable: "WorkflowEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instances_Workflows_WorkflowName",
                        column: x => x.WorkflowName,
                        principalTable: "Workflows",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instances_ZeebeFlow_ZeebeFlowName",
                        column: x => x.ZeebeFlowName,
                        principalTable: "ZeebeFlow",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    StateNameDescription = table.Column<string>(name: "StateName_Description", type: "text", nullable: true),
                    StateNameTitle = table.Column<string>(name: "StateName_Title", type: "text", nullable: true),
                    TransitionNameForm = table.Column<string>(name: "TransitionName_Form", type: "text", nullable: true),
                    TransitionNameTitle = table.Column<string>(name: "TransitionName_Title", type: "text", nullable: true),
                    WorkflowNameTitle = table.Column<string>(name: "WorkflowName_Title", type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translation_State_StateName_Description",
                        column: x => x.StateNameDescription,
                        principalTable: "State",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Translation_State_StateName_Title",
                        column: x => x.StateNameTitle,
                        principalTable: "State",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Translation_Transition_TransitionName_Form",
                        column: x => x.TransitionNameForm,
                        principalTable: "Transition",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Translation_Transition_TransitionName_Title",
                        column: x => x.TransitionNameTitle,
                        principalTable: "Transition",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Translation_Workflows_WorkflowName_Title",
                        column: x => x.WorkflowNameTitle,
                        principalTable: "Workflows",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "InstanceTransition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstanceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ZeebeFlowName = table.Column<string>(type: "text", nullable: true),
                    OnExitZeebeFlowName = table.Column<string>(type: "text", nullable: true),
                    OnEnterZeebeFlowName = table.Column<string>(type: "text", nullable: true),
                    FromStateName = table.Column<string>(type: "text", nullable: false),
                    ToStateName = table.Column<string>(type: "text", nullable: false),
                    Form = table.Column<string>(type: "text", nullable: false),
                    EntityData = table.Column<string>(type: "text", nullable: false),
                    FormData = table.Column<string>(type: "text", nullable: false),
                    AdditionalData = table.Column<string>(type: "text", nullable: false),
                    FieldUpdates = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstanceTransition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstanceTransition_Instances_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "Instances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstanceTransition_State_FromStateName",
                        column: x => x.FromStateName,
                        principalTable: "State",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstanceTransition_State_ToStateName",
                        column: x => x.ToStateName,
                        principalTable: "State",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstanceTransition_ZeebeFlow_OnEnterZeebeFlowName",
                        column: x => x.OnEnterZeebeFlowName,
                        principalTable: "ZeebeFlow",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_InstanceTransition_ZeebeFlow_OnExitZeebeFlowName",
                        column: x => x.OnExitZeebeFlowName,
                        principalTable: "ZeebeFlow",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_InstanceTransition_ZeebeFlow_ZeebeFlowName",
                        column: x => x.ZeebeFlowName,
                        principalTable: "ZeebeFlow",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "InstanceEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstanceTransitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExecutedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    InputData = table.Column<string>(type: "text", nullable: false),
                    OutputData = table.Column<string>(type: "text", nullable: false),
                    AdditionalData = table.Column<string>(type: "text", nullable: false),
                    FieldUpdates = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstanceEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstanceEvent_InstanceTransition_InstanceTransitionId",
                        column: x => x.InstanceTransitionId,
                        principalTable: "InstanceTransition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Workflows",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Tags", "ZeebeFlowName" },
                values: new object[] { "user", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5490), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5490), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user" }, null });

            migrationBuilder.InsertData(
                table: "ZeebeFlow",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Gateway", "IsAtomic", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Process", "Tags" },
                values: new object[] { "zb-user-reset-password", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4790), new Guid("00000000-0000-0000-0000-000000000000"), null, "https://127.0.0.1", false, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4790), new Guid("00000000-0000-0000-0000-000000000000"), null, "<bpmn:process></bpmn:process>", new[] { "idm", "user", "security" } });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Name", "BaseStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "OnEntryFlowName", "OnExitFlowName", "Type", "WorkflowName" },
                values: new object[,]
                {
                    { "user-active", 4, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5600), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5600), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-deactivated", 16, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5720), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5720), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-start", 2, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5540), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5540), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 100, "user" },
                    { "user-suspended", 16, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5660), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5660), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("07cef274-2851-4ecd-8a02-a8c2247e62da"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5520), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5520), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("265aa140-34b9-4c01-8bff-b8de22c528ba"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5510), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5510), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsExclusive", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[] { new Guid("56288f7d-9b82-462a-b153-76b8b3b164db"), 30, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5530), new Guid("00000000-0000-0000-0000-000000000000"), null, false, true, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5530), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" });

            migrationBuilder.InsertData(
                table: "Workflows",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Tags", "ZeebeFlowName" },
                values: new object[] { "user-reset-password", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4810), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4820), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user", "security" }, "zb-user-reset-password" });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Name", "BaseStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "OnEntryFlowName", "OnExitFlowName", "Type", "WorkflowName" },
                values: new object[,]
                {
                    { "user-reset-password-card-password-valid", 8, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4970), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user-reset-password" },
                    { "user-reset-password-fail", 32, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5210), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 200, "user-reset-password" },
                    { "user-reset-password-security-question-valid", 8, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5090), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5090), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user-reset-password" },
                    { "user-reset-password-set", 32, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5150), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 200, "user-reset-password" },
                    { "user-reset-password-start", 8, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4900), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 100, "user-reset-password" }
                });

            migrationBuilder.InsertData(
                table: "Transition",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "FlowName", "FromStateName", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "ToStateName", "Type" },
                values: new object[,]
                {
                    { "user-activate-fd", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6000), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6000), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", 900 },
                    { "user-activate-fs", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5940), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", 900 },
                    { "user-deactive", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5890), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", 900 },
                    { "user-register", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5770), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", 900 },
                    { "user-suspend", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5830), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5830), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", 900 }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("07869dce-8f18-4d73-81b2-9791ff56594e"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5660), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5660), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("0c68f25a-2156-44ab-887c-54a094061d4b"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5620), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("3aad3c9d-f1c5-4f6c-8307-b9557a1191f2"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5650), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5650), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("3c451709-0b1e-4811-b82f-569a80648ffb"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4880), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("45721c42-9d52-45e2-8fd7-55f1f79d6e7c"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5590), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5590), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("463cd097-434f-46ae-a712-8efc997b6e32"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5700), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5700), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("5fa3c008-003b-431c-9322-90924107a420"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5760), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5760), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("67f4235b-c2e1-44e4-9e9f-b6e57b485016"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("83c74c82-db72-4900-ad44-c7afbc9f06e4"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("870dbbb2-803f-4837-bc66-6f4b6378bbf6"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5630), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("8fb47da9-6116-48d2-b4ed-17f59abc42e6"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5550), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("b48d4c6d-ea99-4c48-ba03-7ec3e30aeb8b"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5730), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("b9c286b6-3403-45b3-9899-2e1f575a4511"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5710), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5710), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("bc32ce4e-5f68-4b3a-a811-4cf03490f8e8"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5770), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5770), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("e73cf177-228b-4498-8d32-107a2a880c40"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4890), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("e7aad396-4bf5-4271-8236-820f0ac73d09"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5580), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5580), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("e819a0ab-1566-471e-81a0-23df2dbbc005"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("f6120ab2-2822-4bfc-b1ea-4359a34d7c70"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsExclusive", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[] { new Guid("db7e41e9-8573-44db-a8a2-515db19256a2"), 30, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4860), new Guid("00000000-0000-0000-0000-000000000000"), null, false, false, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4860), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" });

            migrationBuilder.InsertData(
                table: "Transition",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "FlowName", "FromStateName", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "ToStateName", "Type" },
                values: new object[,]
                {
                    { "user-reset-password-set-password-acp", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5390), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5390), new Guid("00000000-0000-0000-0000-000000000000"), null, null, 900 },
                    { "user-reset-password-set-password-asq", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, 900 },
                    { "user-reset-password-validate-with-card", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, 900 },
                    { "user-reset-password-validate-with-security-question", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, 900 }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("05fafe6f-042b-431f-ada9-c3de984cb546"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4920), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("16d28b8a-9f6f-49e1-b061-a53f4b7afc0c"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5980), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("181f7d3b-1425-4a18-aac9-6bfe3ff7841d"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5110), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5110), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("1d5f458e-1121-4d35-8edf-7c54b5827b36"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5880), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("1e44d476-c9a6-4340-968e-9352e2ba098e"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("20fa47e7-eaac-4ec0-b192-a41ffc75aa3d"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4960), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4960), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("25c675a6-a1e9-4c1d-9736-b4bd7090414a"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("27504536-3721-4068-a086-aa279f291b91"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4990), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("2785abc4-5ab7-4f67-8b2b-9efd0efe4152"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5920), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("2d801842-c550-4acc-97f9-ffffe6e0a3b9"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5240), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5240), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("2f6e8514-a4d1-4fa4-adbe-ada70c3b4120"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6030), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6030), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("5ae9b8d4-2da4-423b-81ce-afc7ee9ef506"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5170), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5170), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("6052a303-ec38-481d-a3f2-e2394169d9c3"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5230), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("60bf2ec6-7d24-428f-9556-2af52a07a32e"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5190), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5190), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("6ec84524-dacb-4d5b-aaaa-4ed2dc7be5e1"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6050), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6050), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("7765aef2-c584-4deb-bf7a-84cb679763a0"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5160), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("7a9d7f14-e270-4b4f-a269-6752edeb20f8"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5990), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("850635a1-7ae9-478c-9954-c9cdefa51d8a"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("940512a0-cc91-4f20-9e16-cc6498e6f8ab"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5260), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5260), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("965b3b35-e347-4be2-bab9-67e84f33b73c"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5910), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5910), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("9884f853-bea7-4732-bc40-f45619ae7206"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4930), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("9af7b946-3999-4ff5-8a4c-72658aa01688"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6010), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6010), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("9b2b0aa1-f034-4d23-ab5c-9817c3d0251d"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5120), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("9e6d7a79-4f4d-4ceb-b768-6cfb8712d49b"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5000), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5000), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("a0b97b11-46e4-4778-b67f-46b95d552faa"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5130), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5130), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("a2006ed2-e221-4773-9a7f-324993317cd8"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("a3cc2723-40a3-4800-80ed-cdfe68f60d66"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5090), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5090), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("a80cef57-de5b-4106-b883-75ff5016b15a"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5800), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("a8363ebd-f84d-4d66-ac4c-161cfbb3019d"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5820), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("add1d72d-7677-41bd-9555-67d08d815568"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5200), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("adfdfaeb-79c4-4e3e-8717-6748e198cef0"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5840), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("b7b3b7e7-de17-42f7-ad9b-3bd58624f956"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6020), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("b8c6bc89-f2b9-40a9-88b3-d6d40923e520"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5140), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5140), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("bae86531-8ea2-429f-9cc3-598e13b50db9"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4940), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4940), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("c6e8cae5-473d-4a0f-be8d-3e9d2cbc5d98"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5870), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("dce4ce18-fa93-48ca-acd2-721edcf6d5c2"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("e428e7f4-ab74-423a-94e8-319cf4d9924c"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5810), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("e9948bfe-1b91-4457-9186-79ce5fa2d10f"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5220), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5220), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("f1436177-7158-4f98-975e-89c453126e89"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4980), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("f2246b8e-8667-4df2-b58b-762261120d9f"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5940), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("064e1512-59bd-4546-842f-375f23851c8c"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5480), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5480), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("07802706-fb12-44ee-99e3-314523d55197"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5450), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("0d256ff8-7d26-4c40-ac18-76cdc893632b"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5350), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("17547f9b-a0bf-4469-9b8a-3e8bc8f31030"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5380), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("21da608c-bb96-4594-817d-1342a409bc69"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("2e1afc4d-9ff4-49ec-b524-44897787aecf"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5370), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("560bb406-2f93-41ec-b2b0-859af905c282"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5280), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("8256dbff-b02e-4825-a08b-d12939117da2"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5400), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("829f0d58-3b45-4f0e-b704-681f8b4dd052"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5420), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5420), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("b8433316-1d4a-427d-8147-9ef481f6f07e"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5340), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("bdb2889d-bdde-45de-adc6-d22ff7d735ed"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5310), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5310), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("bf6f0cb7-8cbb-4498-a959-2c57c031a78c"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5320), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("ced2284a-265d-42b6-b0f2-22cbdc630570"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5300), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("e8d6af44-0d6f-451d-94b7-551699937913"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5460), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5460), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("efa6106c-eaae-469e-a7fb-9f542a5d6c89"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5490), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("f6f661a4-3801-4aa4-bca7-28de027b1f9b"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5430), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstanceEvent_InstanceTransitionId",
                table: "InstanceEvent",
                column: "InstanceTransitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_StateName",
                table: "Instances",
                column: "StateName");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_WorkflowEntityId",
                table: "Instances",
                column: "WorkflowEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_WorkflowName",
                table: "Instances",
                column: "WorkflowName");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_ZeebeFlowName",
                table: "Instances",
                column: "ZeebeFlowName");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransition_FromStateName",
                table: "InstanceTransition",
                column: "FromStateName");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransition_InstanceId",
                table: "InstanceTransition",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransition_OnEnterZeebeFlowName",
                table: "InstanceTransition",
                column: "OnEnterZeebeFlowName");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransition_OnExitZeebeFlowName",
                table: "InstanceTransition",
                column: "OnExitZeebeFlowName");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransition_ToStateName",
                table: "InstanceTransition",
                column: "ToStateName");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransition_ZeebeFlowName",
                table: "InstanceTransition",
                column: "ZeebeFlowName");

            migrationBuilder.CreateIndex(
                name: "IX_State_OnEntryFlowName",
                table: "State",
                column: "OnEntryFlowName");

            migrationBuilder.CreateIndex(
                name: "IX_State_OnExitFlowName",
                table: "State",
                column: "OnExitFlowName");

            migrationBuilder.CreateIndex(
                name: "IX_State_WorkflowName",
                table: "State",
                column: "WorkflowName");

            migrationBuilder.CreateIndex(
                name: "IX_Transition_FlowName",
                table: "Transition",
                column: "FlowName");

            migrationBuilder.CreateIndex(
                name: "IX_Transition_FromStateName",
                table: "Transition",
                column: "FromStateName");

            migrationBuilder.CreateIndex(
                name: "IX_Transition_ToStateName",
                table: "Transition",
                column: "ToStateName");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_StateName_Description",
                table: "Translation",
                column: "StateName_Description");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_StateName_Title",
                table: "Translation",
                column: "StateName_Title");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_TransitionName_Form",
                table: "Translation",
                column: "TransitionName_Form");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_TransitionName_Title",
                table: "Translation",
                column: "TransitionName_Title");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_WorkflowName_Title",
                table: "Translation",
                column: "WorkflowName_Title");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowEntities_WorkflowName",
                table: "WorkflowEntities",
                column: "WorkflowName");

            migrationBuilder.CreateIndex(
                name: "IX_Workflows_ZeebeFlowName",
                table: "Workflows",
                column: "ZeebeFlowName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstanceEvent");

            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropTable(
                name: "InstanceTransition");

            migrationBuilder.DropTable(
                name: "Transition");

            migrationBuilder.DropTable(
                name: "Instances");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "WorkflowEntities");

            migrationBuilder.DropTable(
                name: "Workflows");

            migrationBuilder.DropTable(
                name: "ZeebeFlow");
        }
    }
}
