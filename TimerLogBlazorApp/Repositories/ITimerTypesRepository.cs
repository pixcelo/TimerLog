using TimerLogBlazorApp.Attributes;
using TimerLogBlazorApp.Models;

namespace TimerLogBlazorApp.Repositories
{
    /// <summary>
    /// タイマータイプリポジトリのインターフェイス
    /// </summary>
    [Component]
    public interface ITimerTypesRepository
    {
        /// <summary>
        /// タイマータイプを取得する
        /// </summary>
        /// <returns></returns>
        List<M_TimerTypes> Find();
    }
}
