using Microsoft.AspNetCore.Mvc;

namespace TasksControl.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserMainPage()
        {
            return View();
        }
    }
}
