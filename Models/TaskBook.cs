using CrylatoProjectDesktop.Services.TaskCreators;
using CrylatoProjectDesktop.Services.TaskProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrylatoProjectDesktop.Models
{
    public class TaskBook
    {
        private readonly ITaskProvider _taskProvider;
        private readonly ITaskCreator _taskCreator;

        public TaskBook(ITaskProvider taskProvider, ITaskCreator taskCreator)
        {
            _taskProvider = taskProvider;
            _taskCreator = taskCreator;
        }

        public async Task<IEnumerable<Models.Task>> GetAllTasks()
        {
            return await _taskProvider.GetAllTasks();
        }

        public async System.Threading.Tasks.Task AddTask(Models.Task task)
        {
            if (task.StartDate < task.EndDate)
            await _taskCreator.CreateTask(task);
        }
    }
}
