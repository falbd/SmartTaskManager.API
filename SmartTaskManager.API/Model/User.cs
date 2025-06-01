namespace SmartTaskManager.API.Model
{
    public class UserSmartTask
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; } = "User";
        public ICollection<TaskItem> Tasks { get; set; }
    }
}
