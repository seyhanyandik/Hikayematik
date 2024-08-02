using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hikayematik.Migrations
{
    public partial class kullanici : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Soyad",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Sehir",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "OnayKodu",
                table: "AspNetUsers",
                newName: "ConfirmCode");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "AspNetUsers",
                newName: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Soyad");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "Sehir");

            migrationBuilder.RenameColumn(
                name: "ConfirmCode",
                table: "AspNetUsers",
                newName: "OnayKodu");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "AspNetUsers",
                newName: "Ad");
        }
    }
}
