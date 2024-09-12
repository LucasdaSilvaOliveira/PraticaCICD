using Microsoft.EntityFrameworkCore;
using PraticaCICD.Api.Data.Context;
using PraticaCICD.Api.Data.Entities;

namespace PraticaCICD.Api.Data.Repositories
{
    public class RoupaRepository : IRoupaRepository
    {
        private readonly BancoContext _bancoContext;
        public RoupaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task Adicionar(Roupa roupa)
        {
            await _bancoContext.Roupas.AddAsync(roupa);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task Atualizar(Roupa roupa)
        {
            _bancoContext.Roupas.Update(roupa);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task Deletar(Roupa roupa)
        {
            _bancoContext.Roupas.Remove(roupa);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task<Roupa> ObterPorId(int id)
        {
            var roupa = await _bancoContext.Roupas.FirstOrDefaultAsync(roupa => roupa.Id == id);
            return roupa!;
        }

        public async Task<List<Roupa>> ObterTodos()
        {
            var roupas = await _bancoContext.Roupas.ToListAsync();
            return roupas;
        }
    }
}
