using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourBookingApp.Migrations
{
    public partial class Tourbooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravellerId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    PersonsCount = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "UserTourBookings",
                columns: table => new
                {
                    BookingUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    BookingUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingUserPhnNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingUserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingUserGender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTourBookings", x => x.BookingUserId);
                    table.ForeignKey(
                        name: "FK_UserTourBookings_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTourBookings_BookingId",
                table: "UserTourBookings",
                column: "BookingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTourBookings");

            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
