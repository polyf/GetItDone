using GetIdDoneAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetItDone.Controllers
{
    public class TaskController : Controller
    {
        public async Task<IActionResult> Index()
        {
            TaskListViewModel viewModel = new TaskListViewModel();
            viewModel.Tasks = await viewModel.LoadTasksFromApiAsync();
            return View(viewModel);
        }
    }
}
