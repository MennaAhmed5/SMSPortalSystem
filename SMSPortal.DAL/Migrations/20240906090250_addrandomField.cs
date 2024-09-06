using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSPortal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addrandomField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reports_submissionId",
                table: "Reports");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reports_submissionId",
                table: "Reports",
                column: "submissionId",
                unique: true);
        }
    }
}
