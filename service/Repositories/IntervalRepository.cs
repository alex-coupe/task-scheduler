using Service.DataAccess;
using Service.DataTransfer.Interval;
using Service.Repositories.Interfaces;
using Service.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public class IntervalRepository : IIntervalRepository
    {
        private readonly DataContext _context;

        public IntervalRepository() 
        {
            _context = new DataContext();
        }
        public async Task CreateInterval(CreateIntervalDTO intervalDTO)
        {
            _context.Intervals.Add(Mapper.MapCreateIntervalToInterval(intervalDTO));
            await _context.SaveChangesAsync();
        }

        public ReadIntervalDTO GetIntervalById(int id)
        {
            var interval = _context.Intervals.FirstOrDefault(x => x.Id == id);
            return Mapper.MapIntervalToReadDTO(interval!);
        }

        public IEnumerable<ReadIntervalDTO> GetIntervals()
        {
            var intervals = _context.Intervals.AsEnumerable();
            return Mapper.MapIntervalsToReadDTOs(intervals);
        }
    }
}
