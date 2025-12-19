using ServiceEnergie.Application.DTOs;
using ServiceEnergie.Domain.Entities;
using ServiceEnergie.Domain.Ports;

namespace ServiceEnergie.Application.Services
{
    public class EnergyService : IEnergyService
    {
        private readonly IEnergyRepository _repository;

        public EnergyService(IEnergyRepository repository)
        {
            _repository = repository;
        }

        public List<EnergyDtoSend> GetAll()
        {
            return _repository.GetAll()
                .Select(ToDto)
                .ToList();
        }

        public EnergyDtoSend GetById(int id)
        {
            var energy = _repository.GetById(id);
            return energy == null ? null : ToDto(energy);
        }

        public EnergyDtoSend Create(EnergyDtoReceive dto)
        {
            var energy = new Energy
            {
                Source = dto.Source,
                ConsommationKWh = dto.ConsommationKWh,
                Date = dto.Date
            };

            return ToDto(_repository.Create(energy));
        }

        private EnergyDtoSend ToDto(Energy energy)
        {
            return new EnergyDtoSend
            {
                Id = energy.Id,
                Source = energy.Source,
                ConsommationKWh = energy.ConsommationKWh,
                Date = energy.Date
            };
        }
    }
}
