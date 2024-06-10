using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInstanceTransitionVector : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "InstanceTransitions",
                type: "tsvector",
                nullable: true,
                computedColumnSql: "to_tsvector('english', coalesce(\"FromStateName\", '') || ' ' || coalesce(\"ToStateName\", '') || ' ' || coalesce(\"EntityData\", '') || ' ' || coalesce(\"AdditionalData\", '') || ' ' || coalesce(\"TransitionName\", ''))",
                stored: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransitions_SearchVector",
                table: "InstanceTransitions",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InstanceTransitions_SearchVector",
                table: "InstanceTransitions");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "InstanceTransitions");
        }
    }
}
