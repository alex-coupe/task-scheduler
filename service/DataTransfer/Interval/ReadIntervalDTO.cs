using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataTransfer.Interval
{
    public class ReadIntervalDTO
    {
        public int Id { get; set; }
        public IEnumerable<string> Jobs { get; set; } = default!;
        public string Second { get; set; } = default!;
        public string Minute { get; set; } = default!;
        public string Hour { get; set; } = default!;
        public string Day { get; set; } = default!;
        public string Month { get; set; } = default!;
    }
}
