﻿using CrylatoProjectDesktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrylatoProjectDesktop.Stores
{
    public class NavigationStore
    {
        public ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel 
        { 
            get { return _currentViewModel; } 
            set { _currentViewModel = value; OnCurrentViewModelChanged(); } 
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
