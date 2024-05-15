namespace ProjectRunAway.Models
{
    public class Extra
    {
        public int ExtraId { get; set; }
        public string? ChildSeat { get; set; }
        public string? TypeOfTires { get; set; }
        public string? SkiRack { get; set; }
        public string? WifiHotspot { get; set; }
        public string? SnowChains { get; set; }
        public string? RoadsideProtection { get; set; }
        public int CarsId { get; set; }
        public Cars? Cars { get; set; }
    }
}