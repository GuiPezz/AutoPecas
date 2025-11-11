using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPecas.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCamposEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstoqueMinimo",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeEstoque",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EstoqueMinimo", "QuantidadeEstoque" },
                values: new object[] { 5, 0 });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EstoqueMinimo", "QuantidadeEstoque" },
                values: new object[] { 5, 0 });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EstoqueMinimo", "QuantidadeEstoque" },
                values: new object[] { 5, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstoqueMinimo",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "QuantidadeEstoque",
                table: "Produtos");
        }
    }
}
