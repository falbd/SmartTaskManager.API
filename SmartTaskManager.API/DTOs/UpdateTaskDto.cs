﻿namespace SmartTaskManager.API.DTOs
{
    public class UpdateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }  
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}
