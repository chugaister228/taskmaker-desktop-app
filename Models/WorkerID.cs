using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrylatoProjectDesktop.Models
{
    public class WorkerID
    {
        public string WorkerName { get; }
        public string WorkerSpeciality { get; }

        public WorkerID(string workerName, string workerSpeciality)
        {
            WorkerName = workerName;
            WorkerSpeciality = workerSpeciality;
        }

        public override string ToString()
        {
            return $"{WorkerName} {WorkerSpeciality}";
        }
    }
}
