using ServiceDechets.Application.DTOs;
using ServiceDechets.Domain.Entities;
using ServiceDechets.Domain.Ports;

namespace ServiceDechets.Application.Services
{
    public class WasteService : IWasteService
    {
        private readonly IWasteRepository _repo;

        public WasteService(IWasteRepository repo)
        {
            _repo = repo;
        }

        public List<WasteDtoSend> GetAll()
            => _repo.GetAll().Select(ToDto).ToList();

        public WasteDtoSend GetById(int id)
            => _repo.GetById(id) is null ? null : ToDto(_repo.GetById(id));

        public WasteDtoSend Create(WasteDtoReceive dto)
        {
            var waste = new Waste
            {
                Type = dto.Type,
                QuantiteKg = dto.QuantiteKg,
                TauxRecyclage = dto.TauxRecyclage
            };
            return ToDto(_repo.Create(waste));
        }

        public WasteDtoSend Update(int id, WasteDtoReceive dto)
        {
            var waste = _repo.GetById(id);
            if (waste == null) return null;

            waste.TauxRecyclage = dto.TauxRecyclage;
            return ToDto(_repo.Update(waste));
        }

        private WasteDtoSend ToDto(Waste w) => new()
        {
            Id = w.Id,
            Type = w.Type,
            QuantiteKg = w.QuantiteKg,
            TauxRecyclage = w.TauxRecyclage
        };
    }
}
