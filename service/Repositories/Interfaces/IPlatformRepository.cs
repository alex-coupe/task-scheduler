using Service.DataTransfer.Platform;

namespace Service.Repositories.Interfaces
{
    public interface IPlatformRepository
    {
        public IEnumerable<ReadPlatformDTO> GetPlatforms();
    }
}
