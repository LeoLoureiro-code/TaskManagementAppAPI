using Microsoft.AspNetCore.Mvc;
using TaskManagementAppAPI.DataAccess.EF.Models;
using TaskManagementAppAPI.DataAccess.EF.Repositories;

namespace TaskManagementAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskController : Controller
    {

        private TaskRepository taskRepository;

        public UserTaskController(TaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }


        [HttpGet]
        [Route("GetTasks")]

        public IActionResult GetAllTasks() 
        {
            List<UserTask> list = new List<UserTask>();
            try
            {
                list = taskRepository.GetAllTasks();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", reponse = list });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new {message = ex.Message, response = list});
            }


        }

        [HttpGet]
        [Route("GetTaksById")]

        public IActionResult GetTaskById(int taskId) 
        { 
            UserTask userTask =  taskRepository.GetUserTaskById(taskId);
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = userTask });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new {message = "ok", response = ex});
            }
        }

        [HttpPost]
        [Route("AddTask")]

        public IActionResult AddTask([FromBody] int taskId, string taskTitle, string taskDescription, string taskStatus, string subTasks)
        {
            UserTask userTask = new UserTask(taskTitle, taskDescription, taskStatus, subTasks);

            try 
            {
                taskRepository.Create(userTask);
                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new {message = ex.Message, response = ex});
            }
        }

        [HttpPut]
        [Route("EditTask")]

        public IActionResult EditTask([FromBody] int otherParam, int taskId, string taskTitle, string taskDescription, string taskStatus, string subTasks) 
        {
            try
            {
                taskRepository.Update(taskId, taskTitle, taskDescription, taskStatus, subTasks);
                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("RemoveTask")]

        public IActionResult DeleteTask([FromBody]string otherparam,  int taskId)
        {
            taskRepository.Delete(taskId);

            try
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new {message = e.Message });
            }
        }

    }
}
