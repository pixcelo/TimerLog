using TimerLog.WebAPI.Attributes;
using TimerLog.WebAPI.DB.Contexts;
using TimerLog.WebAPI.Models;

namespace TimerLog.WebAPI.Repositoriers
{
    /// <summary>
    /// ストップウォッチログリポジトリのインターフェイス
    /// </summary>
    [Component]
    public interface IStopwatchLogsRepository
    {
        /// <summary>
        /// ログを取得する
        /// </summary>
        /// <returns></returns>
        public List<V_StopwatchLogs> Find();

        /// <summary>
        /// ログを登録する
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public int Insert(T_StopwatchLogs log);

        /// <summary>
        /// ログを更新する
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public int Update(T_StopwatchLogs log);

        /// <summary>
        /// ログを削除する
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(long id);
    }

    /// <summary>
    /// ストップウォッチログリポジトリ
    /// </summary>
    public class V_StopwatchLogsRepository : IStopwatchLogsRepository
    {
        private readonly StopwatchLogsContext context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context"></param>
        public V_StopwatchLogsRepository(StopwatchLogsContext context)
        {
            this.context = context;
        }

        public List<V_StopwatchLogs> Find()
        {
            return this.context.V_StopwatchLogs.ToList();
        }

        public int Insert(T_StopwatchLogs log)
        {
            this.context.T_StopwatchLogs.Add(log);
            return this.context.SaveChanges();
        }

        public int Update(T_StopwatchLogs log)
        {
            this.context.T_StopwatchLogs.Update(log);
            return this.context.SaveChanges();
        }

        public int Delete(long id)
        {
            var log = this.context.T_StopwatchLogs.Find(id);
            if (log is not null)
            {
                this.context.T_StopwatchLogs.Remove(log);
                return this.context.SaveChanges();
            }
            return 0;
        }

    }
}
