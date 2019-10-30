using ListagemFornecedores.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ListagemFornecedores.Domain.Entities
{
    [Table("TelefoneFornecedor")]
    public class TelefoneFornecedor : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Telefone { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

    }
}
