namespace ServiceEnergie.Application.DTOs
{
    public class EnergyDtoSend
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public double ConsommationKWh { get; set; }
        public DateTime Date { get; set; }
    }
}
