using SistemaGerenciamentoContato.Models;

namespace SistemaGerenciamentoContato.Interface
{
    public interface IItemRepositories
    {
        Task<List<ItemModel>> BuscarTodosItems();

        Task<ItemModel> BuscarPorId(int id);

        Task<ItemModel> Adicionar(ItemModel ItemModel);
        Task<ItemModel> Atualizar(ItemModel ItemModel, int id);

        Task<ItemModel> Apagar(int id);

    }
}
