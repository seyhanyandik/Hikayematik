using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hikayematik.Migrations
{
    public partial class Basla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ani_sohbet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Konu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yayim_tarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Yazar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ani_sohbet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "biyografi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dogum_tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    olum_tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Meslek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    biyografi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biyografi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "deyim_hikaye",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deyim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anlam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ornek = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deyim_hikaye", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "drama",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Konu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yayim_tarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Yazar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drama", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hikaye",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Konu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yayim_tarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Yazar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hikaye", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "masal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Konu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yazar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ders = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pratik_bilgiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pratik_bilgiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reklam",
                columns: table => new
                {
                    ReklamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Baslik1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Baslik2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReklamResim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reklam", x => x.ReklamId);
                });

            migrationBuilder.CreateTable(
                name: "siir",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sair = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yayim_tarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_siir", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tarihi_yerler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lokasyon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarihce = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarihi_yerler", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ani_sohbet");

            migrationBuilder.DropTable(
                name: "biyografi");

            migrationBuilder.DropTable(
                name: "deyim_hikaye");

            migrationBuilder.DropTable(
                name: "drama");

            migrationBuilder.DropTable(
                name: "hikaye");

            migrationBuilder.DropTable(
                name: "masal");

            migrationBuilder.DropTable(
                name: "pratik_bilgiler");

            migrationBuilder.DropTable(
                name: "reklam");

            migrationBuilder.DropTable(
                name: "siir");

            migrationBuilder.DropTable(
                name: "tarihi_yerler");
        }
    }
}
