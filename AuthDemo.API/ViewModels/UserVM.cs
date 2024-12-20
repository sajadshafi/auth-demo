namespace AuthDemo.ViewModels
{
    public class UserVM
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required string UserName { get; set; }
        public string? Phone { get; set; }
    }
}