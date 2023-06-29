using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrylatoProjectDesktop.DTOs
{
    public class TaskDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSpeciality { get; set; }
        public string Description { get; set; }
        public string TeamleadName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
