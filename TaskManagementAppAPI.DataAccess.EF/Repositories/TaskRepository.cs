using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementAppAPI.DataAccess.EF.Context;
using TaskManagementAppAPI.DataAccess.EF.Models;

namespace TaskManagementAppAPI.DataAccess.EF.Repositories
{
    public class TaskRepository
    {
        private readonly TaskManagementAppContext _taskManagementAppContext;

        public TaskRepository(TaskManagementAppContext taskManagementAppContext)
        {
            _taskManagementAppContext = taskManagementAppContext;
        }

        public int Create(UserTask task)
        {
            _taskManagementAppContext.Add(task);
            _taskManagementAppContext.SaveChanges();

            return task.TaskId;
        }

        public int Update(int taskId, string taskTitle, string taskDescription, string taskStatus, string subtasks)
        {
            UserTask existingUserTask = _taskManagementAppContext.UserTasks.Find(taskId);
            existingUserTask.TaskTitle = taskTitle;
            existingUserTask.TaskDescription = taskDescription;
            existingUserTask.TaskStatus = taskStatus;
            existingUserTask.Subtasks = subtasks;

            _taskManagementAppContext.SaveChanges();
            return existingUserTask.TaskId;
        }

        public bool Delete(int taskId)
        {
            UserTask userTask = _taskManagementAppContext.UserTasks.Find(taskId);
            _taskManagementAppContext.Remove(userTask);
            _taskManagementAppContext.SaveChanges();
            return true;
        }

        public List<UserTask> GetAllTasks()
        {
            List<UserTask> userTaksList = _taskManagementAppContext.UserTasks.ToList();
            return userTaksList;
        }

        public UserTask GetUserTaskById(int taskId)
        {
            UserTask userTask = _taskManagementAppContext.UserTasks.Find(taskId);
            return userTask;
        }
    }
}
