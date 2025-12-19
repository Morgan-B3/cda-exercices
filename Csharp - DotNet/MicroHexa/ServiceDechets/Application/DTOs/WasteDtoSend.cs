namespace ServiceDechets.Application.DTOs
{
    public class WasteDtoSend
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double QuantiteKg { get; set; }
        public double TauxRecyclage { get; set; }
    }
}
