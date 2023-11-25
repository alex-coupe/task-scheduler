using Service.DataAccess;
using Service.DataTransfer.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        public IEnumerable<ReadStatusDTO> GetStatuses();
    }
}
