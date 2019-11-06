using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ListagemFornecedores.Domain.Entities;
using ListagemFornecedores.DTO;
using ListagemFornecedores.Services.Services.Interfaces;
using ListagemFornecedores.Services.Validators;
using Microsoft.AspNetCore.Mvc;

namespace ListagemFornecedores.WebApi.Controllers
{
    /// <summary>
    /// API para gestão do cadastro de fornecedores.
    /// </summary>
    [Route("api/fornecedor")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService fornecedorService;
        public FornecedorController(IFornecedorService fornecedorService)
        {
            this.fornecedorService = fornecedorService;
        }
        /// <summary>
        /// Retorna lista de todos os fornecedores
        /// </summary>
        /// <returns>Lista dos fornecedores</returns>
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Fornecedor>> Get()
        {
            var result = fornecedorService.Get().Select(a => new FornecedorDTO()
            {
                CpfCnpj = a.CPFCNPJ,
                DataCadastro = a.DataCadastro,
                Nome = a.Nome
            });

            return Ok(result.ToArray());
        }
        /// <summary>
        ///  Retorna o fornecedor à partir do id
        /// </summary>
        /// <param name="id">Identificador do fornecedor</param>
        /// <returns>Cadastro do forneccedor</returns>
        [HttpGet("{id}")]
        public ActionResult<FornecedorDTO> Get(int id)
        {
            Fornecedor fornecedor = fornecedorService.Get(id);
            if (fornecedor == null)
                throw new HttpListenerException((int)HttpStatusCode.NotFound);

            FornecedorDTO fornecedorDTO = new FornecedorDTO
            {
                CpfCnpj = fornecedor.CPFCNPJ,
                DataCadastro = fornecedor.DataCadastro,
                Nome = fornecedor.Nome
            };
            return Ok(fornecedorDTO);
        }

        /// <summary>
        /// Adicionar novos fornecedores
        /// </summary>
        /// <param name="fornecedor">Fornecedor a ser adicionado</param>
        /// <returns>Informações do fornecedor para posterior consulta</returns>
        [HttpPost]
        public ActionResult<Fornecedor> Post(Fornecedor fornecedor)
        {
            try
            {
                fornecedorService.Post<FornecedorValidator>(fornecedor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(fornecedor);
        }

        /// <summary>
        /// Alterar o cadastro de um fornecedor
        /// </summary>
        /// <param name="fornecedor">Fornecedor a ser alterado</param>
        /// <returns>Informações do fornecedor para posterior consulta</returns>
        [HttpPut]
        public ActionResult<Fornecedor> Put(Fornecedor fornecedor)
        {
            try
            {
                fornecedorService.Put<FornecedorValidator>(fornecedor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(fornecedor);
        }

        /// <summary>
        /// Excluir o cadastro do fornecedor
        /// </summary>
        /// <param name="id">Identificador do fornecedor</param>
        /// <returns>Status da exclusão</returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Fornecedor tarefa = fornecedorService.Get(id);
            fornecedorService.Delete<FornecedorValidator>(id);
            return Ok();
        }
    }
}