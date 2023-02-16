using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instances_ZeebeFlow_ZeebeFlowName",
                table: "Instances");

            migrationBuilder.DropIndex(
                name: "IX_Instances_EntityName_RecordId_WorkflowName_StateName",
                table: "Instances");

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0265dde7-a955-4cdc-a6cd-6ae1f251ba90"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("02fef66f-a2ed-4f39-8ae2-8c0b1c272264"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("05762404-606b-4e98-ae6c-b69967bf9707"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0b1b20a5-0cf8-4f78-94b7-772ec5428752"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0b2b0ff0-6cef-4793-8db6-4ac539ead096"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0eba898a-d920-4c69-9f0e-f009f961ee7a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("18c37af6-e41a-4253-a9c8-0989ffaf665e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1a660e8f-7795-479d-8056-59b4f9243302"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2058f8ca-0102-4bc4-998c-ee2233898df0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("21203d9e-ec3d-4042-b9aa-7c127ceedf9a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("21d22a51-5dd4-4313-9856-d039ad7adb3a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("27af8a5b-6065-41f8-a6dd-6069d3a80a12"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("27bd75ad-3123-4d26-83bf-18d9d8c33b28"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("29f443b0-08e1-4fe0-8e91-429d95fc4d0a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2fc0fc2b-5a1f-45bb-9c86-70967f747e01"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3485430c-25af-4dfe-b0dd-bfb4bd9c5791"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("35c518c6-c0f5-4e97-9a1c-5da116e5185f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("38b97bac-799a-4bff-a47f-2d396d749dc3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("38e7a0fe-f781-4081-9f88-fd1719280253"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3a85ed21-cd06-429a-97ba-2cf8621c2218"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("466e86cf-13ae-4189-9cd6-bb5b9427333f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("46ecf20f-4d06-435d-891e-86dea3e1d9cb"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("48960ecc-0900-4e52-8446-f87e9a35a328"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4ade69d9-45d4-4da9-81fd-42c08efc764b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4ca3ff44-ebd3-4ed3-99f0-19ff1d721dbb"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4e605fc6-c7a8-468d-a224-86c4e5afb6b7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("538892e6-2b87-42de-919a-8aa1a4cba914"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("613afdc4-a0e9-4b9d-bb35-9633d96dc539"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("67e07a3d-aa30-433b-9c32-3f178329a788"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("684d0e25-f724-4cbf-a7be-300c4c87eae5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6c2b3bb5-09ea-4d18-8bcb-0cc965609096"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6cf1ebb0-0d7b-4420-acbf-af247751b962"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6de96710-b48d-4d02-9379-362b95fa15dd"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6f67b4b1-ff87-4d0a-83fb-9672880779f9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6fdaa525-406a-4161-9d15-4bb79498467d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("755c5460-2e14-4653-9a7d-75cbf8e78f29"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7c6dece7-8fab-4666-b5b4-57800db55f5e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7dc14146-75ab-4bfb-b80c-56b4ed400cca"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("836b5e3b-e302-4cc0-b5b9-caf79ac2f6a7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8831ce59-2669-44a8-bf22-0f76af893e32"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8a1b6e5e-0057-4332-95e8-97da8bc5bf23"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8aef0647-dc75-4c06-85f1-075867adb49b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8ba3a18b-e1e8-4603-acb6-a3dceb365c4b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("92473345-69cf-4c23-a8bd-973ce17c7d69"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("932b8e53-fbb9-4533-a36e-0c84a2b3d84a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("94ff3eb2-0c62-40b0-8216-c3df599f216e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("986f2a84-259e-4e16-9797-974166ee264d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9ad76f07-0834-45bf-acc2-1946ed38a3b7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9d479ef7-ef8e-4162-a4e3-683bb7acd861"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9e8d561d-ce96-47ba-9c8d-dc42f9f48685"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a0c73ef7-f46f-4a9a-aaf1-d5631b0e9149"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a678ee82-2ef1-4f65-b03a-23d27c2dfa5f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("aa43ae4b-2443-461a-9c69-7a8a4621764c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ac59e70b-a33a-438c-bc7e-27206ecf1a9e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b37e1591-5107-4447-8dfb-731320fc81e2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b458281d-514b-46b1-850e-26ba321f5247"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b4e04f55-258f-4bb5-a0f4-98787ebd37dc"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b6793ca5-7eda-4949-9e5b-f1826370ea94"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b8495db3-9118-46ec-b1db-1e15823cf5ce"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b97bd170-4f32-45e5-aaae-255936558f30"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b9f5f3eb-9865-4111-8ff8-7ac5f4425d19"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ba6ef645-3caf-4c47-8923-6b7c39c7495b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bbcb69a4-90b3-4614-b7cf-0f3dc169e6a3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bf1dac80-44d1-4ee0-8f19-b9900a0df2bc"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bfcc1908-f50d-433c-aba4-9f76dd86fcda"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c0d4c45f-c930-4613-a560-77f540a5a511"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ca2fe291-4e76-41c8-819e-f6111e4f40e5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ce68b3c3-d125-46c4-a544-c9e70830d6e6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d1cd18ba-6df6-4040-81de-4755a911924b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e5369a90-e8af-436c-9a24-e2fc79756f5d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e6fdbe64-5b91-4f07-9f1c-9bf02739e8b9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e71349d4-6a71-4407-8cb8-98e81045c854"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e979572f-9f6e-447e-9110-f116d70f4326"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f0dca32a-8f9b-4a26-b433-5777ea7f1ae5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f732d1e0-3046-4234-966e-2cab476262e2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ff86fe01-23ec-48a1-8b67-9ca6f12a564b"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("abe2fb32-7a28-48d1-b72f-e140c165449c"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("f2d515dd-e0b8-4ed8-aea1-a135e3d65dfc"));

            migrationBuilder.AlterColumn<string>(
                name: "ZeebeFlowName",
                table: "Instances",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-active",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5220), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5220) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-deactivated",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5330), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5330) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-card-password-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4610), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4610) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-fail",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4780), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4780) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-security-question-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4670), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-set",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4730), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4730) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4540), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4540) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5170), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5170) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-suspended",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5280), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5280) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fd",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5630), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5630) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fs",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5560), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-deactive",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5500), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5500) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5390), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5390) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-acp",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4960), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-asq",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5020), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5020) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-card",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4840), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-security-question",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4910), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4910) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-suspend",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5450), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("00c3d9fd-22fd-4470-a8cd-188a4b15f424"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4940), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("04fa9736-a27c-42a9-baa1-a92a91e3bc14"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5150), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("074bf4a0-02ec-4a27-b979-5ddc96d92e79"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5110), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5110), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("07c25b51-ea45-4c6d-ab33-126dd4900c5e"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4620), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("091c6e1f-4630-47c5-904a-f6e0571d35ca"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5600), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5600), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("0c7c8640-e2c5-4611-b020-3772e67d472b"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4980), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("0cd6b209-8a40-453f-9942-d4c802b6da34"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4890), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("11d57981-e47c-4f17-95ce-ebbe44e7b815"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5180), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5180), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("13956101-2090-4d23-b27e-aac896c396bb"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5680), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("175671ab-9cf1-4db6-9faa-bcc84c7d0675"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5330), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("17576987-1abe-46f4-ada1-6c27a589c7ef"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4710), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4710), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("19ac61db-4ca8-40f5-a481-7a1a05e4e007"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4720), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4720), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("1b6b6701-7453-444a-955e-6bce0283b02a"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5460), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5460), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("1fe60979-3ae2-45a0-a7e4-f3838856de8b"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4860), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("21e92fcc-e6bc-4893-b1f6-e286ba5f93a9"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("2220e17b-414a-4397-912d-a63f84c20c6b"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5500), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5500), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("25dc9453-6b7a-4553-bd82-0cb97ee66d22"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("28895f18-150b-4e6d-a0d6-048bcc7a4246"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4590), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4590), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("29233d59-6908-425b-9fcf-976583a66ce8"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5390), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5390), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("2fc41ee4-0720-465f-aa19-98160961a456"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5640), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5650), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("35bc7b60-d0d2-4b2b-bae6-286edd7e1da7"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4660), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4660), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("38304588-3393-45bc-be2b-48dba6a5a4b5"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5380), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("3aaa4ed0-4233-4fe6-a07c-5ba248cd4f15"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4520), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("3bc9891d-7ab0-4e5c-98a0-9d1b35c8a96a"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5580), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5580), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("3e34a5fa-7806-45e7-97d9-d1f59e9f15f3"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5470), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5470), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("446ec6b7-ec84-426e-a456-d75e9e419940"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5040), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("45d24780-799b-4def-9653-2d191192a254"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4600), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4600), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("49c1f968-a162-472e-b327-f88d042ceeb4"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5190), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5190), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("4a5d2414-f20f-4236-ac16-4fd969d5c6a0"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("4c307303-ae42-4ff5-8972-0113689db18a"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4810), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("4c4b8f5b-ab53-47e9-ba4e-4bb0a9792907"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4840), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4840), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("4d977f49-7d80-4be0-a676-590e5a520ada"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4920), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("5174cc55-c90c-47f4-bfaf-a9b5fa44be60"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4530), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4530), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("540a8a0b-a430-4eea-8c3e-99ff44b158b0"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5030), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5030), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("58a30109-6fd4-4ced-b22b-58fca47e7f52"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5130), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5130), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("5b6bc643-ec5c-4bfc-a915-cf0f5cbfa975"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5360), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5360), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("5f4ebc95-a485-42e8-abd6-36c75e85592a"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5260), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5260), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("5f883e04-6619-4fdb-a540-60899aaba01b"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5440), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("6adb0476-8d2c-469b-9e2f-b265e8057d20"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5530), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5530), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("74a928d1-f238-41e4-9144-111ffce4853b"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4650), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4650), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("82aef61d-6ecd-4be9-b0d0-8e92457ba2a1"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4570), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("84779b2e-3b14-44c3-8903-7e3e2d97772b"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5520), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("85a7d11e-46cd-4163-9f69-cd60b38d81dd"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5550), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("8780a389-f3d6-4e03-ad3f-8fd1b3d7b7cf"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5010), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5010), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("88a509f4-0136-4f4e-94a4-29e50b917f74"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("8eb253ce-a0c4-4780-b9cc-e44392eff146"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5220), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5220), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("92ac37b8-81ef-4646-85b6-553e47a6ed86"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5350), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("931fa430-2fce-45d9-893c-e5d3b49933ba"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("940be1c3-8db8-480f-a55b-b9227e101a1d"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5610), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("95b2cdff-3a58-47f6-aa42-d0f580f6591a"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5320), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("96094f13-374e-4e79-b9e7-ff6d81379b3b"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5570), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("96f3be88-4458-4161-bb4d-61ca9f16d2c5"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5230), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("9becfab0-8291-4278-abf8-f62af4495a24"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4900), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("9c92fbee-5984-4af1-ba38-b1c0858b501f"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5430), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("a1885a17-69f5-40bf-9843-2d872338fb3d"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5540), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5540), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("adc5e7f1-d9f7-46dd-a4fe-a86c3785339a"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4930), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("b2a31cd1-0b7f-4537-afc0-c72aebe52d57"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5000), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5000), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("b5ae15a0-23c6-46d3-8be6-39176b541276"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4750), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4750), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("b674507c-77f5-49eb-bf0c-34aa1daab577"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5300), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("b69117b2-41e1-4d8d-b931-9571afbd3def"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4630), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("b7c06f34-6a81-492b-9a7e-67a460ea2e27"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5660), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5660), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("b86ef457-8873-4fa0-b3a0-44d3ed6bb9b9"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5200), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("c38dce78-6eb0-4294-8ee3-45fd57d50c46"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5490), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("c825edf1-7bb8-425c-abfe-f05eb1efd5a8"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5670), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("c9923baf-3381-4117-8291-13e905808ff2"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5250), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5250), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("d15a4c75-ccb3-43e9-a37d-b57ad8119d54"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4760), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4760), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("e0421957-ea2e-4df3-86b7-5abc221a6c0a"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4870), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("e8004ca7-2db6-45e3-baac-f489b6d84642"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5100), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("e80a735c-881e-4c81-938c-220d1c4da792"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5270), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5270), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("eb2e90ce-1ac6-4593-9391-97a157c0aed9"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("efee87b6-2efd-4a2d-82ec-39f82261a431"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4820), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4820), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("f3c5ec7b-9e29-4f40-aaa9-91d94e3a790e"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4800), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("f4cca48a-8b1d-4353-b493-0e73fb8d8708"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5420), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5420), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("f6f60414-072f-48f7-aa26-cab65eaaf900"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4950), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("f704df15-bc11-46dd-9ef2-449e10b32ed8"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5290), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5290), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("fe7d4258-9a91-4b00-b453-3c5c5c0c2bb2"), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4780), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4780), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("198408a8-eec2-48c3-8b52-a06c036db2c6"), false, 30, new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4490), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4490), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" },
                    { new Guid("2ab9b7fc-6259-4c40-94f9-bd1f98ac14f7"), false, 30, new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5160), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5160), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5120), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(5120) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4420), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4420) });

            migrationBuilder.UpdateData(
                table: "ZeebeFlow",
                keyColumn: "Name",
                keyValue: "zb-user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4400), new DateTime(2023, 2, 16, 16, 19, 13, 20, DateTimeKind.Utc).AddTicks(4400) });

            migrationBuilder.CreateIndex(
                name: "IX_Instances_EntityName_RecordId_StateName",
                table: "Instances",
                columns: new[] { "EntityName", "RecordId", "StateName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_ZeebeFlow_ZeebeFlowName",
                table: "Instances",
                column: "ZeebeFlowName",
                principalTable: "ZeebeFlow",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instances_ZeebeFlow_ZeebeFlowName",
                table: "Instances");

            migrationBuilder.DropIndex(
                name: "IX_Instances_EntityName_RecordId_StateName",
                table: "Instances");

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("00c3d9fd-22fd-4470-a8cd-188a4b15f424"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("04fa9736-a27c-42a9-baa1-a92a91e3bc14"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("074bf4a0-02ec-4a27-b979-5ddc96d92e79"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("07c25b51-ea45-4c6d-ab33-126dd4900c5e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("091c6e1f-4630-47c5-904a-f6e0571d35ca"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0c7c8640-e2c5-4611-b020-3772e67d472b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0cd6b209-8a40-453f-9942-d4c802b6da34"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("11d57981-e47c-4f17-95ce-ebbe44e7b815"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("13956101-2090-4d23-b27e-aac896c396bb"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("175671ab-9cf1-4db6-9faa-bcc84c7d0675"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("17576987-1abe-46f4-ada1-6c27a589c7ef"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("19ac61db-4ca8-40f5-a481-7a1a05e4e007"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1b6b6701-7453-444a-955e-6bce0283b02a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1fe60979-3ae2-45a0-a7e4-f3838856de8b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("21e92fcc-e6bc-4893-b1f6-e286ba5f93a9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2220e17b-414a-4397-912d-a63f84c20c6b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("25dc9453-6b7a-4553-bd82-0cb97ee66d22"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("28895f18-150b-4e6d-a0d6-048bcc7a4246"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("29233d59-6908-425b-9fcf-976583a66ce8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2fc41ee4-0720-465f-aa19-98160961a456"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("35bc7b60-d0d2-4b2b-bae6-286edd7e1da7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("38304588-3393-45bc-be2b-48dba6a5a4b5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3aaa4ed0-4233-4fe6-a07c-5ba248cd4f15"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3bc9891d-7ab0-4e5c-98a0-9d1b35c8a96a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3e34a5fa-7806-45e7-97d9-d1f59e9f15f3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("446ec6b7-ec84-426e-a456-d75e9e419940"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("45d24780-799b-4def-9653-2d191192a254"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("49c1f968-a162-472e-b327-f88d042ceeb4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4a5d2414-f20f-4236-ac16-4fd969d5c6a0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4c307303-ae42-4ff5-8972-0113689db18a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4c4b8f5b-ab53-47e9-ba4e-4bb0a9792907"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4d977f49-7d80-4be0-a676-590e5a520ada"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5174cc55-c90c-47f4-bfaf-a9b5fa44be60"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("540a8a0b-a430-4eea-8c3e-99ff44b158b0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("58a30109-6fd4-4ced-b22b-58fca47e7f52"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5b6bc643-ec5c-4bfc-a915-cf0f5cbfa975"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5f4ebc95-a485-42e8-abd6-36c75e85592a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5f883e04-6619-4fdb-a540-60899aaba01b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6adb0476-8d2c-469b-9e2f-b265e8057d20"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("74a928d1-f238-41e4-9144-111ffce4853b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("82aef61d-6ecd-4be9-b0d0-8e92457ba2a1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("84779b2e-3b14-44c3-8903-7e3e2d97772b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("85a7d11e-46cd-4163-9f69-cd60b38d81dd"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8780a389-f3d6-4e03-ad3f-8fd1b3d7b7cf"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("88a509f4-0136-4f4e-94a4-29e50b917f74"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8eb253ce-a0c4-4780-b9cc-e44392eff146"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("92ac37b8-81ef-4646-85b6-553e47a6ed86"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("931fa430-2fce-45d9-893c-e5d3b49933ba"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("940be1c3-8db8-480f-a55b-b9227e101a1d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("95b2cdff-3a58-47f6-aa42-d0f580f6591a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("96094f13-374e-4e79-b9e7-ff6d81379b3b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("96f3be88-4458-4161-bb4d-61ca9f16d2c5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9becfab0-8291-4278-abf8-f62af4495a24"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9c92fbee-5984-4af1-ba38-b1c0858b501f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a1885a17-69f5-40bf-9843-2d872338fb3d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("adc5e7f1-d9f7-46dd-a4fe-a86c3785339a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b2a31cd1-0b7f-4537-afc0-c72aebe52d57"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b5ae15a0-23c6-46d3-8be6-39176b541276"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b674507c-77f5-49eb-bf0c-34aa1daab577"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b69117b2-41e1-4d8d-b931-9571afbd3def"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b7c06f34-6a81-492b-9a7e-67a460ea2e27"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b86ef457-8873-4fa0-b3a0-44d3ed6bb9b9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c38dce78-6eb0-4294-8ee3-45fd57d50c46"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c825edf1-7bb8-425c-abfe-f05eb1efd5a8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c9923baf-3381-4117-8291-13e905808ff2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d15a4c75-ccb3-43e9-a37d-b57ad8119d54"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e0421957-ea2e-4df3-86b7-5abc221a6c0a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e8004ca7-2db6-45e3-baac-f489b6d84642"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e80a735c-881e-4c81-938c-220d1c4da792"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("eb2e90ce-1ac6-4593-9391-97a157c0aed9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("efee87b6-2efd-4a2d-82ec-39f82261a431"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f3c5ec7b-9e29-4f40-aaa9-91d94e3a790e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f4cca48a-8b1d-4353-b493-0e73fb8d8708"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f6f60414-072f-48f7-aa26-cab65eaaf900"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f704df15-bc11-46dd-9ef2-449e10b32ed8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fe7d4258-9a91-4b00-b453-3c5c5c0c2bb2"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("198408a8-eec2-48c3-8b52-a06c036db2c6"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("2ab9b7fc-6259-4c40-94f9-bd1f98ac14f7"));

            migrationBuilder.AlterColumn<string>(
                name: "ZeebeFlowName",
                table: "Instances",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-active",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7420), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7420) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-deactivated",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7530), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7530) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-card-password-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6820), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6820) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-fail",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6990), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-security-question-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6880), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6880) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-set",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6930), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6720), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6720) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7360), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7360) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-suspended",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7480), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fd",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7830), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fs",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7770), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7770) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-deactive",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7710), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7710) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7590), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7590) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-acp",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7170), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-asq",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7230), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-card",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7050), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7050) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-security-question",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7110), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-suspend",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7650), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7650) });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("0265dde7-a955-4cdc-a6cd-6ae1f251ba90"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7130), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7130), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("02fef66f-a2ed-4f39-8ae2-8c0b1c272264"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7710), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7710), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("05762404-606b-4e98-ae6c-b69967bf9707"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0b1b20a5-0cf8-4f78-94b7-772ec5428752"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7470), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7470), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0b2b0ff0-6cef-4793-8db6-4ac539ead096"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0eba898a-d920-4c69-9f0e-f009f961ee7a"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("18c37af6-e41a-4253-a9c8-0989ffaf665e"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1a660e8f-7795-479d-8056-59b4f9243302"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2058f8ca-0102-4bc4-998c-ee2233898df0"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7070), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7070), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("21203d9e-ec3d-4042-b9aa-7c127ceedf9a"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6870), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("21d22a51-5dd4-4313-9856-d039ad7adb3a"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6960), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6960), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("27af8a5b-6065-41f8-a6dd-6069d3a80a12"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7820), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("27bd75ad-3123-4d26-83bf-18d9d8c33b28"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("29f443b0-08e1-4fe0-8e91-429d95fc4d0a"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7870), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2fc0fc2b-5a1f-45bb-9c86-70967f747e01"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7490), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3485430c-25af-4dfe-b0dd-bfb4bd9c5791"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("35c518c6-c0f5-4e97-9a1c-5da116e5185f"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7220), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7220), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("38b97bac-799a-4bff-a47f-2d396d749dc3"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7040), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("38e7a0fe-f781-4081-9f88-fd1719280253"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7280), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3a85ed21-cd06-429a-97ba-2cf8621c2218"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("466e86cf-13ae-4189-9cd6-bb5b9427333f"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6770), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("46ecf20f-4d06-435d-891e-86dea3e1d9cb"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6930), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("48960ecc-0900-4e52-8446-f87e9a35a328"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7190), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7190), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("4ade69d9-45d4-4da9-81fd-42c08efc764b"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7160), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("4ca3ff44-ebd3-4ed3-99f0-19ff1d721dbb"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("4e605fc6-c7a8-468d-a224-86c4e5afb6b7"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6890), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("538892e6-2b87-42de-919a-8aa1a4cba914"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7780), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7780), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("613afdc4-a0e9-4b9d-bb35-9633d96dc539"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("67e07a3d-aa30-433b-9c32-3f178329a788"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7590), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7590), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("684d0e25-f724-4cbf-a7be-300c4c87eae5"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7650), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7650), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6c2b3bb5-09ea-4d18-8bcb-0cc965609096"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7090), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7090), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6cf1ebb0-0d7b-4420-acbf-af247751b962"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6710), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6710), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6de96710-b48d-4d02-9379-362b95fa15dd"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7880), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6f67b4b1-ff87-4d0a-83fb-9672880779f9"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7440), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6fdaa525-406a-4161-9d15-4bb79498467d"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("755c5460-2e14-4653-9a7d-75cbf8e78f29"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7720), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7720), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7c6dece7-8fab-4666-b5b4-57800db55f5e"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7020), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7dc14146-75ab-4bfb-b80c-56b4ed400cca"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7620), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("836b5e3b-e302-4cc0-b5b9-caf79ac2f6a7"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7030), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7030), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8831ce59-2669-44a8-bf22-0f76af893e32"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7270), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7270), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8a1b6e5e-0057-4332-95e8-97da8bc5bf23"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6920), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8aef0647-dc75-4c06-85f1-075867adb49b"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6810), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8ba3a18b-e1e8-4603-acb6-a3dceb365c4b"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7530), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7530), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("92473345-69cf-4c23-a8bd-973ce17c7d69"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6830), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6830), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("932b8e53-fbb9-4533-a36e-0c84a2b3d84a"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("94ff3eb2-0c62-40b0-8216-c3df599f216e"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7750), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7750), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("986f2a84-259e-4e16-9797-974166ee264d"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7180), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7180), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9ad76f07-0834-45bf-acc2-1946ed38a3b7"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7010), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7010), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9d479ef7-ef8e-4162-a4e3-683bb7acd861"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6840), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9e8d561d-ce96-47ba-9c8d-dc42f9f48685"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a0c73ef7-f46f-4a9a-aaf1-d5631b0e9149"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7240), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7240), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a678ee82-2ef1-4f65-b03a-23d27c2dfa5f"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7430), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("aa43ae4b-2443-461a-9c69-7a8a4621764c"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7690), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ac59e70b-a33a-438c-bc7e-27206ecf1a9e"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7500), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b37e1591-5107-4447-8dfb-731320fc81e2"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7510), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7510), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b458281d-514b-46b1-850e-26ba321f5247"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b4e04f55-258f-4bb5-a0f4-98787ebd37dc"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7400), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b6793ca5-7eda-4949-9e5b-f1826370ea94"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7340), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b8495db3-9118-46ec-b1db-1e15823cf5ce"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7460), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7460), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b97bd170-4f32-45e5-aaae-255936558f30"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b9f5f3eb-9865-4111-8ff8-7ac5f4425d19"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7250), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7250), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ba6ef645-3caf-4c47-8923-6b7c39c7495b"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7890), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bbcb69a4-90b3-4614-b7cf-0f3dc169e6a3"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7080), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7080), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bf1dac80-44d1-4ee0-8f19-b9900a0df2bc"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6860), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bfcc1908-f50d-433c-aba4-9f76dd86fcda"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7550), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c0d4c45f-c930-4613-a560-77f540a5a511"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7150), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ca2fe291-4e76-41c8-819e-f6111e4f40e5"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7760), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ce68b3c3-d125-46c4-a544-c9e70830d6e6"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7630), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d1cd18ba-6df6-4040-81de-4755a911924b"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7110), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7110), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e5369a90-e8af-436c-9a24-e2fc79756f5d"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7810), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e6fdbe64-5b91-4f07-9f1c-9bf02739e8b9"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e71349d4-6a71-4407-8cb8-98e81045c854"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e979572f-9f6e-447e-9110-f116d70f4326"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7210), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f0dca32a-8f9b-4a26-b433-5777ea7f1ae5"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7140), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7140), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f732d1e0-3046-4234-966e-2cab476262e2"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6990), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ff86fe01-23ec-48a1-8b67-9ca6f12a564b"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7570), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("abe2fb32-7a28-48d1-b72f-e140c165449c"), false, 30, new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7350), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7350), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" },
                    { new Guid("f2d515dd-e0b8-4ed8-aea1-a135e3d65dfc"), false, 30, new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6670), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6670), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7300), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7300) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6590), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6590) });

            migrationBuilder.UpdateData(
                table: "ZeebeFlow",
                keyColumn: "Name",
                keyValue: "zb-user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6560), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6560) });

            migrationBuilder.CreateIndex(
                name: "IX_Instances_EntityName_RecordId_WorkflowName_StateName",
                table: "Instances",
                columns: new[] { "EntityName", "RecordId", "WorkflowName", "StateName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_ZeebeFlow_ZeebeFlowName",
                table: "Instances",
                column: "ZeebeFlowName",
                principalTable: "ZeebeFlow",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
