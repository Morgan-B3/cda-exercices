using Dashboard.Application.DTOs;

namespace Dashboard.Infrastructure.Http
{
    public interface ITransportClient
    {
        Task<List<TransportDto>> GetAll();
    }
}
