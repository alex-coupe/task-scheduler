using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataAccess
{
    public class SeedData
    {
        public static Status[] GetStatusSeedData()
        {
            return [
                new Status
                {
                    Id = 1,
                    Name = "Pending"
                },
                new Status
                {
                    Id = 2,
                    Name = "Queued"
                },
                new Status
                {
                    Id = 3,
                    Name = "Running"
                },
                new Status
                {
                    Id = 4,
                    Name = "Paused"
                },
                new Status
                {
                    Id = 5,
                    Name = "Removed"
                },
                new Status
                {
                    Id = 6,
                    Name = "Completed"
                },
                new Status
                {
                    Id = 7,
                    Name = "Failed"
                }
            ];
        }

        public static Platform[] GetPlatformSeedData()
        {
            return [
                new Platform
                {
                    Id = 1,
                    Name = "Windows"
                },
                new Platform
                {
                    Id = 2,
                    Name = "Linux"
                },
                new Platform
                {
                    Id = 3,
                    Name = "MacOS"
                }
            ];
        }
    }
}
