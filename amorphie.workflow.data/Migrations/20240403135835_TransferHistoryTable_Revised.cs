using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class TransferHistoryTable_Revised : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkflowName",
                schema: "transfer",
                table: "TransferHistories",
                newName: "TransferringType");

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                schema: "transfer",
                table: "TransferHistories",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectName",
                schema: "transfer",
                table: "TransferHistories");

            migrationBuilder.RenameColumn(
                name: "TransferringType",
                schema: "transfer",
                table: "TransferHistories",
                newName: "WorkflowName");
        }
    }
}
