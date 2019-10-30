using FluentValidation;
using ListagemFornecedores.Data.Context;
using ListagemFornecedores.Data.Repository;
using ListagemFornecedores.Domain.Entities;
using ListagemFornecedores.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListagemFornecedores.Services
{
    public class FornecedorService : IFornecedorService
    {
        private Repository<Fornecedor> _repository;
        private readonly ListagemFornecedoresContext _context;

        private void Validate(Fornecedor fornecedor, AbstractValidator<Fornecedor> validator)
        {
            if (fornecedor == null)
                throw new ArgumentNullException("Objeto não encontrado");

            validator.ValidateAndThrow(fornecedor);
        }

        public FornecedorService(ListagemFornecedoresContext context)
        {
            _context = context;
           // _repository = new Repository<Fornecedor>(_context);
        }

        public void Delete<V>(int id) where V : AbstractValidator<Fornecedor>
        {
            var trf = _repository.GetById(id);

            if (id == 0)
                throw new Exception("Favor informe um Id válido");

            Validate(trf, Activator.CreateInstance<V>());
            _repository.Delete(id);
        }

        public Fornecedor Get(int id)
        {
            if (id == 0)
                throw new Exception("Favor informe um Id válido");

            return (Fornecedor)_repository.GetById(id);
        }

        public IQueryable<Fornecedor> Get()
        {
            return _repository.GetAll();
        }

        public Fornecedor Post<V>(Fornecedor fornecedor) where V : AbstractValidator<Fornecedor>
        {
            Validate(fornecedor, Activator.CreateInstance<V>());

            fornecedor.DataCadastro = DateTime.Now;

            _repository.Create(fornecedor);
            return fornecedor;
        }

        public Fornecedor Put<V>(Fornecedor fornecedor) where V : AbstractValidator<Fornecedor>
        {
            Validate(fornecedor, Activator.CreateInstance<V>());

            _repository.Update(fornecedor);
            return fornecedor;
        }
    }
}
