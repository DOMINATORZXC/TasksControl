using DataAccess.Interfaces;
using Domain.TasksControl;
using Domain.TasksControl.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TasksControlContext _context;
        public ProjectRepository(TasksControlContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Project entity)
        {
            _context.Projects.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Project entity)
        {
            _context.Projects.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Project> GetById(Guid id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public Task<List<Project>> Select()
        {
            return _context.Projects.ToListAsync();
        }

        public async Task<Project> Update(Project entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
