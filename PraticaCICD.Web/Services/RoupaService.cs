using PraticaCICD.Web.DTOs;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace PraticaCICD.Web.Services
{
    public class RoupaService : IRoupaService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        const string BaseUrl = "Roupa";
        public string FullUri;
        public RoupaService(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
            FullUri = _httpClientFactory.CreateClient("RoupaService").BaseAddress!.AbsoluteUri + BaseUrl;
        }
        public async Task<bool> Adicionar(RoupaDTO roupaDTO)
        {
            var content = JsonContent.Create(roupaDTO);

            var response = await _httpClient.PostAsync(FullUri, content);

            if (response.IsSuccessStatusCode) return true;

            return false;
        }

        public async Task<bool> Atualizar(RoupaDTO roupaDTO)
        {
            var content = JsonContent.Create(roupaDTO);

            var response = await _httpClient.PutAsync(FullUri + $"/{roupaDTO.Id}", content);

            if (response.IsSuccessStatusCode) return true;

            return false;
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

            var response = await _httpClient.GetAsync(FullUri);

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
