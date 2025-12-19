using ServiceTransport.Application.DTOs;

namespace ServiceTransport.Application.Services
{
    public interface ITransportService
    {
        List<TransportDtoSend> GetAll();
        TransportDtoSend GetById(int id);
        TransportDtoSend Create(TransportDtoReceive dto);
        TransportDtoSend Update(int id, TransportDtoReceive dto);
        double GetEmissionCO2(int id);
    }
}
