using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListagemFornecedores.Data.Migrations
{
    public partial class Registros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2019, 10, 29, 22, 39, 14, 147, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataCadastro", "RG" },
                values: new object[] { new DateTime(2019, 10, 29, 22, 39, 14, 149, DateTimeKind.Local), "42.039.268-3" });

            migrationBuilder.UpdateData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataCadastro", "RG" },
                values: new object[] { new DateTime(2019, 10, 29, 22, 39, 14, 149, DateTimeKind.Local), "25.376.771-4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2019, 10, 29, 22, 34, 9, 965, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataCadastro", "RG" },
                values: new object[] { new DateTime(2019, 10, 29, 22, 34, 9, 968, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataCadastro", "RG" },
                values: new object[] { new DateTime(2019, 10, 29, 22, 34, 9, 968, DateTimeKind.Local), null });
        }
    }
}
