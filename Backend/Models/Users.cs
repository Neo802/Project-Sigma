namespace ProjectRunAway.Models
{
    public class Users
    {
        public int UsersId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Personal_question { get; set; }
        public string? Personal_answer { get; set; }
        public string? Address { get; set; }
        public ICollection<Cars>? Cars { get; set; }
    }
}
