using Service.DataAccess;
using Service.DataTransfer.Interval;
using Service.DataTransfer.Job;
using Service.DataTransfer.JobResult;
using Service.DataTransfer.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Util
{
    public class Mapper
    {
        public static ReadIntervalDTO MapIntervalToReadDTO(Interval interval)
        {
            if (interval != null)
            {
                return new ReadIntervalDTO
                {
                    Day = interval.Day,
                    Hour = interval.Hour,
                    Second = interval.Second,
                    Id = interval.Id,
                    Minute = interval.Minute,
                    Month = interval.Month,
                    Year = interval.Year,
                    Jobs = interval.Jobs?.Select(x => x.Name).ToList() ?? [""],
                };
            }
            return new ReadIntervalDTO();
        }

        public static IEnumerable<ReadIntervalDTO> MapIntervalsToReadDTOs(IEnumerable<Interval> intervals)
        {
            return intervals.Select(x => new ReadIntervalDTO
            {
                Day = x.Day,
                Hour = x.Hour,
                Second = x.Second,
                Id = x.Id,
                Minute = x.Minute,
                Month = x.Month,
                Year = x.Year,
                Jobs = x.Jobs?.Select(x => x.Name).ToList() ?? [""],
            }).ToList();
        }

        public static Interval MapCreateIntervalToInterval(CreateIntervalDTO intervalDTO)
        {
            return new Interval
            {
                Second = intervalDTO.Second,
                Minute = intervalDTO.Minute,
                Day = intervalDTO.Day,
                Hour = intervalDTO.Hour,
                Month = intervalDTO.Month,
                Year = intervalDTO.Year,
            };
        }

        public static IEnumerable<ReadPlatformDTO> MapPlatformsToReadDTOs(IEnumerable<Platform> platforms)
        {
            return platforms.Select(x => new ReadPlatformDTO
            { Id = x.Id, Name = x.Name }).ToList();
        }

        public static JobResult MapCreateJobResultToJobResult(CreateJobResultDTO dto, DataContext context)
        {
            return new JobResult
            {
                Job = context.Jobs.FirstOrDefault(x => x.Id == dto.JobId)!,
                Message = dto.Message,
                Status = context.Status.FirstOrDefault(x => x.Id == dto.StatusId)!
            };
        }

        public static IEnumerable<ReadJobResultDTO> MapJobResultsToReadDTOs(int jobId, DataContext context)
        {
            var results = context.Results.Where(x => x.Job.Id == jobId).AsEnumerable();
            return results.Select(x => new ReadJobResultDTO
            {
                Message = x.Message,
                Status = x.Status.Name
            }).ToList();
        }

        public static Job MapCreateJobToJob(CreateJobDTO dto, DataContext context)
        {
            var interval = context.Intervals.FirstOrDefault(x => x.Id == dto.Interval);
            if (interval != null)
            {
                return new Job
                {
                    Content = dto.Content,
                    Created = DateTime.Now,
                    Creator = dto.Creator,
                    Parameters = dto.Parameters,
                    Path = dto.Path,
                    Interval = interval,
                    Name = dto.Name,
                    Platform = context.Platforms.FirstOrDefault(x => x.Id == dto.Platform)!,
                    Priority = dto.Priority,
                    Status = context.Status.FirstOrDefault(x => x.Id == (int)Enums.STATUS.Pending)!,
                    NextRunTime = DetermineNextRunTime(interval)
                };
            }
            return new Job();
        }

        private static DateTime DetermineNextRunTime(Interval interval)
        {
            return DateTime.Now;
        }
    }
}
