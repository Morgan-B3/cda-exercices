namespace ServiceTransport.Application.DTOs
{
    public class TransportDtoSend
    {
        public int Id { get; set; }
        public string Mode { get; set; }
        public double DistanceKm { get; set; }
        public double FacteurEmission { get; set; }
    }
}
