using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirmaSiparisYonetimDataLayer.Migrations
{
    public partial class Migration_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Urun_FirmaId",
                table: "Urun",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_FirmaId",
                table: "Siparis",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_UrunId",
                table: "Siparis",
                column: "UrunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparis_Firma_FirmaId",
                table: "Siparis",
                column: "FirmaId",
                principalTable: "Firma",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparis_Urun_UrunId",
                table: "Siparis",
                column: "UrunId",
                principalTable: "Urun",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Urun_Firma_FirmaId",
                table: "Urun",
                column: "FirmaId",
                principalTable: "Firma",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siparis_Firma_FirmaId",
                table: "Siparis");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparis_Urun_UrunId",
                table: "Siparis");

            migrationBuilder.DropForeignKey(
                name: "FK_Urun_Firma_FirmaId",
                table: "Urun");

            migrationBuilder.DropIndex(
                name: "IX_Urun_FirmaId",
                table: "Urun");

            migrationBuilder.DropIndex(
                name: "IX_Siparis_FirmaId",
                table: "Siparis");

            migrationBuilder.DropIndex(
                name: "IX_Siparis_UrunId",
                table: "Siparis");
        }
    }
}
