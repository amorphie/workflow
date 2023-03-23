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
                name: "ZeebeMessages",
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
                    table.PrimaryKey("PK_ZeebeMessages", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "InstanceEvents",
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
                    table.PrimaryKey("PK_InstanceEvents", x => x.Id);
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
                        name: "FK_Instances_ZeebeMessages_ZeebeFlowName",
                        column: x => x.ZeebeFlowName,
                        principalTable: "ZeebeMessages",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "InstanceTransitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstanceId = table.Column<Guid>(type: "uuid", nullable: false),
                    FromStateName = table.Column<string>(type: "text", nullable: false),
                    ToStateName = table.Column<string>(type: "text", nullable: false),
                    EntityData = table.Column<string>(type: "text", nullable: false),
                    FormData = table.Column<string>(type: "text", nullable: true),
                    AdditionalData = table.Column<string>(type: "text", nullable: true),
                    RouteData = table.Column<string>(type: "text", nullable: true),
                    QueryData = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstanceTransitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstanceTransitions_Instances_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "Instances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_States_ZeebeMessages_OnEntryFlowName",
                        column: x => x.OnEntryFlowName,
                        principalTable: "ZeebeMessages",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_States_ZeebeMessages_OnExitFlowName",
                        column: x => x.OnExitFlowName,
                        principalTable: "ZeebeMessages",
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
                    ServiceName = table.Column<string>(type: "text", nullable: true),
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
                        name: "FK_Transitions_ZeebeMessages_FlowName",
                        column: x => x.FlowName,
                        principalTable: "ZeebeMessages",
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
                        name: "FK_Workflows_ZeebeMessages_ZeebeFlowName",
                        column: x => x.ZeebeFlowName,
                        principalTable: "ZeebeMessages",
                        principalColumn: "Name");
                });

            migrationBuilder.InsertData(
                table: "Workflows",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Tags", "WorkflowEntityId", "ZeebeFlowName" },
                values: new object[,]
                {
                    { "user", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4175), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4175), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user" }, null, null },
                    { "user-reset-password", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3572), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3579), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user", "security" }, null, null }
                });

            migrationBuilder.InsertData(
                table: "ZeebeMessages",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Gateway", "Message", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Process", "Tags" },
                values: new object[,]
                {
                    { "user-register", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4140), new Guid("00000000-0000-0000-0000-000000000000"), null, "zeebe-local", "user-register", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4140), new Guid("00000000-0000-0000-0000-000000000000"), null, "User_Register", new[] { "idm", "user" } },
                    { "user-registration-aml-approve", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4159), new Guid("00000000-0000-0000-0000-000000000000"), null, "zeebe-local", "user-registration-aml-approve", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4160), new Guid("00000000-0000-0000-0000-000000000000"), null, "User_Register", new[] { "idm", "user" } },
                    { "user-registration-aml-reject", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4167), new Guid("00000000-0000-0000-0000-000000000000"), null, "zeebe-local", "user-registration-aml-reject", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4168), new Guid("00000000-0000-0000-0000-000000000000"), null, "User_Register", new[] { "idm", "user" } },
                    { "user-registration-approve", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4151), new Guid("00000000-0000-0000-0000-000000000000"), null, "zeebe-local", "user-registration-approve", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4151), new Guid("00000000-0000-0000-0000-000000000000"), null, "User_Register", new[] { "idm", "user" } }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Name", "BaseStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "OnEntryFlowName", "OnExitFlowName", "Type", "WorkflowName" },
                values: new object[,]
                {
                    { "user-active", 4, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4333), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4333), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-aml-approval", 2, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4291), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4292), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-approval", 2, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4250), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4250), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-deactivated", 16, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4412), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4412), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-reset-password-card-password-valid", 8, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3732), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3732), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user-reset-password" },
                    { "user-reset-password-fail", 32, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3860), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 200, "user-reset-password" },
                    { "user-reset-password-security-question-valid", 8, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3779), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3779), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user-reset-password" },
                    { "user-reset-password-set", 32, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3819), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 200, "user-reset-password" },
                    { "user-reset-password-start", 8, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3670), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 100, "user-reset-password" },
                    { "user-start", 2, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4207), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4207), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 100, "user" },
                    { "user-suspended", 16, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4374), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4375), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("480a9a18-aa95-438c-84e6-e36a4d910116"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4192), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4192), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("664b49e1-f608-42e0-b272-302eefa82f95"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3643), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3644), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("6bd613c3-efd4-4e2c-a33b-9c1151af1565"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3660), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3660), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("8d99b4ec-69b1-4149-85c4-5fddd490d031"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4183), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4184), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("725a911b-c81a-40e0-ae98-1952492574cd"), false, 30, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4199), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4200), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" },
                    { new Guid("f819407d-616e-414c-ad33-9966de68edfa"), false, 30, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3632), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3632), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" }
                });

            migrationBuilder.InsertData(
                table: "Transitions",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "FlowName", "FromStateName", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "ServiceName", "ToStateName" },
                values: new object[,]
                {
                    { "user-activate-fd", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4748), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4749), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active" },
                    { "user-activate-fs", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4709), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4709), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active" },
                    { "user-deactive", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4668), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4668), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated" },
                    { "user-register", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4460), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-register", "user-start", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4460), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-approval" },
                    { "user-registration-aml-approve", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4542), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-registration-aml-approve", "user-aml-approval", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4542), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active" },
                    { "user-registration-aml-reject", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4583), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-registration-aml-reject", "user-aml-approval", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4583), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated" },
                    { "user-registration-approve", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4500), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-registration-approve", "user-approval", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4501), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-aml-approval" },
                    { "user-reset-password-set-password-acp", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4049), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4050), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { "user-reset-password-set-password-asq", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4090), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4090), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { "user-reset-password-validate-with-card", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3958), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3958), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { "user-reset-password-validate-with-security-question", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4003), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4003), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { "user-suspend", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4626), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4626), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("0104f67e-7ed2-4511-b0ce-1b27a9013b18"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3757), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3758), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("0825a700-2d8a-48db-8403-45f59f4db459"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4405), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4405), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("0cd3c97d-6c1d-4ecf-873d-22f042a737de"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4452), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4453), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("117ded14-1c3c-4e2d-8956-defdf7610422"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4360), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4360), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("21475bb9-86b6-4b3b-9a4d-44b7942fa340"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3695), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3696), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("2658752d-ae8d-477b-bd4d-afe267ab181e"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4325), new Guid("00000000-0000-0000-0000-000000000000"), null, "AML approval description", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4326), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-aml-approval", null, null, null, null },
                    { new Guid("2c3daa04-d683-4efe-85f4-90707615625e"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4223), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4223), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("2ea1cf98-b124-4806-ae1d-866f01918032"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3724), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3724), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("37b77614-2646-49ea-a3e0-d6bbb478abe2"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3766), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3767), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("398768db-bc3f-494c-b4fa-15c5d2fb396e"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4397), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4398), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("3b29a45a-808f-4eed-af3c-d2fa0c662860"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4435), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4435), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("3d78582c-7da7-4cbf-a4ae-549948ee5567"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4444), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4445), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("4483327d-dc3f-4d26-bb46-56857777b3b2"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4235), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4235), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("45b47b61-a8a9-405c-a8e2-85131a46a4a6"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4390), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4390), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("4709fbcf-ad2a-4eb1-b801-1c33a975d7d1"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3812), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3813), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("48487ec9-5a9a-4318-8dfb-d8ec04cb262a"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3703), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3704), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("4aa2da21-9915-40b2-a32c-cb606ddf377a"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4276), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici onay aciklamasi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4276), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-approval", null, null, null, null },
                    { new Guid("4fe23bf4-6103-4e7d-a287-037430664b53"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3829), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3829), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("53b6b468-c48f-48a5-bfb3-84aaf62b7007"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4243), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4244), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("617b133d-85bb-4d09-88bd-35f667234f08"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3795), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3795), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("627d0dfe-8de8-4fbf-93a1-dfebeb998aad"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4283), new Guid("00000000-0000-0000-0000-000000000000"), null, "User approval description", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4284), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-approval", null, null, null, null },
                    { new Guid("644a9df9-211d-4eb0-9d44-c1d805c01c40"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4352), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4352), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("65bc58d8-5818-4f39-abef-492b535b2032"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4316), new Guid("00000000-0000-0000-0000-000000000000"), null, "AML onay asama aciklamasi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4317), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-aml-approval", null, null, null, null },
                    { new Guid("67010a65-4c3c-4000-82df-c4308520e159"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3685), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3685), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("6e6b1bf6-4719-4705-a3f5-3b7aff3605ea"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3950), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("6e795e51-be9f-4864-95ef-dd2b5454286e"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4308), new Guid("00000000-0000-0000-0000-000000000000"), null, "AML Approval State", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4309), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-aml-approval", null, null, null },
                    { new Guid("760344a9-bfe3-41df-80a2-cd7243446450"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3876), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3876), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("76ee48ca-cd87-4932-8797-100607a97bea"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3741), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3741), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("83aa73ff-9116-432a-a531-e73276322e5b"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4382), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4383), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("86a557f0-9eea-467e-9626-c6b6655b1be3"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4422), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4423), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("9fcf4d41-e886-4856-a184-be259528e697"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3749), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3749), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("a2c45d9c-df8c-4a97-aebc-e8146f1e4d3e"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4300), new Guid("00000000-0000-0000-0000-000000000000"), null, "AML Onay Asamasi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4301), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-aml-approval", null, null, null },
                    { new Guid("b9702742-223e-438d-9da4-ef896a4c3ca5"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4215), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4215), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("c85e2d5c-308b-4700-be29-f11028f80d53"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4267), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Approval State", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4268), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-approval", null, null, null },
                    { new Guid("ca22910f-4ac6-4657-ac5a-8ceda695c4fd"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3853), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3854), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("d4aa8a5e-c060-4260-b03c-48175eed12bf"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4259), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Onay Asamasi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-approval", null, null, null },
                    { new Guid("db89cee9-e1bb-49d0-9de7-228fb481cfc1"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3802), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3803), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("de331e35-db6c-4487-9c99-8d5e28c7b07c"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4368), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4368), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("e12f8e00-37d3-4bb0-9174-7b28d1adc718"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4344), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4344), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("e56500ef-ae5c-4a33-a7b5-62e2abb2a5a8"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3837), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3837), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("f19ecb9b-48c1-4ce6-8ed0-8633c2115a5a"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3869), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3869), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("f8c95927-fb68-41b8-903b-e6cf564e89f2"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3937), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3938), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("fd5dfd6b-d4f1-4995-92f7-958601ac2a7c"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3787), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3788), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("fe347d48-6d9f-41bd-b32e-b5b2f44eee10"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3844), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3845), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("01200cd7-b968-4e4a-b3c3-3a4b84f78ab0"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4469), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Onayla", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4469), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("01de74d3-4eff-4953-aa91-88410bd2caee"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4493), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4494), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("02cfdcdd-8b87-4852-9056-16ef9614a205"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4517), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4518), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-registration-approve", null },
                    { new Guid("03fb1192-60d6-4447-b2c5-1ee62aefd5b4"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4011), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4011), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("0a2d0785-99bf-4ae5-a899-114df2130519"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4550), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici AML Onay", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-registration-aml-approve", null },
                    { new Guid("0f688f77-2efb-4415-af42-6d2f98f1fecb"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4058), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4058), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("10d558fd-e05f-4571-8b0b-305dc686e40c"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3978), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3978), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("126f3ccd-91f8-42d4-9512-6126ca5d04fe"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4028), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4028), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("13db5c38-f0a6-4140-8eaf-499027499d46"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4775), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4776), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("1479812f-8f7e-456a-9717-f0f15b4cf764"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4685), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4685), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("1e6f7f63-4080-4d56-968e-d284fa555cc8"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4608), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4608), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-registration-aml-reject", null, null },
                    { new Guid("1f5ce636-15a2-495c-80a4-d2c31ee01277"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4526), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4526), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-registration-approve", null, null },
                    { new Guid("236e4f50-fc4c-40af-9cf0-7ebff1a2711f"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4478), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Registration Approve", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4478), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("27aa2d7a-c7f0-4f3b-8264-e72ff983aa61"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4653), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4654), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("2e143ce9-4136-471e-b8a6-f6abcd218d43"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4619), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4619), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-registration-aml-reject", null, null },
                    { new Guid("36a29134-c6d3-4c46-9e5a-7f0f48a56b8d"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4701), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4701), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("386d3f2c-3e6d-400c-9033-b19484e5790c"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3968), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3968), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("396d6ad6-15c4-4f9e-b8f2-1bba89bb8d75"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4575), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4575), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-registration-aml-approve", null, null },
                    { new Guid("3fdd3a91-9fb6-4f48-9339-dabfce7a8797"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4783), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4783), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("3fef990e-8f2d-44ed-94da-6f3ae3eda395"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4113), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4114), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("4830326c-920c-4492-bf39-c336c31dce51"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4510), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4510), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-registration-approve", null },
                    { new Guid("4d9bcaf0-b5d5-4d55-bf0b-06a55f994d3f"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4066), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4066), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("59f14a7e-10d1-44b1-831f-148a3f0ef948"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4486), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4486), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("5d76355d-fc38-4e39-8693-93c2358f6420"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4593), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici AML Ret", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4593), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-registration-aml-reject", null },
                    { new Guid("615721fc-a9c6-427a-bf81-f795df2a4fea"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4716), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4716), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("634a96da-0692-404b-9636-ee3a00bafeea"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4600), new Guid("00000000-0000-0000-0000-000000000000"), null, "User AML Reject", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4601), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-registration-aml-reject", null },
                    { new Guid("66f7176b-6637-4ddf-9860-9a49a40f1d7c"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4567), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4567), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-registration-aml-approve", null, null },
                    { new Guid("6d957526-1f11-4b5e-a6e7-38bf8b11198d"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4661), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4661), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("6e1b2c1f-0333-45e3-a8be-fc3ac1441cc7"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4098), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4098), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("72bd3c07-b774-4355-9121-3e2e6f05e9ae"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3995), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3996), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("7964a323-e246-40d5-8cab-0f0ed2025cc3"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4638), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4638), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("79dde890-bda1-4651-8acf-3bd49d2efe5e"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4074), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4074), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("7c4fd3b4-ea9c-409f-b6f6-5709244e42a3"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4740), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4741), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("7c9c18b2-e1d9-432d-8aee-55828000dfb9"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4677), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4677), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("7f4f9947-a3f2-4584-8e4e-2de3a8e505f3"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4105), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4106), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("910ded9b-b823-4af2-882c-8eb47d863e09"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3986), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(3986), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("a453b1b8-2103-4fcb-af82-49a3451ad5d9"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4693), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4693), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("ad85f257-9292-4ee9-acca-9a9e24633557"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4123), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4123), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("b8648c81-2767-408c-ba26-9e37447bf83f"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4083), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4083), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("b9ac1670-b51c-4882-847f-b5b1164de55e"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4767), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4767), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("c545d13b-3dd7-4e1e-a587-395970f2bfcf"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4558), new Guid("00000000-0000-0000-0000-000000000000"), null, "User AML Approve", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4559), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-registration-aml-approve", null },
                    { new Guid("ce340227-f8b6-44e9-a0bc-3c76dd7e3d2c"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4019), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("d26a10f6-a627-469d-a22f-a07065945c00"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4534), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4534), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-registration-approve", null, null },
                    { new Guid("da3e5e53-5c53-4c3d-95af-18d16e7ec1db"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4759), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4759), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("e287c979-b64f-4aad-bcac-0c527406ca39"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4732), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4733), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("ee18604e-1247-4562-91a0-3077ff9c2d3c"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4041), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4042), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("f6d977e2-b751-4d41-8679-aaef2b0ecbf2"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4645), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4646), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("f85a604e-8cd2-49c6-954d-761697df8d00"), new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4724), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 3, 23, 7, 11, 48, 354, DateTimeKind.Utc).AddTicks(4724), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstanceEvents_InstanceTransitionId",
                table: "InstanceEvents",
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
                name: "IX_InstanceTransitions_FromStateName",
                table: "InstanceTransitions",
                column: "FromStateName");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransitions_InstanceId",
                table: "InstanceTransitions",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransitions_ToStateName",
                table: "InstanceTransitions",
                column: "ToStateName");

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
                name: "FK_InstanceEvents_InstanceTransitions_InstanceTransitionId",
                table: "InstanceEvents",
                column: "InstanceTransitionId",
                principalTable: "InstanceTransitions",
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
                name: "FK_InstanceTransitions_States_FromStateName",
                table: "InstanceTransitions",
                column: "FromStateName",
                principalTable: "States",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstanceTransitions_States_ToStateName",
                table: "InstanceTransitions",
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
                name: "InstanceEvents");

            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropTable(
                name: "InstanceTransitions");

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
                name: "ZeebeMessages");
        }
    }
}
