using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Cast.ClassLibrary.Service.Quartz
{
    public class Scheduler
    {
        ISchedulerFactory _factory;
        public Scheduler()
        {
            if (_factory==null)
            {
                _factory = new StdSchedulerFactory();
            }
           
        }

        /// <summary>
        /// Run This job only ONCE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobid"></param>
        /// <param name="runAt"></param>
        public void CreateJob<T>(string jobid, DateTime runAt, string player) where T:IJob
        {
            IScheduler sched = _factory.GetScheduler();
            sched.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(jobid, jobid)
                .UsingJobData("job_name", jobid)
                .UsingJobData("player", player)
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity(jobid, jobid)
                .StartAt(runAt)
                .WithSimpleSchedule(x=>x
                .WithRepeatCount(0)
                .WithMisfireHandlingInstructionNextWithRemainingCount()
                )               
                .Build();

            sched.ScheduleJob(job, trigger);

        }

        /// <summary>
        /// Job to Run with Cron Trigger (Repeating Jobs)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobid"></param>
        /// <param name="runAt"></param>
        /// <param name="crongTrigger"></param>
        public void CreateJobOnce<T>(string jobid, DateTime runAt, string crongTrigger) where T : IJob
        {
            IScheduler sched = _factory.GetScheduler();
            sched.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(jobid, jobid)
                .UsingJobData("job_name", jobid)
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity(jobid, jobid)
                .StartAt(runAt)
                .WithCronSchedule(crongTrigger)                
                .Build();

            sched.ScheduleJob(job, trigger);

        }

        public void DeleteJobs()
        {
            IScheduler sched = _factory.GetScheduler();

            List<IJobDetail> jobs = new List<IJobDetail>();

            foreach (JobKey jobKey in sched.GetJobKeys(GroupMatcher<JobKey>.AnyGroup()))
            {
                sched.DeleteJob(jobKey);
            }

        }


    }
}
