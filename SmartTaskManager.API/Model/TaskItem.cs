namespace SmartTaskManager.API.Model
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "To Do";
        public int UserId { get; set; }
        public UserSmartTask UUserSmartTask { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}