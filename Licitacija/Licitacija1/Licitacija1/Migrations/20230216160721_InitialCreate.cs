using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Licitacija1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokumenti",
                columns: table => new
                {
                    dokumentID = table.Column<Guid>(nullable: false),
                    licitacijaID = table.Column<Guid>(nullable: false),
                    datum = table.Column<DateTime>(nullable: false),
                    NazivDokumenta = table.Column<string>(nullable: true),
                    vrstaPodnosiocaDokumenta = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumenti", x => x.dokumentID);
                });

            migrationBuilder.CreateTable(
                name: "Licitacije",
                columns: table => new
                {
                    licitacijaID = table.Column<Guid>(nullable: false),
                    brojLicitacije = table.Column<int>(nullable: false),
                    godina = table.Column<int>(nullable: false),
                    datumLicitacije = table.Column<DateTime>(nullable: false),
                    ogranicenjeLicitacije = table.Column<int>(nullable: false),
                    korakCene = table.Column<int>(nullable: false),
                    rokZaDostavuPrijava = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licitacije", x => x.licitacijaID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dokumenti");

            migrationBuilder.DropTable(
                name: "Licitacije");
        }
    }
}
