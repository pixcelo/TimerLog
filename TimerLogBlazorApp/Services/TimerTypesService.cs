using TimerLogBlazorApp.Models;
using TimerLogBlazorApp.Repositories;

namespace TimerLogBlazorApp.Services
{
    /// <summary>
    /// タイマータイプサービス
    /// </summary>
    public class TimerTypesService : ITimerTypesService
    {
        private readonly ITimerTypesRepository timerTypesRepository;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="timerTypesRepository"></param>
        /// <returns></returns>
        public TimerTypesService(ITimerTypesRepository timerTypesRepository)
        {
            this.timerTypesRepository = timerTypesRepository;
        }

        public List<M_TimerTypes> Find()
        {
            return this.timerTypesRepository.Find();
        }
    }
}
