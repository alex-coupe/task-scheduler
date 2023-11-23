using Microsoft.EntityFrameworkCore;

namespace Service.DataAccess
{
    class DataContext : DbContext
    {
        public string DbPath { get; }
        public DbSet<Interval> Intervals { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "scheduler.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}