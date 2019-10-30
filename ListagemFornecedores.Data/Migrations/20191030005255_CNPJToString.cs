using Microsoft.EntityFrameworkCore.Migrations;

namespace ListagemFornecedores.Data.Migrations
{
    public partial class CNPJToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPFCNPJ",
                table: "Fornecedores",
                nullable: true,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CPFCNPJ",
                table: "Fornecedores",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
