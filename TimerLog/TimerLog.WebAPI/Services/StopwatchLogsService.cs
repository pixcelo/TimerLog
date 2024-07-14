using TimerLog.WebAPI.Attributes;
using TimerLog.WebAPI.Models;
using TimerLog.WebAPI.Repositoriers;

namespace TimerLog.WebAPI.Services
{
    /// <summary>
    /// ストップウォッチログサービスのインターフェイス
    /// </summary>
    [Component]
    public interface IStopwatchLogsService
    {
        /// <summary>
        /// ログを取得する
        /// </summary>
        /// <returns></returns>
        List<V_StopwatchLogs> Find();

        /// <summary>
        /// ログを登録する
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        int Insert(T_StopwatchLogs log);

        /// <summary>
        /// ログを更新する
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        int Update(T_StopwatchLogs log);

        /// <summary>
        /// ログを削除する
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        int Delete(long id);
    }

    /// <summary>
    /// ストップウォッチログサービス
    /// </summary>
    public class StopwatchLogsService : IStopwatchLogsService
    {
        private readonly IStopwatchLogsRepository repository;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="repository"></param>
        public StopwatchLogsService(IStopwatchLogsRepository repository)
        {
            this.repository = repository;
        }

        public List<V_StopwatchLogs> Find()
        {
            return this.repository.Find();
        }

        public int Insert(T_StopwatchLogs log)
        {
            return this.repository.Insert(log);
        }

        public int Update(T_StopwatchLogs log)
        {
            return this.repository.Update(log);
        }

        public int Delete(long id)
        {
            return this.repository.Delete(id);
        }

    }
}
