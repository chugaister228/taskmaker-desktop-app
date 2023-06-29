using CrylatoProjectDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrylatoProjectDesktop.Stores
{
    public class TeamStore
    {
        private readonly List<Models.Task> _tasks;
        private readonly Team _team;
        private readonly Lazy<System.Threading.Tasks.Task> _initializeLazy;

        public IEnumerable<Models.Task> Tasks => _tasks;

        public TeamStore(Team team)
        {
            _team = team;
            _initializeLazy = new Lazy<System.Threading.Tasks.Task>(Initialize);
            _tasks = new List<Models.Task>();
        }

        public async System.Threading.Tasks.Task Load()
        {
            await _initializeLazy.Value;
        }

        public async System.Threading.Tasks.Task MakeTask(Models.Task task)
        {
            await _team.MakeTask(task);
            _tasks.Add(task);
        }

        private async System.Threading.Tasks.Task Initialize()
        {
            IEnumerable<Models.Task> tasks = await _team.GetAllTasks();

            _tasks.Clear();
            _tasks.AddRange(tasks);
        }
    }
}
