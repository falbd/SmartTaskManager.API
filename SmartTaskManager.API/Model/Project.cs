﻿namespace SmartTaskManager.API.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TaskItem> Tasks { get; set; }
    }
}
