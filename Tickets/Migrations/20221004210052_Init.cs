using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tickets.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_segments",
                table: "segments");

            migrationBuilder.DropColumn(
                name: "key",
                table: "segments");

            migrationBuilder.AddColumn<string>(
                name: "ticket_number",
                table: "segments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "serial_number",
                table: "segments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "airline_code",
                table: "segments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "arrive_datetime",
                table: "segments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "arrive_place",
                table: "segments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "depart_datetime",
                table: "segments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "depart_place",
                table: "segments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "flight_num",
                table: "segments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "pnr_id",
                table: "segments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "segments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketSerial",
                table: "segments",
                columns: new[] { "ticket_number", "serial_number" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketSerial",
                table: "segments");

            migrationBuilder.DropColumn(
                name: "ticket_number",
                table: "segments");

            migrationBuilder.DropColumn(
                name: "serial_number",
                table: "segments");

            migrationBuilder.DropColumn(
                name: "airline_code",
                table: "segments");

            migrationBuilder.DropColumn(
                name: "arrive_datetime",
                table: "segments");

            migrationBuilder.DropColumn(
                name: "arrive_place",
                table: "segments");

            migrationBuilder.DropColumn(
                name: "depart_datetime",
                table: "segments");

            migrationBuilder.DropColumn(
                name: "depart_place",
                table: "segments");

            migrationBuilder.DropColumn(
                name: "flight_num",
                table: "segments");

            migrationBuilder.DropColumn(
                name: "pnr_id",
                table: "segments");

            migrationBuilder.DropColumn(
                name: "state",
                table: "segments");

            migrationBuilder.AddColumn<int>(
                name: "key",
                table: "segments",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_segments",
                table: "segments",
                column: "key");
        }
    }
}
