using TimerLogBlazorApp.Attributes;
using TimerLogBlazorApp.Models;

namespace TimerLogBlazorApp.Repositories
{
    /// <summary>
    /// ユーザーリポジトリのインターフェイス
    /// </summary>
    [Component]
    public interface IUsersRepository
    {
        /// <summary>
        /// ユーザーを取得する
        /// </summary>
        /// <returns></returns>
        List<M_Users> Find();
    }
}
