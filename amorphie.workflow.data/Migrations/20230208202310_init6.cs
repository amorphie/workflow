using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StateName",
                table: "Translation",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    WorkflowName = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Name);
                    table.ForeignKey(
                        name: "FK_State_Workflows_WorkflowName",
                        column: x => x.WorkflowName,
                        principalTable: "Workflows",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translation_StateName",
                table: "Translation",
                column: "StateName");

            migrationBuilder.CreateIndex(
                name: "IX_State_WorkflowName",
                table: "State",
                column: "WorkflowName");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_State_StateName",
                table: "Translation",
                column: "StateName",
                principalTable: "State",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translation_State_StateName",
                table: "Translation");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropIndex(
                name: "IX_Translation_StateName",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "StateName",
                table: "Translation");
        }
    }
}
