using Domain.TasksControl.Entity;
using Domain.TasksControl.Responses;
using Domain.TasksControl.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TasksControl.Interfaces
{
    public interface ITasksService
    {
        Task<IBaseResponse<TasksViewModel>> GetById(Guid id);
        Task<IBaseResponse<List<Project>>> GetAll();
        Task<IBaseResponse<TasksViewModel>> CreateTask(TasksViewModel tasksView);
        Task<IBaseResponse<bool>> Delete(Guid id);
        Task<IBaseResponse<Project>> Edit(Guid id, TasksViewModel tasksView);

    }
}
