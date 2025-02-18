﻿using Service.DataAccess;
using Service.DataTransfer.Interval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataTransfer.Job
{
    public class CreateJobDTO
    {
        public string Name { get; set; } = default!;
        public string? Path { get; set; }
        public string? Content { get; set; }
        public string? Parameters { get; set; }
        public string Creator { get; set; } = default!;
        public CreateIntervalDTO Interval { get; set; } = default!;
        public int Priority { get; set; }
        public int Platform { get; set; }
    }
}
