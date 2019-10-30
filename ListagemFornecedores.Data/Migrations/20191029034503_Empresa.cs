using Microsoft.EntityFrameworkCore.Migrations;

namespace ListagemFornecedores.Data.Migrations
{
    public partial class Empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "empresaId",
                table: "Fornecedores",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_empresaId",
                table: "Fornecedores",
                column: "empresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Empresas_empresaId",
                table: "Fornecedores",
                column: "empresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Empresas_empresaId",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_empresaId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "empresaId",
                table: "Fornecedores");
        }
    }
}
