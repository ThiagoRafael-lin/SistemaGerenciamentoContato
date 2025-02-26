using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SistemaGerenciamentoContato.Data;
using SistemaGerenciamentoContato.Interface;
using SistemaGerenciamentoContato.Models;

namespace SistemaGerenciamentoContato.Repositories
{
    public class ItemRepositories : IItemRepositories
    {
        private readonly SistemaGerenciamentoContatoDbContext _dbContext;

        public ItemRepositories(SistemaGerenciamentoContatoDbContext sistemaGerenciamentoContatoDbContext)
        {
            _dbContext = sistemaGerenciamentoContatoDbContext;
        }

        public async Task<ItemModel> BuscarPorId(int id)
        {
            return await _dbContext.Item.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ItemModel>> BuscarTodosItems()
        {
            return await _dbContext.Item.ToListAsync();
            
        }

        public async Task<ItemModel> Adicionar(ItemModel itemModel)
        {
            await _dbContext.AddAsync(itemModel);
            await _dbContext.SaveChangesAsync();
            return itemModel;
        }

        public async Task<ItemModel> Atualizar(ItemModel itemModel, int id)
        {
            ItemModel itemPorId = await BuscarPorId(id);

            if (itemPorId == null)
            {
                throw new Exception("Id não encontrado");
            }

            itemPorId.Name = itemModel.Name;
            itemPorId.DataCompra = itemModel.DataCompra;
            itemPorId.Valor = itemModel.Valor;

            _dbContext.Item.Update(itemPorId);
            await _dbContext.SaveChangesAsync();
            return itemPorId;
        }

        public async Task<ItemModel> Apagar(int id)
        {
            ItemModel itemPorId = await BuscarPorId(id);

            if (itemPorId == null)
            {
                throw new Exception("Id não encontrado");
            }

            _dbContext.Remove(itemPorId);
            await _dbContext.SaveChangesAsync();
            return itemPorId;

        }
    }
}
