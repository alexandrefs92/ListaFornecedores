
using FluentValidation;
using ListagemFornecedores.Data.Context;
using ListagemFornecedores.Domain.Entities;
using ListagemFornecedores.Services;
using ListagemFornecedores.Services.Services.Interfaces;
using ListagemFornecedores.Services.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ListagemFornecedores.UnitTest.FornecedorTest
{
    [TestClass]
    public class FornecedorServiceTest
    {
        private FornecedorValidator validator;

        [TestInitialize()]
        public void Inicializar()
        {
            validator = new FornecedorValidator();
        }

        [TestMethod]
        public void CriarFornecedorPFSemRG()
        {
            Fornecedor f1 = new Fornecedor()
            {
                CPFCNPJ = "231.074.330-55",
                DataNascimento = new System.DateTime(2003, 10, 01),
                EmpresaId = 1,
                Nome = "Fornecedor1"
            };

            Exception excecao = null;
            try
            {
                validator.ValidateAndThrow(f1);
            }
            catch (Exception e) 
            {
                excecao = e;
            }

            Assert.IsNotNull(excecao);
        }


        [TestMethod]
        public void CriarFornecedorPFMenorIdade()
        {
            Empresa e1 = new Empresa()
            {
                CNPJ = "85.925.537/0001-15",
                Id = 1,
                UF = "PR",
                PermiteMenorIdade = false
            };

            Fornecedor f1 = new Fornecedor()
            {
                CPFCNPJ = "231.074.330-55",
                DataNascimento = new System.DateTime(2003, 10, 01),
                Empresa = e1,
                Nome = "Fornecedor1",
                RG = "16.926.980-2"
            };

            Exception excecao = null;
            try
            {
                validator.ValidateAndThrow(f1);
            }
            catch (Exception e)
            {
                excecao = e;
            }

            Assert.IsNotNull(excecao);
        }


        [TestMethod]
        public void CriarFornecedorPFMaiorIdade()
        {
            Empresa e1 = new Empresa()
            {
                CNPJ = "85.925.537/0001-15",
                Id = 1,
                UF = "PR",
                PermiteMenorIdade = false
            };

            Fornecedor f1 = new Fornecedor()
            {
                CPFCNPJ = "231.074.330-55",
                DataNascimento = new System.DateTime(1970, 10, 01),
                Empresa = e1,
                Nome = "Fornecedor1",
                RG = "16.926.980-2"
            };

            Exception excecao = null;
            try
            {
                validator.ValidateAndThrow(f1);
            }
            catch (Exception e)
            {
                excecao = e;
            }

            Assert.IsNull(excecao);
        }


    }
}
