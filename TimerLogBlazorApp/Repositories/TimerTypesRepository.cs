using TimerLogBlazorApp.DB;
using TimerLogBlazorApp.Models;

namespace TimerLogBlazorApp.Repositories
{
    public class TimerTypesRepository : ITimerTypesRepository
    {
        private readonly TimerLogContext context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context"></param>
        public TimerTypesRepository(TimerLogContext context)
        {
            this.context = context;
        }

        public List<M_TimerTypes> Find()
        {
            return this.context.M_TimerTypes.ToList();
        }
    }
}
