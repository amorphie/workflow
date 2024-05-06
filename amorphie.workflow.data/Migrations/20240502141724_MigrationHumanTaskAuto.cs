using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationHumanTaskAuto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HumanTaskAppTransition",
                table: "HumanTasks",
                newName: "DenyTransitionName");

            migrationBuilder.AddColumn<string>(
                name: "AppTransitionName",
                table: "HumanTasks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AutoTransitionName",
                table: "HumanTasks",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppTransitionName",
                table: "HumanTasks");

            migrationBuilder.DropColumn(
                name: "AutoTransitionName",
                table: "HumanTasks");

            migrationBuilder.RenameColumn(
                name: "DenyTransitionName",
                table: "HumanTasks",
                newName: "HumanTaskAppTransition");
        }
    }
}
