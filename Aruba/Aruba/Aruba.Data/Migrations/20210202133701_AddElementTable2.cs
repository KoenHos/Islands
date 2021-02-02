using Microsoft.EntityFrameworkCore.Migrations;

namespace Aruba.Data.Migrations
{
    public partial class AddElementTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HolidayCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HolidayPackages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: true),
                    MedicalPrecautions = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImageThumbnailUrl = table.Column<string>(nullable: true),
                    IsPackeOfTheWeek = table.Column<bool>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    HolidayCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolidayPackages_HolidayCategories_HolidayCategoryId",
                        column: x => x.HolidayCategoryId,
                        principalTable: "HolidayCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPackages_HolidayCategoryId",
                table: "HolidayPackages",
                column: "HolidayCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "HolidayPackages");

            migrationBuilder.DropTable(
                name: "HolidayCategories");
        }
    }
}
