using ServiceDechets.Domain.Entities;

namespace ServiceDechets.Domain.Ports
{
    public interface IWasteRepository
    {
        List<Waste> GetAll();
        Waste GetById(int id);
        Waste Create(Waste waste);
        Waste Update(Waste waste);
    }
}
