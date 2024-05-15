using Microsoft.AspNetCore.Identity;

namespace ProjectRunAway.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public int CarsId { get; set; }
        public Cars Cars { get; set; }
        public string OrderNr {  get; set; }
    }
}
