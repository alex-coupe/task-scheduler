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
                Month = intervalDTO.Month
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
            return new Job
            {
                Content = dto.Content,
                Created = DateTime.Now,
                Creator = dto.Creator,
                Parameters = dto.Parameters,
                Path = dto.Path,
                Interval = MapCreateIntervalToInterval(dto.Interval),
                Name = dto.Name,
                Platform = context.Platforms.FirstOrDefault(x => x.Id == dto.Platform)!,
                Priority = dto.Priority,
                Status = context.Status.FirstOrDefault(x => x.Id == (int)Enums.STATUS.Pending)!,
                NextRunTime = DetermineNextRunTime(dto.Interval, DateTime.Now)
                };  
        }

        public static IEnumerable<ReadJobDTO> MapJobsToReadDTOs(IEnumerable<Job> jobs)
        {
            return jobs.Select(x => new ReadJobDTO
            {
                Id = x.Id,
                Name = x.Name,
                Parameters = x.Parameters,
                Path = x.Path,
                Content = x.Content,
                Created = x.Created,
                Creator = x.Creator,
                Interval = $"{x.Interval.Second} {x.Interval.Minute} {x.Interval.Hour} {x.Interval.Day} {x.Interval.Month}",
                LastRunTime = x.LastRunTime,
                NextRunTime = x.NextRunTime,
                Platform = x.Platform.Name,
                Priority = x.Priority,
                Results = MapJobResultsToReadDTOs(x.Id,new DataContext()),
                Status = x.Status.Name
            });
        }

        public static void MapUpdateJobToJob(UpdateJobDTO updateJob, Job job)
        {
            using var context = new DataContext();
            job.Status = context.Status.FirstOrDefault(x => x.Id == updateJob.Status)!;
            job.Interval = context.Intervals.FirstOrDefault(x => x.Id == updateJob.Id)!;
            job.Name = updateJob.Name;
            job.Parameters = updateJob.Parameters;
            job.Path = updateJob.Path;
            job.Content = updateJob.Content;
            job.Priority = updateJob.Priority;
            job.Platform = context.Platforms.FirstOrDefault(x => x.Id == updateJob.Platform)!;

        }

       
        public static UpdateJobDTO MapJobToUpdateDTO(Job job)
        {
            using var context = new DataContext();
            return new UpdateJobDTO
            {
                Status = job.Status.Id,
                IntervalId = job.Interval.Id,
                Name = job.Name,
                Parameters = job.Parameters,
                Path = job.Path,
                Content = job.Content,
                Priority = job.Priority,
                Platform = job.Platform.Id
            };
        }

        private static DateTime DetermineNextRunTime(CreateIntervalDTO interval, DateTime current)
        {
            return current.AddSeconds(GetIntervalValue(interval.Second))
                .AddMinutes(GetIntervalValue(interval.Minute))
                .AddDays(GetIntervalValue(interval.Day))
                .AddMonths(GetIntervalValue(interval.Month));
        }

        private static int GetIntervalValue(string interval)
        {
            if (interval == "*") return 1;

            if (interval.StartsWith("/*")) return int.Parse(interval[2..]);

            return int.Parse(interval);

        }
    }
}
