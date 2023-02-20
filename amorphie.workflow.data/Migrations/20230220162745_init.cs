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
                    { "user", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3910), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3910), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user" }, null, null },
                    { "user-reset-password", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3230), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3230), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user", "security" }, null, null }
                });

            migrationBuilder.InsertData(
                table: "ZeebeFlow",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Gateway", "Message", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Process", "Tags" },
                values: new object[] { "user-register", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3900), new Guid("00000000-0000-0000-0000-000000000000"), null, "zeebe-local", "simple-flow-starter", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Process_Simple", new[] { "idm", "user" } });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Name", "BaseStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "OnEntryFlowName", "OnExitFlowName", "Type", "WorkflowName" },
                values: new object[,]
                {
                    { "user-active", 4, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4010), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4010), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-deactivated", 16, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4130), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4130), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-reset-password-card-password-valid", 8, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3420), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3420), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user-reset-password" },
                    { "user-reset-password-fail", 32, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3600), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3600), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 200, "user-reset-password" },
                    { "user-reset-password-security-question-valid", 8, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3480), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3480), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user-reset-password" },
                    { "user-reset-password-set", 32, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3540), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3540), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 200, "user-reset-password" },
                    { "user-reset-password-start", 8, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3350), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 100, "user-reset-password" },
                    { "user-start", 2, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3950), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 100, "user" },
                    { "user-suspended", 16, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4070), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4070), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("315661ba-e293-428b-a8db-13b82e02489c"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3930), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("39d47d2c-4ab8-4e71-b85a-3bb3d8c0b0b6"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3340), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("a0576544-bf2a-4f4c-b898-b9d010ccfb4e"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3920), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("d76faa70-0b86-4ccf-9c30-aa2360fe8b68"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("8cca3027-f96e-467b-a226-d98aa6c5741e"), false, 30, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3310), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3310), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" },
                    { new Guid("e2e0ecf6-1e41-4a2a-86d6-78f3c829f368"), false, 30, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3950), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3950), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" }
                });

            migrationBuilder.InsertData(
                table: "Transitions",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "FlowName", "FromStateName", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "ToStateName" },
                values: new object[,]
                {
                    { "user-activate-fd", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4420), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4420), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active" },
                    { "user-activate-fs", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4360), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4360), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active" },
                    { "user-deactive", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4300), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated" },
                    { "user-register", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4190), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-register", "user-start", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4190), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active" },
                    { "user-reset-password-set-password-acp", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3780), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3780), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-reset-password-set-password-asq", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3840), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-reset-password-validate-with-card", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3660), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3660), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-reset-password-validate-with-security-question", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3720), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3720), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-suspend", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4250), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4250), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("0c262298-1da8-4670-8e1f-147a2d480558"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3450), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("105e31cf-e8d5-49d9-958e-b6f8ef736d74"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4160), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("1d5baf17-b259-4752-9800-2b4d350d6717"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4180), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4180), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("20707b95-0ae7-4e38-800b-de1774f8dc6e"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3650), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3650), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("255a6216-344a-4e8a-a6b5-108664983cb0"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4080), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4080), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("27f487f6-123b-44be-8408-198129cc032c"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4140), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4140), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("293567cf-9d23-45e9-85b7-921779068744"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3400), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3400), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("2f593f4b-b5a1-4d83-8af2-7a8efcdc9a13"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3630), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("3a5a0861-4e80-4e5a-83aa-c1cc443ff6c9"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3500), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("3d002f06-226e-4e35-a6b3-7dad277cde65"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4110), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4110), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("44684680-e32d-4b29-b603-24e5a2ba5981"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4040), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("5a9932f2-4ec9-452c-b375-d4fa95fbf759"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("60be02a5-6745-4683-8a6f-c171048cc051"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3990), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3990), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("66f15fe6-d7aa-4400-9c06-3cc53999b26a"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3590), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3590), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("673f518c-f522-4244-8bd0-3352f35cb896"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4090), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("6be7f6c3-66f8-4c31-b384-1ce6100b233f"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4050), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4050), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("88052587-466d-4b90-9709-a20543fa844a"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("8890e3ca-3de5-4c4e-89b2-553120063337"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("97a8eed6-59d2-46e3-9b9e-c0626e10fc84"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4120), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("997585ad-0fab-423f-a2c7-070b2784179f"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3570), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("9bc826eb-b105-4c8c-b986-31b03774e5e3"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3410), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("a055be4f-6b87-46df-89bf-8ffa8c44f1cc"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4000), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4000), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("a658e5b5-1a39-4db8-bd7f-51f645d20938"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("a7490a88-5232-4571-b59d-a5e6388a0b84"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3460), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3460), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("acfa9e90-f1ba-4e7b-a968-80812edd3938"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4020), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("af1950da-a183-4a20-bd0d-84ca817e2cec"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3980), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("b6f3c3f4-a930-48b0-9818-73725246aa5e"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3520), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("d4ec2378-e1b6-4a54-9254-1cdb083f06de"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4170), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4170), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("d6aeb04a-c5df-49cf-bfba-6d77df92041b"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("e4884a5f-5ef9-4105-be97-eb7d7d0269d6"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3470), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3470), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("e9ee5bad-b184-4116-b887-f910b6caf80f"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3550), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("ec481e9f-2e15-454f-b6e0-23e09ea9c27f"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4060), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4060), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("f51f5535-ad6c-4edb-be20-d9dcc623a7f7"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3640), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3640), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("f85e3f9d-975d-45ac-b60d-ee079772a68a"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3490), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("f94e91c3-daf0-4890-8b0a-5a534194f137"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3530), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3530), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("f9aa0645-50b4-47d3-9c55-c02ea66973fa"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3430), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("0aa2ffa5-e90a-4641-81a2-456a1807b89f"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3720), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3720), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("0ac6c4b0-6065-4789-8fc3-3376c4d72bcc"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3880), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("18f7e2b6-ac53-4896-aa5e-133630d2b3d0"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3890), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("1c8ceb70-82c9-4e55-a6cd-c66caaaef5e1"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4210), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("21bd0d58-16c8-461c-8069-bc082161919c"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4280), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("29bb3e46-8bac-44ea-b8a9-17d43f32d868"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4400), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("2a7bcb4c-992e-4681-b17c-30e0c1c9c54a"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3730), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("2f746824-87e7-4eef-871a-b683bf26a4a4"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3700), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3700), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("39ef18b3-d1f5-4dc5-a28b-320d73ba1a59"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("3d311d51-331a-4feb-9434-29b81d9ebdf0"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3770), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("3f4db356-729d-4103-b997-6efaf2ed1ca3"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("46346198-00e6-45f8-b116-3845df6eadac"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("5ef7a902-317f-449e-bfdd-141811aeb5c1"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3830), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3830), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("649e6cb6-e22b-4ec3-9085-f3c850f24a30"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4440), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("6954a6e4-4ef3-4198-8520-8ca4a52e788e"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4260), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("7449a1b9-ad2e-445c-b934-33daabba1e0e"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("7a2bc2d4-05b5-412a-a67e-558655349987"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("7a8d37f4-f05a-4739-9853-72ceb6fc32ed"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4300), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("7e2b3f4e-bcd7-4457-b399-fee45aa82128"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4350), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("8c7e0907-b587-4b2e-af0e-84a59bd85752"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("8ccecce1-475e-4abb-b516-0aec978a5f30"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3820), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("8ef018a0-b4e4-4197-8e08-ce7d93cac41d"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("98550588-7483-4983-907b-e0358f2b7c23"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4230), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("996216ec-7aa0-494e-ae3e-99745b951fc6"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4430), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("9b44c173-da67-47c2-9a64-6a625fc80712"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4340), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("a3ccb58d-0031-4ab0-8fd5-21ee01409d1c"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4410), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("aaec9470-889a-4d5e-b84a-af3036a67f52"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4270), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4270), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("b19dd88f-54f2-44e8-b182-3c72c4fdfd7b"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4390), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4390), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("bbe6c678-42da-4c08-834a-f71a85fd663b"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("cadb5376-7208-495d-bdf8-a13ece7a7bbe"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3750), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3750), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("d8958ea4-fd4b-4629-9ff9-9334363b3768"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4240), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4240), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("ebff85d3-21a2-45eb-bf4d-37f05c40d7f4"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4460), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4460), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("f13630a4-4139-4559-8706-ba09c969646a"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4470), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4470), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("f672f642-4543-4667-88a8-36cf0960d2be"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3760), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("fca32c65-d1de-4340-9a5c-1a0087772e44"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3860), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("fcc643ea-847c-4207-8cd0-1bb0007fb1e2"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3800), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null }
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
                name: "ZeebeFlow");
        }
    }
}
