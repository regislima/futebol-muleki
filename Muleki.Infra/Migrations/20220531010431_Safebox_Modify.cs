using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muleki.Infra.Migrations
{
    public partial class Safebox_Modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "safeboxes");

            migrationBuilder.AddColumn<decimal>(
                name: "income",
                table: "safeboxes",
                type: "DECIMAL(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "players",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_at",
                value: new DateTime(2022, 5, 30, 22, 4, 30, 804, DateTimeKind.Local).AddTicks(2826));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "income",
                table: "safeboxes");

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
                value: new DateTime(2022, 5, 29, 23, 48, 4, 373, DateTimeKind.Local).AddTicks(4784));
        }
    }
}
