using TimerLogBlazorApp.Models;

namespace TimerLogBlazorApp.Services
{
    /// <summary>
    /// タイマータイプサービスのインターフェイス
    /// </summary>
    public interface ITimerTypesService
    {
        /// <summary>
        /// タイマータイプを取得する
        /// </summary>
        /// <returns></returns>
        List<M_TimerTypes> Find();
    }
}
