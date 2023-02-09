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
                name: "Workflows",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Tags = table.Column<string[]>(type: "text[]", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ProcessName = table.Column<string>(type: "text", nullable: true),
                    Process = table.Column<string>(type: "text", nullable: true),
                    Gateway = table.Column<string>(type: "text", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    WorkflowName = table.Column<string>(type: "text", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "WorkflowEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkflowName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsExclusive = table.Column<bool>(type: "boolean", nullable: false),
                    IsStateManager = table.Column<bool>(type: "boolean", nullable: false),
                    AvailableInStatus = table.Column<int[]>(type: "integer[]", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowEntity_Workflows_WorkflowName",
                        column: x => x.WorkflowName,
                        principalTable: "Workflows",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Transition",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    FromStateName = table.Column<string>(type: "text", nullable: true),
                    ToStateName = table.Column<string>(type: "text", nullable: true),
                    Form = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Process = table.Column<string>(type: "text", nullable: true),
                    Gateway = table.Column<string>(type: "text", nullable: true),
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
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Transition_State_ToStateName",
                        column: x => x.ToStateName,
                        principalTable: "State",
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
                    WorkflowNameTitle = table.Column<string>(name: "WorkflowName_Title", type: "text", nullable: true),
                    WorkflowNameTransition = table.Column<string>(name: "WorkflowName_Transition", type: "text", nullable: true),
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
                        name: "FK_Translation_Transition_WorkflowName_Transition",
                        column: x => x.WorkflowNameTransition,
                        principalTable: "Transition",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Translation_Workflows_WorkflowName_Title",
                        column: x => x.WorkflowNameTitle,
                        principalTable: "Workflows",
                        principalColumn: "Name");
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "WorkflowName_Title", "WorkflowName_Transition" },
                values: new object[,]
                {
                    { new Guid("14d5dcc9-4e45-48dc-b131-69b0875f6370"), new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Bireysel Kredi Sureci", "tr-TR", new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4390), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("7cf9bc13-d33e-4d86-a164-cf6f79dac7f5"), new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4440), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("9aa6ae1a-487f-4a82-82bd-7ccf3bf2fed8"), new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4400), new Guid("00000000-0000-0000-0000-000000000000"), null, "Retail Loan Process", "en-EN", new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("e6c8ef3c-cca8-4f08-9ed1-8dbca0b32d46"), new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4430), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Workflows",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Gateway", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Process", "ProcessName", "Tags", "Type" },
                values: new object[,]
                {
                    { "retail-loan", new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4310), new Guid("00000000-0000-0000-0000-000000000000"), null, "http://localhost:26500", new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4310), new Guid("00000000-0000-0000-0000-000000000000"), null, "<bpmn:definitions>...</bpmn:definitions>", "retail-loan-workflow", new[] { "retail", "loan" }, 200 },
                    { "user-lifecyle", new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new[] { "idm", "user" }, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_State_WorkflowName",
                table: "State",
                column: "WorkflowName");

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
                name: "IX_Translation_WorkflowName_Title",
                table: "Translation",
                column: "WorkflowName_Title");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_WorkflowName_Transition",
                table: "Translation",
                column: "WorkflowName_Transition");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowEntity_WorkflowName",
                table: "WorkflowEntity",
                column: "WorkflowName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropTable(
                name: "WorkflowEntity");

            migrationBuilder.DropTable(
                name: "Transition");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Workflows");
        }
    }
}
