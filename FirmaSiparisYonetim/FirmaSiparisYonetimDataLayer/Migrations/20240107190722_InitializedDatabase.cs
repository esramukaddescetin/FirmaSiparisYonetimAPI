using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirmaSiparisYonetimDataLayer.Migrations
{
    public partial class InitializedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Onay = table.Column<bool>(type: "bit", nullable: false),
                    SiparisIzinBaslangicSaati = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiparisIzinBitisSaati = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firma", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firma");
        }
    }
}
