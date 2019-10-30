using Microsoft.EntityFrameworkCore.Migrations;

namespace ListagemFornecedores.Data.Migrations
{
    public partial class RGDataNascimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CPFCNPJ",
                table: "Fornecedores",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataNascimento",
                table: "Fornecedores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RG",
                table: "Fornecedores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Empresas",
                maxLength: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "RG",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Empresas");

            migrationBuilder.AlterColumn<string>(
                name: "CPFCNPJ",
                table: "Fornecedores",
                nullable: true,
                oldClrType: typeof(long));
        }
    }
}
