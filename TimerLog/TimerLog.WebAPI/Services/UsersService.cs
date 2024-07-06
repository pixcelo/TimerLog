using TimerLog.WebAPI.Attributes;
using TimerLog.WebAPI.Models;
using TimerLog.WebAPI.Repositoriers;

namespace TimerLog.WebAPI.Services
{
    /// <summary>
    /// ユーザーサービスのインターフェイス
    /// </summary>
    [Component]
    public interface IUsersService
    {
        /// <summary>
        /// ユーザーを取得する
        /// </summary>
        /// <returns></returns>
        List<M_Users> Get();

        /// <summary>
        /// ユーザーを登録する
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Insert(M_Users user);

        /// <summary>
        /// ユーザーを更新する
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Update(M_Users user);

        /// <summary>
        /// ユーザーを削除する
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(long id);
    }

    /// <summary>
    /// ユーザーサービス
    /// </summary>
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="timerLogRepository"></param>
        public UsersService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public List<M_Users> Get()
        {
            return this.usersRepository.Get();
        }

        public int Insert(M_Users user)
        {
            return this.usersRepository.Insert(user);
        }

        public int Update(M_Users user)
        {
            return this.usersRepository.Update(user);
        }

        public int Delete(long id)
        {
            return this.usersRepository.Delete(id);
        }

    }
}
