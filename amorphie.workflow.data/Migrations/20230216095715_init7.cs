using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instances_WorkflowEntities_EntityId",
                table: "Instances");

            migrationBuilder.DropIndex(
                name: "IX_Instances_EntityId",
                table: "Instances");

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

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Instances");

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
                    { new Guid("0265dde7-a955-4cdc-a6cd-6ae1f251ba90"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7130), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7130), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("02fef66f-a2ed-4f39-8ae2-8c0b1c272264"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7710), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7710), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("05762404-606b-4e98-ae6c-b69967bf9707"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("0b1b20a5-0cf8-4f78-94b7-772ec5428752"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7470), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7470), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("0b2b0ff0-6cef-4793-8db6-4ac539ead096"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("0eba898a-d920-4c69-9f0e-f009f961ee7a"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("18c37af6-e41a-4253-a9c8-0989ffaf665e"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("1a660e8f-7795-479d-8056-59b4f9243302"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7410), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("2058f8ca-0102-4bc4-998c-ee2233898df0"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7070), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7070), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("21203d9e-ec3d-4042-b9aa-7c127ceedf9a"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6870), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6870), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("21d22a51-5dd4-4313-9856-d039ad7adb3a"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6960), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6960), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("27af8a5b-6065-41f8-a6dd-6069d3a80a12"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7820), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("27bd75ad-3123-4d26-83bf-18d9d8c33b28"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7850), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("29f443b0-08e1-4fe0-8e91-429d95fc4d0a"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7870), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fd", null },
                    { new Guid("2fc0fc2b-5a1f-45bb-9c86-70967f747e01"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7490), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("3485430c-25af-4dfe-b0dd-bfb4bd9c5791"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("35c518c6-c0f5-4e97-9a1c-5da116e5185f"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7220), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7220), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("38b97bac-799a-4bff-a47f-2d396d749dc3"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7040), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("38e7a0fe-f781-4081-9f88-fd1719280253"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7280), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("3a85ed21-cd06-429a-97ba-2cf8621c2218"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("466e86cf-13ae-4189-9cd6-bb5b9427333f"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6770), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("46ecf20f-4d06-435d-891e-86dea3e1d9cb"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6930), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6930), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("48960ecc-0900-4e52-8446-f87e9a35a328"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7190), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7190), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("4ade69d9-45d4-4da9-81fd-42c08efc764b"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7160), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7160), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("4ca3ff44-ebd3-4ed3-99f0-19ff1d721dbb"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7670), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7670), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-suspend", null },
                    { new Guid("4e605fc6-c7a8-468d-a224-86c4e5afb6b7"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6890), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-security-question-valid", null, null, null },
                    { new Guid("538892e6-2b87-42de-919a-8aa1a4cba914"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7780), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7780), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("613afdc4-a0e9-4b9d-bb35-9633d96dc539"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("67e07a3d-aa30-433b-9c32-3f178329a788"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7590), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7590), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null },
                    { new Guid("684d0e25-f724-4cbf-a7be-300c4c87eae5"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7650), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7650), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("6c2b3bb5-09ea-4d18-8bcb-0cc965609096"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7090), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7090), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("6cf1ebb0-0d7b-4420-acbf-af247751b962"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6710), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6710), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user-reset-password" },
                    { new Guid("6de96710-b48d-4d02-9379-362b95fa15dd"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7880), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("6f67b4b1-ff87-4d0a-83fb-9672880779f9"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7440), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("6fdaa525-406a-4161-9d15-4bb79498467d"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-set", null, null, null },
                    { new Guid("755c5460-2e14-4653-9a7d-75cbf8e78f29"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7720), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7720), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-deactive", null },
                    { new Guid("7c6dece7-8fab-4666-b5b4-57800db55f5e"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7020), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7020), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("7dc14146-75ab-4bfb-b80c-56b4ed400cca"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7620), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("836b5e3b-e302-4cc0-b5b9-caf79ac2f6a7"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7030), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7030), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-fail", null, null, null, null },
                    { new Guid("8831ce59-2669-44a8-bf22-0f76af893e32"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7270), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7270), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-asq", null, null },
                    { new Guid("8a1b6e5e-0057-4332-95e8-97da8bc5bf23"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6920), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6920), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-security-question-valid", null, null, null, null },
                    { new Guid("8aef0647-dc75-4c06-85f1-075867adb49b"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6810), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6810), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("8ba3a18b-e1e8-4603-acb6-a3dceb365c4b"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7530), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7530), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("92473345-69cf-4c23-a8bd-973ce17c7d69"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6830), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6830), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("932b8e53-fbb9-4533-a36e-0c84a2b3d84a"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-activate-fs", null },
                    { new Guid("94ff3eb2-0c62-40b0-8216-c3df599f216e"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7750), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7750), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("986f2a84-259e-4e16-9797-974166ee264d"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7180), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7180), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-acp", null },
                    { new Guid("9ad76f07-0834-45bf-acc2-1946ed38a3b7"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7010), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7010), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-fail", null, null, null },
                    { new Guid("9d479ef7-ef8e-4162-a4e3-683bb7acd861"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6840), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6850), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-card-password-valid", null, null, null },
                    { new Guid("9e8d561d-ce96-47ba-9c8d-dc42f9f48685"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-reset-password-start", null, null, null },
                    { new Guid("a0c73ef7-f46f-4a9a-aaf1-d5631b0e9149"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7240), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7240), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("a678ee82-2ef1-4f65-b03a-23d27c2dfa5f"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7430), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-active", null, null, null },
                    { new Guid("aa43ae4b-2443-461a-9c69-7a8a4621764c"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7690), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-suspend", null, null },
                    { new Guid("ac59e70b-a33a-438c-bc7e-27206ecf1a9e"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7500), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7500), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-suspended", null, null, null },
                    { new Guid("b37e1591-5107-4447-8dfb-731320fc81e2"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7510), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7510), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-suspended", null, null, null, null },
                    { new Guid("b458281d-514b-46b1-850e-26ba321f5247"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6790), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-start", null, null, null, null },
                    { new Guid("b4e04f55-258f-4bb5-a0f4-98787ebd37dc"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7400), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7400), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-start", null, null, null, null },
                    { new Guid("b6793ca5-7eda-4949-9e5b-f1826370ea94"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7340), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, "user" },
                    { new Guid("b8495db3-9118-46ec-b1db-1e15823cf5ce"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7460), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7460), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-active", null, null, null, null },
                    { new Guid("b97bd170-4f32-45e5-aaae-255936558f30"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-register", null },
                    { new Guid("b9f5f3eb-9865-4111-8ff8-7ac5f4425d19"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7250), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7250), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-set-password-asq", null },
                    { new Guid("ba6ef645-3caf-4c47-8923-6b7c39c7495b"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7890), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7890), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fd", null, null },
                    { new Guid("bbcb69a4-90b3-4614-b7cf-0f3dc169e6a3"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7080), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7080), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-card", null },
                    { new Guid("bf1dac80-44d1-4ee0-8f19-b9900a0df2bc"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6860), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6860), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-card-password-valid", null, null, null, null },
                    { new Guid("bfcc1908-f50d-433c-aba4-9f76dd86fcda"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7550), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7550), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-deactivated", null, null, null },
                    { new Guid("c0d4c45f-c930-4613-a560-77f540a5a511"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7150), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-security-question", null, null },
                    { new Guid("ca2fe291-4e76-41c8-819e-f6111e4f40e5"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7760), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-deactive", null, null },
                    { new Guid("ce68b3c3-d125-46c4-a544-c9e70830d6e6"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7630), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-register", null, null },
                    { new Guid("d1cd18ba-6df6-4040-81de-4755a911924b"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7110), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7110), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-validate-with-card", null, null },
                    { new Guid("e5369a90-e8af-436c-9a24-e2fc79756f5d"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7810), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-activate-fs", null, null },
                    { new Guid("e6fdbe64-5b91-4f07-9f1c-9bf02739e8b9"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6970), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("e71349d4-6a71-4407-8cb8-98e81045c854"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "user-start", null, null, null },
                    { new Guid("e979572f-9f6e-447e-9110-f116d70f4326"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7210), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "user-reset-password-set-password-acp", null, null },
                    { new Guid("f0dca32a-8f9b-4a26-b433-5777ea7f1ae5"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7140), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7140), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, "user-reset-password-validate-with-security-question", null },
                    { new Guid("f732d1e0-3046-4234-966e-2cab476262e2"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6990), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(6990), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-reset-password-set", null, null, null, null },
                    { new Guid("ff86fe01-23ec-48a1-8b67-9ca6f12a564b"), new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 16, 9, 57, 15, 641, DateTimeKind.Utc).AddTicks(7570), new Guid("00000000-0000-0000-0000-000000000000"), null, "user-deactivated", null, null, null, null }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "EntityId",
                table: "Instances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                    { new Guid("00782349-5c58-47bb-a994-3189c13181d1"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9910), new Guid("00000000-0000-0000-0000-000000000000"), null, "Register User", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9910), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("02e41225-20f7-4f0a-affc-b836a946451b"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9700), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9700), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("04e1e17d-2bb4-47f6-adae-5f262c18b44d"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9950), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Gecici Kitle", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9950), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("09641a64-2a8d-41b9-9fe4-e46138686aed"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(80), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(80), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0b9934b5-c3d5-4478-a571-2e9c254bcc61"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9480), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9480), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("0e80fbf0-62d2-4a61-a67f-3edc1c349cb3"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9150), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1332dfd5-862b-4c10-ac1a-57265f249e61"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9470), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Security Question", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9470), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("16b258d6-3143-461f-bdae-198997f317a4"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9520), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9520), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1781d32d-202b-43b7-94fa-bd70fe06deb7"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9970), new Guid("00000000-0000-0000-0000-000000000000"), null, "Suspend User", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9970), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("18ae610a-faff-46d4-a52a-14d5bb84f68f"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9100), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1bf3be2e-018d-4c8d-9727-0383cf5f9ba3"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9590), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9590), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("1d9bb92d-190c-4bb1-aa83-c22259550faa"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9310), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellendi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9310), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2228f23e-b4b0-4ebe-92b8-49fa8cc9012f"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9860), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactivated", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9860), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("236995e9-041f-488e-8d47-0d39b3feddce"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9710), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9710), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("2878817f-2780-4486-a99e-0f5f7203eff9"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9240), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security Question Valid", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9240), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("28a0bd20-606b-418a-bbf6-2bf024b3cf4b"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Aktif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(120), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("36c6051b-86e1-4b42-a77d-1e1647703876"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9820), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9820), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("37728dd0-484b-48af-a780-ded0803a12b5"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9320), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was reset and flow completed.", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9320), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3bcdfe7d-feff-4a59-9c4e-9fab271805f1"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9210), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card password valid, set password.", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9210), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("3cef4b7b-997c-49b0-9567-2515192c5ef3"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9290), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Degisti", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9290), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("41eb8ada-7e85-4e7e-94dd-d6178bf5758f"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(50), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(50), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("42d63770-57cb-48d3-a5aa-95a79f8c5c52"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9120), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9120), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("479d6601-1568-4d1c-abd6-e1bf55797244"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9400), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Ile Yenile", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("4e85db5e-d587-4a85-bd83-c01922afba75"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9450), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Ile Yenile", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9450), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("4f30cda2-a1f1-4197-8b6f-142597cf20d3"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9200), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9200), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("59cb92be-a9c5-4204-b295-654a6a38e8c2"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9840), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktif", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9840), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("5a137e42-9460-40a4-b1a6-1ae244ea043e"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9540), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9540), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("5ab5ce5e-9c93-40a7-a617-0773a0834fda"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9530), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9530), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("5b9289a7-50b2-4f63-b382-a2377bcbc190"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9040), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici sifre yenileme", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9040), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("5d8014d9-35ac-448a-8ef2-2046cbcde048"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password was NOT reset and flow completed.", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9380), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("63865af3-71d3-4f95-9a37-0f9a6909a572"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("6eec1ab4-6528-4d46-b3ea-c69193a5c0b1"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9870), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kayit deaktive edilmis", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9870), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7129840c-c91a-4e10-bf2a-4134680daf8d"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9180), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Valid", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9180), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("73522ea3-70d4-412e-8464-5847496dbe65"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(130), new Guid("00000000-0000-0000-0000-000000000000"), null, "Activate User", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(130), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("74f57887-b939-4647-93f0-90389e2c64c5"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9110), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9110), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("76631c76-d968-41cb-9a3f-8f0589a070b8"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9810), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9810), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("7be2c45f-8ac0-4d51-9cb1-a61cec96fe4d"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Set New Password", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9570), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("804787b2-1fad-4c73-9939-199c04fa4f25"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9440), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("81676837-0fb8-4b75-b8f0-e078139cc97e"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9300), new Guid("00000000-0000-0000-0000-000000000000"), null, "Password Was Reset", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9300), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("83e844b6-fce3-4776-8f3b-a475c3ef381c"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9050), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Password Reset", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9050), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("84a6e5fd-6fb8-4c8b-b55a-ad0faa1151b0"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9900), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Kaydi Tamamla", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9900), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("86aedeea-e1d8-44b4-961d-5995b40783e5"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9800), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9800), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8d6d2102-d411-4d0f-bc9b-3f47cacf7213"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9560), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9560), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("8f82bc2c-862e-4efe-b719-234f10dd382f"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9510), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre Belirle", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9510), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("94610144-5e66-49e0-a889-a3c86696f950"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9940), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9940), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("96b1882c-a371-47aa-8168-c5209c9d08ca"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9370), new Guid("00000000-0000-0000-0000-000000000000"), null, "Sifre guncellenemedi ve akis tamamlandi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9370), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9877060a-8dd1-45a2-bc0c-be9bd005b299"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9880), new Guid("00000000-0000-0000-0000-000000000000"), null, "Record has been deactivated", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9880), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("9ec1e280-0c86-4040-b7ce-06aa9f564f78"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9680), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9680), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a23253b2-861e-4291-b4f5-206ffe83bb84"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9740), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start State", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9740), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a2690be8-2661-4750-8736-78cd4983283a"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9410), new Guid("00000000-0000-0000-0000-000000000000"), null, "Reset By Card Pin", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9410), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a5a5995b-92ee-4484-96a4-4dceef5c7181"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9770), new Guid("00000000-0000-0000-0000-000000000000"), null, "Start state description", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9770), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a627746b-02a4-4315-ac95-be66aa6cf5ca"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9930), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9930), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("a77f4f23-0eaf-4ad8-b200-77484d27dad5"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(60), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(60), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ac4a59d2-569f-40af-b0ea-b157e6e4aaca"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9170), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart Sifresi Dogru", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9170), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ae4995a7-000b-4e16-b4ff-4e11075d848d"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(90), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(90), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("b92c26a1-83ee-46fe-9367-10c725162304"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(170), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(170), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("bbcd0fa9-731a-4b60-8d52-87d7ec982adf"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(100), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(100), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c0141547-b022-4956-b51a-4fff05c1903f"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(20), new Guid("00000000-0000-0000-0000-000000000000"), null, "Deactive User", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(20), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c608ba9d-e6f8-4421-b636-d5ec71f05b91"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9640), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9650), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c7db5ca8-39b8-487b-9b58-ed27f54e5a24"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9730), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9730), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("c97334ea-34a3-47ee-9b17-7a0f05cfe7fa"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(10), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Pasif Yap", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(10), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("cc5c1353-1913-4e5e-bca3-eddfe1b5ebb0"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9980), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9980), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("d0c54da0-2052-4da0-88be-5b7ebbce8105"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9990), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9990), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("dadbd2ad-3892-4846-a5ff-0493a0d130e5"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9270), new Guid("00000000-0000-0000-0000-000000000000"), null, "Security question valid, set password.", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9270), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("dd5de8c6-3648-4652-8a88-c3300e75e05a"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9250), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9250), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ea436404-2b0a-4ab1-a6ff-cb90161836a5"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9760), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis baslangic asama aciklamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("eb221227-f061-46af-b784-4fdbceb02172"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9490), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9490), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("ec6e43fe-567e-40cb-b2c1-9db66c900cbe"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9600), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...en components... }", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9600), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("edcbbe31-6ac0-4015-8500-d8ecb051fdd2"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9620), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9620), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f08dfc3c-b486-43e1-85f4-ca8d1732dd8c"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(30), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(30), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f1abb713-8036-4a88-b06f-4533908d8fb7"), new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(150), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 495, DateTimeKind.Utc).AddTicks(150), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f1b76b95-4d29-4734-99c0-96a0759b75f0"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9350), new Guid("00000000-0000-0000-0000-000000000000"), null, "Card Pass Or Security Question Not Valid", "en-EN", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f3e535cb-8e6f-4c22-b095-0d5530bc6e24"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9790), new Guid("00000000-0000-0000-0000-000000000000"), null, "Akis Baslangic Asamasi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9790), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f4134fda-7ce5-439a-ad2f-9297705c2e7d"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9230), new Guid("00000000-0000-0000-0000-000000000000"), null, "Guvenlik Sorusu Dogru", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9230), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("f8f219dd-1b9c-49db-b1f4-198c85799dbb"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9340), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kart veya Guvenlik Sorusu Dogrulanamadi", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null },
                    { new Guid("fba75879-7389-479e-aa71-af5103724bbe"), new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9420), new Guid("00000000-0000-0000-0000-000000000000"), null, "{ \"display\": \"form\" ...tr components... }", "tr-TR", new DateTime(2023, 2, 16, 9, 52, 55, 494, DateTimeKind.Utc).AddTicks(9420), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null, null }
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
                name: "IX_Instances_EntityId",
                table: "Instances",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_EntityName_EntityId_WorkflowName_StateName",
                table: "Instances",
                columns: new[] { "EntityName", "EntityId", "WorkflowName", "StateName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_WorkflowEntities_EntityId",
                table: "Instances",
                column: "EntityId",
                principalTable: "WorkflowEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
