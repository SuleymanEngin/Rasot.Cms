using Microsoft.EntityFrameworkCore.Migrations;

namespace Rasot.Data.Migrations
{
    public partial class ChangeBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Deleted",
                table: "Category",
                nullable: false,
                oldClrType: typeof(short));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Deleted",
                table: "Category",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
