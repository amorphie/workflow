using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class Migrationv10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubWorkflowName",
                table: "States",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_SubWorkflowName",
                table: "States",
                column: "SubWorkflowName");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Workflows_SubWorkflowName",
                table: "States",
                column: "SubWorkflowName",
                principalTable: "Workflows",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Workflows_SubWorkflowName",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_SubWorkflowName",
                table: "States");

            migrationBuilder.DropColumn(
                name: "SubWorkflowName",
                table: "States");
        }
    }
}
