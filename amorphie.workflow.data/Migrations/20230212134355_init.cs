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
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Tags", "ZeebeFlowName" },
                values: new object[,]
                {
                    { "retail-loan", new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8250), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8250), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "retail", "loan" }, null },
                    { "user-lifecyle", new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8510), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8510), new Guid("00000000-0000-0000-0000-000000000000"), null, new[] { "idm", "user" }, null }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Name", "BaseStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Type", "WorkflowName" },
                values: new object[,]
                {
                    { "retail-loan-finish", 2, new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8450), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8450), new Guid("00000000-0000-0000-0000-000000000000"), null, 200, "retail-loan" },
                    { "retail-loan-start", 2, new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8380), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8380), new Guid("00000000-0000-0000-0000-000000000000"), null, 100, "retail-loan" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "WorkflowName_Title", "WorkflowName_Transition" },
                values: new object[,]
                {
                    { new Guid("0aaab74e-ed62-407b-bfb5-17d5dd133b60"), new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8540), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8540), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-lifecyle", null },
                    { new Guid("34490288-4d0e-42f2-bfd9-0e8c06038158"), new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Retail Loan Process", "en-EN", new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "retail-loan", null },
                    { new Guid("d08f0ddc-1e7e-403a-9aa9-95bbd575a561"), new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8360), new Guid("00000000-0000-0000-0000-000000000000"), null, "Bireysel Kredi Sureci", "tr-TR", new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8360), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "retail-loan", null },
                    { new Guid("f1fd0afa-b3ec-47bf-825b-22e1dbb106b9"), new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8520), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-lifecyle", null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntity",
                columns: new[] { "Id", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsExclusive", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[] { new Guid("7a8bcec7-8474-4c64-87d3-962b44423f58"), 30, new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8550), new Guid("00000000-0000-0000-0000-000000000000"), null, false, true, new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8550), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-lifecyle" });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "WorkflowName_Title", "WorkflowName_Transition" },
                values: new object[,]
                {
                    { new Guid("46fa303d-1e0f-4c4c-91d2-08b17e816157"), new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8440), new Guid("00000000-0000-0000-0000-000000000000"), null, "Retail Loan Start State", "en-EN", new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8440), new Guid("00000000-0000-0000-0000-000000000000"), null, "retail-loan-start", null, null, null },
                    { new Guid("4aa21cb1-be6b-4ae5-a349-66c664ee6e20"), new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Retail loan finis state", "en-EN", new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8500), new Guid("00000000-0000-0000-0000-000000000000"), null, "retail-loan-finish", null, null, null },
                    { new Guid("532d3364-68ad-463c-9021-bd6bc840a5dc"), new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8460), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis bitis asamasi", "tr-TR", new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8460), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "retail-loan-finish", null, null },
                    { new Guid("7f564577-ff09-4de3-b7c5-ddb2b599605b"), new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8430), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kredi sureci akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8430), new Guid("00000000-0000-0000-0000-000000000000"), null, "retail-loan-start", null, null, null },
                    { new Guid("aa0c8a66-d7ed-453f-a5ba-d06742791244"), new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8490), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kredi sureci akis bitis asamasi", "tr-TR", new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8490), new Guid("00000000-0000-0000-0000-000000000000"), null, "retail-loan-finish", null, null, null },
                    { new Guid("c99d71d4-5d3d-4ec1-a538-9130e5ad5f3b"), new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8470), new Guid("00000000-0000-0000-0000-000000000000"), null, "Finish state", "en-EN", new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8480), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "retail-loan-finish", null, null },
                    { new Guid("dc0566fa-edc7-4309-8e30-bc8e8a37ce2a"), new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "retail-loan-start", null, null },
                    { new Guid("e3b8f29d-c9d3-4400-87e2-3abe6e87d5eb"), new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8400), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 12, 13, 43, 55, 454, DateTimeKind.Utc).AddTicks(8400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "retail-loan-start", null, null }
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
                name: "WorkflowEntity");

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
