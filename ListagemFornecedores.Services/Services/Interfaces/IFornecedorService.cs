using FluentValidation;
using ListagemFornecedores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListagemFornecedores.Services.Services.Interfaces
{
    public interface IFornecedorService
    {
        Fornecedor Post<V>(Fornecedor fornecedor) where V : AbstractValidator<Fornecedor>;
        Fornecedor Put<V>(Fornecedor fornecedor) where V : AbstractValidator<Fornecedor>;
        void Delete<V>(int id) where V : AbstractValidator<Fornecedor>;
        Fornecedor Get(int id);
        IQueryable<Fornecedor> Get();
      
    }
}
