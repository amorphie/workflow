using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSignalRDataToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "requestId",
                schema: "signalrdata",
                table: "SignalRResponses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tokenId",
                schema: "signalrdata",
                table: "SignalRResponses",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "requestId",
                schema: "signalrdata",
                table: "SignalRResponses");

            migrationBuilder.DropColumn(
                name: "tokenId",
                schema: "signalrdata",
                table: "SignalRResponses");
        }
    }
}
