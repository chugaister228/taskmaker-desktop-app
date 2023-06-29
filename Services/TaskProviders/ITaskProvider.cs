using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrylatoProjectDesktop.Services.TaskProviders
{
    public interface ITaskProvider
    {
        Task<IEnumerable<Models.Task>> GetAllTasks();
    }
}
