using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KupacService.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KontaktOsobe",
                columns: table => new
                {
                    KontaktOsobaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Funkcija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KontaktOsobe", x => x.KontaktOsobaID);
                });

            migrationBuilder.CreateTable(
                name: "Kupci",
                columns: table => new
                {
                    KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipKupca = table.Column<int>(type: "int", nullable: false),
                    OstvarenaPovrsina = table.Column<int>(type: "int", nullable: false),
                    ImaZabranu = table.Column<bool>(type: "bit", nullable: false),
                    DatumPocetkaZabrane = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzinaTrajanjaZabraneGodine = table.Column<int>(type: "int", nullable: false),
                    DatumPrestankaZabrane = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupci", x => x.KupacID);
                });

            migrationBuilder.CreateTable(
                name: "OvlascenaLica",
                columns: table => new
                {
                    OvlascenoLiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipOvlascenogLica = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvlascenaLica", x => x.OvlascenoLiceID);
                });

            migrationBuilder.CreateTable(
                name: "Prioriteti",
                columns: table => new
                {
                    PrioritetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrioritetIzbor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioriteti", x => x.PrioritetID);
                    table.ForeignKey(
                        name: "FK_Prioriteti_Kupci_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrojeviTabla",
                columns: table => new
                {
                    BrojTableID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Broj = table.Column<int>(type: "int", nullable: false),
                    OvlascenoLiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrojeviTabla", x => x.BrojTableID);
                    table.ForeignKey(
                        name: "FK_BrojeviTabla_OvlascenaLica_OvlascenoLiceID",
                        column: x => x.OvlascenoLiceID,
                        principalTable: "OvlascenaLica",
                        principalColumn: "OvlascenoLiceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrojeviTabla_OvlascenoLiceID",
                table: "BrojeviTabla",
                column: "OvlascenoLiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Prioriteti_KupacID",
                table: "Prioriteti",
                column: "KupacID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrojeviTabla");

            migrationBuilder.DropTable(
                name: "KontaktOsobe");

            migrationBuilder.DropTable(
                name: "Prioriteti");

            migrationBuilder.DropTable(
                name: "OvlascenaLica");

            migrationBuilder.DropTable(
                name: "Kupci");
        }
    }
}
