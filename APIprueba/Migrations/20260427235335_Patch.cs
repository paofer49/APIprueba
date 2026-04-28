using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIprueba.Migrations
{
    /// <inheritdoc />
    public partial class Patch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Tabla1",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Tabla1",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Tabla1",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cantidad", "Descripcion" },
                values: new object[] { 8, "Jajaja" });

            migrationBuilder.UpdateData(
                table: "Tabla1",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cantidad", "Descripcion" },
                values: new object[] { 10, "Jejeje" });

            migrationBuilder.UpdateData(
                table: "Tabla1",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cantidad", "Descripcion" },
                values: new object[] { 15, "Jijiji" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Tabla1");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Tabla1");
        }
    }
}
