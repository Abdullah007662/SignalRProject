using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRDataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class MigContactrevize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FooterTitle",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpenDays",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpenDaysDescription",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpenHours",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterTitle",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OpenDays",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OpenDaysDescription",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OpenHours",
                table: "Contacts");
        }
    }
}
