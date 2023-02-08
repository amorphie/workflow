using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class init11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransitionName",
                table: "Translation",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Transition",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    FromStateName = table.Column<string>(type: "text", nullable: true),
                    ToStateName = table.Column<string>(type: "text", nullable: true),
                    Form = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Process = table.Column<string>(type: "text", nullable: true),
                    Gateway = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transition", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Transition_State_FromStateName",
                        column: x => x.FromStateName,
                        principalTable: "State",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Transition_State_ToStateName",
                        column: x => x.ToStateName,
                        principalTable: "State",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translation_TransitionName",
                table: "Translation",
                column: "TransitionName");

            migrationBuilder.CreateIndex(
                name: "IX_Transition_FromStateName",
                table: "Transition",
                column: "FromStateName");

            migrationBuilder.CreateIndex(
                name: "IX_Transition_ToStateName",
                table: "Transition",
                column: "ToStateName");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Transition_TransitionName",
                table: "Translation",
                column: "TransitionName",
                principalTable: "Transition",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Transition_TransitionName",
                table: "Translation");

            migrationBuilder.DropTable(
                name: "Transition");

            migrationBuilder.DropIndex(
                name: "IX_Translation_TransitionName",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "TransitionName",
                table: "Translation");
        }
    }
}
