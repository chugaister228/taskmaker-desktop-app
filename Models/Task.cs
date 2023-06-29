using System;

namespace CrylatoProjectDesktop.Models
{
    public class Task
    {
        public string Description { get; }
        public WorkerID WorkerID { get; }
        public string TeamleadName { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public TimeSpan LeftTime => EndDate.Subtract(StartDate);

        public Task(string description, WorkerID workerID, string teamleadName, DateTime startDate, DateTime endDate)
        {
            Description = description;
            WorkerID = workerID;
            TeamleadName = teamleadName;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
