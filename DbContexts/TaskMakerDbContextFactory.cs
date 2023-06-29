using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrylatoProjectDesktop.DbContexts
{
    public class TaskMakerDbContextFactory
    {
        private readonly string _connectionString;

        public TaskMakerDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TaskMakerDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=taskmaker.db").Options;
            return new TaskMakerDbContext(options);
        }
    }
}
