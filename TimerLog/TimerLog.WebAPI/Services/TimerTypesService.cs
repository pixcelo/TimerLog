using TimerLog.WebAPI.Attributes;
using TimerLog.WebAPI.Models;
using TimerLog.WebAPI.Repositoriers;

namespace TimerLog.WebAPI.Services
{
    /// <summary>
    /// タイマータイプサービスのインターフェイス
    /// </summary>
    [Component]
    public interface ITimerTypesService
    {
        /// <summary>
        /// ログを取得する
        /// </summary>
        /// <returns></returns>
        List<M_TimerType> Find();
    }

    /// <summary>
    /// タイマータイプサービス
    /// </summary>
    public class TimerTypesService : ITimerTypesService
    {
        private readonly ITimerTypesRepository repository;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="repository"></param>
        public TimerTypesService(ITimerTypesRepository repository)
        {
            this.repository = repository;
        }

        public List<M_TimerType> Find()
        {
            return this.repository.Find();
        }

    }
}
