using Dashboard.Application.DTOs;

namespace Dashboard.Infrastructure.Http
{
    public class TransportHttpClient : ITransportClient
    {
        private readonly HttpClient _client;
        public TransportHttpClient(HttpClient client) => _client = client;

        public async Task<List<TransportDto>> GetAll()
            => await _client.GetFromJsonAsync<List<TransportDto>>("/api/transport") ?? new();

     }
}
