using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class Migrationv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StateName_PublicForm",
                table: "Translation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublicForm",
                table: "States",
                type: "boolean",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Translation_StateName_PublicForm",
                table: "Translation",
                column: "StateName_PublicForm");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_States_StateName_PublicForm",
                table: "Translation",
                column: "StateName_PublicForm",
                principalTable: "States",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translation_States_StateName_PublicForm",
                table: "Translation");

            migrationBuilder.DropIndex(
                name: "IX_Translation_StateName_PublicForm",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "StateName_PublicForm",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "IsPublicForm",
                table: "States");
        }
    }
}
