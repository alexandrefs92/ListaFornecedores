using System;
using System.Collections.Generic;
using System.Text;

namespace ListagemFornecedores.DTO
{
    public class FornecedorDTO
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
