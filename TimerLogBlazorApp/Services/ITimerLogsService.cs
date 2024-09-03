using TimerLogBlazorApp.Attributes;
using TimerLogBlazorApp.Models;

namespace TimerLogBlazorApp.Services
{
    /// <summary>
    /// タイマーログサービスのインターフェイス
    /// </summary>
    [Component]
    public interface ITimerLogsService
    {
        /// <summary>
        /// タイマーログを取得する
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
        /// タイマーログを登録する
        /// </summary>
        /// <param name="timerLog"></param>
        /// <returns></returns>
        int Save(T_TimerLogs timerLog);
    }
}
