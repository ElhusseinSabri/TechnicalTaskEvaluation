using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainDbContext.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
table: "Departments",
columns: new[] { "Id", "Name" },
values: new object[,]
{
            { 1, "Marketing" },
            { 2, "Development" }
});

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "DepartmentId" },
                values: new object[,]
                {
            { 1, "Mohamed", 1 },
            { 2, "Ahmed", 1 },
            { 3, "Sarah", 1 },
            { 4, "Nahla", 2 },
            { 5, "Hanaa", 2 },
            { 6, "Soaad", 2 }
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
       table: "Employees",
       keyColumn: "Id",
       keyValues: new object[] { 1, 2, 3, 4, 5, 6 });

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2 });
        }
    }
}
