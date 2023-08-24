using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KatastarskaOpstinaService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatutiOpstina",
                columns: table => new
                {
                    StatutOpstineId = table.Column<Guid>(nullable: false),
                    SadrzajStatuta = table.Column<string>(nullable: true),
                    DatumKreiranjaStatuta = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatutiOpstina", x => x.StatutOpstineId);
                });

            migrationBuilder.CreateTable(
                name: "KatastarskeOpstine",
                columns: table => new
                {
                    KatastarskaOpstinaId = table.Column<Guid>(nullable: false),
                    StatutOpstineId = table.Column<Guid>(nullable: false),
                    NazivOpstine = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KatastarskeOpstine", x => x.KatastarskaOpstinaId);
                    table.ForeignKey(
                        name: "FK_KatastarskeOpstine_StatutiOpstina_StatutOpstineId",
                        column: x => x.StatutOpstineId,
                        principalTable: "StatutiOpstina",
                        principalColumn: "StatutOpstineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KatastarskeOpstine_StatutOpstineId",
                table: "KatastarskeOpstine",
                column: "StatutOpstineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KatastarskeOpstine");

            migrationBuilder.DropTable(
                name: "StatutiOpstina");
        }
    }
}
