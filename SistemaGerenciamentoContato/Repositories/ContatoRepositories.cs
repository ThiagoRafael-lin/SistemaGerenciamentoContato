using Microsoft.EntityFrameworkCore;
using SistemaGerenciamentoContato.Data;
using SistemaGerenciamentoContato.Interface;
using SistemaGerenciamentoContato.Models;


namespace SistemaGerenciamentoContato.Repositories
{
    public class ContatoRepositories : IContatoRepositories
    {
        private readonly SistemaGerenciamentoContatoDbContext _dbContext;

        public ContatoRepositories(SistemaGerenciamentoContatoDbContext sistemaGerenciamentoContatoDbContext)
        {
            _dbContext = sistemaGerenciamentoContatoDbContext;
        }

        public async Task<ContatoModel> BuscarPorId(int id)
        {
            return await _dbContext.Contato.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ContatoModel>> BuscarTodosContatos()
        {
            return await _dbContext.Contato.ToListAsync();
        }

        public async Task<ContatoModel> Adicionar(ContatoModel contatoModel)
        {
            await _dbContext.Contato.AddAsync(contatoModel);
            await _dbContext.SaveChangesAsync();
            return contatoModel;

        }

        public async Task<ContatoModel> Atualizar(ContatoModel contatoModel, int id)
        {
            ContatoModel contatoPorId = await BuscarPorId(id);

            if (contatoPorId == null)
            {
                throw new Exception("Id não encontrado");
            }
            contatoPorId.Name = contatoModel.Name;
            contatoPorId.Email = contatoModel.Email;
            contatoPorId.Telefone = contatoModel.Telefone;
            contatoPorId.Endereco = contatoModel.Endereco;

            _dbContext.Contato.Update(contatoPorId);
            await _dbContext.SaveChangesAsync();
            return contatoPorId;
        }
        public async Task<ContatoModel> Apagar(int id)
        {
            ContatoModel contatoPorId = await BuscarPorId(id);

            if (contatoPorId == null)
            {
                throw new Exception("Id não encontrado");
            }

            _dbContext.Contato.Remove(contatoPorId);
            await _dbContext.SaveChangesAsync();
            return contatoPorId;
        }
    }
}
