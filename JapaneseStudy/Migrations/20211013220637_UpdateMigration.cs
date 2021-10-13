using Microsoft.EntityFrameworkCore.Migrations;

namespace JapaneseStudy.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KanjiReview",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    KanjiID = table.Column<int>(type: "int", nullable: false),
                    ReviewType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewNo = table.Column<int>(type: "int", nullable: false),
                    IsLeech = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanjiReview", x => new { x.PersonID, x.KanjiID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KanjiReview");
        }
    }
}
