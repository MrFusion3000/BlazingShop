using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazingShop.Data.Migrations
{
    public partial class addReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reservation",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerPhone",
                table: "Appointments",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reservation",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerPhone",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 12);
        }
    }
}
