using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class Migrationv8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "Instances",
                type: "tsvector",
                nullable: true,
                computedColumnSql: "to_tsvector('english', coalesce(\"WorkflowName\", '') || ' ' || coalesce(\"ZeebeFlowName\", '') || ' ' || coalesce(\"EntityName\", '') || ' ' || coalesce(\"StateName\", ''))",
                stored: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instances_SearchVector",
                table: "Instances",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Instances_SearchVector",
                table: "Instances");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "Instances");
        }
    }
}
