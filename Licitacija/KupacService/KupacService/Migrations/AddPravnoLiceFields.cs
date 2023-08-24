using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KupacService.Migrations
{
    /// <summary>
    /// Migracioni fajl za dodavanje dodatnih obelezja u bazu za razlicite tipove kupaca
    /// </summary>
    public partial class AddPravnoLiceFields : Migration
    {
        /// <summary>
        /// Override up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "Kupci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaticniBroj",
                table: "Kupci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "KontaktOsobaID",
                table: "Kupci",
                type: "uniqueidentifier",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Faks",
                table: "Kupci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kupci_KontaktOsobaID",
                table: "Kupci",
                column: "KontaktOsobaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kupci_KontaktOsobe_KontaktOsobaID",
                table: "Kupci",
                column: "KontaktOsobaID",
                principalTable: "KontaktOsobe",
                principalColumn: "KontaktOsobaID",
                onDelete: ReferentialAction.Restrict);
        }
        /// <summary>
        /// override down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kupci_KontaktOsobe_KontaktOsobaID",
                table: "Kupci");

            migrationBuilder.DropIndex(
                name: "IX_Kupci_KontaktOsobaID",
                table: "Kupci");

            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "Kupci");

            migrationBuilder.DropColumn(
                name: "MaticniBroj",
                table: "Kupci");

            migrationBuilder.DropColumn(
                name: "KontaktOsobaID",
                table: "Kupci");

            migrationBuilder.DropColumn(
                name: "Faks",
                table: "Kupci");
        }
    
    }
}
