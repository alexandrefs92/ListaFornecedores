using ListagemFornecedores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListagemFornecedores.Data.Context
{
    public class ListagemFornecedoresContext : DbContext
    {
        public ListagemFornecedoresContext(DbContextOptions<ListagemFornecedoresContext> options) : base(options) { }

        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Fornecedor> Fornecedores { get; set; }
        public virtual DbSet<TelefoneFornecedor> TelefoneClientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>().ToTable("Empresas");
            modelBuilder.Entity<Fornecedor>().ToTable("Fornecedores");
            modelBuilder.Entity<TelefoneFornecedor>().ToTable("TelefonesFornecedor");

            modelBuilder.Entity<Empresa>().HasData(new Empresa { Id = 1, CNPJ = "08.733.001/0001-57", NomeFantasia = "Empresa 1", UF = "PR", PermiteMenorIdade = true });
            modelBuilder.Entity<Empresa>().HasData(new Empresa { Id = 2, CNPJ = "30.354.935/0001-37", NomeFantasia = "Empresa 2", UF = "SC", PermiteMenorIdade = false });

            modelBuilder.Entity<Fornecedor>().HasData(new Fornecedor { Id = 1, CPFCNPJ = "47.687.465/0001-26", DataCadastro = DateTime.Now, EmpresaId = 1, Nome = "Fornecedor PJ 1" });
            modelBuilder.Entity<Fornecedor>().HasData(new Fornecedor { Id = 2, CPFCNPJ = "002.743.400-11", DataCadastro = DateTime.Now, EmpresaId = 1, Nome = "Fornecedor PF 1", DataNascimento = new DateTime(1992, 05, 11), RG = "42.039.268-3" });
            modelBuilder.Entity<Fornecedor>().HasData(new Fornecedor { Id = 3, CPFCNPJ = "959.444.850-43", DataCadastro = DateTime.Now, EmpresaId = 2, Nome = "Fornecedor PF 2", DataNascimento = new DateTime(1992, 05, 20), RG = "25.376.771-4" });



            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
