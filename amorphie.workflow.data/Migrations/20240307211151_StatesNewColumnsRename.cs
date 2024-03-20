using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class StatesNewColumnsRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StateToStates_States_StateName",
                table: "StateToStates");

            migrationBuilder.RenameColumn(
                name: "StateName",
                table: "StateToStates",
                newName: "FromStateName");

            migrationBuilder.RenameIndex(
                name: "IX_StateToStates_StateName",
                table: "StateToStates",
                newName: "IX_StateToStates_FromStateName");

            migrationBuilder.AddForeignKey(
                name: "FK_StateToStates_States_FromStateName",
                table: "StateToStates",
                column: "FromStateName",
                principalTable: "States",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StateToStates_States_FromStateName",
                table: "StateToStates");

            migrationBuilder.RenameColumn(
                name: "FromStateName",
                table: "StateToStates",
                newName: "StateName");

            migrationBuilder.RenameIndex(
                name: "IX_StateToStates_FromStateName",
                table: "StateToStates",
                newName: "IX_StateToStates_StateName");

            migrationBuilder.AddForeignKey(
                name: "FK_StateToStates_States_StateName",
                table: "StateToStates",
                column: "StateName",
                principalTable: "States",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
