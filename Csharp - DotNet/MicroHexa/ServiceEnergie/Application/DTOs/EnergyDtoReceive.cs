namespace ServiceEnergie.Application.DTOs
{
    public class EnergyDtoReceive
    {
        public string Source { get; set; }
        public double ConsommationKWh { get; set; }
        public DateTime Date { get; set; }
    }
}
