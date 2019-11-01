using FluentValidation;
using ListagemFornecedores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListagemFornecedores.Services.Validators
{
    public class FornecedorValidator : AbstractValidator<Fornecedor>
    {
        public FornecedorValidator()
        {
            RuleFor(a => a)
               .NotNull()
               .OnAnyFailure(b =>
               {
                   throw new ArgumentNullException("Objeto não encontrado.");
               });


            RuleFor(a => a.CPFCNPJ)
                .Must(ValidarDocumento)
                .WithMessage("Favor informar um CPF ou CNPJ válido");

            RuleFor(a => a.RG)
                .NotNull()
                .When(a => string.Join("", System.Text.RegularExpressions.Regex.Split(a.CPFCNPJ, @"[^\d]")).Length <= 11)
                .WithMessage("Favor preencher RG.");

            RuleFor(a => a.DataNascimento)
                .NotNull()
                .When(a => string.Join("", System.Text.RegularExpressions.Regex.Split(a.CPFCNPJ, @"[^\d]")).Length <= 11)
                .WithMessage("Favor preencher Data de nascimento.");

            RuleFor(a => a.Empresa.PermiteMenorIdade)
                .NotEqual(false)
                .When(a => !string.IsNullOrWhiteSpace(a.RG))
                .When(a => a.DataNascimento > System.DateTime.Now.AddYears(-18))
                .WithMessage("Fornecedor deve ser maior de idade"); 
                 
        }

        private bool ValidarDocumento(string CpfCnpj)
        {
            string documentoFormatado = string.Join("", System.Text.RegularExpressions.Regex.Split(CpfCnpj, @"[^\d]"));

            return (documentoFormatado.Length == 14) || (documentoFormatado.Length == 11);
        }
    }
}
