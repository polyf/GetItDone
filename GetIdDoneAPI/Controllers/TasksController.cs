using GetIdDoneAPI.Data;
using GetIdDoneAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GetIdDoneAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly GetItDoneAPIDbContext dbContext;

        public TasksController(GetItDoneAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTaskAsync([FromRoute] Guid id)
        {
            var task = await dbContext.Tasks.FindAsync(id);
            if (task != null)
            {
                return Ok(task);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasksAsync()
        {
            return Ok(await dbContext.Tasks.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddTaskAsync(AddTaskRequest addTaskRequest)
        {
            var task = new Models.Task()
            {
                ID = Guid.NewGuid(),
                Name = addTaskRequest.Name,
                Status = addTaskRequest.Status,
                Created = DateTime.Now

            };

            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();

            return Ok(task);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTaskAsync([FromRoute] Guid id, UpdateTaskRequest updateTaskRequest)
        {
            var task = await dbContext.Tasks.FindAsync(id);

            if (task != null)
            {
                task.Name = updateTaskRequest.Name;
                task.Status = updateTaskRequest.Status;
                task.Edited = DateTime.Now;

                await dbContext.SaveChangesAsync();

                return Ok(task);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteTaskAsync([FromRoute] Guid id)
        {
            var task = await dbContext.Tasks.FindAsync(id);
            if (task != null)
            {
                dbContext.Remove(task);
                await dbContext.SaveChangesAsync();
                return Ok(task);
            }
            return NotFound(id);
        }
    }
}
