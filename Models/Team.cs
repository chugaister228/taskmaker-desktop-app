using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrylatoProjectDesktop.Models
{
    public class Team
    {
        private readonly TaskBook _taskBook;

        public string Name { get; }

        public Team(string name, TaskBook taskBook)
        {
            Name = name;
            _taskBook = taskBook;
        }

        public async System.Threading.Tasks.Task<IEnumerable<Models.Task>> GetAllTasks()
        {
            return await _taskBook.GetAllTasks();
        }

        public async System.Threading.Tasks.Task MakeTask(Models.Task task)
        {
            await _taskBook.AddTask(task);
        }
    }
}
