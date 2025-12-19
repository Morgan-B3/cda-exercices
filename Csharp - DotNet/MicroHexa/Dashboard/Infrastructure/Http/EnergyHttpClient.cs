using Dashboard.Application.DTOs;

namespace Dashboard.Infrastructure.Http
{
    public class EnergyHttpClient : IEnergyClient
    {
        private readonly HttpClient _client;

        public EnergyHttpClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<EnergyDto>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<EnergyDto>>("/api/energy")
                   ?? new List<EnergyDto>();
        }
    }
}
