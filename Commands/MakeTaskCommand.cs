using CrylatoProjectDesktop.Models;
using CrylatoProjectDesktop.Services;
using CrylatoProjectDesktop.Stores;
using CrylatoProjectDesktop.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrylatoProjectDesktop.Commands
{
    public class MakeTaskCommand : AsyncCommandBase
    { 
        private readonly MakeTaskViewModel _makeTaskViewModel;
        private readonly TeamStore _teamStore;
        private readonly NavigationService<TaskListingViewModel> _taskViewNavigationService;

        public MakeTaskCommand(MakeTaskViewModel makeTaskViewModel, TeamStore teamStore, NavigationService<TaskListingViewModel> taskViewNavigationService)
        {
            _makeTaskViewModel = makeTaskViewModel;
            _teamStore = teamStore;
            _taskViewNavigationService = taskViewNavigationService;
            _makeTaskViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (
            e.PropertyName == nameof(MakeTaskViewModel.Description) ||
            e.PropertyName == nameof(MakeTaskViewModel.WorkerName) ||
            e.PropertyName == nameof(MakeTaskViewModel.WorkerSpeciality) ||
            e.PropertyName == nameof(MakeTaskViewModel.TeamleadName)
            )
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return 
                !string.IsNullOrEmpty(_makeTaskViewModel.Description) &&
                !string.IsNullOrEmpty(_makeTaskViewModel.WorkerName) &&
                !string.IsNullOrEmpty(_makeTaskViewModel.WorkerSpeciality) &&
                !string.IsNullOrEmpty(_makeTaskViewModel.TeamleadName) &&
                base.CanExecute(parameter);
        }

        public override async System.Threading.Tasks.Task ExecuteAsync(object? parameter)
        {
            Models.Task task = new Models.Task(
                _makeTaskViewModel.Description,
                new WorkerID(_makeTaskViewModel.WorkerName, _makeTaskViewModel.WorkerSpeciality),
                _makeTaskViewModel.TeamleadName,
                _makeTaskViewModel.StartDate,
                _makeTaskViewModel.EndDate
                );

            try
            {
                if (task.StartDate > task.EndDate)
                {
                    MessageBox.Show("Start date can`t be after End date!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    await _teamStore.MakeTask(task);
                    MessageBox.Show("Task added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    _taskViewNavigationService.Navigate();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong to make task", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
