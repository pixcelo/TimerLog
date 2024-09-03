using TimerLogBlazorApp.DB;
using TimerLogBlazorApp.Models;

namespace TimerLogBlazorApp.Repositories
{
    public class TimerLogsRepository : ITimerLogsRepository
    {
        private readonly TimerLogContext context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context"></param>
        public TimerLogsRepository(TimerLogContext context)
        {
            this.context = context;
        }

        public List<V_TimerLogs> Find()
        {
            return this.context.V_TimerLogs.ToList();
        }

        public List<V_TimerLogs> GetLogsByDate(DateTime date)
        {
            return this.context.V_TimerLogs
                .Where(x => x.LogDate.Date == date.Date)
                .ToList();
        }

        public int Insert(T_TimerLogs timerLog)
        {
            this.context.T_TimerLogs.Add(timerLog);
            return this.context.SaveChanges();
        }
    }
}
