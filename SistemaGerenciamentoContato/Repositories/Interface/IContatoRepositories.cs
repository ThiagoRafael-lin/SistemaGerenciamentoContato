using SistemaGerenciamentoContato.Models;

namespace SistemaGerenciamentoContato.Interface
{
    public interface IContatoRepositories
    {
        Task<List<ContatoModel>> BuscarTodosContatos();

        Task<ContatoModel> BuscarPorId(int id);

        Task<ContatoModel> Adicionar(ContatoModel contatoModel);
        Task<ContatoModel> Atualizar(ContatoModel contatoModel, int id);

        Task<ContatoModel> Apagar(int id);

    }
}
