using Microsoft.AspNetCore.Mvc;

namespace GetItDone.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {


            return View("Index");
        }
    }
}
