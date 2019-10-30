using FluentValidation;
using ListagemFornecedores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListagemFornecedores.Services.Services.Interfaces
{
    public interface IEmpresaService
    {
        Empresa Post<V>(Empresa empresa) where V : AbstractValidator<Empresa>;
        Empresa Put<V>(Empresa empresa) where V : AbstractValidator<Empresa>;
        void Delete<V>(int id) where V : AbstractValidator<Empresa>;
        Empresa Get(int id);
        IQueryable<Empresa> Get();
    }
}
