using PraticaCICD.Web.DTOs;

namespace PraticaCICD.Web.Services
{
    public interface IRoupaService
    {
        Task<List<RoupaDTO>> ObterTodos();
        Task<RoupaDTO> ObterPorId(int id);
        Task Deletar(RoupaDTO roupaDTO);
        Task Atualizar(RoupaDTO roupaDTO);
        Task<bool> Adicionar(RoupaDTO roupaDTO);

    }
}
