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
            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("5eccfe93-d688-4f2b-b879-c07888f3a4e9"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("669a0a6b-c157-425c-9152-e20b5a4f8be8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("a848446b-9771-46cf-8acb-ac48c1cdd8ae"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fcec5f93-fba5-42e7-9176-c21289f7f32a"));

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "retail-loan-start",
                columns: new[] { "CreatedAt", "ModifiedAt", "WorkflowName" },
                values: new object[] { new DateTime(2023, 2, 9, 8, 24, 21, 611, DateTimeKind.Utc).AddTicks(4720), new DateTime(2023, 2, 9, 8, 24, 21, 611, DateTimeKind.Utc).AddTicks(4720), "retail-loan" });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "WorkflowName_Title", "WorkflowName_Transition" },
                values: new object[,]
                {
                    { new Guid("016abe94-3e39-4548-ad0f-58620d90ea33"), new DateTime(2023, 2, 9, 8, 24, 21, 611, DateTimeKind.Utc).AddTicks(4710), new Guid("00000000-0000-0000-0000-000000000000"), null, "Retail Loan Process", "en-EN", new DateTime(2023, 2, 9, 8, 24, 21, 611, DateTimeKind.Utc).AddTicks(4710), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "retail-loan", null },
                    { new Guid("2700a898-e61c-4f01-93e0-38cbb112b2c7"), new DateTime(2023, 2, 9, 8, 24, 21, 611, DateTimeKind.Utc).AddTicks(4760), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 9, 8, 24, 21, 611, DateTimeKind.Utc).AddTicks(4760), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("8ad2e52c-3ab3-47e8-ad98-c213753cc0ab"), new DateTime(2023, 2, 9, 8, 24, 21, 611, DateTimeKind.Utc).AddTicks(4750), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 9, 8, 24, 21, 611, DateTimeKind.Utc).AddTicks(4750), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("c310ee3b-4ded-48e2-9363-890a99554b70"), new DateTime(2023, 2, 9, 8, 24, 21, 611, DateTimeKind.Utc).AddTicks(4690), new Guid("00000000-0000-0000-0000-000000000000"), null, "Bireysel Kredi Sureci", "tr-TR", new DateTime(2023, 2, 9, 8, 24, 21, 611, DateTimeKind.Utc).AddTicks(4690), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "retail-loan", null }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "retail-loan",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 9, 8, 24, 21, 611, DateTimeKind.Utc).AddTicks(4610), new DateTime(2023, 2, 9, 8, 24, 21, 611, DateTimeKind.Utc).AddTicks(4610) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-lifecyle",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 9, 8, 24, 21, 611, DateTimeKind.Utc).AddTicks(4730), new DateTime(2023, 2, 9, 8, 24, 21, 611, DateTimeKind.Utc).AddTicks(4730) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("016abe94-3e39-4548-ad0f-58620d90ea33"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("2700a898-e61c-4f01-93e0-38cbb112b2c7"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8ad2e52c-3ab3-47e8-ad98-c213753cc0ab"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("c310ee3b-4ded-48e2-9363-890a99554b70"));

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Name",
                keyValue: "retail-loan-start",
                columns: new[] { "CreatedAt", "ModifiedAt", "WorkflowName" },
                values: new object[] { new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1300), new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1300), null });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "WorkflowName_Title", "WorkflowName_Transition" },
                values: new object[,]
                {
                    { new Guid("5eccfe93-d688-4f2b-b879-c07888f3a4e9"), new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1290), new Guid("00000000-0000-0000-0000-000000000000"), null, "Retail Loan Process", "en-EN", new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1290), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("669a0a6b-c157-425c-9152-e20b5a4f8be8"), new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("a848446b-9771-46cf-8acb-ac48c1cdd8ae"), new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1340), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("fcec5f93-fba5-42e7-9176-c21289f7f32a"), new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1280), new Guid("00000000-0000-0000-0000-000000000000"), null, "Bireysel Kredi Sureci", "tr-TR", new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "retail-loan",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1190), new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1200) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-lifecyle",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1310), new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1320) });
        }
    }
}
