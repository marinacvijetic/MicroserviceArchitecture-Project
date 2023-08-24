using Microsoft.EntityFrameworkCore.Migrations;

namespace KupacService.Migrations
{
    /// <summary>
    /// Migracioni fajl za dodavanje dodatnih obelezja za srpskog drzavljanina
    /// </summary>
    public class AddSrpskiDrzavljaninFields : Migration
    {
        /// <summary>
        /// override up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JMBG",
                table: "OvlascenaLica",
                type: "nvarchar(max)",
                nullable: true);

        }

        /// <summary>
        /// Override down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JMBG",
                table: "OvlascenaLica");

        }
    }
}
