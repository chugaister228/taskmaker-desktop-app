using CrylatoProjectDesktop.DbContexts;
using CrylatoProjectDesktop.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrylatoProjectDesktop.Services.TaskCreators
{
    public class DatabaseTaskCreator : ITaskCreator
    {
        private readonly TaskMakerDbContextFactory _dbContextFactory;

        public DatabaseTaskCreator(TaskMakerDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateTask(Models.Task task)
        {
            using (TaskMakerDbContext context = _dbContextFactory.CreateDbContext())
            {
                TaskDTO taskDTO = ToTaskDTO(task);

                context.Tasks.Add(taskDTO);
                await context.SaveChangesAsync();
            }
        }

        private TaskDTO ToTaskDTO(Models.Task task)
        {
            return new TaskDTO()
            {
                WorkerName = task.WorkerID.WorkerName,
                WorkerSpeciality = task.WorkerID.WorkerSpeciality,
                Description = task.Description,
                TeamleadName = task.TeamleadName,
                StartDate = task.StartDate,
                EndDate = task.EndDate
            };
        }
    }
}
