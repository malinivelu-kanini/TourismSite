using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourPackageImagesApp.Migrations
{
    /// <inheritdoc />
    public partial class pictu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tourr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourr", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourImagess",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    ImagePaths = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourImagess", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_TourImagess_Tourr_TourId",
                        column: x => x.TourId,
                        principalTable: "Tourr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourImagess_TourId",
                table: "TourImagess",
                column: "TourId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourImagess");

            migrationBuilder.DropTable(
                name: "Tourr");
        }
    }
}
