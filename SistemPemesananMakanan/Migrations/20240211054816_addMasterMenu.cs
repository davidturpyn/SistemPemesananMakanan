using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemPemesananMakanan.Migrations
{
    public partial class addMasterMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Jenis = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Harga = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    updatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deletedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    deletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterMenu");
        }
    }
}
