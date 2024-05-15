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
        public float? PriceCar { get; set; }
        public float? TankCapacity { get; set; }
     /*   public int Id { get; set; }
        public User? Users { get; set; }*/
        public ICollection<Orders>? Orders { get; set; }
        public ICollection<Availability>? Availability { get; set; }
        public ICollection<Liability>? Liability { get; set; }
        public ICollection<Features>? Features { get; set; }
    }
}
