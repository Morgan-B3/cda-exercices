namespace ServiceTransport.Domain.Entities
{
    public class Transport
    {
        public int Id { get; set; }
        public string Mode { get; set; }
        public double DistanceKm { get; set; }
        public double FacteurEmission { get; set; }
    }
}
