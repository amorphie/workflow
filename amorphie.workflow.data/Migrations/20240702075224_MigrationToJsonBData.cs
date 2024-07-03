using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationToJsonBData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "InstanceTransitions",
                type: "tsvector",
                nullable: true,
                computedColumnSql: "to_tsvector('english', coalesce(\"FromStateName\", '') || ' ' || coalesce(\"ToStateName\", '') || ' ' || coalesce(\"TransitionName\", ''))",
                stored: true,
                oldClrType: typeof(NpgsqlTsVector),
                oldType: "tsvector",
                oldNullable: true,
                oldComputedColumnSql: "to_tsvector('english', coalesce(\"FromStateName\", '') || ' ' || coalesce(\"ToStateName\", '') || ' ' || coalesce(\"EntityData\", '') || ' ' || coalesce(\"AdditionalData\", '') || ' ' || coalesce(\"TransitionName\", ''))",
                oldStored: true);

            // migrationBuilder.AlterColumn<string>(
            //     name: "EntityData",
            //     table: "InstanceTransitions",
            //     type: "jsonb",
            //     nullable: false,
            //     oldClrType: typeof(string),
            //     oldType: "text");

            // migrationBuilder.AlterColumn<string>(
            //     name: "AdditionalData",
            //     table: "InstanceTransitions",
            //     type: "jsonb",
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldType: "text",
            //     oldNullable: true);

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "InstanceTransitions",
                type: "tsvector",
                nullable: true,
                computedColumnSql: "to_tsvector('english', coalesce(\"FromStateName\", '') || ' ' || coalesce(\"ToStateName\", '') || ' ' || coalesce(\"EntityData\", '') || ' ' || coalesce(\"AdditionalData\", '') || ' ' || coalesce(\"TransitionName\", ''))",
                stored: true,
                oldClrType: typeof(NpgsqlTsVector),
                oldType: "tsvector",
                oldNullable: true,
                oldComputedColumnSql: "to_tsvector('english', coalesce(\"FromStateName\", '') || ' ' || coalesce(\"ToStateName\", '') || ' ' || coalesce(\"TransitionName\", ''))",
                oldStored: true);

            // migrationBuilder.AlterColumn<string>(
            //     name: "EntityData",
            //     table: "InstanceTransitions",
            //     type: "text",
            //     nullable: false,
            //     oldClrType: typeof(string),
            //     oldType: "jsonb");

            // migrationBuilder.AlterColumn<string>(
            //     name: "AdditionalData",
            //     table: "InstanceTransitions",
            //     type: "text",
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldType: "jsonb",
            //     oldNullable: true);


        }
    }
}
