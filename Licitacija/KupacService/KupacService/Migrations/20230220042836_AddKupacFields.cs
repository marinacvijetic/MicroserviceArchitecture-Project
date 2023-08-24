using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KupacService.Migrations
{
    public partial class AddKupacFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "KupacID",
                table: "OvlascenaLica",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Kupci",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Faks",
                table: "Kupci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Kupci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JMBG",
                table: "Kupci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "KontaktOsobaID",
                table: "Kupci",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaticniBroj",
                table: "Kupci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "Kupci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Kupci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UplataDTO",
                columns: table => new
                {
                    UplataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UplataDTO", x => x.UplataID);
                    table.ForeignKey(
                        name: "FK_UplataDTO_Kupci_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OvlascenaLica_KupacID",
                table: "OvlascenaLica",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupci_KontaktOsobaID",
                table: "Kupci",
                column: "KontaktOsobaID");

            migrationBuilder.CreateIndex(
                name: "IX_UplataDTO_KupacID",
                table: "UplataDTO",
                column: "KupacID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kupci_KontaktOsobe_KontaktOsobaID",
                table: "Kupci",
                column: "KontaktOsobaID",
                principalTable: "KontaktOsobe",
                principalColumn: "KontaktOsobaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OvlascenaLica_Kupci_KupacID",
                table: "OvlascenaLica",
                column: "KupacID",
                principalTable: "Kupci",
                principalColumn: "KupacID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kupci_KontaktOsobe_KontaktOsobaID",
                table: "Kupci");

            migrationBuilder.DropForeignKey(
                name: "FK_OvlascenaLica_Kupci_KupacID",
                table: "OvlascenaLica");

            migrationBuilder.DropTable(
                name: "UplataDTO");

            migrationBuilder.DropIndex(
                name: "IX_OvlascenaLica_KupacID",
                table: "OvlascenaLica");

            migrationBuilder.DropIndex(
                name: "IX_Kupci_KontaktOsobaID",
                table: "Kupci");

            migrationBuilder.DropColumn(
                name: "KupacID",
                table: "OvlascenaLica");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Kupci");

            migrationBuilder.DropColumn(
                name: "Faks",
                table: "Kupci");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Kupci");

            migrationBuilder.DropColumn(
                name: "JMBG",
                table: "Kupci");

            migrationBuilder.DropColumn(
                name: "KontaktOsobaID",
                table: "Kupci");

            migrationBuilder.DropColumn(
                name: "MaticniBroj",
                table: "Kupci");

            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "Kupci");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Kupci");
        }
    }
}
