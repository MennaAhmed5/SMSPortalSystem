using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSPortal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddsubmissionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "submissionId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_submissionId",
                table: "Reports",
                column: "submissionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reports_submissionId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "submissionId",
                table: "Reports");
        }
    }
}
