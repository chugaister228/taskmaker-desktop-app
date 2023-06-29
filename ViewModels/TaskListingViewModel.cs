using CrylatoProjectDesktop.Commands;
using CrylatoProjectDesktop.Models;
using CrylatoProjectDesktop.Services;
using CrylatoProjectDesktop.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CrylatoProjectDesktop.ViewModels
{
    public class TaskListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TaskViewModel> _tasks;

        public IEnumerable<TaskViewModel> Tasks => _tasks;

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand LoadTasksCommand { get; }
        public ICommand MakeTaskCommand { get; }

        public TaskListingViewModel(TeamStore teamStore, NavigationService<MakeTaskViewModel> makeTaskNavigationService) 
        {
            _tasks = new ObservableCollection<TaskViewModel>();

            LoadTasksCommand = new LoadTasksCommand(teamStore, this);
            MakeTaskCommand = new NavigateCommand<MakeTaskViewModel>(makeTaskNavigationService);
        }

        public static TaskListingViewModel LoadViewModel(TeamStore teamStore, NavigationService<MakeTaskViewModel> makeTaskNavigationService)
        {
            TaskListingViewModel viewModel = new TaskListingViewModel(teamStore, makeTaskNavigationService);
            viewModel.LoadTasksCommand.Execute(null);
            return viewModel;
        }

        public void UpdateTasks(IEnumerable<Models.Task> tasks)
        {
            _tasks.Clear();

            foreach (var task in tasks)
            {
                TaskViewModel taskViewModel = new TaskViewModel(task);
                _tasks.Add(taskViewModel);
            }
        }
    }
}
