using ServiceEnergie.Domain.Entities;

namespace ServiceEnergie.Domain.Ports
{
    public interface IEnergyRepository
    {
        List<Energy> GetAll();
        Energy GetById(int id);
        Energy Create(Energy energy);
    }
}
