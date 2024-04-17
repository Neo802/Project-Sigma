namespace ProjectRunAway.Models
{
    public class Users
    {
        public int UsersId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public int FailedAttemptCount { get; set; }
        public string? PersonalQuestion { get; set; }
        public string? PersonalAnswer { get; set; }
        public string? Address { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Telephone { get; set; }
        public string? Email { get; set; }
        public ICollection<Cars>? Cars { get; set; }
    }
}
