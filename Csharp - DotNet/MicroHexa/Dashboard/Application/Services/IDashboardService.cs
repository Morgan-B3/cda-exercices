using Dashboard.Domain.Entities;

namespace Dashboard.Application.Services
{
    public interface IDashboardService
    {
        Task<DashboardResult> GetDashboard();
    }
}
