using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGerenciamentoContato.Interface;
using SistemaGerenciamentoContato.Models;

namespace SistemaGerenciamentoContato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepositories _contatoRepositories;

        public ContatoController(IContatoRepositories contatoRepositories)
        {
            _contatoRepositories = contatoRepositories;
        }

        [HttpGet]

        public async Task<List<ContatoModel>> BuscarTodosContatos()
        {
            List<ContatoModel> contatos = await _contatoRepositories.BuscarTodosContatos();
            return contatos;

        }

        [HttpGet ("{id}")] 

        public async Task<ActionResult<ContatoModel>> BuscarContatoPorId(int id)
        {
             ContatoModel contato = await _contatoRepositories.BuscarPorId(id);
            return Ok(contato);
        }

        [HttpPost]

        public async Task<ActionResult<ContatoModel>> Cadastrar(ContatoModel contatoModel)
        {
            ContatoModel contato = await _contatoRepositories.Adicionar(contatoModel);
            return Ok(contato);
        }

        [HttpPut ("{id}")]

        public async Task<ActionResult<ContatoModel>> Atualizar([FromBody]ContatoModel contatoModel, int id)
        {
            contatoModel.Id = id;
            ContatoModel contato = await _contatoRepositories.Atualizar(contatoModel, id);
            return Ok(contato);
        }

        [HttpDelete ("{id}")]

        public async Task<ActionResult<ContatoModel>> Apagar( int id)
        {
            ContatoModel contato = await _contatoRepositories.Apagar(id);
            return Ok(contato);
        }

    }
}
