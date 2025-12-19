using ServiceDechets.Domain.Entities;
using ServiceDechets.Domain.Ports;

namespace ServiceDechets.Infrastructure.Persistence
{
    public class WasteRepository : IWasteRepository
    {
        private static List<Waste> _data = new();
        private static int _id = 1;

        public List<Waste> GetAll() => _data;

        public Waste GetById(int id)
            => _data.FirstOrDefault(w => w.Id == id);

        public Waste Create(Waste waste)
        {
            waste.Id = _id++;
            _data.Add(waste);
            return waste;
        }

        public Waste Update(Waste waste)
            => waste;
    }
}
