namespace ProjectRunAway.Models
{
    public class Cars
    {
        public int CarsId { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? Description { get; set; }
        public string? Fuel { get; set; }
        public string? Seats { get; set; }
        public string? Gear { get; set; }
        public string? Type { get; set; }
        public string? Doors { get; set; }
        public float? Price_car { get; set; }
        public float? Tank_capacity { get; set; }
        public int UsersId { get; set; }
        public Users? Users { get; set; }
        public ICollection<Availability>? Availability { get; set; }
        public ICollection<Liability>? Liability { get; set; }
        public ICollection<Features>? Features { get; set; }
    }
}
