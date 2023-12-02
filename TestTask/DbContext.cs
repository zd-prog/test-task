namespace TestTask
{
    using Microsoft.EntityFrameworkCore;
    using TestTask.Models;

    public class ApplicationContext : DbContext
    {
        private string _connectionString;

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<TimeReport> TimeReports => Set<TimeReport>();

        public ApplicationContext(string connectionString)
		{
            _connectionString = connectionString;
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}

