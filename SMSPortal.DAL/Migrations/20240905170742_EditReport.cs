using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSPortal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Reports",
                newName: "PhoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Reports",
                newName: "phoneNumber");
        }
    }
}
