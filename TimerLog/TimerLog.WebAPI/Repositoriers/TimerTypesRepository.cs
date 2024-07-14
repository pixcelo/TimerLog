using TimerLog.WebAPI.Attributes;
using TimerLog.WebAPI.DB.Contexts;
using TimerLog.WebAPI.Models;

namespace TimerLog.WebAPI.Repositoriers
{
    /// <summary>
    /// ユーザーリポジトリのインターフェイス
    /// </summary>
    [Component]
    public interface ITimerTypesRepository
    {
        /// <summary>
        /// ユーザーを取得する
        /// </summary>
        /// <returns></returns>
        public List<M_TimerType> Find();
    }

    public class TimerTypesRepository : ITimerTypesRepository
    {
        private readonly StopwatchLogsContext context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context"></param>
        
        public TimerTypesRepository(StopwatchLogsContext context)
        {
            this.context = context;
        }

        public List<M_TimerType> Find()
        {
            return this.context.M_TimerType.ToList();
        }

    }
}
