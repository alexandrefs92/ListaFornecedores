using ListagemFornecedores.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Serialization;

namespace ListagemFornecedores.Domain.Entities
{
    [Table("Fornecedores")]
    public class Fornecedor : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPFCNPJ { get; set; }
        public string RG { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        [XmlIgnore]
        public virtual Empresa Empresa { get; set; }
        [XmlIgnore]
        public ICollection<TelefoneFornecedor> TelefonesFornecedor { get; set; }
    }
}
