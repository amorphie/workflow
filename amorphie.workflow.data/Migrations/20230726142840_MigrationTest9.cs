using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationTest9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransitionName_HistoryForm",
                table: "Translation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkflowName_HistoryForm",
                table: "Translation",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Translation_TransitionName_HistoryForm",
                table: "Translation",
                column: "TransitionName_HistoryForm");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_WorkflowName_HistoryForm",
                table: "Translation",
                column: "WorkflowName_HistoryForm");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Transitions_TransitionName_HistoryForm",
                table: "Translation",
                column: "TransitionName_HistoryForm",
                principalTable: "Transitions",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Workflows_WorkflowName_HistoryForm",
                table: "Translation",
                column: "WorkflowName_HistoryForm",
                principalTable: "Workflows",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Transitions_TransitionName_HistoryForm",
                table: "Translation");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Workflows_WorkflowName_HistoryForm",
                table: "Translation");

            migrationBuilder.DropIndex(
                name: "IX_Translation_TransitionName_HistoryForm",
                table: "Translation");

            migrationBuilder.DropIndex(
                name: "IX_Translation_WorkflowName_HistoryForm",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "TransitionName_HistoryForm",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "WorkflowName_HistoryForm",
                table: "Translation");
        }
    }
}
