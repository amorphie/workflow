using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstanceTransition_ZeebeFlow_OnEnterZeebeFlowName",
                table: "InstanceTransition");

            migrationBuilder.DropForeignKey(
                name: "FK_InstanceTransition_ZeebeFlow_OnExitZeebeFlowName",
                table: "InstanceTransition");

            migrationBuilder.DropForeignKey(
                name: "FK_InstanceTransition_ZeebeFlow_ZeebeFlowName",
                table: "InstanceTransition");

            migrationBuilder.DropIndex(
                name: "IX_InstanceTransition_OnEnterZeebeFlowName",
                table: "InstanceTransition");

            migrationBuilder.DropIndex(
                name: "IX_InstanceTransition_OnExitZeebeFlowName",
                table: "InstanceTransition");

            migrationBuilder.DropIndex(
                name: "IX_InstanceTransition_ZeebeFlowName",
                table: "InstanceTransition");

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0aa2ffa5-e90a-4641-81a2-456a1807b89f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0ac6c4b0-6065-4789-8fc3-3376c4d72bcc"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("0c262298-1da8-4670-8e1f-147a2d480558"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("105e31cf-e8d5-49d9-958e-b6f8ef736d74"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("18f7e2b6-ac53-4896-aa5e-133630d2b3d0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1c8ceb70-82c9-4e55-a6cd-c66caaaef5e1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("1d5baf17-b259-4752-9800-2b4d350d6717"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("20707b95-0ae7-4e38-800b-de1774f8dc6e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("21bd0d58-16c8-461c-8069-bc082161919c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("255a6216-344a-4e8a-a6b5-108664983cb0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("27f487f6-123b-44be-8408-198129cc032c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("293567cf-9d23-45e9-85b7-921779068744"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("29bb3e46-8bac-44ea-b8a9-17d43f32d868"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2a7bcb4c-992e-4681-b17c-30e0c1c9c54a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2f593f4b-b5a1-4d83-8af2-7a8efcdc9a13"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2f746824-87e7-4eef-871a-b683bf26a4a4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("315661ba-e293-428b-a8db-13b82e02489c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("39d47d2c-4ab8-4e71-b85a-3bb3d8c0b0b6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("39ef18b3-d1f5-4dc5-a28b-320d73ba1a59"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3a5a0861-4e80-4e5a-83aa-c1cc443ff6c9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3d002f06-226e-4e35-a6b3-7dad277cde65"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3d311d51-331a-4feb-9434-29b81d9ebdf0"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("3f4db356-729d-4103-b997-6efaf2ed1ca3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("44684680-e32d-4b29-b603-24e5a2ba5981"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("46346198-00e6-45f8-b116-3845df6eadac"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5a9932f2-4ec9-452c-b375-d4fa95fbf759"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5ef7a902-317f-449e-bfdd-141811aeb5c1"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("60be02a5-6745-4683-8a6f-c171048cc051"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("649e6cb6-e22b-4ec3-9085-f3c850f24a30"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("66f15fe6-d7aa-4400-9c06-3cc53999b26a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("673f518c-f522-4244-8bd0-3352f35cb896"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6954a6e4-4ef3-4198-8520-8ca4a52e788e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("6be7f6c3-66f8-4c31-b384-1ce6100b233f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7449a1b9-ad2e-445c-b934-33daabba1e0e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7a2bc2d4-05b5-412a-a67e-558655349987"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7a8d37f4-f05a-4739-9853-72ceb6fc32ed"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7e2b3f4e-bcd7-4457-b399-fee45aa82128"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("88052587-466d-4b90-9709-a20543fa844a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8890e3ca-3de5-4c4e-89b2-553120063337"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8c7e0907-b587-4b2e-af0e-84a59bd85752"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8ccecce1-475e-4abb-b516-0aec978a5f30"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8ef018a0-b4e4-4197-8e08-ce7d93cac41d"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("97a8eed6-59d2-46e3-9b9e-c0626e10fc84"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("98550588-7483-4983-907b-e0358f2b7c23"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("996216ec-7aa0-494e-ae3e-99745b951fc6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("997585ad-0fab-423f-a2c7-070b2784179f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9b44c173-da67-47c2-9a64-6a625fc80712"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9bc826eb-b105-4c8c-b986-31b03774e5e3"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a055be4f-6b87-46df-89bf-8ffa8c44f1cc"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a0576544-bf2a-4f4c-b898-b9d010ccfb4e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a3ccb58d-0031-4ab0-8fd5-21ee01409d1c"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a658e5b5-1a39-4db8-bd7f-51f645d20938"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a7490a88-5232-4571-b59d-a5e6388a0b84"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("aaec9470-889a-4d5e-b84a-af3036a67f52"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("acfa9e90-f1ba-4e7b-a968-80812edd3938"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("af1950da-a183-4a20-bd0d-84ca817e2cec"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b19dd88f-54f2-44e8-b182-3c72c4fdfd7b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b6f3c3f4-a930-48b0-9818-73725246aa5e"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("bbe6c678-42da-4c08-834a-f71a85fd663b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("cadb5376-7208-495d-bdf8-a13ece7a7bbe"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d4ec2378-e1b6-4a54-9254-1cdb083f06de"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d6aeb04a-c5df-49cf-bfba-6d77df92041b"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d76faa70-0b86-4ccf-9c30-aa2360fe8b68"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("d8958ea4-fd4b-4629-9ff9-9334363b3768"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e4884a5f-5ef9-4105-be97-eb7d7d0269d6"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e9ee5bad-b184-4116-b887-f910b6caf80f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ebff85d3-21a2-45eb-bf4d-37f05c40d7f4"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("ec481e9f-2e15-454f-b6e0-23e09ea9c27f"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f13630a4-4139-4559-8706-ba09c969646a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f51f5535-ad6c-4edb-be20-d9dcc623a7f7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f672f642-4543-4667-88a8-36cf0960d2be"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f85e3f9d-975d-45ac-b60d-ee079772a68a"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f94e91c3-daf0-4890-8b0a-5a534194f137"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f9aa0645-50b4-47d3-9c55-c02ea66973fa"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fca32c65-d1de-4340-9a5c-1a0087772e44"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fcc643ea-847c-4207-8cd0-1bb0007fb1e2"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("8cca3027-f96e-467b-a226-d98aa6c5741e"));

            migrationBuilder.DeleteData(
                table: "WorkflowEntities",
                keyColumn: "Id",
                keyValue: new Guid("e2e0ecf6-1e41-4a2a-86d6-78f3c829f368"));

            migrationBuilder.DropColumn(
                name: "OnEnterZeebeFlowName",
                table: "InstanceTransition");

            migrationBuilder.DropColumn(
                name: "OnExitZeebeFlowName",
                table: "InstanceTransition");

            migrationBuilder.DropColumn(
                name: "ZeebeFlowName",
                table: "InstanceTransition");

            migrationBuilder.AddColumn<string>(
                name: "FlowMessage",
                table: "Transitions",
                type: "text",
                nullable: true);

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
                    { new Guid("00519d6c-669a-4f57-ac3d-12a16c457cc0"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5930), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5930), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("059ad202-72c8-430a-8bb6-f011c79fdfa7"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6500), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("095c3e75-0bfa-4875-967d-238a761edf42"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6660), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6660), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("0b4aa3eb-03bd-4996-8703-66c9dfaba38d"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6870), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("0e00999e-553c-433c-94a5-64ce4ffefbe4"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6580), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6580), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("0f296b0d-951e-4293-bef9-3bdb66bb6c4c"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6410), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("1339ec0a-9601-48ba-a75a-f668e4d864da"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("166dc3cd-81e5-406e-8a52-53948eca4243"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6800), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("1fe92b30-e9f4-4d99-b663-2af12879c7d5"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6240), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6240), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("2852c25d-26dc-4a07-9305-47a111996906"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6220), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6220), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("2b801884-d55a-4883-a2a6-9f75e7505e0f"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("2e75bc69-97e7-490c-b45d-10bbd3e51aa4"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6300), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("30814db7-e7ee-4ab0-be17-e076069408d1"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6120), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("3616dd59-afa8-4d2f-8742-f4ee299fb443"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6730), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("39aae081-7393-4883-bd33-c492afffd8d7"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("3a485863-1308-4158-9bd0-ff64411cb4bd"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("3cdaff96-4dc0-4cba-b467-5b4a6198b465"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5950), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("3cf43f10-7590-49a9-8b83-b6120cbfc3a9"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5920), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("423c8a69-f182-4632-b112-6922dfe1931b"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6910), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6910), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("435677b7-b55c-47d5-8fc4-cc7d0c5b4552"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6350), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("458ba6aa-82cd-4d77-bf5a-bef06c11a272"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6690), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("48658728-8645-4551-a2c5-4eaf97400cab"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6890), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("4a727164-76fd-4850-93ae-0d5b0b1a97b3"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6980), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("4d98dd25-3abd-4470-8aad-3445f4fb512c"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6450), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("506f90e5-b645-42fe-be2f-3942c23a759a"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("50f9f332-90f9-4618-b249-7164317e36ad"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6920), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("532371ff-0ce1-4d39-9001-62d296a0a708"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("60482695-6998-4f51-927a-af1c1da0d75e"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("60b36021-8611-44e9-8c83-72bbc28974a0"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6840), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("63379467-598e-4696-833d-8dcdd9b852b3"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6000), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6000), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("67d49121-afb1-424b-b0aa-68da1a8ce7b8"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6040), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("6e48cd17-f7e2-4756-b259-dee1c278aa22"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6940), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("6fd0fe76-d23c-43f8-8645-17b1427a55a3"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("75654029-a98d-4893-8297-ffb9ae90a523"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6230), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("76788759-7e3c-4a84-940c-2ccbfa6a96b9"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6970), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("7bc75bfe-14f4-4059-9b30-e3adcf7e4c5a"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6100), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("81b1688d-32e5-40a6-b37a-0cceb12d2bc8"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6340), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("871dec99-41a7-480d-a93b-3b9eb37f2d13"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6520), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("8782e522-a68d-4fe0-a401-cd1461af2693"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6540), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6540), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("8ecc7616-ab8f-4db1-96e6-9de5b683783b"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6850), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("8fdae5e9-8fe1-479c-b2a0-2bf1e5c31f2d"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6740), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("90425b52-6c4f-4a91-b399-60f48f26f7cf"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6090), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6090), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("98371222-3d2d-4a6d-8218-5a8398375d07"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5870), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("9939efcc-aa26-4a62-a499-04a1834c41df"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6050), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6050), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("9b21cce0-a6c4-464c-963e-76247135f7f6"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6440), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("9e5d20c4-587e-4c4a-93c6-ef7391bb7d5a"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6600), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6600), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("a063ccf8-06ad-4993-bec8-358e0007706d"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6720), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6720), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("a2057a45-ad00-4c13-9bda-77fd8eea643f"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5880), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("a62db010-52e2-4670-bbd8-51118759ba95"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6490), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("a6ccd65c-9040-461a-8895-bcc4e347a0bd"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5980), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("a8be37c3-b344-429d-a787-1b3535c360c5"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("ab64a6c1-ce5d-40c2-aa69-f96f73e33f4a"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6830), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6830), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("ac7da1a7-392c-495f-8418-d0391db37b33"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6810), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("af3a3b8b-f196-4b57-9e24-2aafb249691d"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("b33232c3-b771-454c-acea-346505afc0d0"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6510), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6510), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("b78054d6-fe79-42b5-8dc7-078452d5019a"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6780), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6780), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("bd3eb55c-2ee0-41a4-abb6-4c5d4c23faea"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6570), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("c03cfd86-6a04-434a-8382-9594216f7fa9"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6020), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("c40146d3-165e-4315-82e7-c62043425bd9"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("c8c417eb-bbac-4e01-91d4-e0ec68085fda"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6640), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6640), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("ca67a8fe-0bcc-4f0f-8194-dfbd2477f898"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6290), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6290), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("cf571b01-82b1-477c-b931-c8bad020c549"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6170), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6170), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("d9be15c1-66e9-4be7-81a6-8f33af12252e"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6630), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("dfc63721-c6a0-43f1-9a0f-488cb74b9413"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6270), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6270), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("e0ecab62-b002-4f28-837c-6d67a7583e79"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("e4301494-7fb6-4057-bc24-e7499585567c"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6070), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6070), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("e8d5717b-5ec4-422b-bad8-c9e5eb086468"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6260), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("ea11c734-3380-443b-9d15-34e9cc9e90dc"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6750), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6750), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("ef15dfc2-558e-456b-80c5-cf136694c00f"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5990), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(5990), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("f1174b21-3410-4ed3-a7b1-4b0338323985"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6160), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("f289dcf7-4228-4356-9c6d-ae7c83f1eb05"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6400), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("f3bc4fd4-baf5-4cc1-ae9e-6255a119ae65"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6770), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("f53b9310-e916-400d-8e31-89c0d00f6ec4"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6180), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6180), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("f616ea50-4986-4a51-a9fa-e64d3128a666"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6140), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("f89618a3-1fc0-4a1f-bef3-26fc2e67f8f4"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6110), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6110), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("fd584825-16ce-4c94-8cd5-0ec2b18cbd18"), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6680), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null }
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

            migrationBuilder.UpdateData(
                table: "ZeebeFlow",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6420), new DateTime(2023, 2, 20, 16, 40, 34, 618, DateTimeKind.Utc).AddTicks(6420) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "OnEnterZeebeFlowName",
                table: "InstanceTransition",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OnExitZeebeFlowName",
                table: "InstanceTransition",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZeebeFlowName",
                table: "InstanceTransition",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-active",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4010), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-deactivated",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4130), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-card-password-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3420), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3420) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-fail",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3600), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-security-question-valid",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3480), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-set",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3540), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-reset-password-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3350), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-start",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3950), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "user-suspended",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4070), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fd",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4420), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4420) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-activate-fs",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4360), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-deactive",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4300), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4190), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4190) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-acp",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3780), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3780) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-set-password-asq",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3840), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-card",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3660), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-reset-password-validate-with-security-question",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3720), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "Transitions",
                keyColumn: "Name",
                keyValue: "user-suspend",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4250), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "TransitionName_Form", "TransitionName_Title", "WorkflowName_Title" },
                values: new object[,]
                {
                    { new Guid("0aa2ffa5-e90a-4641-81a2-456a1807b89f"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3720), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3720), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0ac6c4b0-6065-4789-8fc3-3376c4d72bcc"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3880), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0c262298-1da8-4670-8e1f-147a2d480558"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3450), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("105e31cf-e8d5-49d9-958e-b6f8ef736d74"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4160), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("18f7e2b6-ac53-4896-aa5e-133630d2b3d0"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3890), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1c8ceb70-82c9-4e55-a6cd-c66caaaef5e1"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4210), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1d5baf17-b259-4752-9800-2b4d350d6717"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4180), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4180), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("20707b95-0ae7-4e38-800b-de1774f8dc6e"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3650), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3650), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("21bd0d58-16c8-461c-8069-bc082161919c"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4280), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("255a6216-344a-4e8a-a6b5-108664983cb0"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4080), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4080), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("27f487f6-123b-44be-8408-198129cc032c"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4140), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4140), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("293567cf-9d23-45e9-85b7-921779068744"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3400), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("29bb3e46-8bac-44ea-b8a9-17d43f32d868"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4400), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2a7bcb4c-992e-4681-b17c-30e0c1c9c54a"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3730), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2f593f4b-b5a1-4d83-8af2-7a8efcdc9a13"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3630), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2f746824-87e7-4eef-871a-b683bf26a4a4"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3700), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3700), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("315661ba-e293-428b-a8db-13b82e02489c"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3930), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("39d47d2c-4ab8-4e71-b85a-3bb3d8c0b0b6"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3340), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("39ef18b3-d1f5-4dc5-a28b-320d73ba1a59"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3a5a0861-4e80-4e5a-83aa-c1cc443ff6c9"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3500), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3d002f06-226e-4e35-a6b3-7dad277cde65"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4110), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4110), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3d311d51-331a-4feb-9434-29b81d9ebdf0"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3770), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3f4db356-729d-4103-b997-6efaf2ed1ca3"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("44684680-e32d-4b29-b603-24e5a2ba5981"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4040), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("46346198-00e6-45f8-b116-3845df6eadac"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("5a9932f2-4ec9-452c-b375-d4fa95fbf759"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("5ef7a902-317f-449e-bfdd-141811aeb5c1"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3830), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3830), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("60be02a5-6745-4683-8a6f-c171048cc051"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3990), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("649e6cb6-e22b-4ec3-9085-f3c850f24a30"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4440), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("66f15fe6-d7aa-4400-9c06-3cc53999b26a"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3590), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3590), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("673f518c-f522-4244-8bd0-3352f35cb896"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4090), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6954a6e4-4ef3-4198-8520-8ca4a52e788e"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4260), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4260), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6be7f6c3-66f8-4c31-b384-1ce6100b233f"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4050), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4050), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7449a1b9-ad2e-445c-b934-33daabba1e0e"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7a2bc2d4-05b5-412a-a67e-558655349987"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7a8d37f4-f05a-4739-9853-72ceb6fc32ed"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4300), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7e2b3f4e-bcd7-4457-b399-fee45aa82128"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4350), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("88052587-466d-4b90-9709-a20543fa844a"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8890e3ca-3de5-4c4e-89b2-553120063337"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8c7e0907-b587-4b2e-af0e-84a59bd85752"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8ccecce1-475e-4abb-b516-0aec978a5f30"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3820), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8ef018a0-b4e4-4197-8e08-ce7d93cac41d"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("97a8eed6-59d2-46e3-9b9e-c0626e10fc84"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4120), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("98550588-7483-4983-907b-e0358f2b7c23"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4230), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("996216ec-7aa0-494e-ae3e-99745b951fc6"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4430), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("997585ad-0fab-423f-a2c7-070b2784179f"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3570), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9b44c173-da67-47c2-9a64-6a625fc80712"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4340), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9bc826eb-b105-4c8c-b986-31b03774e5e3"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a055be4f-6b87-46df-89bf-8ffa8c44f1cc"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4000), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4000), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a0576544-bf2a-4f4c-b898-b9d010ccfb4e"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3920), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3920), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a3ccb58d-0031-4ab0-8fd5-21ee01409d1c"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4410), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a658e5b5-1a39-4db8-bd7f-51f645d20938"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a7490a88-5232-4571-b59d-a5e6388a0b84"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3460), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3460), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("aaec9470-889a-4d5e-b84a-af3036a67f52"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4270), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4270), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("acfa9e90-f1ba-4e7b-a968-80812edd3938"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4020), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("af1950da-a183-4a20-bd0d-84ca817e2cec"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3980), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b19dd88f-54f2-44e8-b182-3c72c4fdfd7b"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4390), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4390), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b6f3c3f4-a930-48b0-9818-73725246aa5e"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3520), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bbe6c678-42da-4c08-834a-f71a85fd663b"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("cadb5376-7208-495d-bdf8-a13ece7a7bbe"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3750), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3750), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d4ec2378-e1b6-4a54-9254-1cdb083f06de"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4170), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4170), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d6aeb04a-c5df-49cf-bfba-6d77df92041b"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d76faa70-0b86-4ccf-9c30-aa2360fe8b68"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d8958ea4-fd4b-4629-9ff9-9334363b3768"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4240), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4240), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e4884a5f-5ef9-4105-be97-eb7d7d0269d6"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3470), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3470), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("e9ee5bad-b184-4116-b887-f910b6caf80f"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3550), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ebff85d3-21a2-45eb-bf4d-37f05c40d7f4"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4460), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4460), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ec481e9f-2e15-454f-b6e0-23e09ea9c27f"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4060), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4060), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f13630a4-4139-4559-8706-ba09c969646a"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4470), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(4470), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f51f5535-ad6c-4edb-be20-d9dcc623a7f7"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3640), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3640), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f672f642-4543-4667-88a8-36cf0960d2be"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3760), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f85e3f9d-975d-45ac-b60d-ee079772a68a"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3490), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f94e91c3-daf0-4890-8b0a-5a534194f137"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3530), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3530), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f9aa0645-50b4-47d3-9c55-c02ea66973fa"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3430), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("fca32c65-d1de-4340-9a5c-1a0087772e44"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3860), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("fcc643ea-847c-4207-8cd0-1bb0007fb1e2"), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3800), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "WorkflowEntities",
                columns: new[] { "Id", "AllowOnlyOneActiveInstance", "AvailableInStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "IsStateManager", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Name", "WorkflowName" },
                values: new object[,]
                {
                    { new Guid("8cca3027-f96e-467b-a226-d98aa6c5741e"), false, 30, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3310), new Guid("00000000-0000-0000-0000-000000000000"), null, false, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3310), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user-reset-password" },
                    { new Guid("e2e0ecf6-1e41-4a2a-86d6-78f3c829f368"), false, 30, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3950), new Guid("00000000-0000-0000-0000-000000000000"), null, true, new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3950), new Guid("00000000-0000-0000-0000-000000000000"), null, "user", "user" }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3910), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-reset-password",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3230), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "ZeebeFlow",
                keyColumn: "Name",
                keyValue: "user-register",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3900), new DateTime(2023, 2, 20, 16, 27, 44, 813, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransition_OnEnterZeebeFlowName",
                table: "InstanceTransition",
                column: "OnEnterZeebeFlowName");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransition_OnExitZeebeFlowName",
                table: "InstanceTransition",
                column: "OnExitZeebeFlowName");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransition_ZeebeFlowName",
                table: "InstanceTransition",
                column: "ZeebeFlowName");

            migrationBuilder.AddForeignKey(
                name: "FK_InstanceTransition_ZeebeFlow_OnEnterZeebeFlowName",
                table: "InstanceTransition",
                column: "OnEnterZeebeFlowName",
                principalTable: "ZeebeFlow",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_InstanceTransition_ZeebeFlow_OnExitZeebeFlowName",
                table: "InstanceTransition",
                column: "OnExitZeebeFlowName",
                principalTable: "ZeebeFlow",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_InstanceTransition_ZeebeFlow_ZeebeFlowName",
                table: "InstanceTransition",
                column: "ZeebeFlowName",
                principalTable: "ZeebeFlow",
                principalColumn: "Name");
        }
    }
}
