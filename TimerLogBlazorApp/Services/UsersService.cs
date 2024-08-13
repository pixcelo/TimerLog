using TimerLogBlazorApp.Models;
using TimerLogBlazorApp.Repositories;

namespace TimerLogBlazorApp.Services
{
    /// <summary>
    /// ユーザーサービス
    /// </summary>
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="usersRepository"></param>
        /// <returns></returns>
        public UsersService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public List<M_Users> Find()
        {
            return this.usersRepository.Find();
        }
    }
}
