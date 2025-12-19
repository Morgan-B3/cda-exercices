using ServiceEnergie.Domain.Entities;
using ServiceEnergie.Domain.Ports;

namespace ServiceEnergie.Infrastructure.Persistence
{
    public class EnergyRepository : IEnergyRepository
    {
        private static readonly List<Energy> _energies = new();
        private static int _id = 1;

        public List<Energy> GetAll() => _energies;

        public Energy GetById(int id)
            => _energies.FirstOrDefault(e => e.Id == id);

        public Energy Create(Energy energy)
        {
            energy.Id = _id++;
            _energies.Add(energy);
            return energy;
        }
    }
}
