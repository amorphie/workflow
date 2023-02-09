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
            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("14d5dcc9-4e45-48dc-b131-69b0875f6370"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("7cf9bc13-d33e-4d86-a164-cf6f79dac7f5"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("9aa6ae1a-487f-4a82-82bd-7ccf3bf2fed8"));

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumn: "Id",
                keyValue: new Guid("e6c8ef3c-cca8-4f08-9ed1-8dbca0b32d46"));

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "WorkflowName_Title", "WorkflowName_Transition" },
                values: new object[,]
                {
                    { new Guid("8612fe18-3c55-4981-badd-b57d8991fc80"), new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1590), new Guid("00000000-0000-0000-0000-000000000000"), null, "Retail Loan Process", "en-EN", new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1590), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "retail-loan", null },
                    { new Guid("b2bdeb4a-4cb7-47a9-b7d6-6edb0bbaabe2"), new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1630), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1630), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("f433a881-667d-4d40-a5fd-7cb8a92c28ce"), new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1570), new Guid("00000000-0000-0000-0000-000000000000"), null, "Bireysel Kredi Sureci", "tr-TR", new DateTime(2023, 2, 9, 8, 3, 2, 101, DateTimeKind.Utc).AddTicks(1570), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, "retail-loan", null },
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Translation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CreatedByBehalfOf", "Label", "Language", "ModifiedAt", "ModifiedBy", "ModifiedByBehalfOf", "StateName_Description", "StateName_Title", "WorkflowName_Title", "WorkflowName_Transition" },
                values: new object[,]
                {
                    { new Guid("14d5dcc9-4e45-48dc-b131-69b0875f6370"), new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4380), new Guid("00000000-0000-0000-0000-000000000000"), null, "Bireysel Kredi Sureci", "tr-TR", new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4390), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("7cf9bc13-d33e-4d86-a164-cf6f79dac7f5"), new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4440), new Guid("00000000-0000-0000-0000-000000000000"), null, "User State Process", "en-EN", new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4440), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("9aa6ae1a-487f-4a82-82bd-7ccf3bf2fed8"), new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4400), new Guid("00000000-0000-0000-0000-000000000000"), null, "Retail Loan Process", "en-EN", new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4400), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null },
                    { new Guid("e6c8ef3c-cca8-4f08-9ed1-8dbca0b32d46"), new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4430), new Guid("00000000-0000-0000-0000-000000000000"), null, "Kullanici Statu Akisi", "tr-TR", new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4430), new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "retail-loan",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4310), new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "Workflows",
                keyColumn: "Name",
                keyValue: "user-lifecyle",
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4410), new DateTime(2023, 2, 9, 7, 36, 34, 96, DateTimeKind.Utc).AddTicks(4410) });
        }
    }
}
