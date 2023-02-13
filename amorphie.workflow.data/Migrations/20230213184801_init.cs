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

            migrationBuilder.InsertData(
                table: "Workflows",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Tags", "ZeebeFlowName" },
                values: new object[] { "user", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2260), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2260), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user" }, null });

            migrationBuilder.InsertData(
                table: "ZeebeFlow",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Gateway", "IsAtomic", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Process", "Tags" },
                values: new object[] { "zb-user-reset-password", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1650), new Guid("00000000-0000-0000-0000-000000000000"), null, "https://127.0.0.1", false, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1650), new Guid("00000000-0000-0000-0000-000000000000"), null, "<bpmn:process></bpmn:process>", new[] { "idm", "user", "security" } });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Name", "BaseStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "OnEntryFlowName", "OnExitFlowName", "Type", "WorkflowName" },
                values: new object[,]
                {
                    { "user-active", 4, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2360), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2360), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-deactivated", 16, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2480), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2480), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" },
                    { "user-start", 2, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2300), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 100, "user" },
                    { "user-suspended", 16, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2420), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2420), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("695de59d-d183-46d0-a824-b30abe8c1dbc"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2270), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2270), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("d17a35a5-e23a-43f0-b6de-c0a9e3793e17"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2280), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsExclusive", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[] { new Guid("1a160535-ce58-4ac1-988e-73511f09e245"), 30, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2300), new Guid("00000000-0000-0000-0000-000000000000"), null, false, true, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2300), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" });

            migrationBuilder.InsertData(
                table: "Workflows",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Tags", "ZeebeFlowName" },
                values: new object[] { "user-reset-password", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1680), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1680), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user", "security" }, "zb-user-reset-password" });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Name", "BaseStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "OnEntryFlowName", "OnExitFlowName", "Type", "WorkflowName" },
                values: new object[,]
                {
                    { "user-reset-password-card-password-valid", 8, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1840), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 0, "user-reset-password" },
                    { "user-reset-password-fail", 32, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1960), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1960), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 200, "user-reset-password" },
                    { "user-reset-password-set", 32, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1900), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 200, "user-reset-password" },
                    { "user-reset-password-start", 8, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1780), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1780), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, 100, "user-reset-password" }
                });

            migrationBuilder.InsertData(
                table: "Transition",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "FlowName", "FromStateName", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "ToStateName", "Type" },
                values: new object[,]
                {
                    { "user-activate-fd", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2770), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", 900 },
                    { "user-activate-fs", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2710), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2710), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", 900 },
                    { "user-deactive", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2650), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2650), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", 900 },
                    { "user-register", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2540), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2540), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", 900 },
                    { "user-suspend", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2600), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2600), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", 900 }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("0da1fc3f-bbaa-47b6-bffc-bbd9dcb1fd2a"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2500), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("162ba801-e192-4faf-ae97-23598a8903bd"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2520), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("22fdc12a-2838-4f62-89c2-4df77fa3af58"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2490), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("2ae72609-328d-4087-92e6-6666ce5197eb"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("3afa9961-9011-4823-a092-9a5c03ec521f"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2400), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2400), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("4db32033-0aee-4beb-9ca9-04469704586f"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2530), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2530), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("576c0c76-4b87-450f-9d22-eab07e997b8b"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2390), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2390), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("59a6f461-6548-48d9-955e-0946555befe8"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2470), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2470), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("70814442-1925-4b5a-a1e5-9fdf01b3f43a"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("77d2a23a-7381-4963-8dfb-a7d64615b77d"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2410), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("856b55d1-89d0-4b81-85b3-e0cf0c681c5c"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2350), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2350), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("a83fc4ba-f4a6-4b42-accf-f830ef25e310"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2440), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("ac9e7033-fecc-4a65-b3ff-0815c6a870ed"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1760), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("bb2a0da4-5e8b-4a6d-bb3d-0eeef199f41e"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1770), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("c9cbac1a-2621-4a49-a9e6-95a6865c54da"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2460), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2460), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("d57b32fc-4fc6-440c-a63a-2efcf352c4c9"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2340), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2340), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("e917889a-7c52-43d9-b3a6-5c00a47c3244"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2430), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("f3925e7e-4835-459d-9295-18cb12157083"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsExclusive", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[] { new Guid("b103900a-a1fe-41ec-a6c4-445e985b2e48"), 30, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1740), new Guid("00000000-0000-0000-0000-000000000000"), null, false, false, new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1740), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" });

            migrationBuilder.InsertData(
                table: "Transition",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "FlowName", "FromStateName", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "ToStateName", "Type" },
                values: new object[,]
                {
                    { "user-reset-password-set-password-acp", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2140), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2140), new Guid("00000000-0000-0000-0000-000000000000"), null, null, 900 },
                    { "user-reset-password-set-password-asq", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, 900 },
                    { "user-reset-password-validate-with-card", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, 900 },
                    { "user-reset-password-validate-with-security-question", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2080), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2080), new Guid("00000000-0000-0000-0000-000000000000"), null, null, 900 }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("1709c411-54a1-4d3c-bae9-7473f1b84b7a"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2700), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2700), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("18cb717d-9bfa-4961-beaa-67499ef175d9"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2640), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2640), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("21d8603e-3af1-44e2-af2d-527d34e20289"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1830), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1830), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("2ab6c07b-c756-4ae6-b46d-22cabae9f407"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1870), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("315783cd-c7e9-488e-bbfa-f4f36e514baf"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1990), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("35a75390-7d5c-42be-b5f7-c57151dd0474"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2660), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2660), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("4532f381-fd72-40cb-bd47-898af64d33a0"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2820), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("49305e14-64f7-4018-8545-fcf98fdb3c63"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1810), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("609b0395-12c6-4d85-a733-74d2f2cce340"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("659027f0-402b-420d-8e2c-d7aeaec782b9"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2780), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2780), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("6ee2152b-7a91-4574-a948-a56a07d39f99"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1960), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1960), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("7495e9ca-ccd8-4364-9a27-7833d97404d8"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1890), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1890), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("75b5b11d-30b7-4b4e-a5af-fc759375693c"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2580), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2580), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("75ee3f5c-efb6-4149-a244-5c1eb63f0a5d"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2550), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("77c87786-2223-42db-9318-23b64bd6bdf5"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1940), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1940), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("7b51ac14-57ff-4b99-a7b6-fd3d7d1ef41a"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2690), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("7e6d3d0f-1362-4c84-84fa-8e51752a0cae"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2590), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2590), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("7ec0cd53-8ae1-471e-aa5a-218ee52dda33"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1880), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1880), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("88897543-fb42-4d8c-a02a-e4b03281dbd9"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2000), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2000), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("8f91be70-b5a7-4b68-a562-555955d62e39"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2760), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("96c1c3a2-437b-4eb3-8332-7f1d577b056d"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2010), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2010), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("9711d142-06eb-47c0-a59c-ee5e50ad8b95"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("a2a2354a-35e9-4aa7-ba6e-98602c2ba1d3"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("a36dee80-1788-4ed6-b9d1-9e3b2adfebde"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("b0e357cb-4ef9-41b8-92b0-f7157e7465fe"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1930), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("b7ce9c57-30e6-4c1a-a58a-8902ce4b3031"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1920), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("b8d1fcad-1eb0-4bb9-9747-dae13d574672"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("bcb153ad-e133-4987-83fe-8db4f8fe443f"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2810), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("cf7de6c8-d17e-4b74-af31-c26daafbc4a0"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1820), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1820), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("d1c95fbb-bda5-4971-b242-2b8a6dc619b3"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("d46ae050-e720-42d4-a05c-662439188a6d"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("d4e3c218-fbfe-4c2d-872d-fd856ab90db7"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1980), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(1980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("e2c9a7da-2893-4726-8167-c46432401c45"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2630), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("e35a4052-ca8f-4e7d-9152-bd688d3b89ac"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2750), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2750), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("ecf288fc-6b5f-41cd-8545-7b75712ec773"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2620), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("efdff4c8-6625-4f26-971a-59c599f35f28"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2720), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2720), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("23a07669-c3da-4825-b22a-2c633762e50f"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2070), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2070), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("2694c4bd-f504-4a66-9aa1-ef820888582d"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2090), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2090), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("6c133f57-6beb-4e5b-a2a8-c75497f551b1"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2170), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2170), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("88059960-c50f-4d8a-8d15-e53f1c65850e"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2230), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("9257e25b-e22a-4410-9a2b-1fea3d89b96f"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2210), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("9cecaee4-54df-483e-88a7-f63f59981a4c"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2030), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2030), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("ae78096f-1b3f-4c70-a0b2-7dc8d29b41fd"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2150), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("af0e1b3f-a4db-4bf9-a2b3-c43388e0c6e6"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2120), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2120), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("b02483ef-128f-40c7-af37-58d841ed604a"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2100), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("b596894c-f44a-48db-bd24-fd3085707668"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2050), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2050), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("b77d5f4e-25af-45c2-a26b-87f46f35b566"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2190), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2190), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("e1d5cf30-f129-4022-a6ee-d9e87b771fd0"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2130), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2130), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("e35710c8-0174-465e-9db1-3a35452210df"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2220), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2220), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("e67df58d-34b6-475d-8cfa-f64082abedbd"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2250), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2250), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("e705f3af-ad27-424b-88bf-e64d654cfbfb"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2060), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2060), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("f440ce98-9d4e-4950-ba27-df5e859a47b5"), new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2160), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 13, 18, 48, 1, 382, DateTimeKind.Utc).AddTicks(2160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null }
                });

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
                name: "Translation");

            migrationBuilder.DropTable(
                name: "WorkflowEntities");

            migrationBuilder.DropTable(
                name: "Transition");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Workflows");

            migrationBuilder.DropTable(
                name: "ZeebeFlow");
        }
    }
}
