using Dashboard.Application.DTOs;

namespace Dashboard.Infrastructure.Http
{
    public class WasteHttpClient : IWasteClient
    {
        private readonly HttpClient _client;
        public WasteHttpClient(HttpClient client) => _client = client;

        public async Task<List<WasteDto>> GetAll()
            => await _client.GetFromJsonAsync<List<WasteDto>>("/api/waste") ?? new();
    }
}
