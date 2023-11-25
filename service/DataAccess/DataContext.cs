using Microsoft.EntityFrameworkCore;

namespace Service.DataAccess
{
    public class DataContext : DbContext
    {
        public string DbPath { get; }
        public DbSet<Interval> Intervals { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobResult> Results { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                SeedData.GetStatusSeedData()
            );

            modelBuilder.Entity<Platform>().HasData(
                SeedData.GetPlatformSeedData()
            );
        }

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