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
                name: "FK_Instances_WorkflowEntities_WorkflowEntityId",
                table: "Instances");

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("05fafe6f-042b-431f-ada9-c3de984cb546"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("064e1512-59bd-4546-842f-375f23851c8c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("07802706-fb12-44ee-99e3-314523d55197"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("07869dce-8f18-4d73-81b2-9791ff56594e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("07cef274-2851-4ecd-8a02-a8c2247e62da"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0c68f25a-2156-44ab-887c-54a094061d4b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0d256ff8-7d26-4c40-ac18-76cdc893632b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("16d28b8a-9f6f-49e1-b061-a53f4b7afc0c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("17547f9b-a0bf-4469-9b8a-3e8bc8f31030"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("181f7d3b-1425-4a18-aac9-6bfe3ff7841d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1d5f458e-1121-4d35-8edf-7c54b5827b36"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1e44d476-c9a6-4340-968e-9352e2ba098e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("20fa47e7-eaac-4ec0-b192-a41ffc75aa3d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("21da608c-bb96-4594-817d-1342a409bc69"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("25c675a6-a1e9-4c1d-9736-b4bd7090414a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("265aa140-34b9-4c01-8bff-b8de22c528ba"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("27504536-3721-4068-a086-aa279f291b91"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2785abc4-5ab7-4f67-8b2b-9efd0efe4152"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2d801842-c550-4acc-97f9-ffffe6e0a3b9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2e1afc4d-9ff4-49ec-b524-44897787aecf"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2f6e8514-a4d1-4fa4-adbe-ada70c3b4120"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3aad3c9d-f1c5-4f6c-8307-b9557a1191f2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3c451709-0b1e-4811-b82f-569a80648ffb"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("45721c42-9d52-45e2-8fd7-55f1f79d6e7c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("463cd097-434f-46ae-a712-8efc997b6e32"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("560bb406-2f93-41ec-b2b0-859af905c282"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5ae9b8d4-2da4-423b-81ce-afc7ee9ef506"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5fa3c008-003b-431c-9322-90924107a420"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6052a303-ec38-481d-a3f2-e2394169d9c3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("60bf2ec6-7d24-428f-9556-2af52a07a32e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("67f4235b-c2e1-44e4-9e9f-b6e57b485016"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6ec84524-dacb-4d5b-aaaa-4ed2dc7be5e1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7765aef2-c584-4deb-bf7a-84cb679763a0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7a9d7f14-e270-4b4f-a269-6752edeb20f8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8256dbff-b02e-4825-a08b-d12939117da2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("829f0d58-3b45-4f0e-b704-681f8b4dd052"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("83c74c82-db72-4900-ad44-c7afbc9f06e4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("850635a1-7ae9-478c-9954-c9cdefa51d8a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("870dbbb2-803f-4837-bc66-6f4b6378bbf6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8fb47da9-6116-48d2-b4ed-17f59abc42e6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("940512a0-cc91-4f20-9e16-cc6498e6f8ab"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("965b3b35-e347-4be2-bab9-67e84f33b73c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9884f853-bea7-4732-bc40-f45619ae7206"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9af7b946-3999-4ff5-8a4c-72658aa01688"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9b2b0aa1-f034-4d23-ab5c-9817c3d0251d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9e6d7a79-4f4d-4ceb-b768-6cfb8712d49b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a0b97b11-46e4-4778-b67f-46b95d552faa"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a2006ed2-e221-4773-9a7f-324993317cd8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a3cc2723-40a3-4800-80ed-cdfe68f60d66"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a80cef57-de5b-4106-b883-75ff5016b15a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a8363ebd-f84d-4d66-ac4c-161cfbb3019d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("add1d72d-7677-41bd-9555-67d08d815568"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("adfdfaeb-79c4-4e3e-8717-6748e198cef0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b48d4c6d-ea99-4c48-ba03-7ec3e30aeb8b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b7b3b7e7-de17-42f7-ad9b-3bd58624f956"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b8433316-1d4a-427d-8147-9ef481f6f07e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b8c6bc89-f2b9-40a9-88b3-d6d40923e520"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b9c286b6-3403-45b3-9899-2e1f575a4511"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bae86531-8ea2-429f-9cc3-598e13b50db9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bc32ce4e-5f68-4b3a-a811-4cf03490f8e8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bdb2889d-bdde-45de-adc6-d22ff7d735ed"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bf6f0cb7-8cbb-4498-a959-2c57c031a78c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c6e8cae5-473d-4a0f-be8d-3e9d2cbc5d98"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ced2284a-265d-42b6-b0f2-22cbdc630570"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("dce4ce18-fa93-48ca-acd2-721edcf6d5c2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e428e7f4-ab74-423a-94e8-319cf4d9924c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e73cf177-228b-4498-8d32-107a2a880c40"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e7aad396-4bf5-4271-8236-820f0ac73d09"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e819a0ab-1566-471e-81a0-23df2dbbc005"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e8d6af44-0d6f-451d-94b7-551699937913"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e9948bfe-1b91-4457-9186-79ce5fa2d10f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("efa6106c-eaae-469e-a7fb-9f542a5d6c89"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f1436177-7158-4f98-975e-89c453126e89"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f2246b8e-8667-4df2-b58b-762261120d9f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f6120ab2-2822-4bfc-b1ea-4359a34d7c70"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f6f661a4-3801-4aa4-bca7-28de027b1f9b"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("56288f7d-9b82-462a-b153-76b8b3b164db"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("db7e41e9-8573-44db-a8a2-515db19256a2"));

            migrationBuilder.RenameColumn(
                name: "WorkflowEntityId",
                table: "Instances",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Instances_WorkflowEntityId",
                table: "Instances",
                newName: "IX_Instances_EntityId");

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-active",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7130), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-deactivated",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7250), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-card-password-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6510), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-fail",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6700), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-security-question-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6570), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6570) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-set",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6630), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6440), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7070), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-suspended",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7190), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7190) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-activate-fd",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7570), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7570) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-activate-fs",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7490), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7490) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-deactive",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7430), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7310), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-acp",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6880), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6880) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-asq",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6960), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-card",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6760), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6760) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-security-question",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6820), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6820) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-suspend",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7370), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7370) });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("004a8b52-6486-4941-b5e1-059d91838d05"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6650), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6650), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("00b4dc17-e648-4734-b1ff-9e3add3a9281"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7140), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7140), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("0789a372-c8c1-40af-9a4a-cec7e0d9ee8e"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7120), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("13f9747c-4bca-4da6-84ba-eba481e89335"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7170), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7170), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("1929dc34-cd69-4f95-8772-da96ae491942"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("1c63ea3a-2e81-4ec5-a1c3-d9528f5fe64f"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6500), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("1eeefaa7-09c0-4d5d-ab9c-84053e8cea52"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7220), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7220), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("25fbc374-5636-4951-a501-547507fa74dd"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6910), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6910), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("2636e23b-5cee-4b5c-8128-8bf9308bc2ac"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("2af5891b-4177-4958-a5e6-e0e54fcbdeb4"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6860), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("3045122d-36d6-4b8d-a93e-82ade0ec84f7"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7080), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7080), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("3060686e-f485-4cf7-9e83-edbb04b62e87"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6580), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6580), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("3450fc57-3fea-4f61-9b71-aa8ff532f9fc"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7000), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7000), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("36599068-46ad-431b-a901-977cfd6af745"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7240), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7240), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("365c044c-f599-4ab9-be9b-6187115d1b00"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7400), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("37c56e07-e017-4ce2-8d91-5695bb4969de"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7580), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7580), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("3eaff752-1521-4846-bc66-768b63758f3f"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7160), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("3efbd8fe-1019-42f5-b490-996950130b68"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7390), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7390), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("40751f3e-f847-4490-b6a5-171af22dd742"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6680), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("444160ad-f89f-493d-93f1-f8e906453daf"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7480), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("452f7668-72ca-4e9e-af3f-793936e5b7de"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7520), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("4caef475-bf3a-4d48-b696-3071611ad049"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7550), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("53d5ad9a-a5c9-4aea-a7b3-eb041a272495"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7420), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7420), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("5abac451-f63b-486c-a573-09fdfe2924d7"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7410), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("5e832614-451b-471d-a54e-30c717ad7b69"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6920), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("5fa28a44-f2c5-47f4-a349-5871bfa8ddab"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6470), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6470), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("6087750f-56c9-4261-99c2-d4877252a4e9"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7460), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7460), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("61827160-3429-4ea7-b64f-730787faabef"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6520), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("6189cd7f-dfaa-4597-bfb4-7656b96b97a4"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6430), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("65d4350e-7f8c-4268-9fd9-4fb3c4180cb1"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6540), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6540), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("6893a3db-ef2d-44d2-8677-a6efbd0b6adf"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6880), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("73720fc8-2d17-435b-b368-af813c3fb34b"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6770), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("74d99087-47d9-409a-becb-cb9fe7865d16"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6620), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("7819b80b-da74-4ff0-b7bb-8c76a2e78816"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6450), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("78304c5e-7253-418b-ab44-fa17282e18af"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7180), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7180), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("7a93c3a6-9286-4b97-ac4d-f189a8476f9f"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7280), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("86e0baaf-0747-4f97-8720-f1e6a2738599"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7300), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7300), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("882268d6-2bfa-4f6e-ab2c-3c4eead544f1"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7110), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7110), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("8d907a74-6e70-421f-bd27-445dc2925204"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7260), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("8e78193d-3910-4332-a9b4-719ed632ec91"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7230), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7230), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("9284d5dc-5d1d-4166-8f25-afa03b075d11"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6820), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("9379f2c3-3d70-4183-8957-1bc86e1e1c86"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7470), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7470), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("983cd737-fdd2-4402-ada1-bb06f2853afa"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6690), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("997ab0a8-309f-4f6c-8b68-2cd03c5dfa83"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6740), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("9dcd383a-5002-47ad-b0f7-5e2e629be72c"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6840), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("a2ff4b6c-44b7-4cb9-9a51-535a4fb1aea1"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6990), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("a96bbe99-7f78-4b50-a9a7-eae693bf6d9b"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7340), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("b076ac47-19b9-4f28-94db-f380748d641e"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7040), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("b20774dc-32ca-4272-9f0c-a4e718d423cb"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6950), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("b33812fa-c65d-443a-ae6c-a3ab3f340c06"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7100), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("b4350b4f-f3f8-494e-97e2-69bce0a70b6f"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7530), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7530), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("b5ba6749-bddc-442d-b119-f1aceda48ac5"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7050), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7050), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("b6e21d7a-11aa-4036-bd73-a98411dbc96a"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7560), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("b8dd6dec-1e21-4d90-bd8b-3a1c344899d4"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6600), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6600), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("bfb3ac01-0526-432d-bbdc-4f598313e18e"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("c03c427d-4021-4f84-a5cc-229a87dec599"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6480), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6480), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("c1921407-aa93-4345-85ce-bde2d9772bb6"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("c1c7f73b-a5dc-4186-b476-d8ee27843e1d"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6560), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("c5697c4b-c8a3-4aa1-8b61-01e7ecfd6879"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6660), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6660), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("c9813488-eb18-48e8-811f-0daabde6a0b1"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7440), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("cab54928-6efd-4425-b03c-61c3e6f55066"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6610), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("cab616dc-b2e3-4b4f-a4c4-616d3f0997fe"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6750), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6750), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("cce36711-2994-4c90-8921-495f4a2c244d"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6550), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6550), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("d26fc277-c8b8-4f15-a44a-ef65f00aa32f"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7610), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("d7b2fad9-582d-4302-984a-2651f10aa3ca"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6720), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6720), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("dcc00911-a878-43b3-a5f5-217bb74b4f65"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7370), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("df025bc9-d152-49ec-96d2-5efe3594c3a8"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("e7659e6f-eed7-41d0-be4f-567c38e1f974"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6710), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6710), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("e7eb4b60-8c69-4c98-8ab4-87386eff07c4"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("ea10842d-c8fe-4df5-b39e-1618fb4e754a"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6800), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("eaf2cb58-25f6-4ecb-afa0-7971110b0c04"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7290), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7290), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("eb5c4d98-5dd0-433f-9b77-51fd62f71c15"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7590), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7590), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("f34362a5-0c8b-467e-8dac-cd37da1303ad"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("f541fecc-6f6f-499f-9ac2-06471d285ecd"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7620), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7620), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("f908fb65-0cfb-4550-89ac-1957a0feaa95"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7010), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7010), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("f9d7d52c-9814-498e-8763-7331b99196ad"), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7350), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsExclusive", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("c9525b86-f928-48cf-ae1a-08d26020ce58"), 30, new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7060), new Guid("00000000-0000-0000-0000-000000000000"), null, false, true, new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7060), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" },
                    { new Guid("f2589be3-9078-4933-bd19-83b0941a2790"), 30, new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6390), new Guid("00000000-0000-0000-0000-000000000000"), null, false, false, new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6390), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7020), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6340), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "ZeebeFlow",
                keyColumn: "Name",
                keyValue: "zb-user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6310), new DateTime(2023, 2, 14, 14, 39, 52, 187, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_WorkflowEntities_EntityId",
                table: "Instances",
                column: "EntityId",
                principalTable: "WorkflowEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instances_WorkflowEntities_EntityId",
                table: "Instances");

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("004a8b52-6486-4941-b5e1-059d91838d05"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("00b4dc17-e648-4734-b1ff-9e3add3a9281"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0789a372-c8c1-40af-9a4a-cec7e0d9ee8e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("13f9747c-4bca-4da6-84ba-eba481e89335"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1929dc34-cd69-4f95-8772-da96ae491942"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1c63ea3a-2e81-4ec5-a1c3-d9528f5fe64f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1eeefaa7-09c0-4d5d-ab9c-84053e8cea52"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("25fbc374-5636-4951-a501-547507fa74dd"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2636e23b-5cee-4b5c-8128-8bf9308bc2ac"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2af5891b-4177-4958-a5e6-e0e54fcbdeb4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3045122d-36d6-4b8d-a93e-82ade0ec84f7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3060686e-f485-4cf7-9e83-edbb04b62e87"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3450fc57-3fea-4f61-9b71-aa8ff532f9fc"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("36599068-46ad-431b-a901-977cfd6af745"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("365c044c-f599-4ab9-be9b-6187115d1b00"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("37c56e07-e017-4ce2-8d91-5695bb4969de"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3eaff752-1521-4846-bc66-768b63758f3f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3efbd8fe-1019-42f5-b490-996950130b68"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("40751f3e-f847-4490-b6a5-171af22dd742"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("444160ad-f89f-493d-93f1-f8e906453daf"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("452f7668-72ca-4e9e-af3f-793936e5b7de"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4caef475-bf3a-4d48-b696-3071611ad049"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("53d5ad9a-a5c9-4aea-a7b3-eb041a272495"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5abac451-f63b-486c-a573-09fdfe2924d7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5e832614-451b-471d-a54e-30c717ad7b69"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5fa28a44-f2c5-47f4-a349-5871bfa8ddab"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6087750f-56c9-4261-99c2-d4877252a4e9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("61827160-3429-4ea7-b64f-730787faabef"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6189cd7f-dfaa-4597-bfb4-7656b96b97a4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("65d4350e-7f8c-4268-9fd9-4fb3c4180cb1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6893a3db-ef2d-44d2-8677-a6efbd0b6adf"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("73720fc8-2d17-435b-b368-af813c3fb34b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("74d99087-47d9-409a-becb-cb9fe7865d16"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7819b80b-da74-4ff0-b7bb-8c76a2e78816"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("78304c5e-7253-418b-ab44-fa17282e18af"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7a93c3a6-9286-4b97-ac4d-f189a8476f9f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("86e0baaf-0747-4f97-8720-f1e6a2738599"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("882268d6-2bfa-4f6e-ab2c-3c4eead544f1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8d907a74-6e70-421f-bd27-445dc2925204"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8e78193d-3910-4332-a9b4-719ed632ec91"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9284d5dc-5d1d-4166-8f25-afa03b075d11"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9379f2c3-3d70-4183-8957-1bc86e1e1c86"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("983cd737-fdd2-4402-ada1-bb06f2853afa"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("997ab0a8-309f-4f6c-8b68-2cd03c5dfa83"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9dcd383a-5002-47ad-b0f7-5e2e629be72c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a2ff4b6c-44b7-4cb9-9a51-535a4fb1aea1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a96bbe99-7f78-4b50-a9a7-eae693bf6d9b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b076ac47-19b9-4f28-94db-f380748d641e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b20774dc-32ca-4272-9f0c-a4e718d423cb"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b33812fa-c65d-443a-ae6c-a3ab3f340c06"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b4350b4f-f3f8-494e-97e2-69bce0a70b6f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b5ba6749-bddc-442d-b119-f1aceda48ac5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b6e21d7a-11aa-4036-bd73-a98411dbc96a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b8dd6dec-1e21-4d90-bd8b-3a1c344899d4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bfb3ac01-0526-432d-bbdc-4f598313e18e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c03c427d-4021-4f84-a5cc-229a87dec599"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c1921407-aa93-4345-85ce-bde2d9772bb6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c1c7f73b-a5dc-4186-b476-d8ee27843e1d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c5697c4b-c8a3-4aa1-8b61-01e7ecfd6879"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c9813488-eb18-48e8-811f-0daabde6a0b1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cab54928-6efd-4425-b03c-61c3e6f55066"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cab616dc-b2e3-4b4f-a4c4-616d3f0997fe"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cce36711-2994-4c90-8921-495f4a2c244d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d26fc277-c8b8-4f15-a44a-ef65f00aa32f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d7b2fad9-582d-4302-984a-2651f10aa3ca"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("dcc00911-a878-43b3-a5f5-217bb74b4f65"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("df025bc9-d152-49ec-96d2-5efe3594c3a8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e7659e6f-eed7-41d0-be4f-567c38e1f974"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e7eb4b60-8c69-4c98-8ab4-87386eff07c4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ea10842d-c8fe-4df5-b39e-1618fb4e754a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("eaf2cb58-25f6-4ecb-afa0-7971110b0c04"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("eb5c4d98-5dd0-433f-9b77-51fd62f71c15"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f34362a5-0c8b-467e-8dac-cd37da1303ad"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f541fecc-6f6f-499f-9ac2-06471d285ecd"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f908fb65-0cfb-4550-89ac-1957a0feaa95"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f9d7d52c-9814-498e-8763-7331b99196ad"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("c9525b86-f928-48cf-ae1a-08d26020ce58"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("f2589be3-9078-4933-bd19-83b0941a2790"));

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Instances",
                newName: "WorkflowEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Instances_EntityId",
                table: "Instances",
                newName: "IX_Instances_WorkflowEntityId");

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-active",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5600), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5600) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-deactivated",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5720), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5720) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-card-password-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4970), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4970) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-fail",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5210), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5210) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-security-question-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5090), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5090) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-set",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5150), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5150) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4900), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4900) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5540), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-suspended",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5660), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5660) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-activate-fd",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6000), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6000) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-activate-fs",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5940), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5940) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-deactive",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5890), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5890) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5770), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5770) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-acp",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5390), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5390) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-asq",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5440), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-card",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5260), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5260) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-security-question",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5330), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5330) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-suspend",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5830), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5830) });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("05fafe6f-042b-431f-ada9-c3de984cb546"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4920), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("064e1512-59bd-4546-842f-375f23851c8c"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5480), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5480), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("07802706-fb12-44ee-99e3-314523d55197"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5450), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("07869dce-8f18-4d73-81b2-9791ff56594e"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5660), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5660), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("07cef274-2851-4ecd-8a02-a8c2247e62da"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5520), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5520), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0c68f25a-2156-44ab-887c-54a094061d4b"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5620), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0d256ff8-7d26-4c40-ac18-76cdc893632b"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5350), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("16d28b8a-9f6f-49e1-b061-a53f4b7afc0c"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5980), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("17547f9b-a0bf-4469-9b8a-3e8bc8f31030"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5380), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("181f7d3b-1425-4a18-aac9-6bfe3ff7841d"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5110), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5110), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1d5f458e-1121-4d35-8edf-7c54b5827b36"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5880), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1e44d476-c9a6-4340-968e-9352e2ba098e"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("20fa47e7-eaac-4ec0-b192-a41ffc75aa3d"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4960), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4960), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("21da608c-bb96-4594-817d-1342a409bc69"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("25c675a6-a1e9-4c1d-9736-b4bd7090414a"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("265aa140-34b9-4c01-8bff-b8de22c528ba"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5510), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5510), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("27504536-3721-4068-a086-aa279f291b91"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4990), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2785abc4-5ab7-4f67-8b2b-9efd0efe4152"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5920), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2d801842-c550-4acc-97f9-ffffe6e0a3b9"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5240), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5240), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2e1afc4d-9ff4-49ec-b524-44897787aecf"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5370), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2f6e8514-a4d1-4fa4-adbe-ada70c3b4120"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6030), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6030), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3aad3c9d-f1c5-4f6c-8307-b9557a1191f2"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5650), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5650), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3c451709-0b1e-4811-b82f-569a80648ffb"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4880), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("45721c42-9d52-45e2-8fd7-55f1f79d6e7c"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5590), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5590), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("463cd097-434f-46ae-a712-8efc997b6e32"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5700), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5700), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("560bb406-2f93-41ec-b2b0-859af905c282"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5280), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("5ae9b8d4-2da4-423b-81ce-afc7ee9ef506"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5170), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5170), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("5fa3c008-003b-431c-9322-90924107a420"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5760), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6052a303-ec38-481d-a3f2-e2394169d9c3"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5230), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("60bf2ec6-7d24-428f-9556-2af52a07a32e"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5190), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5190), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("67f4235b-c2e1-44e4-9e9f-b6e57b485016"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6ec84524-dacb-4d5b-aaaa-4ed2dc7be5e1"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6050), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6050), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7765aef2-c584-4deb-bf7a-84cb679763a0"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5160), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7a9d7f14-e270-4b4f-a269-6752edeb20f8"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5990), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8256dbff-b02e-4825-a08b-d12939117da2"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5400), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("829f0d58-3b45-4f0e-b704-681f8b4dd052"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5420), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5420), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("83c74c82-db72-4900-ad44-c7afbc9f06e4"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("850635a1-7ae9-478c-9954-c9cdefa51d8a"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("870dbbb2-803f-4837-bc66-6f4b6378bbf6"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5630), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8fb47da9-6116-48d2-b4ed-17f59abc42e6"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5550), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("940512a0-cc91-4f20-9e16-cc6498e6f8ab"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5260), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("965b3b35-e347-4be2-bab9-67e84f33b73c"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5910), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5910), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9884f853-bea7-4732-bc40-f45619ae7206"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4930), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9af7b946-3999-4ff5-8a4c-72658aa01688"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6010), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6010), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9b2b0aa1-f034-4d23-ab5c-9817c3d0251d"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5120), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9e6d7a79-4f4d-4ceb-b768-6cfb8712d49b"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5000), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5000), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a0b97b11-46e4-4778-b67f-46b95d552faa"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5130), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5130), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a2006ed2-e221-4773-9a7f-324993317cd8"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a3cc2723-40a3-4800-80ed-cdfe68f60d66"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5090), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5090), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a80cef57-de5b-4106-b883-75ff5016b15a"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5800), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a8363ebd-f84d-4d66-ac4c-161cfbb3019d"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5820), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("add1d72d-7677-41bd-9555-67d08d815568"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("adfdfaeb-79c4-4e3e-8717-6748e198cef0"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5840), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b48d4c6d-ea99-4c48-ba03-7ec3e30aeb8b"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5730), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b7b3b7e7-de17-42f7-ad9b-3bd58624f956"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6020), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(6020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b8433316-1d4a-427d-8147-9ef481f6f07e"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5340), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b8c6bc89-f2b9-40a9-88b3-d6d40923e520"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5140), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5140), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b9c286b6-3403-45b3-9899-2e1f575a4511"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5710), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5710), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bae86531-8ea2-429f-9cc3-598e13b50db9"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4940), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bc32ce4e-5f68-4b3a-a811-4cf03490f8e8"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5770), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bdb2889d-bdde-45de-adc6-d22ff7d735ed"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5310), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5310), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bf6f0cb7-8cbb-4498-a959-2c57c031a78c"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5320), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c6e8cae5-473d-4a0f-be8d-3e9d2cbc5d98"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5870), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ced2284a-265d-42b6-b0f2-22cbdc630570"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5300), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("dce4ce18-fa93-48ca-acd2-721edcf6d5c2"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e428e7f4-ab74-423a-94e8-319cf4d9924c"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5810), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e73cf177-228b-4498-8d32-107a2a880c40"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4890), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e7aad396-4bf5-4271-8236-820f0ac73d09"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5580), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5580), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e819a0ab-1566-471e-81a0-23df2dbbc005"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e8d6af44-0d6f-451d-94b7-551699937913"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5460), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5460), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e9948bfe-1b91-4457-9186-79ce5fa2d10f"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5220), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5220), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("efa6106c-eaae-469e-a7fb-9f542a5d6c89"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5490), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f1436177-7158-4f98-975e-89c453126e89"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4980), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f2246b8e-8667-4df2-b58b-762261120d9f"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5940), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f6120ab2-2822-4bfc-b1ea-4359a34d7c70"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f6f661a4-3801-4aa4-bca7-28de027b1f9b"), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5430), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsExclusive", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("56288f7d-9b82-462a-b153-76b8b3b164db"), 30, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5530), new Guid("00000000-0000-0000-0000-000000000000"), null, false, true, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5530), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" },
                    { new Guid("db7e41e9-8573-44db-a8a2-515db19256a2"), 30, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4860), new Guid("00000000-0000-0000-0000-000000000000"), null, false, false, new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4860), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5490), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4810), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4820) });

            migrationBuilder.UpdateData(
                table: "ZeebeFlow",
                keyColumn: "Name",
                keyValue: "zb-user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4790), new DateTime(2023, 2, 14, 14, 35, 20, 583, DateTimeKind.Utc).AddTicks(4790) });

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_WorkflowEntities_WorkflowEntityId",
                table: "Instances",
                column: "WorkflowEntityId",
                principalTable: "WorkflowEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
