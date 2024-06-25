using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class start13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutItems",
                columns: table => new
                {
                    AboutItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutItemImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutItemTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutItemTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutItems", x => x.AboutItemId);
                });
        }
    }
}
