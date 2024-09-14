using PraticaCICD.Web.DTOs;
using System.Text.Json;

namespace PraticaCICD.Web.Services
{
    public class RoupaService : IRoupaService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        const string BaseUrl = "Roupa";
        public RoupaService(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
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

        public async Task<List<RoupaDTO>> ObterTodos()
        {

            var httpClient = _httpClientFactory.CreateClient("RoupaService");
            
            var response = await _httpClient.GetAsync(httpClient.BaseAddress + BaseUrl);

            var responseBody = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var responseDeserialized = JsonSerializer.Deserialize<List<RoupaDTO>>(responseBody, options)!;

            return responseDeserialized;
        }
    }
}
