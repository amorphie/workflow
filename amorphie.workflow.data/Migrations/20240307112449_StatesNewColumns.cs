using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class StatesNewColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translation_States_StateName",
                table: "Translation");

            migrationBuilder.DropIndex(
                name: "IX_Translation_StateName",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "StateName",
                table: "Translation");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "StateToStates",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Kind",
                table: "States",
                type: "integer",
                nullable: false,
                defaultValue: 10001,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "FlowName",
                table: "States",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "StateToStates");

            migrationBuilder.DropColumn(
                name: "FlowName",
                table: "States");

            migrationBuilder.DropColumn(
                name: "navigationType",
                schema: "signalrdata",
                table: "SignalRResponses");


            migrationBuilder.AddColumn<string>(
                name: "StateName",
                table: "Translation",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kind",
                table: "States",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 10001);

            migrationBuilder.CreateIndex(
                name: "IX_Translation_StateName",
                table: "Translation",
                column: "StateName");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_States_StateName",
                table: "Translation",
                column: "StateName",
                principalTable: "States",
                principalColumn: "Name");
        }
    }
}
