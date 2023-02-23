using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instances_ZeebeFlow_ZeebeFlowName",
                table: "Instances");

            migrationBuilder.DropForeignKey(
                name: "FK_State_ZeebeFlow_OnEntryFlowName",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_State_ZeebeFlow_OnExitFlowName",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_ZeebeFlow_FlowName",
                table: "Transitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Workflows_ZeebeFlow_ZeebeFlowName",
                table: "Workflows");

            migrationBuilder.DropTable(
                name: "ZeebeFlow");

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("00519d6c-669a-4f57-ac3d-12a16c457cc0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("059ad202-72c8-430a-8bb6-f011c79fdfa7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("095c3e75-0bfa-4875-967d-238a761edf42"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0b4aa3eb-03bd-4996-8703-66c9dfaba38d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0e00999e-553c-433c-94a5-64ce4ffefbe4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0f296b0d-951e-4293-bef9-3bdb66bb6c4c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1339ec0a-9601-48ba-a75a-f668e4d864da"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("166dc3cd-81e5-406e-8a52-53948eca4243"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1fe92b30-e9f4-4d99-b663-2af12879c7d5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2852c25d-26dc-4a07-9305-47a111996906"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2b801884-d55a-4883-a2a6-9f75e7505e0f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2e75bc69-97e7-490c-b45d-10bbd3e51aa4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("30814db7-e7ee-4ab0-be17-e076069408d1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3616dd59-afa8-4d2f-8742-f4ee299fb443"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("39aae081-7393-4883-bd33-c492afffd8d7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3a485863-1308-4158-9bd0-ff64411cb4bd"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3cdaff96-4dc0-4cba-b467-5b4a6198b465"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3cf43f10-7590-49a9-8b83-b6120cbfc3a9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("423c8a69-f182-4632-b112-6922dfe1931b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("435677b7-b55c-47d5-8fc4-cc7d0c5b4552"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("458ba6aa-82cd-4d77-bf5a-bef06c11a272"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("48658728-8645-4551-a2c5-4eaf97400cab"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4a727164-76fd-4850-93ae-0d5b0b1a97b3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4d98dd25-3abd-4470-8aad-3445f4fb512c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("506f90e5-b645-42fe-be2f-3942c23a759a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("50f9f332-90f9-4618-b249-7164317e36ad"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("532371ff-0ce1-4d39-9001-62d296a0a708"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("60482695-6998-4f51-927a-af1c1da0d75e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("60b36021-8611-44e9-8c83-72bbc28974a0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("63379467-598e-4696-833d-8dcdd9b852b3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("67d49121-afb1-424b-b0aa-68da1a8ce7b8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6e48cd17-f7e2-4756-b259-dee1c278aa22"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6fd0fe76-d23c-43f8-8645-17b1427a55a3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("75654029-a98d-4893-8297-ffb9ae90a523"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("76788759-7e3c-4a84-940c-2ccbfa6a96b9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7bc75bfe-14f4-4059-9b30-e3adcf7e4c5a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("81b1688d-32e5-40a6-b37a-0cceb12d2bc8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("871dec99-41a7-480d-a93b-3b9eb37f2d13"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8782e522-a68d-4fe0-a401-cd1461af2693"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8ecc7616-ab8f-4db1-96e6-9de5b683783b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8fdae5e9-8fe1-479c-b2a0-2bf1e5c31f2d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("90425b52-6c4f-4a91-b399-60f48f26f7cf"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("98371222-3d2d-4a6d-8218-5a8398375d07"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9939efcc-aa26-4a62-a499-04a1834c41df"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9b21cce0-a6c4-464c-963e-76247135f7f6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9e5d20c4-587e-4c4a-93c6-ef7391bb7d5a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a063ccf8-06ad-4993-bec8-358e0007706d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a2057a45-ad00-4c13-9bda-77fd8eea643f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a62db010-52e2-4670-bbd8-51118759ba95"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a6ccd65c-9040-461a-8895-bcc4e347a0bd"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a8be37c3-b344-429d-a787-1b3535c360c5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ab64a6c1-ce5d-40c2-aa69-f96f73e33f4a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ac7da1a7-392c-495f-8418-d0391db37b33"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("af3a3b8b-f196-4b57-9e24-2aafb249691d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b33232c3-b771-454c-acea-346505afc0d0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b78054d6-fe79-42b5-8dc7-078452d5019a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bd3eb55c-2ee0-41a4-abb6-4c5d4c23faea"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c03cfd86-6a04-434a-8382-9594216f7fa9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c40146d3-165e-4315-82e7-c62043425bd9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c8c417eb-bbac-4e01-91d4-e0ec68085fda"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ca67a8fe-0bcc-4f0f-8194-dfbd2477f898"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cf571b01-82b1-477c-b931-c8bad020c549"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d9be15c1-66e9-4be7-81a6-8f33af12252e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("dfc63721-c6a0-43f1-9a0f-488cb74b9413"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e0ecab62-b002-4f28-837c-6d67a7583e79"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e4301494-7fb6-4057-bc24-e7499585567c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e8d5717b-5ec4-422b-bad8-c9e5eb086468"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ea11c734-3380-443b-9d15-34e9cc9e90dc"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ef15dfc2-558e-456b-80c5-cf136694c00f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f1174b21-3410-4ed3-a7b1-4b0338323985"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f289dcf7-4228-4356-9c6d-ae7c83f1eb05"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f3bc4fd4-baf5-4cc1-ae9e-6255a119ae65"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f53b9310-e916-400d-8e31-89c0d00f6ec4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f616ea50-4986-4a51-a9fa-e64d3128a666"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f89618a3-1fc0-4a1f-bef3-26fc2e67f8f4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fd584825-16ce-4c94-8cd5-0ec2b18cbd18"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("04fd105f-91cc-49f9-8f25-63f6aaa232ae"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("21ebdc97-cce6-4bb9-b6ef-77fb6d772b87"));

            migrationBuilder.DropColumn(
                name: "FlowMessage",
                table: "Transitions");

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

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-active",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1590), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1590) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-deactivated",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1710), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1710) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-card-password-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1010), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-fail",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1180), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-security-question-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1070), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-set",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1120), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(940), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1530), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1530) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-suspended",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1650), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1650) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fd",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2000), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2000) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fs",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1940), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1940) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-deactive",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1890), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1890) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1770), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1770) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-acp",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1360), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-asq",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1420), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-card",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1240), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-security-question",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1300), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-suspend",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1830), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1830) });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("030ab5b0-00c2-4c33-94ea-1615a799f359"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1730), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("044196a8-c4df-423f-b423-f1088dab16e7"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1700), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1700), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("0c12ed51-3521-4130-9318-7f90577f2d57"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1000), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1000), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("0f643991-ab24-4dac-a3b4-0b11df3dff59"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1020), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("11bda497-46a9-4bb7-8646-f41a91b0cde6"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1470), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1470), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("13f7364a-3b40-4a6e-9ff6-ed197da3737e"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("16ebb9f0-f0df-4436-82e1-ff972849f236"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("1b180cbf-ab15-4868-a24f-1a093f99948a"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1660), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("1dd26906-dbc4-44be-9e27-bbabb4d48153"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(980), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(980), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("1f34f14c-59f9-42a1-bb1e-4aa635622972"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1410), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("2d668a23-a546-4177-a1cd-2a37bf8b8ade"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1770), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1770), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("31d91938-a64e-44ca-a490-c52211042f3f"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1870), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("321c7cc1-ceda-4248-b199-07fa79c22250"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1160), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1160), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("37a19aa9-4e75-45ea-92ef-2531e95ae444"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1840), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("38c3485e-1855-44a5-aab1-ac413c6b1980"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("3d64994d-e015-43d3-983c-aebab7823b6f"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("3f7d5686-8bbc-4780-83c3-8af53e028197"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2010), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2010), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("413e6dc6-125e-4f28-820e-66f7b3c507e8"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1690), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("452edc7e-c0ef-4a60-a0fa-b20218afa299"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("45389f87-3c76-4c5b-8e99-91c636d382da"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("4571aeb2-d733-4385-88af-03a6de9e87eb"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(930), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("45bd69ff-50c5-4fc1-a6af-a9600fe5cc84"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1140), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1140), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("4b1e3ddd-fdea-449a-99fc-88f8c5a78b0b"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1820), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("546c9a2e-b899-4aae-8284-b540a7a3f97f"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1100), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1100), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("59d37f10-774e-4c82-a378-9d5fda0eb109"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1050), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("5e05a0a5-f86e-4b86-83c3-cb1cf1f481f4"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1270), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1270), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("5fc213a7-d20a-4d28-9567-c4d08f7fe9d5"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1750), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1750), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("620e34a6-1c11-4f64-86c2-27e9dbec9a28"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1640), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1640), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("63e57ae2-b408-4927-bd84-8b007fbd94bc"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1440), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("79bc4ec7-3420-4df3-8ec3-9bf9547aa4fa"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(910), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(910), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("7ccd63cb-f410-4107-aa36-39418df86c93"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("7eba0bc5-d5f7-4406-9daf-a0d6cccf3c72"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2050), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2050), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("7f9c883d-272f-426c-9f5b-e2913c97bb75"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1090), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1090), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("80c97c5a-8ab1-4ef6-aafd-6dd08214bae0"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2040), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2040), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("861daa17-e172-418b-9273-b36ffa11ef30"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("86a68656-5576-42ed-809c-e2b767b8f406"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1210), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("895e2a1c-4f11-4a9a-bf08-b8830fcca7b9"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1030), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1030), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("8b55fd2e-153f-420c-a4b1-4c2f760aa325"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1340), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("8d0c2bfd-6f87-4035-8ede-a6b65204c262"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1060), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1060), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("8e1fde08-4aab-41fe-830f-80c7da0d463a"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1940), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("8e923d25-decf-4f87-ba62-3d927e51581c"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1080), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1080), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("8f47e51e-93ab-4251-959c-067c885c385f"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1500), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("8fa462a1-157a-4e44-a0c4-6c0eb6ac0060"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1550), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("937a0413-65a1-4d73-827b-70fa6d592136"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1240), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1240), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("95b4b500-3763-48cd-9f6c-276b165df94a"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1570), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("a20a2d65-5057-4ffc-9329-4100cdb99363"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1300), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("a2803055-e820-4161-b3cb-7817120966a9"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("a465c1ee-1723-4b55-b511-f3f4864f41e1"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("a4a52522-4381-4c0c-9512-3275a9844558"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1800), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("a8584983-cdf5-4bef-9d62-23a526fbab81"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("a95bf894-cb1f-4d63-84ad-12b47caccb5b"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1630), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1630), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("ac7e2ee3-4022-442d-834d-9e1df5cf54e2"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1180), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1180), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("bafcaae3-d4c5-4365-8ecb-c4f4ea5d16b0"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("bed5f8d6-cab5-41a8-8925-34b655bd8654"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1260), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("c5afdcb7-aaf4-492c-b5a8-e3debb7579ca"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1980), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("c996c77b-1ab4-4b78-a383-05e3e3b9d579"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1510), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1510), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("cac7914a-8a8b-464f-8e3d-e516aa8abc9d"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1450), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("d0a97b07-597e-4951-abba-225ae4454fbe"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1810), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("d20c3e62-f042-42e1-863d-959b866a1f8e"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1150), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("d3f2cdf9-454f-44e9-af17-3bfccd405b1d"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2030), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2030), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("d853a12f-3da1-4258-aec9-3494cc98b073"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1990), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("d96efb42-d182-4adc-9881-b09c8eca5dc6"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1120), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("d9ca7867-b5b4-45ad-86a1-89a516ad9d2d"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1430), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("dcd0e525-83d4-465c-966c-7e23bd380d6b"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1400), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("df7ca9cf-5c02-489b-8816-e007df70ce56"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1880), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("e3aeb86b-a1b8-4b09-9e9c-84b368aaa8da"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1910), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1910), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("e6d1b862-f489-498f-b437-f822a9b61ff1"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("ea1101e5-e1e5-4ee7-aa5c-65492a7849ef"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("ecdbbb74-a5a3-4362-9d2d-18440e3c5e16"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1280), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("efba5089-9018-4530-afc2-da42082cd67a"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("f37eceb8-2bcc-471e-b522-af9ffd1d0921"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1350), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("f3a4d6ac-1308-4683-a68e-c506409b27e5"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1230), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1230), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("f78538ca-4017-4359-85fc-15b6926768ee"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(960), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(960), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("f7fa1a92-36d3-4ddf-bcd3-dcc571ce48b1"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1920), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("fa687165-4d51-4df9-9c3c-f8eada69ec15"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1620), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("fc7881d2-d9cc-4891-8ce8-e9cebbda8c32"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1580), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1580), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("790cdc22-774d-47e6-98c5-ab016b2a5ac2"), false, 30, new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(900), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(900), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" },
                    { new Guid("e5225a8d-0440-4233-a00d-23f80825308e"), false, 30, new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1530), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1530), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1490), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1490) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(830), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(830) });

            migrationBuilder.InsertData(
                table: "ZeebeMessage",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Gateway", "Message", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Process", "Tags" },
                values: new object[] { "user-register", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1480), new Guid("00000000-0000-0000-0000-000000000000"), null, "zeebe-local", "simple-flow-starter", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1480), new Guid("00000000-0000-0000-0000-000000000000"), null, "Process_Simple", new[] { "idm", "user" } });

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_ZeebeMessage_ZeebeFlowName",
                table: "Instances",
                column: "ZeebeFlowName",
                principalTable: "ZeebeMessage",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_State_ZeebeMessage_OnEntryFlowName",
                table: "State",
                column: "OnEntryFlowName",
                principalTable: "ZeebeMessage",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_State_ZeebeMessage_OnExitFlowName",
                table: "State",
                column: "OnExitFlowName",
                principalTable: "ZeebeMessage",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Transitions_ZeebeMessage_FlowName",
                table: "Transitions",
                column: "FlowName",
                principalTable: "ZeebeMessage",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Workflows_ZeebeMessage_ZeebeFlowName",
                table: "Workflows",
                column: "ZeebeFlowName",
                principalTable: "ZeebeMessage",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instances_ZeebeMessage_ZeebeFlowName",
                table: "Instances");

            migrationBuilder.DropForeignKey(
                name: "FK_State_ZeebeMessage_OnEntryFlowName",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_State_ZeebeMessage_OnExitFlowName",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_ZeebeMessage_FlowName",
                table: "Transitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Workflows_ZeebeMessage_ZeebeFlowName",
                table: "Workflows");

            migrationBuilder.DropTable(
                name: "ZeebeMessage");

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("030ab5b0-00c2-4c33-94ea-1615a799f359"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("044196a8-c4df-423f-b423-f1088dab16e7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0c12ed51-3521-4130-9318-7f90577f2d57"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0f643991-ab24-4dac-a3b4-0b11df3dff59"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("11bda497-46a9-4bb7-8646-f41a91b0cde6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("13f7364a-3b40-4a6e-9ff6-ed197da3737e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("16ebb9f0-f0df-4436-82e1-ff972849f236"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1b180cbf-ab15-4868-a24f-1a093f99948a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1dd26906-dbc4-44be-9e27-bbabb4d48153"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1f34f14c-59f9-42a1-bb1e-4aa635622972"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2d668a23-a546-4177-a1cd-2a37bf8b8ade"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("31d91938-a64e-44ca-a490-c52211042f3f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("321c7cc1-ceda-4248-b199-07fa79c22250"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("37a19aa9-4e75-45ea-92ef-2531e95ae444"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("38c3485e-1855-44a5-aab1-ac413c6b1980"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3d64994d-e015-43d3-983c-aebab7823b6f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3f7d5686-8bbc-4780-83c3-8af53e028197"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("413e6dc6-125e-4f28-820e-66f7b3c507e8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("452edc7e-c0ef-4a60-a0fa-b20218afa299"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("45389f87-3c76-4c5b-8e99-91c636d382da"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4571aeb2-d733-4385-88af-03a6de9e87eb"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("45bd69ff-50c5-4fc1-a6af-a9600fe5cc84"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4b1e3ddd-fdea-449a-99fc-88f8c5a78b0b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("546c9a2e-b899-4aae-8284-b540a7a3f97f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("59d37f10-774e-4c82-a378-9d5fda0eb109"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5e05a0a5-f86e-4b86-83c3-cb1cf1f481f4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5fc213a7-d20a-4d28-9567-c4d08f7fe9d5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("620e34a6-1c11-4f64-86c2-27e9dbec9a28"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("63e57ae2-b408-4927-bd84-8b007fbd94bc"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("79bc4ec7-3420-4df3-8ec3-9bf9547aa4fa"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7ccd63cb-f410-4107-aa36-39418df86c93"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7eba0bc5-d5f7-4406-9daf-a0d6cccf3c72"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7f9c883d-272f-426c-9f5b-e2913c97bb75"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("80c97c5a-8ab1-4ef6-aafd-6dd08214bae0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("861daa17-e172-418b-9273-b36ffa11ef30"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("86a68656-5576-42ed-809c-e2b767b8f406"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("895e2a1c-4f11-4a9a-bf08-b8830fcca7b9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8b55fd2e-153f-420c-a4b1-4c2f760aa325"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8d0c2bfd-6f87-4035-8ede-a6b65204c262"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8e1fde08-4aab-41fe-830f-80c7da0d463a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8e923d25-decf-4f87-ba62-3d927e51581c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8f47e51e-93ab-4251-959c-067c885c385f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8fa462a1-157a-4e44-a0c4-6c0eb6ac0060"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("937a0413-65a1-4d73-827b-70fa6d592136"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("95b4b500-3763-48cd-9f6c-276b165df94a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a20a2d65-5057-4ffc-9329-4100cdb99363"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a2803055-e820-4161-b3cb-7817120966a9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a465c1ee-1723-4b55-b511-f3f4864f41e1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a4a52522-4381-4c0c-9512-3275a9844558"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a8584983-cdf5-4bef-9d62-23a526fbab81"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a95bf894-cb1f-4d63-84ad-12b47caccb5b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ac7e2ee3-4022-442d-834d-9e1df5cf54e2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bafcaae3-d4c5-4365-8ecb-c4f4ea5d16b0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bed5f8d6-cab5-41a8-8925-34b655bd8654"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c5afdcb7-aaf4-492c-b5a8-e3debb7579ca"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c996c77b-1ab4-4b78-a383-05e3e3b9d579"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cac7914a-8a8b-464f-8e3d-e516aa8abc9d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d0a97b07-597e-4951-abba-225ae4454fbe"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d20c3e62-f042-42e1-863d-959b866a1f8e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d3f2cdf9-454f-44e9-af17-3bfccd405b1d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d853a12f-3da1-4258-aec9-3494cc98b073"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d96efb42-d182-4adc-9881-b09c8eca5dc6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d9ca7867-b5b4-45ad-86a1-89a516ad9d2d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("dcd0e525-83d4-465c-966c-7e23bd380d6b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("df7ca9cf-5c02-489b-8816-e007df70ce56"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e3aeb86b-a1b8-4b09-9e9c-84b368aaa8da"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e6d1b862-f489-498f-b437-f822a9b61ff1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ea1101e5-e1e5-4ee7-aa5c-65492a7849ef"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ecdbbb74-a5a3-4362-9d2d-18440e3c5e16"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("efba5089-9018-4530-afc2-da42082cd67a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f37eceb8-2bcc-471e-b522-af9ffd1d0921"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f3a4d6ac-1308-4683-a68e-c506409b27e5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f78538ca-4017-4359-85fc-15b6926768ee"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f7fa1a92-36d3-4ddf-bcd3-dcc571ce48b1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fa687165-4d51-4df9-9c3c-f8eada69ec15"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fc7881d2-d9cc-4891-8ce8-e9cebbda8c32"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("790cdc22-774d-47e6-98c5-ab016b2a5ac2"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("e5225a8d-0440-4233-a00d-23f80825308e"));

            migrationBuilder.AddColumn<string>(
                name: "FlowMessage",
                table: "Transitions",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ZeebeFlow",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    Gateway = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    Process = table.Column<string>(type: "text", nullable: false),
                    Tags = table.Column<string[]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZeebeFlow", x => x.Name);
                });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-active",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6530), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-deactivated",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6640), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6640) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-card-password-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5950), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5950) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-fail",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6130), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-security-question-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6010), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6010) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-set",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6070), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6070) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5890), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5890) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6470), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-suspended",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6590), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6590) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fd",
                columns: new[] { "CreatedAt", "FlowMessage", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6930), null, new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fs",
                columns: new[] { "CreatedAt", "FlowMessage", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6870), null, new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-deactive",
                columns: new[] { "CreatedAt", "FlowMessage", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6820), null, new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6820) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "FlowMessage", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6700), null, new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-acp",
                columns: new[] { "CreatedAt", "FlowMessage", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6300), null, new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-asq",
                columns: new[] { "CreatedAt", "FlowMessage", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6360), null, new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6360) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-card",
                columns: new[] { "CreatedAt", "FlowMessage", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6190), null, new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-security-question",
                columns: new[] { "CreatedAt", "FlowMessage", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6250), null, new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-suspend",
                columns: new[] { "CreatedAt", "FlowMessage", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6760), null, new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6760) });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("00519d6c-669a-4f57-ac3d-12a16c457cc0"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5930), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("059ad202-72c8-430a-8bb6-f011c79fdfa7"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6500), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("095c3e75-0bfa-4875-967d-238a761edf42"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6660), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6660), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0b4aa3eb-03bd-4996-8703-66c9dfaba38d"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6870), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0e00999e-553c-433c-94a5-64ce4ffefbe4"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6580), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6580), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0f296b0d-951e-4293-bef9-3bdb66bb6c4c"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6410), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1339ec0a-9601-48ba-a75a-f668e4d864da"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("166dc3cd-81e5-406e-8a52-53948eca4243"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6800), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1fe92b30-e9f4-4d99-b663-2af12879c7d5"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6240), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6240), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2852c25d-26dc-4a07-9305-47a111996906"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6220), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6220), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2b801884-d55a-4883-a2a6-9f75e7505e0f"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2e75bc69-97e7-490c-b45d-10bbd3e51aa4"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6300), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("30814db7-e7ee-4ab0-be17-e076069408d1"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6120), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3616dd59-afa8-4d2f-8742-f4ee299fb443"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6730), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("39aae081-7393-4883-bd33-c492afffd8d7"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3a485863-1308-4158-9bd0-ff64411cb4bd"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3cdaff96-4dc0-4cba-b467-5b4a6198b465"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3cf43f10-7590-49a9-8b83-b6120cbfc3a9"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5920), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("423c8a69-f182-4632-b112-6922dfe1931b"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6910), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6910), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("435677b7-b55c-47d5-8fc4-cc7d0c5b4552"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6350), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("458ba6aa-82cd-4d77-bf5a-bef06c11a272"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("48658728-8645-4551-a2c5-4eaf97400cab"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6890), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("4a727164-76fd-4850-93ae-0d5b0b1a97b3"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6980), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("4d98dd25-3abd-4470-8aad-3445f4fb512c"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6450), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("506f90e5-b645-42fe-be2f-3942c23a759a"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("50f9f332-90f9-4618-b249-7164317e36ad"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6920), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("532371ff-0ce1-4d39-9001-62d296a0a708"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("60482695-6998-4f51-927a-af1c1da0d75e"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("60b36021-8611-44e9-8c83-72bbc28974a0"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6840), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("63379467-598e-4696-833d-8dcdd9b852b3"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6000), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6000), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("67d49121-afb1-424b-b0aa-68da1a8ce7b8"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6040), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6e48cd17-f7e2-4756-b259-dee1c278aa22"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6940), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6fd0fe76-d23c-43f8-8645-17b1427a55a3"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("75654029-a98d-4893-8297-ffb9ae90a523"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6230), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("76788759-7e3c-4a84-940c-2ccbfa6a96b9"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6970), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7bc75bfe-14f4-4059-9b30-e3adcf7e4c5a"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6100), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("81b1688d-32e5-40a6-b37a-0cceb12d2bc8"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6340), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("871dec99-41a7-480d-a93b-3b9eb37f2d13"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6520), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8782e522-a68d-4fe0-a401-cd1461af2693"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6540), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6540), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8ecc7616-ab8f-4db1-96e6-9de5b683783b"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6850), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8fdae5e9-8fe1-479c-b2a0-2bf1e5c31f2d"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6740), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("90425b52-6c4f-4a91-b399-60f48f26f7cf"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6090), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6090), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("98371222-3d2d-4a6d-8218-5a8398375d07"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5870), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9939efcc-aa26-4a62-a499-04a1834c41df"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6050), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6050), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9b21cce0-a6c4-464c-963e-76247135f7f6"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6440), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9e5d20c4-587e-4c4a-93c6-ef7391bb7d5a"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6600), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6600), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a063ccf8-06ad-4993-bec8-358e0007706d"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6720), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6720), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a2057a45-ad00-4c13-9bda-77fd8eea643f"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5880), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a62db010-52e2-4670-bbd8-51118759ba95"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6490), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a6ccd65c-9040-461a-8895-bcc4e347a0bd"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5980), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a8be37c3-b344-429d-a787-1b3535c360c5"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ab64a6c1-ce5d-40c2-aa69-f96f73e33f4a"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6830), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6830), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ac7da1a7-392c-495f-8418-d0391db37b33"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6810), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("af3a3b8b-f196-4b57-9e24-2aafb249691d"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b33232c3-b771-454c-acea-346505afc0d0"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6510), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6510), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b78054d6-fe79-42b5-8dc7-078452d5019a"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6780), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6780), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bd3eb55c-2ee0-41a4-abb6-4c5d4c23faea"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6570), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c03cfd86-6a04-434a-8382-9594216f7fa9"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6020), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c40146d3-165e-4315-82e7-c62043425bd9"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c8c417eb-bbac-4e01-91d4-e0ec68085fda"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6640), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6640), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ca67a8fe-0bcc-4f0f-8194-dfbd2477f898"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6290), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6290), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("cf571b01-82b1-477c-b931-c8bad020c549"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6170), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6170), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d9be15c1-66e9-4be7-81a6-8f33af12252e"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("dfc63721-c6a0-43f1-9a0f-488cb74b9413"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6270), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6270), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e0ecab62-b002-4f28-837c-6d67a7583e79"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e4301494-7fb6-4057-bc24-e7499585567c"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6070), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6070), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e8d5717b-5ec4-422b-bad8-c9e5eb086468"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6260), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ea11c734-3380-443b-9d15-34e9cc9e90dc"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6750), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6750), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ef15dfc2-558e-456b-80c5-cf136694c00f"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5990), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f1174b21-3410-4ed3-a7b1-4b0338323985"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6160), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f289dcf7-4228-4356-9c6d-ae7c83f1eb05"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6400), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f3bc4fd4-baf5-4cc1-ae9e-6255a119ae65"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6770), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f53b9310-e916-400d-8e31-89c0d00f6ec4"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6180), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6180), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f616ea50-4986-4a51-a9fa-e64d3128a666"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6140), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f89618a3-1fc0-4a1f-bef3-26fc2e67f8f4"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6110), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6110), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("fd584825-16ce-4c94-8cd5-0ec2b18cbd18"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("04fd105f-91cc-49f9-8f25-63f6aaa232ae"), false, 30, new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5850), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5850), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" },
                    { new Guid("21ebdc97-cce6-4bb9-b6ef-77fb6d772b87"), false, 30, new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6470), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6470), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6430), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5770), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5780) });

            migrationBuilder.InsertData(
                table: "ZeebeFlow",
                columns: new[] { "Name", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Gateway", "Message", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Process", "Tags" },
                values: new object[] { "user-register", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6420), new Guid("00000000-0000-0000-0000-000000000000"), null, "zeebe-local", "simple-flow-starter", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6420), new Guid("00000000-0000-0000-0000-000000000000"), null, "Process_Simple", new[] { "idm", "user" } });

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_ZeebeFlow_ZeebeFlowName",
                table: "Instances",
                column: "ZeebeFlowName",
                principalTable: "ZeebeFlow",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_State_ZeebeFlow_OnEntryFlowName",
                table: "State",
                column: "OnEntryFlowName",
                principalTable: "ZeebeFlow",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_State_ZeebeFlow_OnExitFlowName",
                table: "State",
                column: "OnExitFlowName",
                principalTable: "ZeebeFlow",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Transitions_ZeebeFlow_FlowName",
                table: "Transitions",
                column: "FlowName",
                principalTable: "ZeebeFlow",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Workflows_ZeebeFlow_ZeebeFlowName",
                table: "Workflows",
                column: "ZeebeFlowName",
                principalTable: "ZeebeFlow",
                principalColumn: "Name");
        }
    }
}
