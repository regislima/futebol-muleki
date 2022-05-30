using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muleki.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "footballs",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    updated_at = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_footballs", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nick = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password_hash = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password_salt = table.Column<string>(type: "VARCHAR(240)", maxLength: 240, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role = table.Column<sbyte>(type: "TINYINT", maxLength: 1, nullable: false),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    updated_at = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "safeboxes",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<sbyte>(type: "TINYINT", maxLength: 1, nullable: false),
                    expense = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    FootballId = table.Column<long>(type: "BIGINT", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    updated_at = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_safeboxes", x => x.id);
                    table.ForeignKey(
                        name: "FK_safeboxes_footballs_FootballId",
                        column: x => x.FootballId,
                        principalTable: "footballs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "player_football",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<long>(type: "BIGINT", nullable: false),
                    FootballId = table.Column<long>(type: "BIGINT", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    updated_at = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_football", x => x.id);
                    table.ForeignKey(
                        name: "FK_player_football_footballs_FootballId",
                        column: x => x.FootballId,
                        principalTable: "footballs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_player_football_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "scores",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    attribute = table.Column<sbyte>(type: "TINYINT", nullable: false),
                    note = table.Column<decimal>(type: "DECIMAL(3,2)", maxLength: 10, nullable: false),
                    quantity = table.Column<short>(type: "SMALLINT", nullable: false),
                    total = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    PlayerFootballId = table.Column<long>(type: "BIGINT", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    updated_at = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scores", x => x.id);
                    table.ForeignKey(
                        name: "FK_scores_player_football_PlayerFootballId",
                        column: x => x.PlayerFootballId,
                        principalTable: "player_football",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "players",
                columns: new[] { "id", "created_at", "deleted_at", "email", "name", "nick", "password_hash", "password_salt", "role", "updated_at" },
                values: new object[] { 1L, new DateTime(2022, 5, 29, 23, 48, 4, 373, DateTimeKind.Local).AddTicks(4784), null, "root@email.com", "Root", "Root", "39kX8Xb50tg4bMTpGTNQnBB548+J95bjlFi0bA2Qm6dakj3cim7xLtTDxINUd6PHdRYckEoranIweWyvg3n30w==", "GU2xX9kpeVjBEBTi9hAaAK2tNmVXS4gbnXjrcgqHamwIMdOBsqAvquYYHVr55pp6bZ56vZ28gH31d2GZCZz8SdVT7oreUBRewI4nEv2rAhkY07JEF+oHU+DTO+WbYFDqh2Qzj+JPYUuPrMsOBl+LHp4RsKGyAduIOLWh4yKbaoU=", (sbyte)1, null });

            migrationBuilder.CreateIndex(
                name: "IX_player_football_FootballId",
                table: "player_football",
                column: "FootballId");

            migrationBuilder.CreateIndex(
                name: "IX_player_football_PlayerId",
                table: "player_football",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_safeboxes_FootballId",
                table: "safeboxes",
                column: "FootballId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_scores_PlayerFootballId",
                table: "scores",
                column: "PlayerFootballId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "safeboxes");

            migrationBuilder.DropTable(
                name: "scores");

            migrationBuilder.DropTable(
                name: "player_football");

            migrationBuilder.DropTable(
                name: "footballs");

            migrationBuilder.DropTable(
                name: "players");
        }
    }
}
