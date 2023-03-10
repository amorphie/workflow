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
                        name: "FK_Instances_ZeebeMessage_ZeebeFlowName",
                        column: x => x.ZeebeFlowName,
                        principalTable: "ZeebeMessage",
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
                        name: "FK_States_ZeebeMessage_OnEntryFlowName",
                        column: x => x.OnEntryFlowName,
                        principalTable: "ZeebeMessage",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_States_ZeebeMessage_OnExitFlowName",
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
                    { "user", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(847), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(848), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user" }, null, null },
                    { "user-reset-password", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9228), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9236), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user", "security" }, null, null }
                });

            migrationBuilder.InsertData(
                table: "ZeebeMessage",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Gateway", "Message", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Process", "Tags" },
                values: new object[,]
                {
                    { "user-register", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(759), new Guid("00000000-0000-0000-0000-000000000000"), null, "zeebe-local", "user-register", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(760), new Guid("00000000-0000-0000-0000-000000000000"), null, "User_Register", new[] { "idm", "user" } },
                    { "user-registration-aml-approve", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(801), new Guid("00000000-0000-0000-0000-000000000000"), null, "zeebe-local", "user-registration-aml-approve", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(802), new Guid("00000000-0000-0000-0000-000000000000"), null, "User_Register", new[] { "idm", "user" } },
                    { "user-registration-aml-reject", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(820), new Guid("00000000-0000-0000-0000-000000000000"), null, "zeebe-local", "user-registration-aml-reject", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(821), new Guid("00000000-0000-0000-0000-000000000000"), null, "User_Register", new[] { "idm", "user" } },
                    { "user-registration-approve", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(783), new Guid("00000000-0000-0000-0000-000000000000"), null, "zeebe-local", "user-registration-approve", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(784), new Guid("00000000-0000-0000-0000-000000000000"), null, "User_Register", new[] { "idm", "user" } }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Name", "BaseStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "OnEntryFlowName", "OnExitFlowName", "Type", "WorkflowName" },
                values: new object[,]
                {
                    { "user-active", 4, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1341), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1342), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-aml-approval", 2, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1174), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1175), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-approval", 2, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1013), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1015), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-deactivated", 16, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1971), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1972), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-reset-password-card-password-valid", 8, new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9618), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9619), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user-reset-password" },
                    { "user-reset-password-fail", 32, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(93), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(94), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 200, "user-reset-password" },
                    { "user-reset-password-security-question-valid", 8, new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9902), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9903), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user-reset-password" },
                    { "user-reset-password-set", 32, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(3), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(4), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 200, "user-reset-password" },
                    { "user-reset-password-start", 8, new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9401), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9402), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 100, "user-reset-password" },
                    { "user-start", 2, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(921), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(922), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 100, "user" },
                    { "user-suspended", 16, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1802), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1803), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("00fe1785-ff5e-4a22-a38d-d9f0d07a14e8"), new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9356), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9357), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("685a1a3c-fb7c-4219-a790-d103fc7925a9"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(885), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(886), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("6f054c39-7726-409d-a664-8e41ed90cd61"), new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9379), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("806405d1-d9dd-457e-b93e-0e1902fc0c27"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(867), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(868), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("a18fab15-9b0d-4155-a010-1e0aef402fd0"), false, 30, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(903), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(904), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" },
                    { new Guid("d16be049-684c-4ce6-bdba-836ffc37e6d0"), false, 30, new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9323), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9324), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" }
                });

            migrationBuilder.InsertData(
                table: "Transitions",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "FlowName", "FromStateName", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "ToStateName" },
                values: new object[,]
                {
                    { "user-activate-fd", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2777), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2778), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active" },
                    { "user-activate-fs", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2689), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2690), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active" },
                    { "user-deactive", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2607), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2608), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated" },
                    { "user-register", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2130), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-register", "user-start", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2131), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-approval" },
                    { "user-registration-aml-approve", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2330), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-registration-aml-approve", "user-aml-approval", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2331), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active" },
                    { "user-registration-aml-reject", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2428), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-registration-aml-reject", "user-aml-approval", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2429), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated" },
                    { "user-registration-approve", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2244), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-registration-approve", "user-approval", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2244), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-aml-approval" },
                    { "user-reset-password-set-password-acp", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(507), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(508), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-reset-password-set-password-asq", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(644), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(645), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-reset-password-validate-with-card", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(191), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(191), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-reset-password-validate-with-security-question", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(345), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(347), new Guid("00000000-0000-0000-0000-000000000000"), null, null },
                    { "user-suspend", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2511), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2511), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("000ba77c-aa71-4a48-95f1-238dbe59f396"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(76), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(77), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("04f74340-6265-4d90-b353-8e9a7de4fdb9"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2067), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2068), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("0579a33d-92ee-4c83-8141-414f2a498352"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2035), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2036), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("05aac5d4-415a-4f04-b0cd-0601d0cc9754"), new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9966), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9967), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("0bd07aff-2aaf-460c-87a8-6a6d161db7af"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(172), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(173), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("0cb11274-d168-4314-9dc0-454235447c9e"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(957), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(958), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("0f6f9711-dbe1-4f4c-8429-0be93c6b94d8"), new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9489), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("110b8466-c2cd-434c-aa79-7b69d70d501a"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(22), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(23), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("16e9d67d-d986-4744-b16d-9922bb106a19"), new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9585), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9586), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("1a09eedc-b642-4471-a5df-88da569ddbde"), new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9441), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9443), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("1dc841eb-0794-4309-9b23-000fe16b55fa"), new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9921), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9922), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("214fc4d0-91a0-45bc-8283-56d95b13c4d3"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(996), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(997), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("2427d3fe-a492-4495-ad60-72efb5fb7d30"), new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9884), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9885), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("2e26fe86-59d2-4e12-8403-cd1b909173d8"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2003), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2005), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("35d162d3-dea2-4ac5-b207-72a8e42e2fb7"), new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9986), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9987), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("3c731031-67ae-40bb-b33c-02ba2c494b4a"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1081), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Approval State", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1082), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-approval", null, null, null },
                    { new Guid("46b52731-fd0e-49ee-93bb-36620f3914ae"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(39), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(40), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("4d5bf8b5-0422-4c8c-987f-16486c2c7251"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1754), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1755), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("506593a6-20e8-4929-aa31-8169338f7301"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1206), new Guid("00000000-0000-0000-0000-000000000000"), null, "AML Onay Asamasi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1207), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-aml-approval", null, null, null },
                    { new Guid("53bb288c-48b1-414c-8263-0764fa54e855"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(153), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(154), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("5ffbd77f-3bb7-4a80-89da-6dc8d4d9c29f"), new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9719), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9720), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("6b97fbd0-d16d-44ee-b95f-af28a588ff04"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1868), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1869), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("6f52d5e0-cd7a-4318-bb2d-0750ca2ba08d"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1308), new Guid("00000000-0000-0000-0000-000000000000"), null, "AML approval description", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1311), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-aml-approval", null, null, null, null },
                    { new Guid("7b580d37-6924-4065-a689-65b9cd4f1d1b"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1691), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("7f5769d7-5202-46ce-9340-215a15a6ef08"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1145), new Guid("00000000-0000-0000-0000-000000000000"), null, "User approval description", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1146), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-approval", null, null, null, null },
                    { new Guid("80ccc328-4c9e-4a29-8c5e-6687077c85f5"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1721), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1722), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("85397304-aa22-49d2-a2ba-ed3445a3e7b3"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1237), new Guid("00000000-0000-0000-0000-000000000000"), null, "AML Approval State", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1239), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-aml-approval", null, null, null },
                    { new Guid("87400fa1-ea3a-48f1-9fce-ca13aa8bcbb2"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1905), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1906), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("90166396-62f6-489b-a8a3-0b06a529e674"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1651), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1652), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("997b3242-5dd5-4d2a-ba1e-6908786130d4"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1048), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Onay Asamasi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1049), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-approval", null, null, null },
                    { new Guid("9dc157b3-f847-43c6-8d50-ac1b29a441f9"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(979), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(979), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("a0a93794-80bd-432b-86c5-22f3bc3c0cb6"), new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9519), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9520), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("a25b452e-c226-40bf-b475-c32b5da7add9"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1939), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1940), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("a4f2ff9e-ac5a-446f-8e47-93bff915958b"), new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9687), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9688), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("b17f64bb-cf8e-4c7a-8ab7-b211ebaaa35c"), new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9945), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9946), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("b650c1f4-537e-46f7-b6e2-bbfe531d0ae8"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1276), new Guid("00000000-0000-0000-0000-000000000000"), null, "AML onay asama aciklamasi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1277), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-aml-approval", null, null, null, null },
                    { new Guid("bcb6c877-bc49-4a46-97b7-66be7d3738f0"), new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9653), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 420, DateTimeKind.Utc).AddTicks(9654), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("c28d7410-67d0-415e-a49d-c891fcd4fa6a"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(136), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(137), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("c4854552-c4e1-4eca-802a-767f8dd6bac7"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1837), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1838), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("c552d8c9-f173-43d5-848b-898d08580b37"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2101), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2102), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("c9d96967-bd1c-4084-a486-43cd8ffcd546"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1114), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici onay aciklamasi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(1115), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-approval", null, null, null, null },
                    { new Guid("cab59ecc-268f-4e0c-b1a3-5f5cae79c387"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(112), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(113), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("d0bf4edf-ea78-4384-9a38-b9181baecdb8"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(55), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(56), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("d66c232c-f8b5-41a2-8a31-ba7300d6d6a0"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(939), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("092a8f43-c685-440b-bc3f-8717f8fde019"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2674), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2675), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("10df2090-fbd5-4386-8930-e014c8bda1c6"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2855), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2856), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("1c669a8f-ce1b-4642-a00c-eaf14085b712"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(225), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(226), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("2f5866ee-bc72-4015-9d0b-96eae89af8b3"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2356), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici AML Onay", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2357), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-registration-aml-approve", null },
                    { new Guid("4a227c5e-d91f-4a55-b3ab-4653f3895b6f"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2395), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2396), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-registration-aml-approve", null, null },
                    { new Guid("4ba5f8a0-9ef8-4659-ba35-f5bdcd9d8ec7"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(628), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(629), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("4bf0a3cc-70a1-4341-86bf-506175ec3a65"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2820), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("503255be-ac37-4405-aede-babebe611d1a"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2723), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2723), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("53cf3550-bc51-421d-938f-669d77818e51"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2166), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Onayla", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2167), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("543e6ecd-a674-4dd7-9907-fdcabfb03c62"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2658), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2659), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("5c7fbca7-d963-463d-8d30-274adeb94906"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2625), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2626), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("608d0d53-e71b-45be-9fcc-875541fb4c20"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2461), new Guid("00000000-0000-0000-0000-000000000000"), null, "User AML Reject", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2462), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-registration-aml-reject", null },
                    { new Guid("64db0b5a-707f-44d4-bf16-b7af900eb3b3"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2590), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2591), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("6d8d7479-ca43-4277-92a3-7fb10ceeedad"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(717), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(718), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("6e7427b7-9062-45b8-8973-9d51ec03194f"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2706), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2707), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("7238c0e2-6726-43d2-8ae8-ce83c7de8720"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2188), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Registration Approve", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2188), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("73b75f5d-5315-449b-8fea-ce0836590c73"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2495), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2496), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-registration-aml-reject", null, null },
                    { new Guid("7e960887-6a94-4165-ae4b-2682fcee5bac"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(604), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(605), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("83b3281e-17c0-4df1-9fa6-7737ea78d1af"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2444), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici AML Ret", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2445), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-registration-aml-reject", null },
                    { new Guid("8ddcfd81-39f1-46fc-a9c3-3fa95722fb2d"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2551), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2552), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("94490c11-37a2-4e54-ad9f-6f237a0245be"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2209), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("9827dc50-d0f0-4a60-923f-febc2c0b39dc"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(476), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(477), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("9a9fd45d-dbf0-47ff-9d7b-ffcbcf2b658d"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2262), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2263), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-registration-approve", null },
                    { new Guid("a5023d8b-7c6c-4a54-8a2c-ea2bc4bd54a8"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(283), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(284), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("a7887d01-24cb-4bdc-9ba6-5600d694fde5"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2297), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2298), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-registration-approve", null, null },
                    { new Guid("aaae7d08-8a48-4638-988b-e1d133ca7b60"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2572), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2573), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("aaedb633-8a2c-4731-bd40-e5ccd2c94709"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2412), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2413), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-registration-aml-approve", null, null },
                    { new Guid("ab89412b-8f58-438f-912c-06b2b21ad692"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2375), new Guid("00000000-0000-0000-0000-000000000000"), null, "User AML Approve", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2375), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-registration-aml-approve", null },
                    { new Guid("af45525e-86ac-4f05-9abb-2a6abebf3484"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(249), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(250), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("af685c7b-c3c9-4c2c-907e-22c729654823"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2279), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-registration-approve", null },
                    { new Guid("b3e43655-211e-4517-8079-a4582690b222"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2743), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2744), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("b41502f0-fd69-4de7-806b-0f2629e00b61"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(411), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(413), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("b950a6d3-9f22-4df4-ba28-4900970a7fee"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2533), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2534), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("ba4796d9-bb37-40c4-bfa5-3098fba916ed"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(375), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(376), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("bee4471b-1979-44cd-ae7d-bb892f84c9c5"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2839), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("c076a138-6561-411b-8722-cbcb564e7627"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2802), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2802), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("c3691b77-79f9-4ddb-873c-f8eb0b85c963"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2761), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2761), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("c3c934f4-b6c5-400f-9627-a9cc8919fa07"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(682), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(683), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("cabce1bf-7be6-4fa8-a30f-ef60ebaf9bc5"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(571), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(572), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("d24c1464-ac2c-4406-b482-ea5c3dbf1d19"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(445), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(446), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("d5dc9356-e080-4535-825b-2b866d84704a"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(317), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(318), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("d952381e-e36c-43ea-8ad7-a0ce7f82dd28"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(701), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(702), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("e01980ce-22c4-4439-a371-e696a740c14d"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2641), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2642), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("e659ecd9-7ff4-4332-9b60-8f0f1e944cdb"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2228), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2229), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("f7a2c7be-2c7c-48f0-adc5-095778ab5c7b"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(662), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(663), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("f7fe0c72-2bae-4069-98ce-3e46bdf64a29"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2314), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2314), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-registration-approve", null, null },
                    { new Guid("fc6515ac-140e-411a-aa56-71ab936eb905"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2478), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(2478), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-registration-aml-reject", null, null },
                    { new Guid("fff25d9a-8c85-44a4-899a-99a7efe1d859"), new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(539), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 3, 10, 6, 56, 21, 421, DateTimeKind.Utc).AddTicks(540), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null }
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
                name: "ZeebeMessage");
        }
    }
}
