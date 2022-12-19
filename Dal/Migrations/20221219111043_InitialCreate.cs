using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    ClassroomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    classname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Corridor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom", x => x.ClassroomID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    Average = table.Column<double>(type: "float", nullable: false),
                    IsClassDelegate = table.Column<bool>(type: "bit", nullable: false),
                    ClassroomID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Student_Classroom_ClassroomID",
                        column: x => x.ClassroomID,
                        principalTable: "Classroom",
                        principalColumn: "ClassroomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    Discipline = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    ClassroomID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Teacher_Classroom_ClassroomID",
                        column: x => x.ClassroomID,
                        principalTable: "Classroom",
                        principalColumn: "ClassroomID");
                    table.ForeignKey(
                        name: "FK_Teacher_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassroomID",
                table: "Student",
                column: "ClassroomID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_ClassroomID",
                table: "Teacher",
                column: "ClassroomID",
                unique: true,
                filter: "[ClassroomID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Classroom");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
