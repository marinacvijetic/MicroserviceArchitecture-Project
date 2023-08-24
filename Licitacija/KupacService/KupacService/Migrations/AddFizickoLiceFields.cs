using Microsoft.EntityFrameworkCore.Migrations;

namespace KupacService.Migrations
{
    /// <summary>
    /// Migracioni fajl za dodavanje dodatnih obelezja u bazu za tipove kupaca
    /// </summary>
    public class AddFizickoLiceFields : Migration
    {
        /// <summary>
        /// override up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Kupci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Kupci",
                type: "nvarchar(max)",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "JMBG",
                table: "Kupci",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <summary>
        /// override down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Kupci");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Kupci");
        }
    }
}
