using CrylatoProjectDesktop.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrylatoProjectDesktop.DbContexts
{
    public class TaskMakerDbContext : DbContext
    {
        public TaskMakerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskDTO> Tasks { get; set; }
    }
}
