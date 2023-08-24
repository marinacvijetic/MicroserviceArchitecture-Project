using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dokument.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokumenti",
                columns: table => new
                {
                    DokumentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZavodniBroj = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    DatumDonosenjaDokumenta = table.Column<DateTime>(nullable: false),
                    Sablon = table.Column<string>(nullable: true),
                    StatusDokumenta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumenti", x => x.DokumentID);
                });

            migrationBuilder.CreateTable(
                name: "Ugovori",
                columns: table => new
                {
                    UgovorOZakupuID = table.Column<Guid>(nullable: false),
                    TipGarancije = table.Column<int>(nullable: false),
                    RokDospeca = table.Column<int>(nullable: false),
                    ZavodniBroj = table.Column<string>(nullable: true),
                    DatumZavodjenja = table.Column<DateTime>(nullable: false),
                    RokZaVracanje = table.Column<DateTime>(nullable: false),
                    MestoPotpisivanja = table.Column<string>(nullable: true),
                    DatumPotpisivanja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ugovori", x => x.UgovorOZakupuID);
                });

            migrationBuilder.CreateTable(
                name: "VerzijeDokumenata",
                columns: table => new
                {
                    VerzijaID = table.Column<Guid>(nullable: false),
                    Verzija = table.Column<string>(nullable: true),
                    Revizija = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerzijeDokumenata", x => x.VerzijaID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dokumenti");

            migrationBuilder.DropTable(
                name: "Ugovori");

            migrationBuilder.DropTable(
                name: "VerzijeDokumenata");
        }
    }
}
