using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSignalRDataPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "navigationType",
                schema: "signalrdata",
                table: "SignalRResponses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pageUrl",
                schema: "signalrdata",
                table: "SignalRResponses",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "navigationType",
                schema: "signalrdata",
                table: "SignalRResponses");

            migrationBuilder.DropColumn(
                name: "pageUrl",
                schema: "signalrdata",
                table: "SignalRResponses");
        }
    }
}
