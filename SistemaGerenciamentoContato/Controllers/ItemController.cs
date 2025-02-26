using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGerenciamentoContato.Interface;
using SistemaGerenciamentoContato.Models;
using SistemaGerenciamentoContato.Repositories;

namespace SistemaGerenciamentoContato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepositories _itemRepositories;

        public ItemController(IItemRepositories itemRepositories)
        {
            _itemRepositories = itemRepositories;
        }

        [HttpGet]

        public async Task<List<ItemModel>> BuscarTodosItems()
        {
            List<ItemModel> item = await _itemRepositories.BuscarTodosItems();
            return item;
        }

        [HttpGet("{id}")]

        public async Task<ItemModel> BuscarItemPorId(int id)
        {
            ItemModel itemModel = await _itemRepositories.BuscarPorId(id);
            return itemModel;
        }

        [HttpPost]

        public async Task<ActionResult<ItemModel>> Adicionar(ItemModel itemModel)
        {
            ItemModel item = await _itemRepositories.Adicionar(itemModel);
            return Ok(item);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<ItemModel>> Atualizar(ItemModel itemModel, int id)
        {
            itemModel.Id = id;
            ItemModel item = await _itemRepositories.Atualizar(itemModel, id);
            return Ok(item);
        }

        [HttpDelete]

        public async Task<ActionResult<ItemModel>> Apagar(int id)
        {
            ItemModel item = await _itemRepositories.Apagar(id);
            return Ok(item);
        }
    }
}
