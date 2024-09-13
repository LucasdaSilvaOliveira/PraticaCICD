using PraticaCICD.Web.DTOs;

namespace PraticaCICD.Web.Services
{
    public class RoupaService : IRoupaService
    {
        private readonly HttpClient _httpClient;
        public RoupaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task Adicionar(RoupaDTO roupaDTO)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(RoupaDTO roupaDTO)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(RoupaDTO roupaDTO)
        {
            throw new NotImplementedException();
        }

        public Task<RoupaDTO> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RoupaDTO>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
