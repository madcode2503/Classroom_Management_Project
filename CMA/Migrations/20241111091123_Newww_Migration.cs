using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMA.Migrations
{
    /// <inheritdoc />
    public partial class Newww_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "GradeBook",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "GradeBook");
        }
    }
}
