using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListagemFornecedores.Data.Migrations
{
    public partial class PermiteMenorIdade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Empresas_EmpresaId",
                table: "Fornecedores");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Fornecedores",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Fornecedores",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PermiteMenorIdade",
                table: "Empresas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "CNPJ", "NomeFantasia", "PermiteMenorIdade", "UF" },
                values: new object[] { 1, "08.733.001/0001-57", "Empresa 1", true, "PR" });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "CNPJ", "NomeFantasia", "PermiteMenorIdade", "UF" },
                values: new object[] { 2, "30.354.935/0001-37", "Empresa 2", false, "SC" });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CPFCNPJ", "DataCadastro", "DataNascimento", "EmpresaId", "Nome", "RG" },
                values: new object[] { 1, "47.687.465/0001-26", new DateTime(2019, 10, 29, 22, 34, 9, 965, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fornecedor PJ 1", null });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CPFCNPJ", "DataCadastro", "DataNascimento", "EmpresaId", "Nome", "RG" },
                values: new object[] { 2, "002.743.400-11", new DateTime(2019, 10, 29, 22, 34, 9, 968, DateTimeKind.Local), new DateTime(1992, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fornecedor PF 1", null });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CPFCNPJ", "DataCadastro", "DataNascimento", "EmpresaId", "Nome", "RG" },
                values: new object[] { 3, "959.444.850-43", new DateTime(2019, 10, 29, 22, 34, 9, 968, DateTimeKind.Local), new DateTime(1992, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Fornecedor PF 2", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Empresas_EmpresaId",
                table: "Fornecedores",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Empresas_EmpresaId",
                table: "Fornecedores");

            migrationBuilder.DeleteData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "PermiteMenorIdade",
                table: "Empresas");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Fornecedores",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Fornecedores",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Empresas_EmpresaId",
                table: "Fornecedores",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
