using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class Migrationv12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserReference",
                table: "Instances",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TransitionRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransitionName = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransitionRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransitionRoles_Transitions_TransitionName",
                        column: x => x.TransitionName,
                        principalTable: "Transitions",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransitionRoles_TransitionName",
                table: "TransitionRoles",
                column: "TransitionName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransitionRoles");

            migrationBuilder.DropColumn(
                name: "UserReference",
                table: "Instances");
        }
    }
}
