using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazingShop.Data.Migrations
{
    public partial class changeFieldReservationToBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Reservation",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Reservation",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
