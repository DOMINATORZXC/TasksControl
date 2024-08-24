using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TasksControl.Controllers
{
    public class TasksController : Controller
    {
 
        [HttpPost]
        public ActionResult TaskCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaskEdit() {  return View(); }
    }
}
