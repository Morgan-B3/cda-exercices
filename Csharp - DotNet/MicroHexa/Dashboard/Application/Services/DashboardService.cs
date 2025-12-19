using Dashboard.Domain.Entities;
using Dashboard.Infrastructure.Http;

namespace Dashboard.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IEnergyClient _energyClient;
        private readonly IWasteClient _wasteClient;
        private readonly ITransportClient _transportClient;

        public DashboardService(
            IEnergyClient energyClient,
            IWasteClient wasteClient,
            ITransportClient transportClient)
        {
            _energyClient = energyClient;
            _wasteClient = wasteClient;
            _transportClient = transportClient;
        }

        public async Task<DashboardResult> GetDashboard()
        {
            var energies = await _energyClient.GetAll();
            var wastes = await _wasteClient.GetAll();
            var transports = await _transportClient.GetAll();

            return new DashboardResult
            {
                TotalEnergyConsumption = energies.Sum(e => e.ConsommationKWh),
                TotalWasteKg = wastes.Sum(w => w.QuantiteKg),
                TotalCO2Emission = transports.Sum(t => t.DistanceKm * t.FacteurEmission)
            };
        }
    }
}
