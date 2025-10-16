using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class stringuseremail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "TrackEmail",
                type: "varchar(333)",
                maxLength: 333,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "TrackEmail");
        }
    }
}
