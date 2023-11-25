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
        public int Second { get; set; }
        public int Minute { get; set; }
        public int Hour { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
