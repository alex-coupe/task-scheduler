using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Util
{
    public class Enums
    {
        public enum STATUS
        {
            Pending = 1,
            Queued,
            Running,
            Paused,
            Removed,
            Completed,
            Failed
        }
    }
}
