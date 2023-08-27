using Microsoft.AspNetCore.Mvc;

namespace GetIdDoneAPI.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
