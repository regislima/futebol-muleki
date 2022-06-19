using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muleki.Infra.Migrations
{
    public partial class Score_UpdateRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "players",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_at",
                value: new DateTime(2022, 6, 4, 16, 58, 23, 11, DateTimeKind.Local).AddTicks(6188));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "players",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_at",
                value: new DateTime(2022, 5, 30, 22, 4, 30, 804, DateTimeKind.Local).AddTicks(2826));
        }
    }
}
