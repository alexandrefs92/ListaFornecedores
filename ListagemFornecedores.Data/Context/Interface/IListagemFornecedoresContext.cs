using ListagemFornecedores.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ListagemFornecedores.Data.Context
{
    public interface IListagemFornecedoresContext
    {
        DbSet<Empresa> Empresas { get; set; }
        DbSet<Fornecedor> Fornecedores { get; set; }
        DbSet<TelefoneFornecedor> TelefoneClientes { get; set; }
    }
}