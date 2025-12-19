using ServiceTransport.Domain.Entities;
using ServiceTransport.Domain.Ports;

namespace ServiceTransport.Infrastructure.Persistence
{
    public class TransportRepository : ITransportRepository
    {
        private static List<Transport> _data = new();
        private static int _id = 1;

        public List<Transport> GetAll() => _data;

        public Transport GetById(int id)
            => _data.FirstOrDefault(t => t.Id == id);

        public Transport Create(Transport transport)
        {
            transport.Id = _id++;
            _data.Add(transport);
            return transport;
        }

        public Transport Update(Transport transport)
            => transport;
    }
}
