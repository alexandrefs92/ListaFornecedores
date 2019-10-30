using FluentValidation;
using ListagemFornecedores.Data.Context;
using ListagemFornecedores.Data.Repository;
using ListagemFornecedores.Domain.Entities;
using ListagemFornecedores.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListagemFornecedores.Services.Services
{
    public class EmpresaService : IEmpresaService
    {
        private Repository<Empresa> _repository;
        private readonly ListagemFornecedoresContext _context;


        public EmpresaService(ListagemFornecedoresContext context)
        {
            _context = context;
            _repository = new Repository<Empresa>(_context);
        }
        private void Validate(Empresa empresa, AbstractValidator<Empresa> validator)
        {
            if (empresa == null)
                throw new ArgumentNullException("Objeto não encontrado");

            validator.ValidateAndThrow(empresa);
        }
        public void Delete<V>(int id) where V : AbstractValidator<Empresa>
        {
            var trf = _repository.GetById(id);

            if (id == 0)
                throw new Exception("Favor informe um Id válido");

            Validate(trf, Activator.CreateInstance<V>());
            _repository.Delete(id);
        }

        public Empresa Get(int id)
        {
            if (id == 0)
                throw new Exception("Favor informe um Id válido");

            return (Empresa)_repository.GetById(id);
        }

        public IQueryable<Empresa> Get()
        {
            return _repository.GetAll();
        }

        public Empresa Post<V>(Empresa empresa) where V : AbstractValidator<Empresa>
        {
            Validate(empresa, Activator.CreateInstance<V>());

             _repository.Create(empresa);
            return empresa;
        }

        public Empresa Put<V>(Empresa empresa) where V : AbstractValidator<Empresa>
        {
            Validate(empresa, Activator.CreateInstance<V>());

            _repository.Update(empresa);
            return empresa;
        }
    }
}
