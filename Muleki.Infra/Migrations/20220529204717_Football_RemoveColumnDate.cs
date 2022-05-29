using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muleki.Infra.Migrations
{
    public partial class Football_RemoveColumnDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "income",
                table: "safeboxes");

            migrationBuilder.DropColumn(
                name: "date",
                table: "footballs");

            migrationBuilder.AlterColumn<decimal>(
                name: "expense",
                table: "safeboxes",
                type: "DECIMAL(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(65,30)");

            migrationBuilder.AddColumn<sbyte>(
                name: "type",
                table: "safeboxes",
                type: "TINYINT",
                maxLength: 1,
                nullable: false,
                defaultValue: (sbyte)0);

            migrationBuilder.UpdateData(
                table: "players",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_at",
                value: new DateTime(2022, 5, 29, 17, 47, 17, 8, DateTimeKind.Local).AddTicks(7991));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "safeboxes");

            migrationBuilder.AlterColumn<decimal>(
                name: "expense",
                table: "safeboxes",
                type: "DECIMAL(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(5,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "income",
                table: "safeboxes",
                type: "DECIMAL(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "footballs",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "players",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_at",
                value: new DateTime(2022, 5, 9, 23, 32, 59, 774, DateTimeKind.Local).AddTicks(1862));
        }
    }
}
