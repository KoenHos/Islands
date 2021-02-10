using Microsoft.EntityFrameworkCore.Migrations;

namespace Aruba.Data.Migrations
{
    public partial class ExtendElementTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtomicNumber",
                table: "Elements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Elements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtomicNumber",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Elements");
        }
    }
}
