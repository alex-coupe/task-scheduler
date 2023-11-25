using Service.DataAccess;
using Service.DataTransfer.Platform;
using Service.Repositories.Interfaces;
using Service.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly DataContext _context;

        public PlatformRepository()
        {
            _context = new DataContext();
        }
        public IEnumerable<ReadPlatformDTO> GetPlatforms()
        {
            return Mapper.MapPlatformsToReadDTOs(_context.Platforms.AsEnumerable());
        }
    }
}
