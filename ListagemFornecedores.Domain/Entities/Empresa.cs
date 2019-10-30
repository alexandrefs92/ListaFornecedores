using ListagemFornecedores.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ListagemFornecedores.Domain.Entities
{
    [Table("Empresas")]
    public class Empresa : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        [DisplayFormat(DataFormatString = "{0:000\\.000\\.000-00}", ApplyFormatInEditMode = true)]
        public string CNPJ { get; set; }

        [MaxLength(2)]
        public string UF { get; set; }
        public bool PermiteMenorIdade { get; set; }

        public ICollection<Fornecedor> EmpresasFornecedor { get; set; }
    }
}
