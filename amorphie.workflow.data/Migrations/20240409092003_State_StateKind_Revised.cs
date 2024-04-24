using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations;
/// <inheritdoc />
public partial class State_StateKind_Revised : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<int>(
            name: "Kind",
            table: "States",
            type: "integer",
            nullable: true,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "integer",
            oldNullable: true,
            oldDefaultValue: 10001);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<int>(
            name: "Kind",
            table: "States",
            type: "integer",
            nullable: true,
            defaultValue: 10001,
            oldClrType: typeof(int),
            oldType: "integer",
            oldNullable: true,
            oldDefaultValue: 0);
    }
}

