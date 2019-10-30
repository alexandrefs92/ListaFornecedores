using Microsoft.EntityFrameworkCore.Migrations;

namespace ListagemFornecedores.Data.Migrations
{
    public partial class Empresa2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Empresas_empresaId",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "empresaId",
                table: "Fornecedores",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedores_empresaId",
                table: "Fornecedores",
                newName: "IX_Fornecedores_EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Empresas_EmpresaId",
                table: "Fornecedores",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Empresas_EmpresaId",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Fornecedores",
                newName: "empresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedores_EmpresaId",
                table: "Fornecedores",
                newName: "IX_Fornecedores_empresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Empresas_empresaId",
                table: "Fornecedores",
                column: "empresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
