using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dal.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrative",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrative", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Administrative_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrative");
        }
    }
}
