using Domain.TasksControl.Entity;
using Domain.TasksControl.Responses;
using Domain.TasksControl.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.TasksControl.Implementations;
using Service.TasksControl.Interfaces;

namespace TasksControl.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksService _taskSrvce;
        public TasksController (ITasksService taskSrvce)
        {
            _taskSrvce = taskSrvce;
        }

        [HttpGet]
        public async Task<ActionResult> TaskGetList()
        {
            var response = await _taskSrvce.GetAll();
            if (response.StatusCode == Domain.TasksControl.Enum.StatusCode.OK)
            {
                return View(response.Data.ToList());
            }
            return RedirectToAction();
        }

        [HttpPost]
        public async Task<ActionResult> TaskCreate(TasksViewModel model)
        {
            
            if (ModelState.IsValid) {
                if (model.Id == null)
                {
                    await _taskSrvce.CreateTask(model);
                }
                else
                {
                    await _taskSrvce.Edit(model.Id, model);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> TaskEdit(TasksViewModel model) 
        {  
            if(ModelState.IsValid)
            {
                if (model.Id != null)
                {
                    await _taskSrvce.Edit(model.Id ,model);
                }
                else
                {
                    await _taskSrvce.CreateTask(model);
                }
            }
            return View(); 
        }
    }
}
