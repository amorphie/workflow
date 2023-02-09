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
                table: "Workflows",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Gateway", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Process", "ProcessName", "Tags", "Type" },
                values: new object[,]
                {
                    { "retail-loan", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9440), new Guid("00000000-0000-0000-0000-000000000000"), null, "http://localhost:26500", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9450), new Guid("00000000-0000-0000-0000-000000000000"), null, "<bpmn:definitions>...</bpmn:definitions>", "retail-loan-workflow", new[] { "retail", "loan" }, 200 },
                    { "user-lifecyle", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new[] { "idm", "user" }, 100 }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Name", "BaseStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Type", "WorkflowName" },
                values: new object[,]
                {
                    { "retail-loan-finish", 0, new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9670), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9670), new Guid("00000000-0000-0000-0000-000000000000"), null, 200, "retail-loan" },
                    { "retail-loan-start", 0, new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9580), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9580), new Guid("00000000-0000-0000-0000-000000000000"), null, 100, "retail-loan" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "WorkflowName_Title", "WorkflowName_Transition" },
                values: new object[,]
                {
                    { new Guid("2a8214b5-59fa-40f6-8aad-2ec86bf76e6c"), new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Retail Loan Process", "en-EN", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9570), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "retail-loan", null },
                    { new Guid("6885a406-084e-4347-b963-495dad5625b1"), new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9750), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9750), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-lifecyle", null },
                    { new Guid("7d69eac6-6ec6-4d1a-b93f-bd2bd0b0e2ee"), new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9760), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-lifecyle", null },
                    { new Guid("887f29c3-6bf7-43bd-9bd5-5f2ec99c32e7"), new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Bireysel Kredi Sureci", "tr-TR", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "retail-loan", null },
                    { new Guid("03361d4a-5f3b-4381-a498-45e027c6fef2"), new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9710), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kredi sureci akis bitis asamasi", "tr-TR", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9710), new Guid("00000000-0000-0000-0000-000000000000"), null, "retail-loan-finish", null, null, null },
                    { new Guid("1d887c71-134b-4560-9eab-cd51b687dc02"), new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9620), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "retail-loan-start", null, null },
                    { new Guid("367941d5-0526-4979-95ab-b02b5899af25"), new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9660), new Guid("00000000-0000-0000-0000-000000000000"), null, "Retail Loan Start State", "en-EN", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9660), new Guid("00000000-0000-0000-0000-000000000000"), null, "retail-loan-start", null, null, null },
                    { new Guid("4eaafdef-f2fe-4234-b369-1b8c2d208233"), new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9650), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kredi sureci akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9650), new Guid("00000000-0000-0000-0000-000000000000"), null, "retail-loan-start", null, null, null },
                    { new Guid("70c103ae-571d-43a7-97de-553d85f14dcd"), new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis bitis asamasi", "tr-TR", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "retail-loan-finish", null, null },
                    { new Guid("c160d062-0352-409f-9e16-fca1e48724e4"), new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9720), new Guid("00000000-0000-0000-0000-000000000000"), null, "Retail loan finis state", "en-EN", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9720), new Guid("00000000-0000-0000-0000-000000000000"), null, "retail-loan-finish", null, null, null },
                    { new Guid("c7f1f24e-8269-411d-a739-3080e87d3873"), new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9700), new Guid("00000000-0000-0000-0000-000000000000"), null, "Finish state", "en-EN", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9700), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "retail-loan-finish", null, null },
                    { new Guid("e1e99dff-02ac-4294-8b7c-28c264857998"), new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9630), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 9, 13, 5, 56, 761, DateTimeKind.Utc).AddTicks(9630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "retail-loan-start", null, null }
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
