using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Instances_EntityName_EntityId_WorkflowName",
                table: "Instances");

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0847d6fd-60c6-4cbf-be50-f4c6695e8673"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0de788c1-22a7-4cf3-801c-ba349bfba6dd"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("107af028-142f-494d-859f-44836476a093"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("11d8bd04-8848-4bdf-8c1a-26969be69e2f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1424635f-9a2c-4b36-9aa3-b837275ca9ad"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("17960b6f-d2b7-4d3d-a124-acaa32bdc1a5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1cf4f0e4-ee43-437e-bb79-3aa0b9a965d9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("20a9dbd8-ae57-4d15-9390-9489187b898e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("22456683-5534-4c96-a48b-1b717cb485ba"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("23973586-e003-4f7c-9a52-2ac6c29fe9a0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("24bba205-e38d-455e-82bb-148d69611f37"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2a3f34ed-c434-4300-b445-e946db139c78"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2aabf070-013e-43f9-b1fa-549c65747413"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2b8a0b28-eccc-43fc-b5c1-a3d3d1a897be"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2beb7a3f-4551-4154-82ac-90b07e666db3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2cb10675-9f61-4577-be9c-bf8159bb4bda"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("370f499c-583b-47a4-b5cc-6507bcd14708"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("374c27c9-aff3-4e9a-b00f-8119c67afe7a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("39da7e23-5400-4c67-8b02-eae56e4aeaa3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3b671d47-40a4-4df1-a9be-e275f5e31ae8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("48901678-749d-445e-916c-69532bfea39b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("49f183da-9c0e-4efe-a620-5e9b8da2072c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4ff7c01d-c5d2-497b-ae60-5e8b7cbf9fcb"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5234c4e6-1090-4bd6-b6f7-6926f4ea8ed7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5d818571-b12a-4e8c-b03d-74a7655de12c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5e500871-2531-4cdb-837b-f8b67b717c1d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("627cb2f9-704f-4b74-9552-d3e055003d1d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("62fa38b7-1f2c-4f35-bd49-f28353748643"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("65cf174d-92d4-462f-b792-74769d24c241"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("68acb5b6-b073-4678-8721-de5a958f5cce"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6e4c27ee-dc0d-4095-a6bf-c13501d6010a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("70c069a9-3d3e-43ff-aaee-2a833b5c937f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("71597b2b-5df1-4e26-8cd7-d7734540f343"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("72946d57-e3ca-4c9d-bfad-671dddd1c1bd"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("79a3229e-392c-4d1d-8295-7319b6ff132a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("832a6611-ff01-44a9-b367-5ccb4f6f2c2a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("877cea51-e99a-40a5-9dd9-b3ae43c5ed9e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8a39e8d0-c636-4601-b25e-8bf664ed8077"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8b0a3ff8-b1a5-463c-815f-7b7c51939db7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("907756a4-8af0-419b-9144-763a78a12a0a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("918d37b5-f88e-4c52-adb7-eecca3f7ce93"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("922b1c39-3168-4072-ab5a-864fc577fb8f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("99b2977b-4740-45e1-bff7-32d37b7d239e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("99fbbd28-178d-4744-8d0e-bef3a818c015"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a1f85020-3ba0-47c6-9bd1-86bf253c6d72"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("acaac065-46bd-48c6-87e2-03e6baebbf9a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ad5aa5e5-9793-4043-8fab-0bd742bfc1e9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b62bf544-219b-4938-b73c-a158a633e350"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b9228dbc-9fe2-4d20-b5e0-da476af5b158"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bb8987a5-8d2a-4ea0-81d2-e6f85e9c7f55"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bc91c621-6a14-4653-b948-52c2849662d1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bde556b2-157c-4f22-8b5a-8a1df9f049d2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c747abb5-5f3a-46f8-9632-1739742a5694"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cccf0bc8-8bf0-4c46-83b2-3033c88bd870"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cef35454-e0f7-4ccf-9a5d-a1bb31d9f0c2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d5081144-e89b-4af4-8a38-b8287ae10a64"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d6e8be6c-ba6f-4437-a089-d8eb7b4550f2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d8d256c4-31b8-4b58-9735-0b96ef349fde"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d95c0ffe-1af3-42f4-9eee-93909199dc71"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d9731e1b-d4ca-408b-9524-905f2c3e7c96"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("db566c7b-35b7-4df9-b8ac-2891e862fb72"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("dbdee2b0-ab46-4047-8f41-d936a397eebb"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("dd5d7ae0-44f3-4056-8529-4e2ab770a230"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("de33573e-dfd6-44c3-8735-1ea12630d148"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e2f90e8a-6c56-4fb8-bb94-78b702b62bea"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e3476fe3-987e-4629-88bc-70f4e0916c3d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e3b7af78-3943-444d-aafd-479a739f8751"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e6fb0146-6b9d-4002-8231-0ba1b42dd474"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("eb782f91-4dfd-459c-93c0-937ca4435551"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("eda9850a-786d-4e1a-9fd9-be0347a0be13"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("eff197e0-15a9-4c3c-b55c-844b18d997b2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f00028a0-abb4-4d8c-a2af-3a0f24759c56"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f96f356f-03c8-43ad-9a4c-d40f12d54023"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fe84d92c-feab-41f9-9413-1c341a239135"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fe861fc8-6300-4276-815c-94b326c4d9d0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fff4d0df-8bb5-4a94-8ff1-b75600419f2f"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("7f015114-0625-434b-920c-8f8455436149"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("b350604a-c107-434b-b5ec-0b6efe1cdf5c"));

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-active",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9720), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9720) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-deactivated",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9830), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9830) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-card-password-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9160), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9160) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-fail",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9330), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9330) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-security-question-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9220), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9220) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-set",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9270), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9060), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9060) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9660), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9660) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-suspended",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9770), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9770) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fd",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(100), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(100) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fs",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(50), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(50) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-deactive",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9880), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9890) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-acp",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9500), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-asq",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9550), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9550) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-card",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9390), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9390) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-security-question",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9440), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-suspend",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9940), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9940) });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("00782349-5c58-47bb-a994-3189c13181d1"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9910), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9910), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("02e41225-20f7-4f0a-affc-b836a946451b"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9700), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9700), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("04e1e17d-2bb4-47f6-adae-5f262c18b44d"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("09641a64-2a8d-41b9-9fe4-e46138686aed"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(80), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(80), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("0b9934b5-c3d5-4478-a571-2e9c254bcc61"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9480), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9480), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("0e80fbf0-62d2-4a61-a67f-3edc1c349cb3"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9150), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9150), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("1332dfd5-862b-4c10-ac1a-57265f249e61"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9470), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9470), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("16b258d6-3143-461f-bdae-198997f317a4"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9520), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("1781d32d-202b-43b7-94fa-bd70fe06deb7"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("18ae610a-faff-46d4-a52a-14d5bb84f68f"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9100), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("1bf3be2e-018d-4c8d-9727-0383cf5f9ba3"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9590), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9590), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("1d9bb92d-190c-4bb1-aa83-c22259550faa"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9310), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9310), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("2228f23e-b4b0-4ebe-92b8-49fa8cc9012f"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9860), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("236995e9-041f-488e-8d47-0d39b3feddce"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9710), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9710), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("2878817f-2780-4486-a99e-0f5f7203eff9"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9240), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9240), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("28a0bd20-606b-418a-bbf6-2bf024b3cf4b"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(120), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("36c6051b-86e1-4b42-a77d-1e1647703876"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9820), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9820), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("37728dd0-484b-48af-a780-ded0803a12b5"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9320), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("3bcdfe7d-feff-4a59-9c4e-9fab271805f1"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9210), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9210), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("3cef4b7b-997c-49b0-9567-2515192c5ef3"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9290), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9290), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("41eb8ada-7e85-4e7e-94dd-d6178bf5758f"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(50), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(50), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("42d63770-57cb-48d3-a5aa-95a79f8c5c52"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9120), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("479d6601-1568-4d1c-abd6-e1bf55797244"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9400), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("4e85db5e-d587-4a85-bd83-c01922afba75"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9450), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("4f30cda2-a1f1-4197-8b6f-142597cf20d3"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9200), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("59cb92be-a9c5-4204-b295-654a6a38e8c2"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9840), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("5a137e42-9460-40a4-b1a6-1ae244ea043e"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9540), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9540), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("5ab5ce5e-9c93-40a7-a617-0773a0834fda"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9530), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9530), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("5b9289a7-50b2-4f63-b382-a2377bcbc190"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9040), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("5d8014d9-35ac-448a-8ef2-2046cbcde048"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9380), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("63865af3-71d3-4f95-9a37-0f9a6909a572"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("6eec1ab4-6528-4d46-b3ea-c69193a5c0b1"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9870), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9870), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("7129840c-c91a-4e10-bf2a-4134680daf8d"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9180), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9180), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("73522ea3-70d4-412e-8464-5847496dbe65"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(130), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(130), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("74f57887-b939-4647-93f0-90389e2c64c5"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9110), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9110), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("76631c76-d968-41cb-9a3f-8f0589a070b8"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9810), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9810), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("7be2c45f-8ac0-4d51-9cb1-a61cec96fe4d"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9570), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("804787b2-1fad-4c73-9939-199c04fa4f25"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9440), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("81676837-0fb8-4b75-b8f0-e078139cc97e"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9300), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("83e844b6-fce3-4776-8f3b-a475c3ef381c"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9050), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9050), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("84a6e5fd-6fb8-4c8b-b55a-ad0faa1151b0"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("86aedeea-e1d8-44b4-961d-5995b40783e5"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9800), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("8d6d2102-d411-4d0f-bc9b-3f47cacf7213"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("8f82bc2c-862e-4efe-b719-234f10dd382f"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9510), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9510), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("94610144-5e66-49e0-a889-a3c86696f950"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9940), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("96b1882c-a371-47aa-8168-c5209c9d08ca"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9370), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("9877060a-8dd1-45a2-bc0c-be9bd005b299"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9880), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9880), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("9ec1e280-0c86-4040-b7ce-06aa9f564f78"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("a23253b2-861e-4291-b4f5-206ffe83bb84"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("a2690be8-2661-4750-8736-78cd4983283a"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("a5a5995b-92ee-4484-96a4-4dceef5c7181"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9770), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9770), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("a627746b-02a4-4315-ac95-be66aa6cf5ca"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9930), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("a77f4f23-0eaf-4ad8-b200-77484d27dad5"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(60), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(60), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("ac4a59d2-569f-40af-b0ea-b157e6e4aaca"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9170), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9170), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("ae4995a7-000b-4e16-b4ff-4e11075d848d"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(90), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(90), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("b92c26a1-83ee-46fe-9367-10c725162304"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(170), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(170), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("bbcd0fa9-731a-4b60-8d52-87d7ec982adf"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(100), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("c0141547-b022-4956-b51a-4fff05c1903f"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(20), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(20), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("c608ba9d-e6f8-4421-b636-d5ec71f05b91"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9640), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9650), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("c7db5ca8-39b8-487b-9b58-ed27f54e5a24"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9730), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("c97334ea-34a3-47ee-9b17-7a0f05cfe7fa"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(10), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(10), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("cc5c1353-1913-4e5e-bca3-eddfe1b5ebb0"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9980), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("d0c54da0-2052-4da0-88be-5b7ebbce8105"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9990), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("dadbd2ad-3892-4846-a5ff-0493a0d130e5"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9270), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9270), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("dd5de8c6-3648-4652-8a88-c3300e75e05a"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9250), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9250), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("ea436404-2b0a-4ab1-a6ff-cb90161836a5"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9760), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9760), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("eb221227-f061-46af-b784-4fdbceb02172"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9490), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("ec6e43fe-567e-40cb-b2c1-9db66c900cbe"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9600), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9600), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("edcbbe31-6ac0-4015-8500-d8ecb051fdd2"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9620), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("f08dfc3c-b486-43e1-85f4-ca8d1732dd8c"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(30), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(30), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("f1abb713-8036-4a88-b06f-4533908d8fb7"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(150), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("f1b76b95-4d29-4734-99c0-96a0759b75f0"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9350), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("f3e535cb-8e6f-4c22-b095-0d5530bc6e24"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("f4134fda-7ce5-439a-ad2f-9297705c2e7d"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9230), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("f8f219dd-1b9c-49db-b1f4-198c85799dbb"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9340), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("fba75879-7389-479e-aa71-af5103724bbe"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9420), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9420), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("013aa65b-f081-49d9-8d04-243e38f9ff38"), false, 30, new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9660), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9660), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" },
                    { new Guid("cdfb07d0-d39d-4a00-9e38-986cde094bae"), false, 30, new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9020), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9020), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9610), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(8920), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(8920) });

            migrationBuilder.UpdateData(
                table: "ZeebeFlow",
                keyColumn: "Name",
                keyValue: "zb-user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(8860), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.CreateIndex(
                name: "IX_Instances_EntityName_EntityId_WorkflowName_StateName",
                table: "Instances",
                columns: new[] { "EntityName", "EntityId", "WorkflowName", "StateName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Instances_EntityName_EntityId_WorkflowName_StateName",
                table: "Instances");

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("00782349-5c58-47bb-a994-3189c13181d1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("02e41225-20f7-4f0a-affc-b836a946451b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("04e1e17d-2bb4-47f6-adae-5f262c18b44d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("09641a64-2a8d-41b9-9fe4-e46138686aed"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0b9934b5-c3d5-4478-a571-2e9c254bcc61"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0e80fbf0-62d2-4a61-a67f-3edc1c349cb3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1332dfd5-862b-4c10-ac1a-57265f249e61"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("16b258d6-3143-461f-bdae-198997f317a4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1781d32d-202b-43b7-94fa-bd70fe06deb7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("18ae610a-faff-46d4-a52a-14d5bb84f68f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1bf3be2e-018d-4c8d-9727-0383cf5f9ba3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1d9bb92d-190c-4bb1-aa83-c22259550faa"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2228f23e-b4b0-4ebe-92b8-49fa8cc9012f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("236995e9-041f-488e-8d47-0d39b3feddce"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2878817f-2780-4486-a99e-0f5f7203eff9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("28a0bd20-606b-418a-bbf6-2bf024b3cf4b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("36c6051b-86e1-4b42-a77d-1e1647703876"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("37728dd0-484b-48af-a780-ded0803a12b5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3bcdfe7d-feff-4a59-9c4e-9fab271805f1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3cef4b7b-997c-49b0-9567-2515192c5ef3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("41eb8ada-7e85-4e7e-94dd-d6178bf5758f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("42d63770-57cb-48d3-a5aa-95a79f8c5c52"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("479d6601-1568-4d1c-abd6-e1bf55797244"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4e85db5e-d587-4a85-bd83-c01922afba75"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4f30cda2-a1f1-4197-8b6f-142597cf20d3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("59cb92be-a9c5-4204-b295-654a6a38e8c2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5a137e42-9460-40a4-b1a6-1ae244ea043e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5ab5ce5e-9c93-40a7-a617-0773a0834fda"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5b9289a7-50b2-4f63-b382-a2377bcbc190"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5d8014d9-35ac-448a-8ef2-2046cbcde048"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("63865af3-71d3-4f95-9a37-0f9a6909a572"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6eec1ab4-6528-4d46-b3ea-c69193a5c0b1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7129840c-c91a-4e10-bf2a-4134680daf8d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("73522ea3-70d4-412e-8464-5847496dbe65"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("74f57887-b939-4647-93f0-90389e2c64c5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("76631c76-d968-41cb-9a3f-8f0589a070b8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7be2c45f-8ac0-4d51-9cb1-a61cec96fe4d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("804787b2-1fad-4c73-9939-199c04fa4f25"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("81676837-0fb8-4b75-b8f0-e078139cc97e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("83e844b6-fce3-4776-8f3b-a475c3ef381c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("84a6e5fd-6fb8-4c8b-b55a-ad0faa1151b0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("86aedeea-e1d8-44b4-961d-5995b40783e5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8d6d2102-d411-4d0f-bc9b-3f47cacf7213"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8f82bc2c-862e-4efe-b719-234f10dd382f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("94610144-5e66-49e0-a889-a3c86696f950"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("96b1882c-a371-47aa-8168-c5209c9d08ca"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9877060a-8dd1-45a2-bc0c-be9bd005b299"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9ec1e280-0c86-4040-b7ce-06aa9f564f78"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a23253b2-861e-4291-b4f5-206ffe83bb84"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a2690be8-2661-4750-8736-78cd4983283a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a5a5995b-92ee-4484-96a4-4dceef5c7181"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a627746b-02a4-4315-ac95-be66aa6cf5ca"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a77f4f23-0eaf-4ad8-b200-77484d27dad5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ac4a59d2-569f-40af-b0ea-b157e6e4aaca"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ae4995a7-000b-4e16-b4ff-4e11075d848d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b92c26a1-83ee-46fe-9367-10c725162304"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bbcd0fa9-731a-4b60-8d52-87d7ec982adf"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c0141547-b022-4956-b51a-4fff05c1903f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c608ba9d-e6f8-4421-b636-d5ec71f05b91"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c7db5ca8-39b8-487b-9b58-ed27f54e5a24"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c97334ea-34a3-47ee-9b17-7a0f05cfe7fa"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cc5c1353-1913-4e5e-bca3-eddfe1b5ebb0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d0c54da0-2052-4da0-88be-5b7ebbce8105"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("dadbd2ad-3892-4846-a5ff-0493a0d130e5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("dd5de8c6-3648-4652-8a88-c3300e75e05a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ea436404-2b0a-4ab1-a6ff-cb90161836a5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("eb221227-f061-46af-b784-4fdbceb02172"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ec6e43fe-567e-40cb-b2c1-9db66c900cbe"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("edcbbe31-6ac0-4015-8500-d8ecb051fdd2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f08dfc3c-b486-43e1-85f4-ca8d1732dd8c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f1abb713-8036-4a88-b06f-4533908d8fb7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f1b76b95-4d29-4734-99c0-96a0759b75f0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f3e535cb-8e6f-4c22-b095-0d5530bc6e24"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f4134fda-7ce5-439a-ad2f-9297705c2e7d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f8f219dd-1b9c-49db-b1f4-198c85799dbb"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fba75879-7389-479e-aa71-af5103724bbe"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("013aa65b-f081-49d9-8d04-243e38f9ff38"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("cdfb07d0-d39d-4a00-9e38-986cde094bae"));

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-active",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8950), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8950) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-deactivated",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9080), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9080) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-card-password-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8340), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8340) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-fail",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8530), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8530) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-security-question-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8400), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-set",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8470), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8260), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8260) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8880), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8880) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-suspended",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9000), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9000) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fd",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9360), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fs",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9310), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-deactive",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9250), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9250) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9130), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9130) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-acp",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8710), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8710) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-asq",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8780), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8780) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-card",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8590), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8590) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-security-question",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8660), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8660) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-suspend",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9190), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9190) });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("0847d6fd-60c6-4cbf-be50-f4c6695e8673"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8710), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8710), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0de788c1-22a7-4cf3-801c-ba349bfba6dd"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8280), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("107af028-142f-494d-859f-44836476a093"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9190), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9190), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("11d8bd04-8848-4bdf-8c1a-26969be69e2f"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8770), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1424635f-9a2c-4b36-9aa3-b837275ca9ad"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8930), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("17960b6f-d2b7-4d3d-a124-acaa32bdc1a5"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8640), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8640), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1cf4f0e4-ee43-437e-bb79-3aa0b9a965d9"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8590), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8590), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("20a9dbd8-ae57-4d15-9390-9489187b898e"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8730), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("22456683-5534-4c96-a48b-1b717cb485ba"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8650), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8650), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("23973586-e003-4f7c-9a52-2ac6c29fe9a0"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("24bba205-e38d-455e-82bb-148d69611f37"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2a3f34ed-c434-4300-b445-e946db139c78"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2aabf070-013e-43f9-b1fa-549c65747413"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2b8a0b28-eccc-43fc-b5c1-a3d3d1a897be"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9070), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9070), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2beb7a3f-4551-4154-82ac-90b07e666db3"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8420), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8420), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2cb10675-9f61-4577-be9c-bf8159bb4bda"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8810), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("370f499c-583b-47a4-b5cc-6507bcd14708"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9390), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9390), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("374c27c9-aff3-4e9a-b00f-8119c67afe7a"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9100), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("39da7e23-5400-4c67-8b02-eae56e4aeaa3"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8910), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8910), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3b671d47-40a4-4df1-a9be-e275f5e31ae8"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("48901678-749d-445e-916c-69532bfea39b"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("49f183da-9c0e-4efe-a620-5e9b8da2072c"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8570), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("4ff7c01d-c5d2-497b-ae60-5e8b7cbf9fcb"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8500), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("5234c4e6-1090-4bd6-b6f7-6926f4ea8ed7"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8310), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8310), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("5d818571-b12a-4e8c-b03d-74a7655de12c"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9160), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("5e500871-2531-4cdb-837b-f8b67b717c1d"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9400), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("627cb2f9-704f-4b74-9552-d3e055003d1d"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9280), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("62fa38b7-1f2c-4f35-bd49-f28353748643"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("65cf174d-92d4-462f-b792-74769d24c241"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("68acb5b6-b073-4678-8721-de5a958f5cce"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9260), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6e4c27ee-dc0d-4095-a6bf-c13501d6010a"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("70c069a9-3d3e-43ff-aaee-2a833b5c937f"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8860), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("71597b2b-5df1-4e26-8cd7-d7734540f343"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9130), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9130), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("72946d57-e3ca-4c9d-bfad-671dddd1c1bd"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9020), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("79a3229e-392c-4d1d-8295-7319b6ff132a"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("832a6611-ff01-44a9-b367-5ccb4f6f2c2a"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9340), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("877cea51-e99a-40a5-9dd9-b3ae43c5ed9e"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8350), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8a39e8d0-c636-4601-b25e-8bf664ed8077"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8b0a3ff8-b1a5-463c-815f-7b7c51939db7"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8960), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8960), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("907756a4-8af0-419b-9144-763a78a12a0a"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8620), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("918d37b5-f88e-4c52-adb7-eecca3f7ce93"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8360), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8360), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("922b1c39-3168-4072-ab5a-864fc577fb8f"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("99b2977b-4740-45e1-bff7-32d37b7d239e"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8800), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("99fbbd28-178d-4744-8d0e-bef3a818c015"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9410), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a1f85020-3ba0-47c6-9bd1-86bf253c6d72"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8260), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("acaac065-46bd-48c6-87e2-03e6baebbf9a"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8830), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8830), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ad5aa5e5-9793-4043-8fab-0bd742bfc1e9"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9000), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9000), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b62bf544-219b-4938-b73c-a158a633e350"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9150), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b9228dbc-9fe2-4d20-b5e0-da476af5b158"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bb8987a5-8d2a-4ea0-81d2-e6f85e9c7f55"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8490), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bc91c621-6a14-4653-b948-52c2849662d1"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8510), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8510), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bde556b2-157c-4f22-8b5a-8a1df9f049d2"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9220), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9220), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c747abb5-5f3a-46f8-9632-1739742a5694"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8550), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("cccf0bc8-8bf0-4c46-83b2-3033c88bd870"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9240), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9240), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("cef35454-e0f7-4ccf-9a5d-a1bb31d9f0c2"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8760), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d5081144-e89b-4af4-8a38-b8287ae10a64"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8520), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d6e8be6c-ba6f-4437-a089-d8eb7b4550f2"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8980), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d8d256c4-31b8-4b58-9735-0b96ef349fde"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d95c0ffe-1af3-42f4-9eee-93909199dc71"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8290), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8290), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d9731e1b-d4ca-408b-9524-905f2c3e7c96"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9090), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9090), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("db566c7b-35b7-4df9-b8ac-2891e862fb72"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8450), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("dbdee2b0-ab46-4047-8f41-d936a397eebb"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9170), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9170), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("dd5d7ae0-44f3-4056-8529-4e2ab770a230"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("de33573e-dfd6-44c3-8735-1ea12630d148"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9360), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9360), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e2f90e8a-6c56-4fb8-bb94-78b702b62bea"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8940), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e3476fe3-987e-4629-88bc-70f4e0916c3d"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9040), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e3b7af78-3943-444d-aafd-479a739f8751"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9110), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9120), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e6fb0146-6b9d-4002-8231-0ba1b42dd474"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8390), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8390), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("eb782f91-4dfd-459c-93c0-937ca4435551"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9060), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9060), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("eda9850a-786d-4e1a-9fd9-be0347a0be13"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8240), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8240), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("eff197e0-15a9-4c3c-b55c-844b18d997b2"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8430), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f00028a0-abb4-4d8c-a2af-3a0f24759c56"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8700), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8700), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f96f356f-03c8-43ad-9a4c-d40f12d54023"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("fe84d92c-feab-41f9-9413-1c341a239135"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9230), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("fe861fc8-6300-4276-815c-94b326c4d9d0"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9300), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("fff4d0df-8bb5-4a94-8ff1-b75600419f2f"), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9290), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(9290), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("7f015114-0625-434b-920c-8f8455436149"), false, 30, new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8220), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8220), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" },
                    { new Guid("b350604a-c107-434b-b5ec-0b6efe1cdf5c"), false, 30, new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8880), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8880), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8840), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8170), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8170) });

            migrationBuilder.UpdateData(
                table: "ZeebeFlow",
                keyColumn: "Name",
                keyValue: "zb-user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8110), new DateTime(2023, 2, 16, 9, 45, 32, 529, DateTimeKind.Utc).AddTicks(8120) });

            migrationBuilder.CreateIndex(
                name: "IX_Instances_EntityName_EntityId_WorkflowName",
                table: "Instances",
                columns: new[] { "EntityName", "EntityId", "WorkflowName" });
        }
    }
}
