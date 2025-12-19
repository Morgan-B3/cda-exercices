using ServiceTransport.Application.DTOs;
using ServiceTransport.Domain.Entities;
using ServiceTransport.Domain.Ports;

namespace ServiceTransport.Application.Services
{
    public class TransportService : ITransportService
    {
        private readonly ITransportRepository _repository;

        public TransportService(ITransportRepository repository)
        {
            _repository = repository;
        }

        public List<TransportDtoSend> GetAll()
            => _repository.GetAll().Select(ToDto).ToList();

        public TransportDtoSend GetById(int id)
            => _repository.GetById(id) is null ? null : ToDto(_repository.GetById(id));

        public TransportDtoSend Create(TransportDtoReceive dto)
        {
            var transport = new Transport
            {
                Mode = dto.Mode,
                DistanceKm = dto.DistanceKm,
                FacteurEmission = GetFacteur(dto.Mode)
            };

            return ToDto(_repository.Create(transport));
        }

        public TransportDtoSend Update(int id, TransportDtoReceive dto)
        {
            var transport = _repository.GetById(id);
            if (transport == null) return null;

            transport.Mode = dto.Mode;
            transport.DistanceKm = dto.DistanceKm;
            transport.FacteurEmission = GetFacteur(dto.Mode);

            return ToDto(_repository.Update(transport));
        }

        public double GetEmissionCO2(int id)
        {
            var transport = _repository.GetById(id);
            if (transport == null) return -1;

            return transport.DistanceKm * transport.FacteurEmission;
        }

        private double GetFacteur(string mode)
        {
            return mode switch
            {
                "Voiture" => 120,
                "Bus" => 80,
                "Train" => 30,
                "Vélo" => 0,
                _ => 0
            };
        }

        private TransportDtoSend ToDto(Transport t)
        {
            return new TransportDtoSend
            {
                Id = t.Id,
                Mode = t.Mode,
                DistanceKm = t.DistanceKm,
                FacteurEmission = t.FacteurEmission
            };
        }
    }
}
