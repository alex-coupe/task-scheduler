using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataTransfer.Interval
{
    public class CreateIntervalDTO
    {
        public string Second { get; set; } = default!;
        public string Minute { get; set; } = default!;
        public string Hour { get; set; } = default!;
        public string Day { get; set; } = default!;
        public string Month { get; set; } = default!;
    }
}
