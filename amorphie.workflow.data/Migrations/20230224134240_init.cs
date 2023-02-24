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
                name: "ZeebeMessage",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Tags = table.Column<string[]>(type: "text[]", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_ZeebeMessage", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "InstanceEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstanceTransitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExecutedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    InputData = table.Column<string>(type: "text", nullable: false),
                    OutputData = table.Column<string>(type: "text", nullable: false),
                    AdditionalData = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
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
                        name: "FK_Instances_ZeebeMessage_ZeebeFlowName",
                        column: x => x.ZeebeFlowName,
                        principalTable: "ZeebeMessage",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "InstanceTransition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstanceId = table.Column<Guid>(type: "uuid", nullable: false),
                    FromStateName = table.Column<string>(type: "text", nullable: false),
                    ToStateName = table.Column<string>(type: "text", nullable: false),
                    EntityData = table.Column<string>(type: "text", nullable: false),
                    FormData = table.Column<string>(type: "text", nullable: true),
                    AdditionalData = table.Column<string>(type: "text", nullable: true),
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
                        name: "FK_State_ZeebeMessage_OnEntryFlowName",
                        column: x => x.OnEntryFlowName,
                        principalTable: "ZeebeMessage",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_State_ZeebeMessage_OnExitFlowName",
                        column: x => x.OnExitFlowName,
                        principalTable: "ZeebeMessage",
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
                        name: "FK_Transitions_State_FromStateName",
                        column: x => x.FromStateName,
                        principalTable: "State",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transitions_State_ToStateName",
                        column: x => x.ToStateName,
                        principalTable: "State",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Transitions_ZeebeMessage_FlowName",
                        column: x => x.FlowName,
                        principalTable: "ZeebeMessage",
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
                        name: "FK_Workflows_ZeebeMessage_ZeebeFlowName",
                        column: x => x.ZeebeFlowName,
                        principalTable: "ZeebeMessage",
                        principalColumn: "Name");
                });

            migrationBuilder.InsertData(
                table: "Workflows",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Tags", "WorkflowEntityId", "ZeebeFlowName" },
                values: new object[,]
                {
                    { "user", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4310), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4310), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user" }, null, null },
                    { "user-reset-password", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3620), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3630), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user", "security" }, null, null }
                });

            migrationBuilder.InsertData(
                table: "ZeebeMessage",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Gateway", "Message", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Process", "Tags" },
                values: new object[] { "user-register", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4300), new Guid("00000000-0000-0000-0000-000000000000"), null, "zeebe-local", "simple-flow-starter", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4300), new Guid("00000000-0000-0000-0000-000000000000"), null, "Process_Simple", new[] { "idm", "user" } });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Name", "BaseStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "OnEntryFlowName", "OnExitFlowName", "Type", "WorkflowName" },
                values: new object[,]
                {
                    { "user-active", 4, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4420), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4420), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-deactivated", 16, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4530), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4530), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-reset-password-card-password-valid", 8, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3810), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user-reset-password" },
                    { "user-reset-password-fail", 32, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4000), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4000), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 200, "user-reset-password" },
                    { "user-reset-password-security-question-valid", 8, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3880), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user-reset-password" },
                    { "user-reset-password-set", 32, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3930), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 200, "user-reset-password" },
                    { "user-reset-password-start", 8, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3740), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 100, "user-reset-password" },
                    { "user-start", 2, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4360), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4360), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 100, "user" },
                    { "user-suspended", 16, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4470), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4470), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("27f6669e-1b29-40d6-a551-a25bf93b7f19"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("54c8c998-0ef8-4444-a6de-f9375525a461"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4340), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("830bab27-8039-4db3-b2fe-1c979dfc9dd4"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3730), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("b38b9e25-4aa5-4310-b22a-1a740895c1bc"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3720), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3720), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("6ae29e8d-98ae-434b-a5f9-e25ce0971301"), false, 30, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3700), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3700), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" },
                    { new Guid("724db99a-d2d4-41f3-a4b1-cdb07ca6357b"), false, 30, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4350), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4350), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" }
                });

            migrationBuilder.InsertData(
                table: "Transitions",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "FlowName", "FromStateName", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "ToStateName" },
                values: new object[,]
                {
                    { "user-activate-fd", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4820), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active" },
                    { "user-activate-fs", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4760), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active" },
                    { "user-deactive", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4710), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4710), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated" },
                    { "user-register", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4590), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-register", "user-start", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4590), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active" },
                    { "user-reset-password-set-password-acp", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4180), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4180), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-reset-password-set-password-asq", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4240), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4240), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-reset-password-validate-with-card", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4050), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4050), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-reset-password-validate-with-security-question", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4120), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4120), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-suspend", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4650), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4650), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("096ab922-11be-4349-81ba-dbbec2108372"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4390), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4390), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("10d64dd3-38b7-4541-83d7-914d338afe6e"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("118d851f-7108-4e6d-ba3c-db7579e7adb6"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4500), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("17ce83ba-3bbe-42c6-8660-565e424a374d"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4030), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4030), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("19c32298-164f-4582-ad80-3ac4700d067e"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("1a692c6f-9ded-4cb5-9932-e4a1c5b313cf"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4410), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("1ddd4e75-e5a7-4218-9c1b-f943c098c6a6"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4510), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4510), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("2e3f9d09-e878-44eb-b42a-43bd16dd3279"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3840), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("2fbfd663-62d2-45a1-b318-72e93a2e8c44"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3800), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3800), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("330b40cb-9179-4414-9ac5-d8bc41f0ee1f"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4580), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4580), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("38499b93-d396-498f-bad3-4b4122419211"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3850), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("3b05b84e-b83a-4304-8dbd-4c72a328466e"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3790), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("47b434fc-7caf-4454-95ea-fa6497133335"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4550), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("58cecb04-3ff0-4704-97e8-2da90f7e08f3"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4430), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("76a31af1-3f6b-4e05-8287-5eb91677c1d7"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4010), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4010), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("7eabdaf9-5b2d-400a-8480-91a178c7d934"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3990), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3990), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("83a2e7fa-4886-4a31-b416-b1aba3088b1c"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4020), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("83e3dc48-3b0b-4f2c-a7c7-87ea438af050"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3930), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3930), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("841da2ed-858d-4a56-b3f8-d431b1173915"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4470), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4470), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("95fb1832-9ab9-4ab0-8fb8-ead11d4e7b5a"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("9b40213d-fadb-4772-aa7b-5f22828e47c0"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4490), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("a73acbd3-8116-4097-9bfd-e3d538fd351f"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4570), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("babde9bb-6f4f-46ff-baf0-865d6135092e"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("c5a5e8f4-5143-4130-b4f4-9a0cff92756b"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("ced78b37-9b71-4949-82b5-11c28f28824b"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4050), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4050), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("cf83c5c5-b714-476c-9747-bc8371b7f50e"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4450), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4450), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("d14f6b88-121e-4430-a4ac-6b468d37f8e8"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3960), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3960), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("d5a6f636-5cc1-4db7-af8c-c1786c1dff3a"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3760), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("dd0d49c0-8ae5-4d5d-b5ac-c1d31c4a4f86"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3870), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3870), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("e609cbd4-67de-4ee5-a2e4-211a35e28a90"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3970), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("e7db1968-5831-4e4b-b05f-4fe2a369571c"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3770), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("f270e8ad-7b1f-4a26-812e-81227e50c050"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3820), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("f2edeb48-05b3-4ab7-a0d2-309c2b381670"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3890), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("f4823823-0048-45c6-aba7-5e2ae744b140"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3910), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(3910), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("f4b2570a-216c-4dcb-846b-bdf547dad3dd"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4440), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("fb59e962-e530-4ec7-a04a-9078c15bda4d"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4520), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("00035bcf-79d8-4d9a-b29c-4d9a55cec533"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4280), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("05a79c39-8680-4a10-9d1a-c2ca378608f0"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4870), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("15d9a162-45b7-4a01-8224-5f5f3bd0f4b1"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4210), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("18bca9c3-b3df-4aa6-983c-ac6950b1ab00"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4150), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("1b3d3f9c-35e8-4ccc-bf8b-407c140f73eb"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4220), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4220), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("1b622072-6aab-42d1-9bb0-435735002b03"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4070), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4070), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("1d03a93b-2bbe-46fe-82ea-2c931e164bfa"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4730), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("226ae314-0eb4-4c1d-8cef-70245903350e"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4750), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4750), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("2b43c349-956d-4cc6-9b72-3917ddd295c2"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4720), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4720), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("2f4a8caf-81cf-4a86-84ab-a5059a95b0b0"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4190), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4190), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("3364f765-d964-4976-adac-403a0aac89e0"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4260), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("3bb6fd99-d6d5-4ba0-b0d6-29ffb045e385"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4100), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("42d644a5-b59b-4561-946b-1f292e84a9dc"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4630), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("699c6853-95d2-4a9e-832a-ae43ed06880a"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4170), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4170), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("69ecd83f-2e29-405d-8445-99fab98d7b96"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4810), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("7434d8a2-98c5-4a4f-a600-3658cfc3fba6"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4780), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4780), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("74ee1f32-91e6-47e2-bc01-ad003261ff69"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4760), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("827d0faf-31c1-48d6-82d8-1647e0fa6969"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4690), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("84d410d6-495f-4780-9e86-442a27c52714"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("85f8b03d-5ca3-42d6-8b70-c6a85d553ea4"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4800), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("8a716443-62b4-4e17-8e22-6f063c3aa5c9"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4640), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4640), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("91c2f1f5-71c2-44b9-8902-a6ff42d97ce1"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4160), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("9899b900-3539-4bfa-a529-54307885dd92"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4830), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4830), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("a0601857-c9f3-44cd-9bdd-01af0f962a66"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4290), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4290), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("a4e8af1f-a4a4-47a2-8771-83520d4437c6"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4860), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("aa269eb0-6b19-41a3-b6c0-ac49ada6317b"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4250), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4250), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("abb1b3c7-7b63-4e1c-a9f2-88a7322285a0"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4110), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4110), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("b1dd6f42-e2fb-43f1-92d4-c5fa83057523"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4700), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4700), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("c16230c8-a1dc-435e-9d40-7a3efe7ce56b"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("c96c97d8-9b39-4428-b2c3-ccb52ca61af3"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4230), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("d393fd93-397f-4de0-b60f-6c29a443142d"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("d5b47376-64a0-43fc-904c-4a51b4b04807"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("d8377a9b-89c4-4881-adcc-602c09d78ca3"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4660), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4660), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("db3e9f3f-25fb-4c78-a7e0-05647c56a03d"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4130), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4130), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("e18c5b70-c1c2-4ace-ac4e-2a37a8040640"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4600), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4600), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("ed2c8b64-c0a1-4eae-93c1-27b44c155a84"), new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4080), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 24, 13, 42, 39, 849, DateTimeKind.Utc).AddTicks(4080), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null }
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
                name: "IX_InstanceTransition_ToStateName",
                table: "InstanceTransition",
                column: "ToStateName");

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
                name: "FK_Instances_State_StateName",
                table: "Instances",
                column: "StateName",
                principalTable: "State",
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
                name: "FK_InstanceTransition_State_FromStateName",
                table: "InstanceTransition",
                column: "FromStateName",
                principalTable: "State",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstanceTransition_State_ToStateName",
                table: "InstanceTransition",
                column: "ToStateName",
                principalTable: "State",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_State_Workflows_WorkflowName",
                table: "State",
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
                name: "State");

            migrationBuilder.DropTable(
                name: "Workflows");

            migrationBuilder.DropTable(
                name: "WorkflowEntities");

            migrationBuilder.DropTable(
                name: "ZeebeMessage");
        }
    }
}
