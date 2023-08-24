using Microsoft.EntityFrameworkCore.Migrations;

namespace KupacService.Migrations
{
    /// <summary>
    /// Migracioni fajl za dodavanje dodatnih kolona u ovlasceno lice
    /// </summary>
    public class AddStraniDrzavljaninFields : Migration
    {
        /// <summary>
        /// override up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrojPasosa",
                table: "OvlascenaLica",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Drzava",
                table: "OvlascenoLice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <summary>
        /// override down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojPasosa",
                table: "OvlascenaLica");

            migrationBuilder.DropColumn(
                name: "Drzava",
                table: "OvlascenaLica");
        }
    }
}
