using DataAccess.Interfaces;
using DataAccess.Repository;
using Domain.TasksControl.Entity;
using Domain.TasksControl.Enum;
using Domain.TasksControl.Responses;
using Domain.TasksControl.ViewModel;
using Service.TasksControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Service.TasksControl.Implementations
{

    public class TasksService : ITasksService
    {
        private readonly IProjectRepository _projrep;
        public TasksService(IProjectRepository projrep)
        {
            _projrep = projrep;
        }
        public async Task<IBaseResponse<TasksViewModel>> GetById(Guid id)
        {
            var baseResponse = new BaseResponse<TasksViewModel>();
            try
            {
                var project = await _projrep.GetById(id);
                if (project == null)
                {
                    baseResponse.Desctiption = "Project not found";
                    baseResponse.StatusCode = StatusCode.TaskNotFound;
                    return baseResponse;
                }
                var data = new TasksViewModel();
                {
                    data.Id = id;
                    data.Name = project.Name;
                    data.Description = project.Description;
                    data.Author = project.Author;
                    data.DeadLine = project.DeadLine;
                    data.StatusProject = project.StatusProject;
                }
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = data;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<TasksViewModel>()
                {
                    Desctiption = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<List<Project>>> GetAll()
        {
            var baseResponse = new BaseResponse<List<Project>>();
            try
            {
                var projects = await _projrep.Select();
                if (projects.Count == null)
                {
                    baseResponse.Desctiption = "Projects not found";
                    baseResponse.StatusCode = StatusCode.TaskNotFound;
                    return baseResponse;
                }
                baseResponse.Data = projects;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Project>>()
                {
                    Desctiption = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<TasksViewModel>> CreateTask(TasksViewModel task)
        {
            var baseResponse = new BaseResponse<TasksViewModel>();
            try
            {
                var project = new Project()
                {
                    Name = task.Name,
                    Description = task.Description,
                    StatusProject = task.StatusProject,
                    Author = task.Author,
                    DeadLine = task.DeadLine
                };
                await _projrep.Create(project);
            }
            catch (Exception ex)
            {
                return new BaseResponse<TasksViewModel>()
                {
                    Desctiption = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponse;
        }
        public async Task<IBaseResponse<bool>> Delete(Guid id)
        {
            var baseResponse = new BaseResponse<bool>()
            {
                Data = true
            };
            try
            {
                var project = await _projrep.GetById(id);
                if (project == null)
                {
                    baseResponse.Desctiption = "Project not found";
                    baseResponse.StatusCode = StatusCode.TaskNotFound;
                    return baseResponse;
                }
                await _projrep.Delete(project);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Desctiption = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Project>> Edit(Guid id, TasksViewModel tasksView)
        {
            var baseResponse = new BaseResponse<Project>();
            try
            {
                var project = await _projrep.GetById(id);
                if (project == null) {
                    baseResponse.Desctiption = "Project not found";
                    baseResponse.StatusCode= StatusCode.TaskNotFound;
                    return baseResponse;
                }
                project.Name = tasksView.Name;
                project.Description = tasksView.Description;
                project.StatusProject = tasksView.StatusProject;
                project.DeadLine = tasksView.DeadLine;
                project.Author = tasksView.Author;
                await _projrep.Update(project);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Project>()
                {
                    Desctiption = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
