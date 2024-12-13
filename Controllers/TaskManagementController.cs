using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

//{"title": "test", "description": "test", "priority": "medium", "status": "TODO", "dueDate": "01-01-2001"}

namespace TaskManagementRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskManagementController : ControllerBase
    {
        private static List<Task> _tasks = new List<Task>();

        [HttpPost(Name = "CreateTask")]
        public StatusCodeResult Post(string json)
        {
            Task? newTask = JsonSerializer.Deserialize<Task>(json);
            _tasks.Add(newTask);
            return new StatusCodeResult(200);
        }

        [HttpGet(Name = "GetTasks")]
        public string Get()
        {
            string json = "";
            if (_tasks.Count > 0)
            {
                json = JsonSerializer.Serialize(_tasks);
            }
            else
            {
                json = "{}";
            }
            return json;
        }
    }
}
