using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instances_State_StateName",
                table: "Instances");

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

            migrationBuilder.AlterColumn<string>(
                name: "StateName",
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
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7490), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7490) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-deactivated",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7600), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7600) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-card-password-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6910), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-fail",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7090), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-security-question-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6970), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-set",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7030), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6850), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7430), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-suspended",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7540), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7550) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fd",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7880), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fs",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7830), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-deactive",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7770), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7770) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7660), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7660) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-acp",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7260), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7260) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-asq",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7320), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7320) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-card",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7150), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-security-question",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7210), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-suspend",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7710), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7710) });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("0129ebe4-0cc5-4fb1-a074-ca5d6d3bf514"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("0345c1f5-f5e9-4995-91ee-aedda789e5c7"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7880), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("05c0e6b6-a9ad-4829-a1cb-40a239d8a055"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7270), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7270), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("12798b1b-c847-44e1-9b06-f2cfb1cfe320"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6990), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("14c03835-520a-4dba-8425-a1c7ba1a2f24"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7800), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("19b759c7-7b77-404a-82ac-bbc9667d30fb"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7240), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7240), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("1c93c5a7-3169-4a63-ada5-83af87c09f1a"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6860), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("1dee6696-49fe-45ad-be6e-2015ddadd01d"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7530), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7530), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("24805bf0-2fdc-4438-930c-61b314d664d3"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7230), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("24b5d274-3bf0-4d03-8a89-6c9490338160"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("26b5e69e-6c7f-4c9e-9489-3ecf4303f27e"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7730), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("30cc49f8-b887-4a9c-a8dc-bc12f1c9031d"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7860), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("324e043b-1a9f-4173-b2e4-083b12c8a235"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7120), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("349ce8a4-8723-49c2-bc10-349f5b60b4c4"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7570), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("38630ef4-fc8f-4ae6-bf27-59c7b46e54df"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7930), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("39b29958-5b44-47ee-8062-d1c4673873bc"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("3c3ba761-0d5a-40dc-a9a2-c7ee11375b14"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7400), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("3ef2e57f-c3ef-4ce9-8c61-6ec83a841b4d"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7190), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7190), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("4a22b73e-46f9-4ef5-be47-a3ae70a661ea"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7810), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("4ff45dba-84ef-4032-914a-f335d44481b6"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6970), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("51f608be-5a72-4fc2-8fae-829ae8317d4b"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7300), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("53c88d49-5bba-45cd-abd9-b92a0f8bb02b"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7220), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7220), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("5ee2183e-cc7b-42f0-ada1-f18b2528c027"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7450), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("6088dde0-244c-4c71-a699-af948b474702"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7060), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7060), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("621a5610-c765-44f6-9a0c-78270aaf29b1"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7310), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7310), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("63e9c49b-c299-4b99-94cd-0c00a9c52ed0"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7480), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7480), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("66fbff80-5e4d-47aa-aeed-d556a303f6e6"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7370), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("67a9afe3-810e-4559-b916-beaeba9d3770"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6940), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("6b243df1-f50c-48ec-ac1e-f73b77b77e85"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7070), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7070), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("6c80b29a-e891-4d60-9d69-5a650e394b58"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6820), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("6db7c1f9-60ca-4068-b877-dda853755b33"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7010), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7010), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("70f707c7-61b9-498a-8773-de3098ab0513"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("71bad346-3dce-45f3-bdaf-4e53f0692243"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7920), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("73bf66b4-fde9-42b9-b205-7c08cc5760a1"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7350), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("7937168f-96a2-4b9b-8089-1d1bc0bd1ef8"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("7a9b1857-bde7-4ab0-a9bd-57c1739fb157"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7750), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7750), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("7bd50843-7778-4569-ae75-f63d9ea6bc78"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7020), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7030), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("7c5d977e-2a00-4aa3-b1b2-1518a269b4fe"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6950), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("7f19753f-1942-4c60-8812-ee6ecd36fb2a"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6890), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6890), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("851aa54f-4191-428e-926f-979fc834cf42"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6840), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("85b71bdf-d6cf-4ae1-bc6d-6818268fd1a0"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7650), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7650), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("8c3b18cf-61f4-4c28-bde7-ac0ba40a79f7"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7130), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7130), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("8fa7c2fe-ea3e-44c5-b273-307b093405ec"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7590), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7590), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("9961497b-89b8-464a-9b7c-3a9b226ac4f3"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6910), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6910), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("9a8dff4e-c343-4494-a2a0-1d6151085c5a"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7260), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("9c16058d-6a3d-437a-8467-f2e3f46bb22d"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7100), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("9f1c2e2e-3693-455f-8f7c-6189d23b40c5"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7440), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("a6c75e59-9cb5-474b-8389-5397a850ae16"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7510), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7510), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("a9d7fcd0-ad28-4a43-a886-d714b47f66ce"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7340), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("aa4d75cb-ea4e-4dda-bf34-d422015c9bef"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7170), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7170), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("b0527705-fd26-4e53-8435-1075da23a8fd"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7820), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("b2c0d786-9db0-44c8-bea4-e1a0b3e0203f"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7200), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("bcf37fe5-338d-46e1-a188-75637314a7c4"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7080), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7080), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("c00219d4-0cfa-4eb5-8a9a-c400ac85210e"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7580), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7580), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("c89ccb0f-0fe9-40f4-8632-5807dd608ed3"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7160), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("ca054d09-3671-49fd-a0d3-7e6de6064804"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7040), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("ca9d2fcc-deed-4f22-9a87-fb8f3f8b9d1a"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7630), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("cb51ed11-e9db-4b06-ae86-ad04283abc6e"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7780), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7780), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("ce50268e-d4f2-4c29-a698-ae940ad92c27"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7470), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7470), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("cfa45bb8-cc6a-40b3-ab2b-2465c577219b"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7000), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7000), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("d3b3a3ca-6f65-46c6-a706-07009a4c8c05"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7760), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("d6770f23-b5e3-4b5d-820c-81d3381d14b5"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7840), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("d977b762-5d2f-451c-95c4-3d4fae7b4605"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7890), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("d9fe1161-4536-4c6f-8d1c-d54e5c96a09c"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6930), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("e13b27d9-9755-4196-a421-71b07a6f8b4c"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7500), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("e5ba67dc-db39-4003-b6ae-fcf797f0bf51"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6880), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("e69b9901-e17d-46a6-a0ae-dd25b245c89a"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7140), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7140), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("e6f5fa20-957b-43a6-8080-baecd6849c6b"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7910), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7910), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("f163444f-f6c1-43c2-b8c9-457e1aba2e8b"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7290), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7290), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("f3976279-6932-494c-a732-088547a06399"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7640), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7640), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("f3a58566-e620-4519-ac90-399547352aa4"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("f3ee4181-ce73-4ae8-8430-ee1b4803cb4d"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("f93b44fc-a61f-49e5-bf07-2a0e6195b531"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7710), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7710), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("fa8ac418-a320-4eef-adf0-793e23b5fc1b"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7410), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("fdd19328-623b-49e5-b195-f0a9d0f8018b"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7690), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7700), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("fe619e29-771a-4b5a-a16d-601542ae60c2"), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7540), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7540), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("72df6406-8c6e-4209-887f-51c2d370aec3"), false, 30, new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7420), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7420), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" },
                    { new Guid("89746cb5-048e-4448-98b0-48b63c954298"), false, 30, new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6800), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6800), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7390), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7390) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6710), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "ZeebeMessage",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7380), new DateTime(2023, 2, 23, 5, 32, 32, 452, DateTimeKind.Utc).AddTicks(7380) });

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_State_StateName",
                table: "Instances",
                column: "StateName",
                principalTable: "State",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instances_State_StateName",
                table: "Instances");

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0129ebe4-0cc5-4fb1-a074-ca5d6d3bf514"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0345c1f5-f5e9-4995-91ee-aedda789e5c7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("05c0e6b6-a9ad-4829-a1cb-40a239d8a055"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("12798b1b-c847-44e1-9b06-f2cfb1cfe320"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("14c03835-520a-4dba-8425-a1c7ba1a2f24"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("19b759c7-7b77-404a-82ac-bbc9667d30fb"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1c93c5a7-3169-4a63-ada5-83af87c09f1a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1dee6696-49fe-45ad-be6e-2015ddadd01d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("24805bf0-2fdc-4438-930c-61b314d664d3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("24b5d274-3bf0-4d03-8a89-6c9490338160"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("26b5e69e-6c7f-4c9e-9489-3ecf4303f27e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("30cc49f8-b887-4a9c-a8dc-bc12f1c9031d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("324e043b-1a9f-4173-b2e4-083b12c8a235"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("349ce8a4-8723-49c2-bc10-349f5b60b4c4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("38630ef4-fc8f-4ae6-bf27-59c7b46e54df"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("39b29958-5b44-47ee-8062-d1c4673873bc"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3c3ba761-0d5a-40dc-a9a2-c7ee11375b14"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3ef2e57f-c3ef-4ce9-8c61-6ec83a841b4d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4a22b73e-46f9-4ef5-be47-a3ae70a661ea"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4ff45dba-84ef-4032-914a-f335d44481b6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("51f608be-5a72-4fc2-8fae-829ae8317d4b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("53c88d49-5bba-45cd-abd9-b92a0f8bb02b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5ee2183e-cc7b-42f0-ada1-f18b2528c027"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6088dde0-244c-4c71-a699-af948b474702"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("621a5610-c765-44f6-9a0c-78270aaf29b1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("63e9c49b-c299-4b99-94cd-0c00a9c52ed0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("66fbff80-5e4d-47aa-aeed-d556a303f6e6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("67a9afe3-810e-4559-b916-beaeba9d3770"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6b243df1-f50c-48ec-ac1e-f73b77b77e85"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6c80b29a-e891-4d60-9d69-5a650e394b58"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6db7c1f9-60ca-4068-b877-dda853755b33"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("70f707c7-61b9-498a-8773-de3098ab0513"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("71bad346-3dce-45f3-bdaf-4e53f0692243"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("73bf66b4-fde9-42b9-b205-7c08cc5760a1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7937168f-96a2-4b9b-8089-1d1bc0bd1ef8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7a9b1857-bde7-4ab0-a9bd-57c1739fb157"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7bd50843-7778-4569-ae75-f63d9ea6bc78"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7c5d977e-2a00-4aa3-b1b2-1518a269b4fe"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7f19753f-1942-4c60-8812-ee6ecd36fb2a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("851aa54f-4191-428e-926f-979fc834cf42"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("85b71bdf-d6cf-4ae1-bc6d-6818268fd1a0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8c3b18cf-61f4-4c28-bde7-ac0ba40a79f7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8fa7c2fe-ea3e-44c5-b273-307b093405ec"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9961497b-89b8-464a-9b7c-3a9b226ac4f3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9a8dff4e-c343-4494-a2a0-1d6151085c5a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9c16058d-6a3d-437a-8467-f2e3f46bb22d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9f1c2e2e-3693-455f-8f7c-6189d23b40c5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a6c75e59-9cb5-474b-8389-5397a850ae16"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a9d7fcd0-ad28-4a43-a886-d714b47f66ce"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("aa4d75cb-ea4e-4dda-bf34-d422015c9bef"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b0527705-fd26-4e53-8435-1075da23a8fd"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b2c0d786-9db0-44c8-bea4-e1a0b3e0203f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bcf37fe5-338d-46e1-a188-75637314a7c4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c00219d4-0cfa-4eb5-8a9a-c400ac85210e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c89ccb0f-0fe9-40f4-8632-5807dd608ed3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ca054d09-3671-49fd-a0d3-7e6de6064804"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ca9d2fcc-deed-4f22-9a87-fb8f3f8b9d1a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cb51ed11-e9db-4b06-ae86-ad04283abc6e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ce50268e-d4f2-4c29-a698-ae940ad92c27"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cfa45bb8-cc6a-40b3-ab2b-2465c577219b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d3b3a3ca-6f65-46c6-a706-07009a4c8c05"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d6770f23-b5e3-4b5d-820c-81d3381d14b5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d977b762-5d2f-451c-95c4-3d4fae7b4605"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d9fe1161-4536-4c6f-8d1c-d54e5c96a09c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e13b27d9-9755-4196-a421-71b07a6f8b4c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e5ba67dc-db39-4003-b6ae-fcf797f0bf51"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e69b9901-e17d-46a6-a0ae-dd25b245c89a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e6f5fa20-957b-43a6-8080-baecd6849c6b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f163444f-f6c1-43c2-b8c9-457e1aba2e8b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f3976279-6932-494c-a732-088547a06399"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f3a58566-e620-4519-ac90-399547352aa4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f3ee4181-ce73-4ae8-8430-ee1b4803cb4d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f93b44fc-a61f-49e5-bf07-2a0e6195b531"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fa8ac418-a320-4eef-adf0-793e23b5fc1b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fdd19328-623b-49e5-b195-f0a9d0f8018b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fe619e29-771a-4b5a-a16d-601542ae60c2"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("72df6406-8c6e-4209-887f-51c2d370aec3"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("89746cb5-048e-4448-98b0-48b63c954298"));

            migrationBuilder.AlterColumn<string>(
                name: "StateName",
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
                    { new Guid("030ab5b0-00c2-4c33-94ea-1615a799f359"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1730), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("044196a8-c4df-423f-b423-f1088dab16e7"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1700), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1700), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0c12ed51-3521-4130-9318-7f90577f2d57"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1000), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1000), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0f643991-ab24-4dac-a3b4-0b11df3dff59"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1020), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("11bda497-46a9-4bb7-8646-f41a91b0cde6"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1470), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1470), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("13f7364a-3b40-4a6e-9ff6-ed197da3737e"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("16ebb9f0-f0df-4436-82e1-ff972849f236"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1b180cbf-ab15-4868-a24f-1a093f99948a"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1660), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1dd26906-dbc4-44be-9e27-bbabb4d48153"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(980), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1f34f14c-59f9-42a1-bb1e-4aa635622972"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1410), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2d668a23-a546-4177-a1cd-2a37bf8b8ade"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1770), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("31d91938-a64e-44ca-a490-c52211042f3f"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1870), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("321c7cc1-ceda-4248-b199-07fa79c22250"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1160), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("37a19aa9-4e75-45ea-92ef-2531e95ae444"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1840), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("38c3485e-1855-44a5-aab1-ac413c6b1980"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3d64994d-e015-43d3-983c-aebab7823b6f"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3f7d5686-8bbc-4780-83c3-8af53e028197"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2010), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2010), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("413e6dc6-125e-4f28-820e-66f7b3c507e8"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("452edc7e-c0ef-4a60-a0fa-b20218afa299"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("45389f87-3c76-4c5b-8e99-91c636d382da"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("4571aeb2-d733-4385-88af-03a6de9e87eb"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(930), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("45bd69ff-50c5-4fc1-a6af-a9600fe5cc84"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1140), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1140), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("4b1e3ddd-fdea-449a-99fc-88f8c5a78b0b"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1820), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("546c9a2e-b899-4aae-8284-b540a7a3f97f"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1100), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("59d37f10-774e-4c82-a378-9d5fda0eb109"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1050), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("5e05a0a5-f86e-4b86-83c3-cb1cf1f481f4"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1270), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1270), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("5fc213a7-d20a-4d28-9567-c4d08f7fe9d5"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1750), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1750), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("620e34a6-1c11-4f64-86c2-27e9dbec9a28"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1640), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1640), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("63e57ae2-b408-4927-bd84-8b007fbd94bc"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1440), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("79bc4ec7-3420-4df3-8ec3-9bf9547aa4fa"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(910), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(910), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7ccd63cb-f410-4107-aa36-39418df86c93"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7eba0bc5-d5f7-4406-9daf-a0d6cccf3c72"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2050), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2050), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7f9c883d-272f-426c-9f5b-e2913c97bb75"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1090), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1090), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("80c97c5a-8ab1-4ef6-aafd-6dd08214bae0"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2040), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2040), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("861daa17-e172-418b-9273-b36ffa11ef30"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("86a68656-5576-42ed-809c-e2b767b8f406"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1210), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("895e2a1c-4f11-4a9a-bf08-b8830fcca7b9"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1030), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1030), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8b55fd2e-153f-420c-a4b1-4c2f760aa325"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1340), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8d0c2bfd-6f87-4035-8ede-a6b65204c262"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1060), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1060), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8e1fde08-4aab-41fe-830f-80c7da0d463a"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1940), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8e923d25-decf-4f87-ba62-3d927e51581c"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1080), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1080), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8f47e51e-93ab-4251-959c-067c885c385f"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1500), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8fa462a1-157a-4e44-a0c4-6c0eb6ac0060"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1550), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("937a0413-65a1-4d73-827b-70fa6d592136"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1240), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1240), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("95b4b500-3763-48cd-9f6c-276b165df94a"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1570), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a20a2d65-5057-4ffc-9329-4100cdb99363"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1300), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a2803055-e820-4161-b3cb-7817120966a9"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a465c1ee-1723-4b55-b511-f3f4864f41e1"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a4a52522-4381-4c0c-9512-3275a9844558"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1800), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a8584983-cdf5-4bef-9d62-23a526fbab81"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a95bf894-cb1f-4d63-84ad-12b47caccb5b"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1630), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ac7e2ee3-4022-442d-834d-9e1df5cf54e2"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1180), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1180), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bafcaae3-d4c5-4365-8ecb-c4f4ea5d16b0"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bed5f8d6-cab5-41a8-8925-34b655bd8654"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1260), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c5afdcb7-aaf4-492c-b5a8-e3debb7579ca"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1980), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c996c77b-1ab4-4b78-a383-05e3e3b9d579"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1510), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1510), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("cac7914a-8a8b-464f-8e3d-e516aa8abc9d"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1450), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d0a97b07-597e-4951-abba-225ae4454fbe"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1810), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d20c3e62-f042-42e1-863d-959b866a1f8e"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1150), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d3f2cdf9-454f-44e9-af17-3bfccd405b1d"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2030), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(2030), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d853a12f-3da1-4258-aec9-3494cc98b073"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1990), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d96efb42-d182-4adc-9881-b09c8eca5dc6"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1120), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d9ca7867-b5b4-45ad-86a1-89a516ad9d2d"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1430), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("dcd0e525-83d4-465c-966c-7e23bd380d6b"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1400), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("df7ca9cf-5c02-489b-8816-e007df70ce56"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1880), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e3aeb86b-a1b8-4b09-9e9c-84b368aaa8da"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1910), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1910), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e6d1b862-f489-498f-b437-f822a9b61ff1"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ea1101e5-e1e5-4ee7-aa5c-65492a7849ef"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ecdbbb74-a5a3-4362-9d2d-18440e3c5e16"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1280), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("efba5089-9018-4530-afc2-da42082cd67a"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f37eceb8-2bcc-471e-b522-af9ffd1d0921"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1350), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f3a4d6ac-1308-4683-a68e-c506409b27e5"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1230), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f78538ca-4017-4359-85fc-15b6926768ee"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(960), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(960), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f7fa1a92-36d3-4ddf-bcd3-dcc571ce48b1"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1920), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("fa687165-4d51-4df9-9c3c-f8eada69ec15"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1620), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("fc7881d2-d9cc-4891-8ce8-e9cebbda8c32"), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1580), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1580), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null }
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

            migrationBuilder.UpdateData(
                table: "ZeebeMessage",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1480), new DateTime(2023, 2, 20, 16, 46, 37, 473, DateTimeKind.Utc).AddTicks(1480) });

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_State_StateName",
                table: "Instances",
                column: "StateName",
                principalTable: "State",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
