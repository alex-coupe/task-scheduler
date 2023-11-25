using Service.DataTransfer.Interval;

namespace Service.Repositories.Interfaces
{
    public interface IIntervalRepository
    {
        public Task CreateInterval(CreateIntervalDTO interval);
        public IEnumerable<ReadIntervalDTO> GetIntervals();
        public ReadIntervalDTO GetIntervalById(int id);
    }
}
