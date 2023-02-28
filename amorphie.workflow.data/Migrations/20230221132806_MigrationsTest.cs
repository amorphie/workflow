using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationsTest : Migration
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
                    Process = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
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
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstanceEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkflowName = table.Column<string>(type: "text", nullable: false),
                    ZeebeFlowName = table.Column<string>(type: "text", nullable: true),
                    EntityName = table.Column<string>(type: "text", nullable: false),
                    RecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    StateName = table.Column<string>(type: "text", nullable: false),
                    BaseStatus = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_Instances_ZeebeFlow_ZeebeFlowName",
                        column: x => x.ZeebeFlowName,
                        principalTable: "ZeebeFlow",
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
                    EntityData = table.Column<string>(type: "text", nullable: false),
                    FormData = table.Column<string>(type: "text", nullable: true),
                    AdditionalData = table.Column<string>(type: "text", nullable: true),
                    FieldUpdates = table.Column<string>(type: "text", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
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
                name: "States",
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
                    table.PrimaryKey("PK_States", x => x.Name);
                    table.ForeignKey(
                        name: "FK_States_ZeebeFlow_OnEntryFlowName",
                        column: x => x.OnEntryFlowName,
                        principalTable: "ZeebeFlow",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_States_ZeebeFlow_OnExitFlowName",
                        column: x => x.OnExitFlowName,
                        principalTable: "ZeebeFlow",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Transitions",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    FromStateName = table.Column<string>(type: "text", nullable: false),
                    ToStateName = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_Transitions", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Transitions_States_FromStateName",
                        column: x => x.FromStateName,
                        principalTable: "States",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transitions_States_ToStateName",
                        column: x => x.ToStateName,
                        principalTable: "States",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Transitions_ZeebeFlow_FlowName",
                        column: x => x.FlowName,
                        principalTable: "ZeebeFlow",
                        principalColumn: "Name");
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
                        name: "FK_Translation_States_StateName_Description",
                        column: x => x.StateNameDescription,
                        principalTable: "States",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Translation_States_StateName_Title",
                        column: x => x.StateNameTitle,
                        principalTable: "States",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Translation_Transitions_TransitionName_Form",
                        column: x => x.TransitionNameForm,
                        principalTable: "Transitions",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Translation_Transitions_TransitionName_Title",
                        column: x => x.TransitionNameTitle,
                        principalTable: "Transitions",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "WorkflowEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkflowName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsStateManager = table.Column<bool>(type: "boolean", nullable: false),
                    AllowOnlyOneActiveInstance = table.Column<bool>(type: "boolean", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Workflows",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Tags = table.Column<string[]>(type: "text[]", nullable: true),
                    ZeebeFlowName = table.Column<string>(type: "text", nullable: true),
                    WorkflowEntityId = table.Column<Guid>(type: "uuid", nullable: true),
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
                        name: "FK_Workflows_WorkflowEntities_WorkflowEntityId",
                        column: x => x.WorkflowEntityId,
                        principalTable: "WorkflowEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Workflows_ZeebeFlow_ZeebeFlowName",
                        column: x => x.ZeebeFlowName,
                        principalTable: "ZeebeFlow",
                        principalColumn: "Name");
                });

            migrationBuilder.InsertData(
                table: "Workflows",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Tags", "WorkflowEntityId", "ZeebeFlowName" },
                values: new object[,]
                {
                    { "user", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3350), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3350), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user" }, null, null },
                    { "user-reset-password", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2300), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2306), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user", "security" }, null, null }
                });

            migrationBuilder.InsertData(
                table: "ZeebeFlow",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Gateway", "Message", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Process", "Tags" },
                values: new object[] { "user-register", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3325), new Guid("00000000-0000-0000-0000-000000000000"), null, "zeebe-local", "simple-flow-starter", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3326), new Guid("00000000-0000-0000-0000-000000000000"), null, "Process_Simple", new[] { "idm", "user" } });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Name", "BaseStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "OnEntryFlowName", "OnExitFlowName", "Type", "WorkflowName" },
                values: new object[,]
                {
                    { "user-active", 4, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3509), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3510), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-deactivated", 16, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3810), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3811), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-reset-password-card-password-valid", 8, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2596), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2597), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user-reset-password" },
                    { "user-reset-password-fail", 32, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2854), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2854), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 200, "user-reset-password" },
                    { "user-reset-password-security-question-valid", 8, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2684), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2685), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user-reset-password" },
                    { "user-reset-password-set", 32, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2763), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2764), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 200, "user-reset-password" },
                    { "user-reset-password-start", 8, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2485), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2486), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 100, "user-reset-password" },
                    { "user-start", 2, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3427), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3428), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 100, "user" },
                    { "user-suspended", 16, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3596), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3597), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("205b4c22-02e3-4055-a853-cb8a7c00ceef"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2439), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("20776c2d-9e5f-40d1-9e2c-414fda39cf6e"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3385), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3386), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("36b4fcfb-7aa7-4a05-a217-48d8f911f130"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3366), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3367), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("5194138b-aef7-48ff-b94c-617c0c4c9e2b"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2466), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2466), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("820a17a5-c34a-486e-81ec-b3517c7e1d2d"), false, 30, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3412), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3413), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" },
                    { new Guid("b516f575-9d72-4fcd-89b8-250d0fb3f55e"), false, 30, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2398), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2399), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" }
                });

            migrationBuilder.InsertData(
                table: "Transitions",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "FlowName", "FromStateName", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "ToStateName" },
                values: new object[,]
                {
                    { "user-activate-fd", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4270), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4270), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active" },
                    { "user-activate-fs", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4179), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4180), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active" },
                    { "user-deactive", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4094), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4095), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated" },
                    { "user-register", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3907), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-register", "user-start", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3908), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active" },
                    { "user-reset-password-set-password-acp", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3134), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3135), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-reset-password-set-password-asq", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3228), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3229), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-reset-password-validate-with-card", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2939), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2939), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-reset-password-validate-with-security-question", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3049), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3050), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-suspend", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4005), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4006), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("0008f976-3886-4d64-a510-64445db3ed50"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2530), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2531), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("05b07adc-0287-43ea-9fb1-47c9dde8c9a4"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3869), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3870), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("06817e43-0fef-412f-ad91-bec0da19cf5a"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3493), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3494), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("10a82c7f-2742-44f1-9e5f-1a66d95847eb"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2702), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2703), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("10e5a934-fe44-46a0-b987-81866cb56861"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3460), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3461), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("1c630eec-69c1-49bc-9a36-c24fbe54ae4d"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3546), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3547), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("23ab09a4-276e-4c50-9ad2-6ddbffbf0f10"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3629), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3629), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("265bd64e-6397-4307-862a-fa57707901ae"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2631), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2632), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("2bca8579-6b0e-4bc8-a4e9-e2975f78167b"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2924), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2924), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("2ce2be81-3d0b-48de-be7c-d32aab4208dd"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2906), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2907), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("38e11762-7523-4585-93a1-91c3c29cfe12"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2671), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("4493848b-ba42-472f-ae0b-68f84caaabaf"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2780), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2780), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("4adb5793-6027-481e-835e-f2071ebf4d93"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2838), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2839), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("52d3144a-f55e-4566-a97f-d1a6b5f896e8"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3561), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3562), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("58a9651f-3cb1-4426-aa83-f67251285b7c"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3477), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3478), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("5b3b6558-60ee-4b9f-9308-6af2e012822d"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2614), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2615), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("5e6e81cb-27f2-48ab-b51f-bd881d5f61ae"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3647), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3648), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("68513187-53eb-40f5-a616-197c9d6e6e63"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2795), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2796), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("7a9682e9-39ea-4044-9a70-0ed2fc8a33ed"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3581), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3581), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("81899d96-130f-4d1b-9754-91d3732d0f56"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3613), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3615), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("8cfe2943-c827-4d74-8c00-33de8fbbec74"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2889), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("8f6356b2-4490-49b0-96cf-e443c2d17301"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2734), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2734), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("8fc7b7d5-ebe1-4a06-bb0d-9fe2395dc4df"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2717), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2718), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("945dcc0c-e279-41fc-9be5-4a06e2a2177c"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3852), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3853), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("9709518d-e9cb-4a06-843b-7ff3d889efa6"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3444), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3445), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("a867a23f-e78d-47f8-8633-5b9f460bcadc"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2508), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2509), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("abb40dfd-f2d6-4e39-b619-571f24534c0d"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2651), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2652), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("ad9cca2b-abda-44c1-aeff-ad3c629b0f10"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3528), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3529), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("c13734db-0425-47e6-8bc6-1b7416546a97"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2749), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2750), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("c187463d-dad2-4e26-b3dd-d2cd07d5c3ee"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2874), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2875), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("c2903b0c-9668-4297-8027-dc1bc64974a7"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2581), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2581), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("d9c38ede-9d06-475a-9922-6eb024ecf2ca"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3890), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3891), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("f3ab742a-8bb4-457a-9423-aa8ca6b1fe5f"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2816), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2817), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("f512ce7e-ef4f-4104-8294-9574f810d1db"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2555), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2556), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("fd72f63c-8eb3-4c86-bdac-2e96d09ead17"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3834), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3835), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("fe1cb1e3-f021-4a5b-81de-b6727c3dd5d6"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3664), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3665), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("0a1a295f-81a8-4107-8d29-139ecf21d100"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3951), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("151c937a-e211-4f84-a6f0-b41d54bbfe97"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2966), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2967), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("17a54ff2-c732-4e95-8873-02de39a5f024"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4349), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("1f694213-2ec2-4739-8ae5-1106d59d0cce"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3169), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3170), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("2a210647-9c1b-460e-87fe-b46627a5745b"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4149), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("3bf21227-6801-4c19-b91d-e846f0cc7abd"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3211), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3212), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("45a41424-7eeb-406c-8aa9-c3b7acfef623"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4197), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4198), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("48ea4936-e09b-4f55-98e6-a64f7329a29d"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3100), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3101), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("4a24568c-e7da-4c3c-abd5-2ef129e022b3"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3012), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3013), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("51fd24e8-c585-41eb-aac8-b9eae105aba9"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3974), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3975), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("52216830-f711-431d-9a6d-92e98fa9b788"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4026), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4027), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("531af2f8-5b40-44ec-9e2d-c2d1b39ce385"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3034), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3035), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("59d468b9-2574-4659-81ed-fc0edb5db4fc"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4308), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4309), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("5b495af5-5241-4830-a0b7-a1fef4efcbfc"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3151), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3152), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("611c7aed-0c21-408b-9d97-4e2bfd6d5225"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4133), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4134), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("638f6000-53e3-4bb2-9cf4-19014b5b8b25"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3246), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3247), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("66c9ef94-8086-4ade-adfa-6e35f505a39c"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3116), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3117), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("697f9f1d-5b66-4dae-9538-d1eb50b81117"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3262), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3263), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("6a510ddd-fff9-4e89-9ada-ecf0b32557ae"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3065), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3066), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("77bc38f7-8d82-451e-a3a7-9e5e85c92e20"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4291), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4292), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("784f0ae5-e3f2-45fe-b49e-d675c4eb54fd"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3296), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3297), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("7920e726-2f63-4ef9-bf26-232053dbfdbb"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3990), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3991), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("8872807e-01b3-478d-ac9d-366ef61019d8"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4078), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4079), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("910bb885-bd0b-46ac-a6b4-3a666cf3b9c6"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3191), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3192), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("95be0e13-cfd1-44e2-a67e-91e22090baf7"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4231), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4232), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("9e05f778-dd1d-4181-a401-25def73faebb"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2989), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(2990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("a500fce2-17fb-42c3-8971-bc8f47704ef8"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4325), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4326), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("adb9ca8a-3adf-43ac-a690-4695030aad00"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4041), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4042), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("b1f8aabd-0459-4202-9ce7-bbb43dc62c36"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3081), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3082), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("b65b5d66-82c7-4a6d-ba13-c09bb9253aaf"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4254), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4255), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("b8dd140f-84e5-436a-a474-7acffd40dce4"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4215), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4215), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("ba9988f7-9cd1-41be-9730-317e08964fae"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3280), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("e308f686-31ac-4597-8f89-cad510f3b89b"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3932), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(3933), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("f397061d-f94f-4685-940c-1ed9aac68ec6"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4112), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4112), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("f4fa25f0-8dfc-4fce-a9e8-4dfc8d9a3916"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4165), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4166), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("fa6c9e1c-1b6f-4ce5-bdbf-6b34a2300031"), new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4058), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 21, 13, 28, 6, 425, DateTimeKind.Utc).AddTicks(4059), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstanceEvent_InstanceTransitionId",
                table: "InstanceEvent",
                column: "InstanceTransitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_EntityName_RecordId_StateName",
                table: "Instances",
                columns: new[] { "EntityName", "RecordId", "StateName" });

            migrationBuilder.CreateIndex(
                name: "IX_Instances_StateName",
                table: "Instances",
                column: "StateName");

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
                name: "IX_States_OnEntryFlowName",
                table: "States",
                column: "OnEntryFlowName");

            migrationBuilder.CreateIndex(
                name: "IX_States_OnExitFlowName",
                table: "States",
                column: "OnExitFlowName");

            migrationBuilder.CreateIndex(
                name: "IX_States_WorkflowName",
                table: "States",
                column: "WorkflowName");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_FlowName",
                table: "Transitions",
                column: "FlowName");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_FromStateName",
                table: "Transitions",
                column: "FromStateName");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_ToStateName",
                table: "Transitions",
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
                name: "IX_Workflows_WorkflowEntityId",
                table: "Workflows",
                column: "WorkflowEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflows_ZeebeFlowName",
                table: "Workflows",
                column: "ZeebeFlowName");

            migrationBuilder.AddForeignKey(
                name: "FK_InstanceEvent_InstanceTransition_InstanceTransitionId",
                table: "InstanceEvent",
                column: "InstanceTransitionId",
                principalTable: "InstanceTransition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_States_StateName",
                table: "Instances",
                column: "StateName",
                principalTable: "States",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_Workflows_WorkflowName",
                table: "Instances",
                column: "WorkflowName",
                principalTable: "Workflows",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstanceTransition_States_FromStateName",
                table: "InstanceTransition",
                column: "FromStateName",
                principalTable: "States",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstanceTransition_States_ToStateName",
                table: "InstanceTransition",
                column: "ToStateName",
                principalTable: "States",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Workflows_WorkflowName",
                table: "States",
                column: "WorkflowName",
                principalTable: "Workflows",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Workflows_WorkflowName_Title",
                table: "Translation",
                column: "WorkflowName_Title",
                principalTable: "Workflows",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowEntities_Workflows_WorkflowName",
                table: "WorkflowEntities",
                column: "WorkflowName",
                principalTable: "Workflows",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowEntities_Workflows_WorkflowName",
                table: "WorkflowEntities");

            migrationBuilder.DropTable(
                name: "InstanceEvent");

            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropTable(
                name: "InstanceTransition");

            migrationBuilder.DropTable(
                name: "Transitions");

            migrationBuilder.DropTable(
                name: "Instances");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Workflows");

            migrationBuilder.DropTable(
                name: "WorkflowEntities");

            migrationBuilder.DropTable(
                name: "ZeebeFlow");
        }
    }
}
