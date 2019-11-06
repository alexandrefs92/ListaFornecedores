using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ListagemFornecedores.Data.Context;
using ListagemFornecedores.Data.Repository;
using ListagemFornecedores.Domain.Entities;
using ListagemFornecedores.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ListagemFornecedores.WebApi.Controllers
{
    /// <summary>
    /// API para consulta do cadastro de empresas
    /// </summary>
    [Route("api/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            this.empresaService = empresaService;
        }
        /// <summary>
        ///  Retorna a empresa à partir do id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Cadastro da empresa</returns>
        [HttpDelete("{id}")]
        public ActionResult<Empresa> Get(int id)
        {
            Empresa empresa = empresaService.Get(id);

            if (empresa == null)
                throw new HttpListenerException((int)HttpStatusCode.NotFound);

            return Ok(empresa);
        }
        /// <summary>
        /// Retorna lista de todos as empresas
        /// </summary>
        /// <returns>Lista de empresas</returns>
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Empresa>> Get()
        {
            return Ok(empresaService.Get().ToArray());
        }
    }
}