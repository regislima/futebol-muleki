using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muleki.Infra.Migrations
{
    public partial class InitialMigration_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "players");

            migrationBuilder.AddColumn<string>(
                name: "password_hash",
                table: "players",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "players",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password_hash", "password_salt" },
                values: new object[] { new DateTime(2022, 5, 9, 23, 32, 59, 774, DateTimeKind.Local).AddTicks(1862), "39kX8Xb50tg4bMTpGTNQnBB548+J95bjlFi0bA2Qm6dakj3cim7xLtTDxINUd6PHdRYckEoranIweWyvg3n30w==", "GU2xX9kpeVjBEBTi9hAaAK2tNmVXS4gbnXjrcgqHamwIMdOBsqAvquYYHVr55pp6bZ56vZ28gH31d2GZCZz8SdVT7oreUBRewI4nEv2rAhkY07JEF+oHU+DTO+WbYFDqh2Qzj+JPYUuPrMsOBl+LHp4RsKGyAduIOLWh4yKbaoU=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_hash",
                table: "players");

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "players",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "players",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password_salt", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 5, 9, 22, 1, 31, 544, DateTimeKind.Local).AddTicks(3350), "mV/+IST6+80UcjdFuaUN4CZ7mcHiClpYndmlayqk8nNYH025/PE+P/+0ulgG49fQB0ZxkH/98arOA1of40Oo7g==", "gGOO/obFwf50zaJ9LhZ0fMnV8ztfLicMBcaIhEswjK+0IdNQaN0ezEmVCk/T1PTnK/6Ahz8iKmtAGjmTq/ewKPopMKLBMC0G5rAXJNeZs1db7OXoip0zL82vmKucJhNDgiKXBpy/SGxKWI81vrcCKzY+9VZIOQLnuBTrezsZPkg=" });
        }
    }
}
