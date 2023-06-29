using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrylatoProjectDesktop.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        private bool _isExecutting;
        private bool IsExecuting
        {
            get
            {
                return _isExecutting;
            }
            set
            {
                _isExecutting = value;
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }

        public override async void Execute(object? parameter)
        {
            IsExecuting = true;

            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                IsExecuting = false;
            }
        }

        public abstract Task ExecuteAsync(object? parameter);
    }
}
