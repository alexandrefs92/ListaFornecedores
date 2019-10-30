﻿// <auto-generated />
using System;
using ListagemFornecedores.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ListagemFornecedores.Data.Migrations
{
    [DbContext(typeof(ListagemFornecedoresContext))]
    [Migration("20191029034550_Empresa2")]
    partial class Empresa2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ListagemFornecedores.Domain.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ");

                    b.Property<string>("NomeFantasia");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("ListagemFornecedores.Domain.Entities.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPFCNPJ");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<int?>("EmpresaId");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("ListagemFornecedores.Domain.Entities.TelefoneFornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FornecedorId");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("TelefonesFornecedor");
                });

            modelBuilder.Entity("ListagemFornecedores.Domain.Entities.Fornecedor", b =>
                {
                    b.HasOne("ListagemFornecedores.Domain.Entities.Empresa", "Empresa")
                        .WithMany("EmpresasFornecedor")
                        .HasForeignKey("EmpresaId");
                });

            modelBuilder.Entity("ListagemFornecedores.Domain.Entities.TelefoneFornecedor", b =>
                {
                    b.HasOne("ListagemFornecedores.Domain.Entities.Fornecedor", "Fornecedor")
                        .WithMany("TelefonesFornecedor")
                        .HasForeignKey("FornecedorId");
                });
#pragma warning restore 612, 618
        }
    }
}
