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
            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("8612fe18-3c55-4981-badd-b57d8991fc80"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("b2bdeb4a-4cb7-47a9-b7d6-6edb0bbaabe2"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("f433a881-667d-4d40-a5fd-7cb8a92c28ce"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("fbb3e9c6-8860-474f-a2bc-a48d111818de"));

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Name", "BaseStatus", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "Type", "WorkflowName" },
                values: new object[] { "retail-loan-start", 0, new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1300), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1300), new Guid("00000000-0000-0000-0000-000000000000"), null, 100, null });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "WorkflowName_Title", "WorkflowName_Transition" },
                values: new object[,]
                {
                    { new Guid("5eccfe93-d688-4f2b-b879-c07888f3a4e9"), new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1290), new Guid("00000000-0000-0000-0000-000000000000"), null, "Retail Loan Process", "en-EN", new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1290), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "retail-loan", null },
                    { new Guid("669a0a6b-c157-425c-9152-e20b5a4f8be8"), new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1330), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("a848446b-9771-46cf-8acb-ac48c1cdd8ae"), new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1340), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1340), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("fcec5f93-fba5-42e7-9176-c21289f7f32a"), new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1280), new Guid("00000000-0000-0000-0000-000000000000"), null, "Bireysel Kredi Sureci", "tr-TR", new DateTime(2023, 2, 9, 8, 23, 5, 908, DateTimeKind.Utc).AddTicks(1280), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "retail-loan", null }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "Name",
                keyValue: "retail-loan-start");

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

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "WorkflowName_Title", "WorkflowName_Transition" },
                values: new object[,]
                {
                    { new Guid("8612fe18-3c55-4981-badd-b57d8991fc80"), new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1590), new Guid("00000000-0000-0000-0000-000000000000"), null, "Retail Loan Process", "en-EN", new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1590), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("b2bdeb4a-4cb7-47a9-b7d6-6edb0bbaabe2"), new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1630), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("f433a881-667d-4d40-a5fd-7cb8a92c28ce"), new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Bireysel Kredi Sureci", "tr-TR", new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1570), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("fbb3e9c6-8860-474f-a2bc-a48d111818de"), new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1610), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1610), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "retail-loan",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1490), new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1490) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-lifecyle",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1600), new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1600) });
        }
    }
}
