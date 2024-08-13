using TimerLogBlazorApp.DB;
using TimerLogBlazorApp.Models;

namespace TimerLogBlazorApp.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TimerLogContext context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context"></param>
        public UsersRepository(TimerLogContext context)
        {
            this.context = context;
        }

        public List<M_Users> Find()
        {
            return this.context.M_Users.ToList();
        }
    }
}
