using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSignalRData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "signalrdata");

            migrationBuilder.CreateTable(
                name: "SignalRResponses",
                schema: "signalrdata",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstanceId = table.Column<string>(type: "text", nullable: true),
                    source = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    subject = table.Column<string>(type: "text", nullable: true),
                    data = table.Column<string>(type: "text", nullable: true),
                    mfatype = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    datacontenttype = table.Column<string>(type: "text", nullable: true),
                    specversion = table.Column<string>(type: "text", nullable: true),
                    deviceId = table.Column<string>(type: "text", nullable: true),
                    userId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignalRResponses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignalRResponses",
                schema: "signalrdata");
        }
    }
}
