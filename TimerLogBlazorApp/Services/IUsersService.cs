using TimerLogBlazorApp.Models;

namespace TimerLogBlazorApp.Services
{
    /// <summary>
    /// ユーザーサービスのインターフェイス
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// ユーザーを取得する
        /// </summary>
        /// <returns></returns>
        List<M_Users> Find();
    }
}
