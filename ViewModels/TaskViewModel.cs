using CrylatoProjectDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrylatoProjectDesktop.ViewModels
{
    public class TaskViewModel : ViewModelBase
    {
        private readonly Task _task;

        public string Description => _task.Description;
        public string WorkerID => _task.WorkerID.ToString();
        public string TeamleadName => _task.TeamleadName;
        public string StartDate => _task.StartDate.ToString("d");
        public string EndDate => _task.EndDate.ToString("d");

        public TaskViewModel(Task task)
        {
            _task = task;
        }
    }
}
