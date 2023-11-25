using Service.DataAccess;
using Service.DataTransfer.Status;
using Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly DataContext _context;

        public StatusRepository()
        {
            _context = new DataContext();
        }
        public IEnumerable<ReadStatusDTO> GetStatuses()
        {
            return _context.Status.Select(st => new ReadStatusDTO
            {
                Name = st.Name,
                Id = st.Id,
            }).ToList();
        }
    }
}
