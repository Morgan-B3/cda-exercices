namespace Dashboard.Application.DTOs
{
    public class EnergyDto
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public double ConsommationKWh { get; set; }
        public DateTime Date { get; set; }
    }
}
