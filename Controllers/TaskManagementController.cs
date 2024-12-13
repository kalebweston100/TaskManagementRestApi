using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskManagementController : ControllerBase
    {
        private List<Task> _tasks = new List<Task>();

        [HttpPost(Name = "CreateTask")]
        public StatusCodeResult Post(string json)
        {
            Task? newTask = JsonSerializer.Deserialize<Task>(json);
            _tasks.Append(newTask);
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
