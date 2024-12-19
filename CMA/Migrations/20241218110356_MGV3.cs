using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CMA.Migrations
{
    /// <inheritdoc />
    public partial class MGV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Total_lectures",
                table: "physics_Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total_lectures",
                table: "math_Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total_lectures",
                table: "lit_Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total_lectures",
                table: "history_Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total_lectures",
                table: "chemistry_Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total_lectures",
                table: "biology_Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27bd8cae-50bc-4904-9965-1eacc4da4f52", null, "Math Teacher", "Math Teacher" },
                    { "6bd937ec-7be3-4da3-8cae-ecf8eb755012", null, "History Teacher", "History Teacher" },
                    { "7bd95037-126c-46a2-9899-908ce97a4188", null, "Literature Teacher", "Literature Teacher" },
                    { "960b06b5-c864-4cc5-b34f-0ac97a570e79", null, "Admin", "Admin" },
                    { "a8874a5c-0115-42ad-93d9-199a5f883d0b", null, "Physics Teacher", "Physics Teacher" },
                    { "c1d5e84e-4fd9-4e51-86a4-62f6f2c1da20", null, "User", "User" },
                    { "c66adb85-83b2-4674-8a3f-f48808e20198", null, "Chemistry Teacher", "Chemistry Teacher" },
                    { "d93bdba9-7653-4e19-864b-8970b4273dba", null, "Biology Teacher", "Biology Teacher" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27bd8cae-50bc-4904-9965-1eacc4da4f52");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bd937ec-7be3-4da3-8cae-ecf8eb755012");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bd95037-126c-46a2-9899-908ce97a4188");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "960b06b5-c864-4cc5-b34f-0ac97a570e79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8874a5c-0115-42ad-93d9-199a5f883d0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1d5e84e-4fd9-4e51-86a4-62f6f2c1da20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c66adb85-83b2-4674-8a3f-f48808e20198");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d93bdba9-7653-4e19-864b-8970b4273dba");

            migrationBuilder.DropColumn(
                name: "Total_lectures",
                table: "physics_Attendance");

            migrationBuilder.DropColumn(
                name: "Total_lectures",
                table: "math_Attendance");

            migrationBuilder.DropColumn(
                name: "Total_lectures",
                table: "lit_Attendance");

            migrationBuilder.DropColumn(
                name: "Total_lectures",
                table: "history_Attendance");

            migrationBuilder.DropColumn(
                name: "Total_lectures",
                table: "chemistry_Attendance");

            migrationBuilder.DropColumn(
                name: "Total_lectures",
                table: "biology_Attendance");
        }
    }
}
