namespace ProjectRunAway.Models
{
    public class Liability
    {

        public int LiabilityId { get; set; }
        public string? Category { get; set; }
        public string? Price_liability { get; set; }
        public string? About { get; set; }
        public int CarsId { get; set; }
        public Cars? Cars { get; set; }
    }
}
