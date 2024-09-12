using PraticaCICD.Api.Data.Entities;

namespace PraticaCICD.Api.Data.Repositories
{
    public interface IRoupaRepository
    {
        Task<List<Roupa>> ObterTodos();

        Task<Roupa> ObterPorId(int id);
 
        Task Deletar(Roupa roupa);
 
        Task Atualizar(Roupa roupa);
  
        Task Adicionar(Roupa roupa);
    }
}
