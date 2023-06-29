using CrylatoProjectDesktop.Commands;
using CrylatoProjectDesktop.Models;
using CrylatoProjectDesktop.Services;
using CrylatoProjectDesktop.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrylatoProjectDesktop.ViewModels
{
    public class MakeTaskViewModel : ViewModelBase
    {
        private string _description;
        public string Description 
        { 
            get { return _description; } 
            set { _description = value; OnPropertyChanged(nameof(Description)); } 
        }

        private string _workerName;
        public string WorkerName
        {
            get { return _workerName; }
            set { _workerName = value; OnPropertyChanged(nameof(WorkerName)); }
        }

        private string _workerSpeciality;
        public string WorkerSpeciality
        {
            get { return _workerSpeciality; }
            set { _workerSpeciality = value; OnPropertyChanged(nameof(WorkerSpeciality)); }
        }

        private string _teamleadName;
        public string TeamleadName
        {
            get { return _teamleadName; }
            set { _teamleadName = value; OnPropertyChanged(nameof(TeamleadName)); }
        }

        private DateTime _startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day); //setting default start time
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; OnPropertyChanged(nameof(StartDate)); }
        }

        private DateTime _endDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day); //setting default end time
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; OnPropertyChanged(nameof(EndDate)); }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeTaskViewModel(TeamStore teamStore, NavigationService<TaskListingViewModel> taskViewNavigationService)
        {
            SubmitCommand = new MakeTaskCommand(this, teamStore, taskViewNavigationService);
            CancelCommand = new NavigateCommand<TaskListingViewModel>(taskViewNavigationService);
        }
    }
}
