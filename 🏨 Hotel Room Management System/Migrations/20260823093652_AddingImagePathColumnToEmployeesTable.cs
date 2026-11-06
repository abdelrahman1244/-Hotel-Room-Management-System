using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace __Hotel_Room_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddingImagePathColumnToEmployeesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Customers");
        }
    }
}
