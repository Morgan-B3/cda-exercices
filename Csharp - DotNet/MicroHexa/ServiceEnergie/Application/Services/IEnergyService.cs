using ServiceEnergie.Application.DTOs;

namespace ServiceEnergie.Application.Services
{
    public interface IEnergyService
    {
        List<EnergyDtoSend> GetAll();
        EnergyDtoSend GetById(int id);
        EnergyDtoSend Create(EnergyDtoReceive dto);
    }
}
