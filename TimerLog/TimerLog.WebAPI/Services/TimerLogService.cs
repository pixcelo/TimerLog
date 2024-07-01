using TimerLog.WebAPI.Models;
using TimerLog.WebAPI.Repositoriers;

namespace TimerLog.WebAPI.Services
{
    /// <summary>
    /// タイマーログサービスのインターフェイス
    /// </summary>
    public interface ITimerLogService
    {
        /// <summary>
        /// タイマーログを取得する
        /// </summary>
        /// <returns></returns>
        List<V_TimerLog> Find();

        /// <summary>
        /// タイマーログを登録する
        /// </summary>
        /// <param name="timerLog"></param>
        /// <returns></returns>
        int Insert(T_TimerLog timerLog);

        /// <summary>
        /// タイマーログを更新する
        /// </summary>
        /// <param name="timerLog"></param>
        /// <returns></returns>
        int Update(T_TimerLog timerLog);

        /// <summary>
        /// タイマーログを削除する
        /// </summary>
        /// <param name="timerLog"></param>
        /// <returns></returns>
        int Delete(long id);
    }

    /// <summary>
    /// タイマーログサービス
    /// </summary>
    public class TimerLogService : ITimerLogService
    {
        private readonly ITimerLogRepository timerLogRepository;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="timerLogRepository"></param>
        public TimerLogService(ITimerLogRepository timerLogRepository)
        {
            this.timerLogRepository = timerLogRepository;
        }

        public List<V_TimerLog> Find()
        {
            return this.timerLogRepository.Find();
        }

        public int Insert(T_TimerLog timerLog)
        {
            return this.timerLogRepository.Insert(timerLog);
        }

        public int Update(T_TimerLog timerLog)
        {
            return this.timerLogRepository.Update(timerLog);
        }

        public int Delete(long id)
        {
            return this.timerLogRepository.Delete(id);
        }

    }
}
