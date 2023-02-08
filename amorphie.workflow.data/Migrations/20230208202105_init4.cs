using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowEntity_Workflows_WorkflowName",
                table: "WorkflowEntity");

            migrationBuilder.AlterColumn<string>(
                name: "WorkflowName",
                table: "WorkflowEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Translation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_Translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translation_Workflows_WorkflowName",
                        column: x => x.WorkflowName,
                        principalTable: "Workflows",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translation_WorkflowName",
                table: "Translation",
                column: "WorkflowName");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowEntity_Workflows_WorkflowName",
                table: "WorkflowEntity",
                column: "WorkflowName",
                principalTable: "Workflows",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowEntity_Workflows_WorkflowName",
                table: "WorkflowEntity");

            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.AlterColumn<string>(
                name: "WorkflowName",
                table: "WorkflowEntity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowEntity_Workflows_WorkflowName",
                table: "WorkflowEntity",
                column: "WorkflowName",
                principalTable: "Workflows",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
