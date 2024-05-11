namespace ProjectRunAway.Models
{
    public class Locations
    {
        public int LocationsId { get; set; }
        public string? City { get; set; }
        public int? CarsAvailable { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public ICollection<Availability>? Availability { get; set; }
    }
}
