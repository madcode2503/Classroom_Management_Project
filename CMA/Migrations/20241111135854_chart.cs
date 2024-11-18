using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMA.Migrations
{
    /// <inheritdoc />
    public partial class chart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attendance_Chart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Math_Attendance = table.Column<float>(type: "real", nullable: false),
                    Physics_Attendance = table.Column<float>(type: "real", nullable: false),
                    Chemitry_Attendance = table.Column<float>(type: "real", nullable: false),
                    Biology_Attendance = table.Column<float>(type: "real", nullable: false),
                    History_Attendance = table.Column<float>(type: "real", nullable: false),
                    Literature_Attendance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendance_Chart", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attendance_Chart");
        }
    }
}
