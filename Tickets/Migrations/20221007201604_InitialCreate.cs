using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "segments",
                columns: table => new
                {
                    ticket_number = table.Column<string>(type: "text", nullable: false),
                    serial_number = table.Column<int>(type: "integer", nullable: false),
                    operation_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    operation_time_timezone = table.Column<short>(type: "smallint", nullable: false),
                    airline_code = table.Column<string>(type: "text", nullable: false),
                    flight_num = table.Column<long>(type: "bigint", nullable: false),
                    depart_place = table.Column<string>(type: "text", nullable: false),
                    depart_datetime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    depart_datetime_timezone = table.Column<short>(type: "smallint", nullable: false),
                    arrive_place = table.Column<string>(type: "text", nullable: false),
                    arrive_datetime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    arrive_datetime_timezone = table.Column<short>(type: "smallint", nullable: false),
                    pnr_id = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSerial", x => new { x.ticket_number, x.serial_number });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "segments");
        }
    }
}
