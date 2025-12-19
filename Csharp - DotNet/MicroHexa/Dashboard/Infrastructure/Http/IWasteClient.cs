using Dashboard.Application.DTOs;

namespace Dashboard.Infrastructure.Http
{
    public interface IWasteClient
    {
        Task<List<WasteDto>> GetAll();
    }
}
