using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations;
/// <inheritdoc />
public partial class JobBatchTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<int>(
            name: "Kind",
            table: "States",
            type: "integer",
            nullable: true,
            defaultValue: 10001,
            oldClrType: typeof(int),
            oldType: "integer",
            oldDefaultValue: 10001);

        migrationBuilder.CreateTable(
            name: "JobBatchs",
            schema: "exporter",
            columns: table => new
            {
                Key = table.Column<long>(type: "bigint", nullable: false),
                ElementInstanceKey = table.Column<long>(type: "bigint", nullable: false),
                Timestamp = table.Column<long>(type: "bigint", nullable: false),
                EndTimestamp = table.Column<long>(type: "bigint", nullable: false),
                Retries = table.Column<int>(type: "integer", nullable: false),
                BpmnProcessId = table.Column<string>(type: "text", nullable: true),
                ElementType = table.Column<string>(type: "text", nullable: true),
                Intent = table.Column<string>(type: "text", nullable: true),
                ProcessInstanceKey = table.Column<long>(type: "bigint", nullable: false),
                Variables = table.Column<string>(type: "text", nullable: true),
                CustomHeaders = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_JobBatchs", x => new { x.Key, x.ElementInstanceKey });
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "JobBatchs",
            schema: "exporter");

        migrationBuilder.AlterColumn<int>(
            name: "Kind",
            table: "States",
            type: "integer",
            nullable: false,
            defaultValue: 10001,
            oldClrType: typeof(int),
            oldType: "integer",
            oldNullable: true,
            oldDefaultValue: 10001);
    }
}
