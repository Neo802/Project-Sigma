namespace ProjectRunAway.Models
{
    public class Availability
    {
        public string? Busy_car { get; set; }
        public DateOnly? Date_start { get; set; }
        public DateOnly? Date_end { get; set; }
        public TimeSpan? From_hour { get; set; }
        public TimeSpan? To_hour { get; set; }
        public int CarsId { get; set; }
        public Cars? Cars { get; set; }
        public int LocationsId { get; set; }
        public Locations? Locations { get; set; }
    }
}
