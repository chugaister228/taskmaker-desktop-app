using CrylatoProjectDesktop.DbContexts;
using CrylatoProjectDesktop.Models;
using CrylatoProjectDesktop.Services;
using CrylatoProjectDesktop.Services.TaskCreators;
using CrylatoProjectDesktop.Services.TaskProviders;
using CrylatoProjectDesktop.Stores;
using CrylatoProjectDesktop.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace CrylatoProjectDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=taskmaker.db";
        private IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton(new TaskMakerDbContextFactory(CONNECTION_STRING));
                services.AddSingleton<ITaskProvider, DatabaseTaskProvider>();
                services.AddSingleton<ITaskCreator, DatabaseTaskCreator>();

                services.AddTransient<TaskBook>();
                services.AddSingleton((s) => new Team("Deafault team", s.GetRequiredService<TaskBook>()));

                services.AddTransient((s) => CreateTaskListingViewModel(s));
                services.AddSingleton<Func<TaskListingViewModel>>((s) => () => s.GetRequiredService<TaskListingViewModel>());
                services.AddSingleton<NavigationService<TaskListingViewModel>>();

                services.AddTransient<MakeTaskViewModel>();
                services.AddSingleton<Func<MakeTaskViewModel>>((s) => () => s.GetRequiredService<MakeTaskViewModel>());
                services.AddSingleton<NavigationService<MakeTaskViewModel>>();

                services.AddSingleton<TeamStore>();
                services.AddSingleton<NavigationStore>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                });
            })
            .Build();
        }

        private TaskListingViewModel CreateTaskListingViewModel(IServiceProvider services)
        {
            return TaskListingViewModel.LoadViewModel(
                services.GetRequiredService<TeamStore>(),
                services.GetRequiredService<NavigationService<MakeTaskViewModel>>()
                );
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            TaskMakerDbContextFactory taskMakerDbContextFactory = _host.Services.GetRequiredService<TaskMakerDbContextFactory>();
            using (TaskMakerDbContext dbContext = taskMakerDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            NavigationService<TaskListingViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<TaskListingViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
