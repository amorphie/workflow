using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transition_State_FromStateName",
                table: "Transition");

            migrationBuilder.DropForeignKey(
                name: "FK_Transition_State_ToStateName",
                table: "Transition");

            migrationBuilder.DropForeignKey(
                name: "FK_Transition_ZeebeFlow_FlowName",
                table: "Transition");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Transition_TransitionName_Form",
                table: "Translation");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Transition_TransitionName_Title",
                table: "Translation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transition",
                table: "Transition");

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("00da1624-6ebd-45f6-bfb9-7ee2a95e2e4d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("01f2281a-05a2-4c94-b948-8f6d3019ba49"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("02f6d2b6-d0b2-4d19-a3d3-853df072bf93"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0419bf51-ce16-4f99-9b82-609ca68851db"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("07592c24-104e-43a8-9bcf-eb592dbec743"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1255650d-1b07-41e3-89fa-3ccfe1d89e4c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1378ffc0-b088-40b7-8516-5aed02de90c4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("192d57f8-e86d-42d0-b49a-f0cd07585e33"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1b11caf2-9294-4f39-be8a-32f83b6b15a5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1b9f3c99-d732-4862-9dfb-6b869bd56bc6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1dbc5230-f6e7-4886-acb3-22340c093135"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1dc9b26e-2a73-4c25-a39a-4dfe7dd40226"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("22f44dbe-5b29-40a0-a354-d81a41120bba"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("27952d8a-a55d-46af-af0a-1b5db42efd5c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2c2e49eb-01ac-4052-9ea8-f65e2617f808"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2d5be8b0-be9a-4916-9dcf-6ac6c46ee4e1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2eaf299b-07be-4df3-9c14-1c7beab5a1f5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2fac3444-93b6-445e-877f-ef006034a669"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("36ac4e3d-df8d-493b-a97d-4f12582a2224"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3c9a0028-77bb-4898-a51d-8cdb290ca6cf"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("408c9ec7-6fda-4e5d-b422-4473322b253c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("419ef968-7400-452e-b238-6674328aed6c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("42f453dc-ba56-4a4b-9db6-c2de11f2e18e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("43150a10-51ef-44b0-98d6-fe73e6c744ad"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4731f282-4535-4486-9f63-2947f76d2072"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("50bf3ed3-c131-4cc7-aa52-533cb64bb29e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("59cc9ce4-968a-4dd0-be7a-643dd5196c91"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5e79c8e5-1eb7-417b-acc8-eea06e3b9749"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6271ccc2-8d8d-4ded-8f12-3687d862bf2c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("65d1ebb6-088b-43a2-9a0a-f80a58fe7b1a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("674e5ade-0908-4e87-84d3-9b933d9f4c1a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("67d3fb02-dd27-4748-930d-2f88ea9408e6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6a73cc2f-7001-4027-8ecf-03d58770a7a4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6c1a665d-d8d4-4d66-8b88-74fc5bfefe78"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6f68a4e0-bb77-4494-813d-1915f42a5756"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("70099476-3376-48d0-b939-cbf31b7752cc"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("72a89566-3628-4b15-ab57-533c1bed8c6c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("75a65ecb-677e-4245-a7cb-a000f77b10ee"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("77fd244f-4e9a-4c0e-8608-1cbca8ab9006"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("79fd1377-7509-4c96-8eae-56344d8900b5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7ba5cd1f-1f79-4d50-83ba-f348895ded7b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7eb89482-17d1-4302-abd9-e615ebe2bf75"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("83e3776f-fc1b-4736-8bc2-fa60433b3997"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("84756bac-480d-4bc2-8623-fe8f958cc6ab"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("89255041-3950-4514-9077-b543670dc93b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8b95989f-c6dd-4b80-b56e-17d4b0b652bf"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8edf1615-0b21-43cd-82b8-c286632c2823"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8efa4268-baef-480f-8acf-30962a46286f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("94f034fe-6142-46d6-aa27-ad95aec2fa18"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9a4aea9c-4242-4fae-b702-faa721286b39"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9d1b356a-7837-4048-a3a5-87153aae3534"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a11ec603-710e-4e5c-9ee5-dc6292f59aeb"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a74ff671-c2cb-4f14-a469-33df398c9e63"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a8da1080-93ce-417a-8fbe-c47836636b64"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ac03b584-4ef5-43c9-8d4c-6dfca1ff5c3f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ac349f7d-18e6-457f-ba8f-ad244cf4524b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ae155fcd-f579-4f6e-bf50-161d6a0657ce"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("aee13dc2-5559-4395-8168-83aa4087f9e8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b996f8b8-efdd-4ee4-8187-104f8f45af7e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c16af16f-cde9-4004-8dcc-6389f58107cc"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c512d92e-75fc-4781-9a99-f7f8f4aeaf81"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c73994dc-67ec-4741-8e91-f20ba81bf0db"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c9cc71f9-c7ac-4486-9334-a01b05a3595e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cc6f2966-5354-44fa-9530-c0a1c0519cd0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ce0c8254-1abd-4a5e-acae-9cd51e9e4816"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cfe3c8b9-5bb7-4a13-834a-00f8d3afe24c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d1545fec-fe86-4f4d-94b0-b382a88578f7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d81d2176-0019-4405-9e3a-5bfa9d519edf"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("dcae163a-6656-4b18-bb58-3fd88e22f1f7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("dd3a2d91-a9b2-4c30-b037-8a1db8a2dbdf"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e8d86b9e-9098-468e-bcc3-7afdc1edcce5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ebdd87a0-a71a-450c-9c96-e4cce369cbbd"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f127f8b3-2e88-404f-abd3-7d4aaa17b34b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f6607c76-c55c-4446-b9a5-60094db03244"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fc42d498-023f-4e0d-a45b-78ff219b469d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ff19ae70-d1d5-45da-ae0a-158d29bc64ce"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("1814d8b6-d27e-47c9-aaae-8a5ac054080c"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("7fbf4c86-7838-4ebd-9af1-1fc5d811eb9a"));

            migrationBuilder.RenameTable(
                name: "Transition",
                newName: "Transitions");

            migrationBuilder.RenameIndex(
                name: "IX_Transition_ToStateName",
                table: "Transitions",
                newName: "IX_Transitions_ToStateName");

            migrationBuilder.RenameIndex(
                name: "IX_Transition_FromStateName",
                table: "Transitions",
                newName: "IX_Transitions_FromStateName");

            migrationBuilder.RenameIndex(
                name: "IX_Transition_FlowName",
                table: "Transitions",
                newName: "IX_Transitions_FlowName");

            migrationBuilder.AddColumn<int>(
                name: "BaseStatus",
                table: "Instances",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EntityName",
                table: "Instances",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transitions",
                table: "Transitions",
                column: "Name");

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-active",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8700), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-deactivated",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9000), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9000) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-card-password-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8060), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-fail",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8250), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8250) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-security-question-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8120), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8120) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-set",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8190), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8190) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(7990), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(7990) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8640), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8640) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-suspended",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8770), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8770) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fd",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9360), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fs",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9300), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-deactive",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9230), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9230) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9080), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9080) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-acp",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8450), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-asq",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8520), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8520) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-card",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8330), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8330) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-security-question",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8400), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-suspend",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9170), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9170) });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("000fd990-6142-4760-be14-86095ec38c79"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9160), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("0243b3c7-b88d-43b8-92d1-56387cc53f4e"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8070), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8070), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("03d48e68-a10e-4861-872e-ddda5396c4c1"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8780), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8780), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("05045669-7384-4a28-8215-bb74d2c08899"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9190), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9190), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("06b04ef2-a637-48c8-aae4-043023090b18"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8760), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8760), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("0a2776de-c308-40a3-84b8-f69030de16f2"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8090), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8090), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("0eec5aba-71b2-43f8-9a62-daa449320cf1"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8730), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("113a6f3e-d9dd-437a-a47f-d90e3a8d51f7"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8020), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("14013b51-0b6e-4178-bc5a-0ee4568f6745"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9290), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9290), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("15f12707-c61e-447d-b77f-53a9d1072432"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("16044817-8685-4cde-938a-e081e8b0798d"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8040), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("1a1b9ad8-989f-493e-a64c-cdaf1c402bd4"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9150), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("22623a2d-b472-4699-8669-3d167c422fbb"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8510), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8510), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("2404b520-801e-43de-9e9d-6d2d79f33347"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("2695c82b-4fa2-4b0b-8e76-3a6d7cf2e43d"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8390), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8390), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("269b3bed-38e0-4487-9469-33d56a44063e"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8650), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8650), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("277b0ad9-2d4c-481d-8bef-9199b4906446"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8810), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8810), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("286fd08a-edae-4c22-b288-28e13bca09ab"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9280), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("2885b599-9ad3-43af-8957-88cd2d5ff5b7"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8950), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("29d1975e-1fe1-471e-b4de-4378fac6699f"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8280), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("33a57cec-92c6-4099-8fc0-f7e772fd1a8b"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8210), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("379227ab-fbc7-41d2-ac33-b3ff6e2f089a"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8420), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8420), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("380c72ed-446e-4422-89bd-7a61f38abad1"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(7960), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(7960), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("3bb9a0f8-81e3-4011-bed9-787ec13bd4d1"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("3f6b3212-2eb4-47e8-b9ee-7aa61f0d202e"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8380), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("3f96a1b8-64d2-4f4f-bc66-8e49bd3978d5"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9310), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9310), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("4374d338-9c47-4835-9488-f164284cda22"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8100), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8100), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("439b8e4e-2185-4a82-910e-58151bd4a09c"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8120), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("44a9a284-3c29-4019-880a-9e16546e6b7c"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(7970), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(7970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("45bcf06d-981c-47e9-bd3c-1c5d279e397b"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8720), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8720), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("47076e44-e600-4de2-bb0a-959eefdf4001"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9210), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("4a1b52fa-3762-4cc0-b9d1-1b064635b180"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8230), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8230), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("50af82d9-8f58-4dfb-a557-4da40b579c99"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8260), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("5114c94f-587d-47de-a758-5c5874ba440d"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8740), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("529ddc32-4443-4990-a802-d2a6e8349b31"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8000), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8000), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("551b1bd8-3262-4c1a-b988-b081f33b206b"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9030), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9030), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("5644f015-ce83-4970-8916-39925190a313"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8450), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("5a6c19c1-ea8a-4c01-b28d-de11afeb293c"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8350), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("5c271ddc-c284-4c50-832d-cd22e1e16c69"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("5e9f1568-207f-4c03-9e6b-5fa49f018287"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8050), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8050), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("601478bb-dba0-46aa-8d45-3164cf9cd110"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9340), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("616b8eb9-0652-46c9-a24e-f8a6353e5013"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8140), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8140), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("6a027357-e684-4a2a-9c7d-7f6e7ad41c61"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8610), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("7404b7c8-611a-4dcf-9bd1-e1ea13631a21"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8490), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("7ba08b8e-25b2-42c8-b3c7-ab9741b3ea79"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9400), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("85698a5f-a962-41e7-8893-3773439691f5"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9260), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("856d82d8-2792-4ef9-82fc-129a505789cd"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9040), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("87686e6b-5ab8-4941-8c83-7064bb10e343"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8180), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8180), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("8b3454f5-d03c-45df-8fca-5642e6a90307"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("a5ace54f-21ff-4a4f-a86f-4543c1dc8ee6"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9250), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9250), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("a5ead946-60bc-4714-b5eb-f293ff893aac"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8430), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("a7eac6d8-07bc-4d72-82f2-400fdc6bd6bc"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8290), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8290), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("a91ce451-38f9-463d-b3a2-9f0bb0c61066"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8470), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8470), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("ab1cb8ce-93a8-4ae5-84fd-2a8832431947"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9110), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9110), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("ac879afe-e714-4f3b-b8e0-b31a55a9bdae"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8600), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8600), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("ae6b5781-0e53-4558-b306-adfa5348cc16"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8700), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8700), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("b4424d92-ec90-41f0-9c0c-f78ee9a09ddf"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8170), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8170), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("b458c854-2e17-4e80-b68f-a106777254f0"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8240), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8240), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("b8bf583d-1521-4abb-9eb1-9a5b1bb58726"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8300), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8300), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("bb87ed6b-d6c5-4257-bf75-c2438fbee5c2"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9350), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("c5391ca1-3884-4ad9-b370-231c1fb5e39a"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8530), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8530), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("c6d41d73-83c8-4def-8811-206c942ccaca"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8540), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8540), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("cd05d9bf-5ec4-4789-9b6c-bd4ce89a1ae7"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("cd43096c-f9a7-45d8-97d7-35ca2265ad52"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8800), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("cd5653b5-87b3-4001-b3e4-9431fe60951b"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8570), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8570), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("d37dc592-06b2-4bfa-ac17-935f3559c03c"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8150), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("d53e62c9-65df-4c16-a481-e2d5083163af"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9090), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9090), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("d9dd5e1c-d880-4089-900e-a2277515a3f6"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8480), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8480), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("ddd72eb5-02d9-4ee1-aad2-3b9451e318e2"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8550), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("f2afafa3-ac12-460d-8689-0ded62402bd0"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("f3ace30f-aaa7-4c54-ad2e-6ea9d4ad551c"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9230), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("f6b28ce2-0532-47db-8e8b-aa2b82f0bf23"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8680), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("fc15c999-7141-4e29-a376-e4d28937453d"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8360), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8360), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("fe57f715-99ce-4abd-ad51-6d1bb0de0433"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9070), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9070), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("fe73c3c3-fa75-4b4d-a74f-a9d762f7b04c"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9410), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("ff0da621-5976-4fc3-aef1-e81d62d09cfd"), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9050), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(9050), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("818e56a1-47a6-44ce-b303-26a7ee882804"), false, 30, new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8630), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8630), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" },
                    { new Guid("b814c8dd-7501-4e01-b0ed-aa9620d0a926"), false, 30, new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(7940), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(7940), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8580), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(8580) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(7890), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(7890) });

            migrationBuilder.UpdateData(
                table: "ZeebeFlow",
                keyColumn: "Name",
                keyValue: "zb-user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(7860), new DateTime(2023, 2, 16, 9, 34, 3, 391, DateTimeKind.Utc).AddTicks(7860) });

            migrationBuilder.CreateIndex(
                name: "IX_Instances_EntityName_EntityId_WorkflowName",
                table: "Instances",
                columns: new[] { "EntityName", "EntityId", "WorkflowName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Transitions_State_FromStateName",
                table: "Transitions",
                column: "FromStateName",
                principalTable: "State",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transitions_State_ToStateName",
                table: "Transitions",
                column: "ToStateName",
                principalTable: "State",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Transitions_ZeebeFlow_FlowName",
                table: "Transitions",
                column: "FlowName",
                principalTable: "ZeebeFlow",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Transitions_TransitionName_Form",
                table: "Translation",
                column: "TransitionName_Form",
                principalTable: "Transitions",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Transitions_TransitionName_Title",
                table: "Translation",
                column: "TransitionName_Title",
                principalTable: "Transitions",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_State_FromStateName",
                table: "Transitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_State_ToStateName",
                table: "Transitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_ZeebeFlow_FlowName",
                table: "Transitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Transitions_TransitionName_Form",
                table: "Translation");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Transitions_TransitionName_Title",
                table: "Translation");

            migrationBuilder.DropIndex(
                name: "IX_Instances_EntityName_EntityId_WorkflowName",
                table: "Instances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transitions",
                table: "Transitions");

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("000fd990-6142-4760-be14-86095ec38c79"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0243b3c7-b88d-43b8-92d1-56387cc53f4e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("03d48e68-a10e-4861-872e-ddda5396c4c1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("05045669-7384-4a28-8215-bb74d2c08899"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("06b04ef2-a637-48c8-aae4-043023090b18"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0a2776de-c308-40a3-84b8-f69030de16f2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0eec5aba-71b2-43f8-9a62-daa449320cf1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("113a6f3e-d9dd-437a-a47f-d90e3a8d51f7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("14013b51-0b6e-4178-bc5a-0ee4568f6745"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("15f12707-c61e-447d-b77f-53a9d1072432"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("16044817-8685-4cde-938a-e081e8b0798d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1a1b9ad8-989f-493e-a64c-cdaf1c402bd4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("22623a2d-b472-4699-8669-3d167c422fbb"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2404b520-801e-43de-9e9d-6d2d79f33347"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2695c82b-4fa2-4b0b-8e76-3a6d7cf2e43d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("269b3bed-38e0-4487-9469-33d56a44063e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("277b0ad9-2d4c-481d-8bef-9199b4906446"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("286fd08a-edae-4c22-b288-28e13bca09ab"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2885b599-9ad3-43af-8957-88cd2d5ff5b7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("29d1975e-1fe1-471e-b4de-4378fac6699f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("33a57cec-92c6-4099-8fc0-f7e772fd1a8b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("379227ab-fbc7-41d2-ac33-b3ff6e2f089a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("380c72ed-446e-4422-89bd-7a61f38abad1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3bb9a0f8-81e3-4011-bed9-787ec13bd4d1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3f6b3212-2eb4-47e8-b9ee-7aa61f0d202e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3f96a1b8-64d2-4f4f-bc66-8e49bd3978d5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4374d338-9c47-4835-9488-f164284cda22"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("439b8e4e-2185-4a82-910e-58151bd4a09c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("44a9a284-3c29-4019-880a-9e16546e6b7c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("45bcf06d-981c-47e9-bd3c-1c5d279e397b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("47076e44-e600-4de2-bb0a-959eefdf4001"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("4a1b52fa-3762-4cc0-b9d1-1b064635b180"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("50af82d9-8f58-4dfb-a557-4da40b579c99"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5114c94f-587d-47de-a758-5c5874ba440d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("529ddc32-4443-4990-a802-d2a6e8349b31"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("551b1bd8-3262-4c1a-b988-b081f33b206b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5644f015-ce83-4970-8916-39925190a313"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5a6c19c1-ea8a-4c01-b28d-de11afeb293c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5c271ddc-c284-4c50-832d-cd22e1e16c69"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5e9f1568-207f-4c03-9e6b-5fa49f018287"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("601478bb-dba0-46aa-8d45-3164cf9cd110"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("616b8eb9-0652-46c9-a24e-f8a6353e5013"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6a027357-e684-4a2a-9c7d-7f6e7ad41c61"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7404b7c8-611a-4dcf-9bd1-e1ea13631a21"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7ba08b8e-25b2-42c8-b3c7-ab9741b3ea79"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("85698a5f-a962-41e7-8893-3773439691f5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("856d82d8-2792-4ef9-82fc-129a505789cd"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("87686e6b-5ab8-4941-8c83-7064bb10e343"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8b3454f5-d03c-45df-8fca-5642e6a90307"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a5ace54f-21ff-4a4f-a86f-4543c1dc8ee6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a5ead946-60bc-4714-b5eb-f293ff893aac"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a7eac6d8-07bc-4d72-82f2-400fdc6bd6bc"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a91ce451-38f9-463d-b3a2-9f0bb0c61066"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ab1cb8ce-93a8-4ae5-84fd-2a8832431947"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ac879afe-e714-4f3b-b8e0-b31a55a9bdae"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ae6b5781-0e53-4558-b306-adfa5348cc16"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b4424d92-ec90-41f0-9c0c-f78ee9a09ddf"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b458c854-2e17-4e80-b68f-a106777254f0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b8bf583d-1521-4abb-9eb1-9a5b1bb58726"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bb87ed6b-d6c5-4257-bf75-c2438fbee5c2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c5391ca1-3884-4ad9-b370-231c1fb5e39a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c6d41d73-83c8-4def-8811-206c942ccaca"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cd05d9bf-5ec4-4789-9b6c-bd4ce89a1ae7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cd43096c-f9a7-45d8-97d7-35ca2265ad52"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cd5653b5-87b3-4001-b3e4-9431fe60951b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d37dc592-06b2-4bfa-ac17-935f3559c03c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d53e62c9-65df-4c16-a481-e2d5083163af"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d9dd5e1c-d880-4089-900e-a2277515a3f6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ddd72eb5-02d9-4ee1-aad2-3b9451e318e2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f2afafa3-ac12-460d-8689-0ded62402bd0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f3ace30f-aaa7-4c54-ad2e-6ea9d4ad551c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f6b28ce2-0532-47db-8e8b-aa2b82f0bf23"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fc15c999-7141-4e29-a376-e4d28937453d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fe57f715-99ce-4abd-ad51-6d1bb0de0433"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fe73c3c3-fa75-4b4d-a74f-a9d762f7b04c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ff0da621-5976-4fc3-aef1-e81d62d09cfd"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("818e56a1-47a6-44ce-b303-26a7ee882804"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("b814c8dd-7501-4e01-b0ed-aa9620d0a926"));

            migrationBuilder.DropColumn(
                name: "BaseStatus",
                table: "Instances");

            migrationBuilder.DropColumn(
                name: "EntityName",
                table: "Instances");

            migrationBuilder.RenameTable(
                name: "Transitions",
                newName: "Transition");

            migrationBuilder.RenameIndex(
                name: "IX_Transitions_ToStateName",
                table: "Transition",
                newName: "IX_Transition_ToStateName");

            migrationBuilder.RenameIndex(
                name: "IX_Transitions_FromStateName",
                table: "Transition",
                newName: "IX_Transition_FromStateName");

            migrationBuilder.RenameIndex(
                name: "IX_Transitions_FlowName",
                table: "Transition",
                newName: "IX_Transition_FlowName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transition",
                table: "Transition",
                column: "Name");

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-active",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(480), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(480) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-deactivated",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(600), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(600) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-card-password-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9890), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9890) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-fail",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(80), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(80) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-security-question-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9950), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9950) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-set",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9820), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9820) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(430), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-suspended",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(540), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-activate-fd",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(910), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-activate-fs",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(850), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-deactive",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(790), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(790) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(670), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(670) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-acp",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(260), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(270) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-asq",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(320), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(320) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-card",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(140), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-security-question",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(210), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "Transition",
                keyColumn: "Name",
                keyValue: "user-suspend",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(730), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(730) });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("00da1624-6ebd-45f6-bfb9-7ee2a95e2e4d"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(30), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(30), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("01f2281a-05a2-4c94-b948-8f6d3019ba49"), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9830), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9830), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("02f6d2b6-d0b2-4d19-a3d3-853df072bf93"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(590), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(590), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0419bf51-ce16-4f99-9b82-609ca68851db"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(450), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("07592c24-104e-43a8-9bcf-eb592dbec743"), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9930), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1255650d-1b07-41e3-89fa-3ccfe1d89e4c"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(350), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1378ffc0-b088-40b7-8516-5aed02de90c4"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(620), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("192d57f8-e86d-42d0-b49a-f0cd07585e33"), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9960), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9960), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1b11caf2-9294-4f39-be8a-32f83b6b15a5"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(900), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1b9f3c99-d732-4862-9dfb-6b869bd56bc6"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(650), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(650), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1dbc5230-f6e7-4886-acb3-22340c093135"), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9980), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1dc9b26e-2a73-4c25-a39a-4dfe7dd40226"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(770), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("22f44dbe-5b29-40a0-a354-d81a41120bba"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(520), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("27952d8a-a55d-46af-af0a-1b5db42efd5c"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(200), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2c2e49eb-01ac-4052-9ea8-f65e2617f808"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(800), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2d5be8b0-be9a-4916-9dcf-6ac6c46ee4e1"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(580), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(580), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2eaf299b-07be-4df3-9c14-1c7beab5a1f5"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(310), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2fac3444-93b6-445e-877f-ef006034a669"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(160), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("36ac4e3d-df8d-493b-a97d-4f12582a2224"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(260), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3c9a0028-77bb-4898-a51d-8cdb290ca6cf"), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("408c9ec7-6fda-4e5d-b422-4473322b253c"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("419ef968-7400-452e-b238-6674328aed6c"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(530), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(530), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("42f453dc-ba56-4a4b-9db6-c2de11f2e18e"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(60), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(60), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("43150a10-51ef-44b0-98d6-fe73e6c744ad"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(880), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("4731f282-4535-4486-9f63-2947f76d2072"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(220), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(220), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("50bf3ed3-c131-4cc7-aa52-533cb64bb29e"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(700), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(700), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("59cc9ce4-968a-4dd0-be7a-643dd5196c91"), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("5e79c8e5-1eb7-417b-acc8-eea06e3b9749"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(100), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6271ccc2-8d8d-4ded-8f12-3687d862bf2c"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(510), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(510), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("65d1ebb6-088b-43a2-9a0a-f80a58fe7b1a"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(960), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(960), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("674e5ade-0908-4e87-84d3-9b933d9f4c1a"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(500), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("67d3fb02-dd27-4748-930d-2f88ea9408e6"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(710), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(710), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6a73cc2f-7001-4027-8ecf-03d58770a7a4"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6c1a665d-d8d4-4d66-8b88-74fc5bfefe78"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(370), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6f68a4e0-bb77-4494-813d-1915f42a5756"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(860), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("70099476-3376-48d0-b939-cbf31b7752cc"), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("72a89566-3628-4b15-ab57-533c1bed8c6c"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("75a65ecb-677e-4245-a7cb-a000f77b10ee"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(930), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("77fd244f-4e9a-4c0e-8608-1cbca8ab9006"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(120), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("79fd1377-7509-4c96-8eae-56344d8900b5"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(140), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(140), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7ba5cd1f-1f79-4d50-83ba-f348895ded7b"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7eb89482-17d1-4302-abd9-e615ebe2bf75"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(780), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(780), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("83e3776f-fc1b-4736-8bc2-fa60433b3997"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(760), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("84756bac-480d-4bc2-8623-fe8f958cc6ab"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("89255041-3950-4514-9077-b543670dc93b"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(830), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(830), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8b95989f-c6dd-4b80-b56e-17d4b0b652bf"), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9810), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8edf1615-0b21-43cd-82b8-c286632c2823"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(460), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(470), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8efa4268-baef-480f-8acf-30962a46286f"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(410), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("94f034fe-6142-46d6-aa27-ad95aec2fa18"), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9910), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9910), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9a4aea9c-4242-4fae-b702-faa721286b39"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(750), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(750), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9d1b356a-7837-4048-a3a5-87153aae3534"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(840), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a11ec603-710e-4e5c-9ee5-dc6292f59aeb"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(300), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a74ff671-c2cb-4f14-a469-33df398c9e63"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(480), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(480), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a8da1080-93ce-417a-8fbe-c47836636b64"), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9940), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ac03b584-4ef5-43c9-8d4c-6dfca1ff5c3f"), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9880), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ac349f7d-18e6-457f-ba8f-ad244cf4524b"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(730), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ae155fcd-f579-4f6e-bf50-161d6a0657ce"), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9860), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("aee13dc2-5559-4395-8168-83aa4087f9e8"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(20), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(20), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b996f8b8-efdd-4ee4-8187-104f8f45af7e"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(820), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c16af16f-cde9-4004-8dcc-6389f58107cc"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(230), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c512d92e-75fc-4781-9a99-f7f8f4aeaf81"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(920), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c73994dc-67ec-4741-8e91-f20ba81bf0db"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(280), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c9cc71f9-c7ac-4486-9334-a01b05a3595e"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(250), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(250), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("cc6f2966-5354-44fa-9530-c0a1c0519cd0"), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ce0c8254-1abd-4a5e-acae-9cd51e9e4816"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(950), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("cfe3c8b9-5bb7-4a13-834a-00f8d3afe24c"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(890), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d1545fec-fe86-4f4d-94b0-b382a88578f7"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(40), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(40), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d81d2176-0019-4405-9e3a-5bfa9d519edf"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(190), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(190), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("dcae163a-6656-4b18-bb58-3fd88e22f1f7"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(170), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(170), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("dd3a2d91-a9b2-4c30-b037-8a1db8a2dbdf"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(390), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(390), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e8d86b9e-9098-468e-bcc3-7afdc1edcce5"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(550), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ebdd87a0-a71a-450c-9c96-e4cce369cbbd"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(360), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(360), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f127f8b3-2e88-404f-abd3-7d4aaa17b34b"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f6607c76-c55c-4446-b9a5-60094db03244"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(110), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(110), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("fc42d498-023f-4e0d-a45b-78ff219b469d"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(290), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(290), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ff19ae70-d1d5-45da-ae0a-158d29bc64ce"), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(440), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("1814d8b6-d27e-47c9-aaae-8a5ac054080c"), false, 30, new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9770), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9770), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" },
                    { new Guid("7fbf4c86-7838-4ebd-9af1-1fc5d811eb9a"), false, 30, new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(420), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(420), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(380), new DateTime(2023, 2, 15, 10, 55, 39, 914, DateTimeKind.Utc).AddTicks(380) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9700), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9700) });

            migrationBuilder.UpdateData(
                table: "ZeebeFlow",
                keyColumn: "Name",
                keyValue: "zb-user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9680), new DateTime(2023, 2, 15, 10, 55, 39, 913, DateTimeKind.Utc).AddTicks(9680) });

            migrationBuilder.AddForeignKey(
                name: "FK_Transition_State_FromStateName",
                table: "Transition",
                column: "FromStateName",
                principalTable: "State",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transition_State_ToStateName",
                table: "Transition",
                column: "ToStateName",
                principalTable: "State",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Transition_ZeebeFlow_FlowName",
                table: "Transition",
                column: "FlowName",
                principalTable: "ZeebeFlow",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Transition_TransitionName_Form",
                table: "Translation",
                column: "TransitionName_Form",
                principalTable: "Transition",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Transition_TransitionName_Title",
                table: "Translation",
                column: "TransitionName_Title",
                principalTable: "Transition",
                principalColumn: "Name");
        }
    }
}
