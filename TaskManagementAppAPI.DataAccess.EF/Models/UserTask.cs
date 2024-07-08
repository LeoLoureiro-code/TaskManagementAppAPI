using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementAppAPI.DataAccess.EF.Models;

public partial class UserTask
{

    public UserTask( string taskTitle, string taskDescription, string taskStatus, string subtasks) 
    {
     
        TaskTitle = taskTitle;
        TaskDescription = taskDescription;
        TaskStatus = taskStatus;
        Subtasks = subtasks;
    }

    public UserTask() 
    { 
    
    }

    public int TaskId { get; set; }

    public string TaskTitle { get; set; } = null!;

    public string? TaskDescription { get; set; }

    public string TaskStatus { get; set; } = null!;

    public string? Subtasks { get; set; }
}
