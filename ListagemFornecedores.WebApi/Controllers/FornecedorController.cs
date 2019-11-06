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
    [Route("api/fornecedor")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService fornecedorService;
        public FornecedorController(IFornecedorService fornecedorService)
        {
            this.fornecedorService = fornecedorService;
        }
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

        [HttpPost]
        public ActionResult<Fornecedor> Post(Fornecedor value)
        {
            try
            {
                fornecedorService.Post<FornecedorValidator>(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(value);
        }

        [HttpPut]
        public ActionResult<Fornecedor> Put(Fornecedor value)
        {
            try
            {
                fornecedorService.Put<FornecedorValidator>(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Fornecedor tarefa = fornecedorService.Get(id);
            fornecedorService.Delete<FornecedorValidator>(id);
            return Ok();
        }
    }
}