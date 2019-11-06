using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListagemFornecedores.Data.Context;
using ListagemFornecedores.Data.Repository;
using ListagemFornecedores.Domain.Entities;
using ListagemFornecedores.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ListagemFornecedores.WebApi.Controllers
{
    [Route("api/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            this.empresaService = empresaService;
        }
        [HttpDelete("{id}")]
        public ActionResult<string> Get(int id)
        {
            Empresa empresa = empresaService.Get(id);
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Empresa>> Get()
        {
            return Ok(empresaService.Get().ToArray());
        }
    }
}