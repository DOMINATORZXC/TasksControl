using Domain.TasksControl;
using Domain.TasksControl.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class TasksControlContext : DbContext
    {
        public TasksControlContext() 
        {
        }
        public TasksControlContext(DbContextOptions<TasksControlContext> options) 
            : base(options)
        {
        }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<SubProject> SubProjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
