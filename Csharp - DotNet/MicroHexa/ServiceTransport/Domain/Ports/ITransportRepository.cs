using ServiceTransport.Domain.Entities;

namespace ServiceTransport.Domain.Ports
{
    public interface ITransportRepository
    {
        List<Transport> GetAll();
        Transport GetById(int id);
        Transport Create(Transport transport);
        Transport Update(Transport transport);
    }
}
