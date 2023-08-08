using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationsTest6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
       
            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransitions_TransitionName",
                table: "InstanceTransitions",
                column: "TransitionName");

            migrationBuilder.AddForeignKey(
                name: "FK_InstanceTransitions_Transitions_TransitionName",
                table: "InstanceTransitions",
                column: "TransitionName",
                principalTable: "Transitions",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstanceTransitions_Transitions_TransitionName",
                table: "InstanceTransitions");

            migrationBuilder.DropIndex(
                name: "IX_InstanceTransitions_TransitionName",
                table: "InstanceTransitions");
        }
    }
}
