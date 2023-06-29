using CrylatoProjectDesktop.Models;
using CrylatoProjectDesktop.Stores;
using CrylatoProjectDesktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrylatoProjectDesktop.Commands
{
    public class LoadTasksCommand : AsyncCommandBase
    {
        private readonly TeamStore _teamStore;
        private readonly TaskListingViewModel _viewModel;

        public LoadTasksCommand(TeamStore teamStore, TaskListingViewModel viewModel)
        {
            _teamStore = teamStore;
            _viewModel = viewModel;
        }

        public override async System.Threading.Tasks.Task ExecuteAsync(object? parameter)
        {
            _viewModel.IsLoading = true;

            try
            {
                await _teamStore.Load();
                _viewModel.UpdateTasks(_teamStore.Tasks);
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong to load tasks", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            _viewModel.IsLoading = false;
        }
    }
}
