using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParcelaService.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KvalitetiZemljista",
                columns: table => new
                {
                    KvalitetZemljistaId = table.Column<Guid>(nullable: false),
                    OznakaKvaliteta = table.Column<string>(maxLength: 5, nullable: false),
                    Opis = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KvalitetiZemljista", x => x.KvalitetZemljistaId);
                });

            migrationBuilder.CreateTable(
                name: "ZasticeneZone",
                columns: table => new
                {
                    ZasticenaZonaId = table.Column<Guid>(nullable: false),
                    BrojZasticeneZone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZasticeneZone", x => x.ZasticenaZonaId);
                });

            migrationBuilder.CreateTable(
                name: "DozvoljeniRadovi",
                columns: table => new
                {
                    DozvoljeniRadId = table.Column<Guid>(nullable: false),
                    Opis = table.Column<string>(maxLength: 100, nullable: false),
                    ZasticenaZonaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DozvoljeniRadovi", x => x.DozvoljeniRadId);
                    table.ForeignKey(
                        name: "FK_DozvoljeniRadovi_ZasticeneZone_ZasticenaZonaId",
                        column: x => x.ZasticenaZonaId,
                        principalTable: "ZasticeneZone",
                        principalColumn: "ZasticenaZonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcele",
                columns: table => new
                {
                    ParcelaId = table.Column<Guid>(nullable: false),
                    BrojParcele = table.Column<string>(nullable: false),
                    BrojListaNepokretnosti = table.Column<string>(nullable: false),
                    KatastarskaOpstinaId = table.Column<Guid>(nullable: false),
                    Kultura = table.Column<int>(nullable: false),
                    Klasa = table.Column<int>(nullable: false),
                    Obradivost = table.Column<int>(nullable: false),
                    ZasticenaZonaId = table.Column<Guid>(nullable: false),
                    OblikSvojine = table.Column<int>(nullable: false),
                    Odvodnjavanje = table.Column<string>(maxLength: 50, nullable: true),
                    KulturaStvarnoStanje = table.Column<string>(maxLength: 50, nullable: true),
                    KlasaStvarnoStanje = table.Column<string>(maxLength: 50, nullable: true),
                    ObradivostStvarnoStanje = table.Column<string>(maxLength: 50, nullable: true),
                    ZasticenaZonaStvarnoStanje = table.Column<string>(maxLength: 50, nullable: true),
                    OdvodnjavanjeStvarnoStanje = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcele", x => x.ParcelaId);
                    table.ForeignKey(
                        name: "FK_Parcele_ZasticeneZone_ZasticenaZonaId",
                        column: x => x.ZasticenaZonaId,
                        principalTable: "ZasticeneZone",
                        principalColumn: "ZasticenaZonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeloviParcele",
                columns: table => new
                {
                    DeoParceleId = table.Column<Guid>(nullable: false),
                    ParcelaId = table.Column<Guid>(nullable: false),
                    RedniBrojDelaParcele = table.Column<int>(nullable: false),
                    PovrsinaDelaParcele = table.Column<int>(nullable: false),
                    KvalitetZemljistaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeloviParcele", x => x.DeoParceleId);
                    table.ForeignKey(
                        name: "FK_DeloviParcele_KvalitetiZemljista_KvalitetZemljistaId",
                        column: x => x.KvalitetZemljistaId,
                        principalTable: "KvalitetiZemljista",
                        principalColumn: "KvalitetZemljistaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeloviParcele_Parcele_ParcelaId",
                        column: x => x.ParcelaId,
                        principalTable: "Parcele",
                        principalColumn: "ParcelaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeloviParcele_KvalitetZemljistaId",
                table: "DeloviParcele",
                column: "KvalitetZemljistaId");

            migrationBuilder.CreateIndex(
                name: "IX_DeloviParcele_ParcelaId",
                table: "DeloviParcele",
                column: "ParcelaId");

            migrationBuilder.CreateIndex(
                name: "IX_DozvoljeniRadovi_ZasticenaZonaId",
                table: "DozvoljeniRadovi",
                column: "ZasticenaZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcele_ZasticenaZonaId",
                table: "Parcele",
                column: "ZasticenaZonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeloviParcele");

            migrationBuilder.DropTable(
                name: "DozvoljeniRadovi");

            migrationBuilder.DropTable(
                name: "KvalitetiZemljista");

            migrationBuilder.DropTable(
                name: "Parcele");

            migrationBuilder.DropTable(
                name: "ZasticeneZone");
        }
    }
}
