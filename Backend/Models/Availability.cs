namespace ProjectRunAway.Models
{
    public class Availability
    {
        public string? BusyCar { get; set; }
        public DateOnly? DateStart { get; set; }
        public DateOnly? DateEnd { get; set; }
        public TimeSpan? FromHour { get; set; }
        public TimeSpan? ToHour { get; set; }
        public int CarsId { get; set; }
        public Cars? Cars { get; set; }
        public int LocationsId { get; set; }
        public Locations? Locations { get; set; }
    }
}
