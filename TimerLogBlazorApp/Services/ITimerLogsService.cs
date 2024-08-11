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
        /// タイマーログを登録する
        /// </summary>
        /// <param name="timerLog"></param>
        /// <returns></returns>
        int Insert(T_TimerLogs timerLog);
    }
}
