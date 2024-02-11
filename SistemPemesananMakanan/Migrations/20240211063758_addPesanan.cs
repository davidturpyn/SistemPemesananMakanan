using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemPemesananMakanan.Migrations
{
    public partial class addPesanan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pesanan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomorPesanan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorMeja = table.Column<int>(type: "int", nullable: false),
                    MakananId = table.Column<int>(type: "int", nullable: false),
                    MinumanId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pesanan");
        }
    }
}
