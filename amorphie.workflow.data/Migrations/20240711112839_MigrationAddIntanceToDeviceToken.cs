using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAddIntanceToDeviceToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "XDeviceId",
                table: "Instances",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "XTokenId",
                table: "Instances",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "XDeviceId",
                table: "Instances");

            migrationBuilder.DropColumn(
                name: "XTokenId",
                table: "Instances");
        }
    }
}
