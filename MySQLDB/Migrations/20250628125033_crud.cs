using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class crud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "User",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Role",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Role",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Role",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "LeadHistory",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "LeadHistory",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "LeadHistory",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "LeadHistory",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Lead",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Lead",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUnsubscribed",
                table: "Lead",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Lead",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateDeleted", "DateUpdated" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateDeleted", "DateUpdated" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateDeleted", "DateUpdated" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateDeleted", "DateUpdated" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateDeleted", "DateUpdated" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateDeleted", "DateUpdated" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "LeadHistory");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "LeadHistory");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "LeadHistory");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "DateUnsubscribed",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Lead");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "LeadHistory",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");
        }
    }
}
