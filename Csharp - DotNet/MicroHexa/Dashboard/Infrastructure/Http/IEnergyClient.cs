using Dashboard.Application.DTOs;

namespace Dashboard.Infrastructure.Http
{
    public interface IEnergyClient
    {
        Task<List<EnergyDto>> GetAll();
    }
}
