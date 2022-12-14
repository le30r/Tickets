// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tickets.Data;

#nullable disable

namespace Tickets.Migrations
{
    [DbContext(typeof(TicketsContext))]
    partial class TicketsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Tickets.Model.Segment", b =>
                {
                    b.Property<string>("TicketNumber")
                        .HasColumnType("text")
                        .HasColumnName("ticket_number");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("integer")
                        .HasColumnName("serial_number");

                    b.Property<string>("AirlineCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("airline_code");

                    b.Property<DateTime>("ArriveDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("arrive_datetime");

                    b.Property<short>("ArriveDateTimeTimezone")
                        .HasColumnType("smallint")
                        .HasColumnName("arrive_datetime_timezone");

                    b.Property<string>("ArrivePlace")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("arrive_place");

                    b.Property<DateTime>("DepartDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("depart_datetime");

                    b.Property<short>("DepartDateTimeTimezone")
                        .HasColumnType("smallint")
                        .HasColumnName("depart_datetime_timezone");

                    b.Property<string>("DepartPlace")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("depart_place");

                    b.Property<long>("FlightNum")
                        .HasColumnType("bigint")
                        .HasColumnName("flight_num");

                    b.Property<DateTime>("OperationTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("operation_time");

                    b.Property<short>("OperationTimeTimezone")
                        .HasColumnType("smallint")
                        .HasColumnName("operation_time_timezone");

                    b.Property<string>("PnrId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("pnr_id");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("state");

                    b.HasKey("TicketNumber", "SerialNumber")
                        .HasName("PK_TicketSerial");

                    b.ToTable("segments", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
