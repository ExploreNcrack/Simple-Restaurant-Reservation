using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantReservation.Data.Migrations
{
    public partial class Add_NumberOfPeople_To_Reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfPeople",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPeople",
                table: "Reservations");
        }
    }
}
