using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrylatoProjectDesktop.DbContexts
{
    public class TaskMakerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<TaskMakerDbContext>
    {
        public TaskMakerDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=taskmaker.db").Options;
            return new TaskMakerDbContext(options);
        }
    }
}
