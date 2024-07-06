using Dapper;
using TimerLog.WebAPI.Attributes;
using TimerLog.WebAPI.DB.SQLServer;
using TimerLog.WebAPI.Models;

namespace TimerLog.WebAPI.Repositoriers
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
        public List<M_Users> Get();

        /// <summary>
        /// ユーザーを登録する
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Insert(M_Users user);

        /// <summary>
        /// ユーザーを更新する
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Update(M_Users user);

        /// <summary>
        /// ユーザーを削除する
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(long id);
    }

    public class UsersRepository : IUsersRepository
    {
        public List<M_Users> Get()
        {
           var query = "SELECT * FROM M_Users";

            using (var connection = SQLServerHelper.CreateConnection())
            {
                return connection.Query<M_Users>(query).ToList();
            }
        }

        public int Insert(M_Users user) {
                        var query = @"
                INSERT INTO M_Users (
                    Name                    
                ) VALUES (
                    @Name,                    
                )";

            using (var connection = SQLServerHelper.CreateConnection())
            {
                return connection.Execute(query, user);
            }
        }

        public int Update(M_Users user) {
            var query = @"
                UPDATE M_Users
                SET
                    Name = @Name                    
                WHERE
                    Id = @Id
            ";

            using (var connection = SQLServerHelper.CreateConnection())
            {
                return connection.Execute(query, user);
            }
        }

        public int Delete(long id)
        {
            var query = "DELETE FROM M_Users WHERE Id = @Id";

            using (var connection = SQLServerHelper.CreateConnection())
            {
                return connection.Execute(query, new { Id = id });
            }
        }

    }
}
