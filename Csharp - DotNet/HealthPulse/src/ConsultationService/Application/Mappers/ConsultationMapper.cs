using ConsultationService.Application.DTOs;
using ConsultationService.Domain.Entities;

namespace ConsultationService.Application.Mappers
{
    public static class ConsultationMapper
    {
        public static ConsultationResponseDto ToDto(Consultation consultation)
        {
            return new ConsultationResponseDto
            {
                Id = consultation.Id,
                PatientId = consultation.PatientId,
                Motif = consultation.Motif.ToString(),
                DateConsultation = consultation.DateConsultation,
                DureeMinutes = consultation.DureeMinutes,
                Tarif = consultation.Tarif
            };
        }

        public static Consultation ToEntity(ConsultationRequestDto dto)
        {
            if (!Enum.TryParse<MotifConsultation>(
                dto.Motif,
                ignoreCase: true,
                out var motif))
            {
                throw new ArgumentException($"Motif invalide : {dto.Motif}");
            }

            return new Consultation
            {
                Id = Guid.NewGuid(),
                PatientId = dto.PatientId,
                Motif = motif,
                DateConsultation = dto.DateConsultation,
                DureeMinutes = dto.DureeMinutes,
                Tarif = dto.Tarif
            };
        }

        public static IEnumerable<ConsultationResponseDto> ToDtoList(IEnumerable<Consultation> consultations)
        {
            return consultations.Select(ToDto);
        }
    }
}
