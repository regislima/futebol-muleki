using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muleki.Infra.Migrations
{
    public partial class Score_RemoveCollumnData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "scores");

            migrationBuilder.UpdateData(
                table: "players",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_at",
                value: new DateTime(2022, 7, 3, 12, 25, 50, 499, DateTimeKind.Local).AddTicks(4341));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "scores",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "players",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_at",
                value: new DateTime(2022, 6, 4, 16, 58, 23, 11, DateTimeKind.Local).AddTicks(6188));
        }
    }
}
