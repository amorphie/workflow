using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class Exporter_Tables_Modify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Deployments",
                schema: "exporter",
                table: "Deployments");

            migrationBuilder.DropColumn(
                name: "RedisId",
                schema: "exporter",
                table: "ProcessInstances");

            migrationBuilder.DropColumn(
                name: "RedisId",
                schema: "exporter",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "RedisId",
                schema: "exporter",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Key",
                schema: "exporter",
                table: "Deployments");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstanceId",
                schema: "exporter",
                table: "MessageSubscriptions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resource",
                schema: "exporter",
                table: "Deployments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deployments",
                schema: "exporter",
                table: "Deployments",
                column: "ResourceName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Deployments",
                schema: "exporter",
                table: "Deployments");

            migrationBuilder.DropColumn(
                name: "Resource",
                schema: "exporter",
                table: "Deployments");

            migrationBuilder.AddColumn<string>(
                name: "RedisId",
                schema: "exporter",
                table: "ProcessInstances",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RedisId",
                schema: "exporter",
                table: "Process",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "InstanceId",
                schema: "exporter",
                table: "MessageSubscriptions",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "RedisId",
                schema: "exporter",
                table: "Messages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Key",
                schema: "exporter",
                table: "Deployments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deployments",
                schema: "exporter",
                table: "Deployments",
                column: "Key");
        }
    }
}
