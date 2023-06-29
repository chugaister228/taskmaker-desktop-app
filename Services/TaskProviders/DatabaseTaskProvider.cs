using CrylatoProjectDesktop.DbContexts;
using CrylatoProjectDesktop.DTOs;
using CrylatoProjectDesktop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrylatoProjectDesktop.Services.TaskProviders
{
    public class DatabaseTaskProvider : ITaskProvider
    {
        private readonly TaskMakerDbContextFactory _dbContextFactory;

        public DatabaseTaskProvider(TaskMakerDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Models.Task>> GetAllTasks()
        {
            using (TaskMakerDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<TaskDTO> taskDTOs = await context.Tasks.ToListAsync();

                await System.Threading.Tasks.Task.Delay(2000);

                return taskDTOs.Select(t => ToTask(t)).Reverse();
            }
        }

        private static Models.Task ToTask(TaskDTO dto)
        {
            return new Models.Task(
                dto.Description, 
                new WorkerID(dto.WorkerName, dto.WorkerSpeciality),
                dto.TeamleadName, 
                dto.StartDate, 
                dto.EndDate
                );
        }
    }
}
