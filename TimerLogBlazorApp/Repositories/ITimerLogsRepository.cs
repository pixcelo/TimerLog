using TimerLogBlazorApp.Attributes;
using TimerLogBlazorApp.Models;

namespace TimerLogBlazorApp.Repositories
{
    /// <summary>
    /// タイマーログリポジトリのインターフェイス
    /// </summary>
    [Component]
    public interface ITimerLogsRepository
    {
        /// <summary>
        /// ログを取得する
        /// </summary>
        /// <returns></returns>
        List<V_TimerLogs> Find();

        /// <summary>
        /// 指定日のタイマーログを取得する
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        List<V_TimerLogs> GetLogsByDate(DateTime date);

        /// <summary>
        /// ログを登録する
        /// </summary>
        /// <param name="timerLog"></param>
        /// <returns></returns>
        int Insert(T_TimerLogs timerLog);
    }
}
