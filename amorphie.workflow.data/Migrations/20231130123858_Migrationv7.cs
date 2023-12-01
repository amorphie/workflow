using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class Migrationv7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UiForms_States_stateName",
                table: "UiForms");

            migrationBuilder.DropForeignKey(
                name: "FK_UiForms_Transitions_transitionName",
                table: "UiForms");

            migrationBuilder.RenameColumn(
                name: "typeofUiEnum",
                table: "UiForms",
                newName: "TypeofUiEnum");

            migrationBuilder.RenameColumn(
                name: "transitionName",
                table: "UiForms",
                newName: "TransitionName");

            migrationBuilder.RenameColumn(
                name: "stateName",
                table: "UiForms",
                newName: "StateName");

            migrationBuilder.RenameIndex(
                name: "IX_UiForms_transitionName",
                table: "UiForms",
                newName: "IX_UiForms_TransitionName");

            migrationBuilder.RenameIndex(
                name: "IX_UiForms_stateName",
                table: "UiForms",
                newName: "IX_UiForms_StateName");

            migrationBuilder.AlterColumn<int>(
                name: "TypeofUiEnum",
                table: "UiForms",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Navigation",
                table: "UiForms",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "requireData",
                table: "Transitions",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "transitionButtonType",
                table: "Transitions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UiForms_States_StateName",
                table: "UiForms",
                column: "StateName",
                principalTable: "States",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_UiForms_Transitions_TransitionName",
                table: "UiForms",
                column: "TransitionName",
                principalTable: "Transitions",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UiForms_States_StateName",
                table: "UiForms");

            migrationBuilder.DropForeignKey(
                name: "FK_UiForms_Transitions_TransitionName",
                table: "UiForms");

            migrationBuilder.DropColumn(
                name: "Navigation",
                table: "UiForms");

            migrationBuilder.DropColumn(
                name: "requireData",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "transitionButtonType",
                table: "Transitions");

            migrationBuilder.RenameColumn(
                name: "TypeofUiEnum",
                table: "UiForms",
                newName: "typeofUiEnum");

            migrationBuilder.RenameColumn(
                name: "TransitionName",
                table: "UiForms",
                newName: "transitionName");

            migrationBuilder.RenameColumn(
                name: "StateName",
                table: "UiForms",
                newName: "stateName");

            migrationBuilder.RenameIndex(
                name: "IX_UiForms_TransitionName",
                table: "UiForms",
                newName: "IX_UiForms_transitionName");

            migrationBuilder.RenameIndex(
                name: "IX_UiForms_StateName",
                table: "UiForms",
                newName: "IX_UiForms_stateName");

            migrationBuilder.AlterColumn<int>(
                name: "typeofUiEnum",
                table: "UiForms",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UiForms_States_stateName",
                table: "UiForms",
                column: "stateName",
                principalTable: "States",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_UiForms_Transitions_transitionName",
                table: "UiForms",
                column: "transitionName",
                principalTable: "Transitions",
                principalColumn: "Name");
        }
    }
}
