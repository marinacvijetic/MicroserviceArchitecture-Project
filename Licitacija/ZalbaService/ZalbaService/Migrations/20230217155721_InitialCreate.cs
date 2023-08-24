using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZalbaService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zalbe",
                columns: table => new
                {
                    ZalbaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipZalbe = table.Column<int>(type: "int", nullable: false),
                    DatumPodnosenjaZalbe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RazlogZalbe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obrazlozenje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumResenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojResenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusZalbe = table.Column<int>(type: "int", nullable: false),
                    BrojOdluke = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RadnjaNaOsnovuZalbe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zalbe", x => x.ZalbaID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zalbe");
        }
    }
}
