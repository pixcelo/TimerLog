using Dapper;
using System.Data.SqlClient;
using TimerLog.WebAPI.Attributes;
using TimerLog.WebAPI.DB.SQLServer;
using TimerLog.WebAPI.Models;

namespace TimerLog.WebAPI.Repositoriers
{
    /// <summary>
    /// タイマーログリポジトリのインターフェイス
    /// </summary>
    [Component]
    public interface ITimerLogRepository
    {
        /// <summary>
        /// タイマーログを取得する
        /// </summary>
        /// <returns></returns>
        public List<V_TimerLog> Find();

        /// <summary>
        /// タイマーログを登録する
        /// </summary>
        /// <param name="timerLog"></param>
        /// <returns></returns>
        public int Insert(T_TimerLog timerLog);

        /// <summary>
        /// タイマーログを更新する
        /// </summary>
        /// <param name="timerLog"></param>
        /// <returns></returns>
        public int Update(T_TimerLog timerLog);

        /// <summary>
        /// タイマーログを削除する
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(long id);
    }

    /// <summary>
    /// タイマーログリポジトリ
    /// </summary>
    public class TimerLogRepository : ITimerLogRepository
    {
        public List<V_TimerLog> Find()
        {
            var query = "SELECT * FROM V_TimerLog";

            using (var connection = new SqlConnection(
                SQLServerHelper.GetConnectionStringWithWindowsAuth("(localdb)\\MSSQLLocalDB", "TR")))
            {
                return connection.Query<V_TimerLog>(query).ToList();
            }
        }

        public int Insert(T_TimerLog timerLog)
        {
            var query = @"
                INSERT INTO T_TimerLog (
                    StartAt,
                    EndAt,
                    UserId,
                    TypeId
                )
                VALUES (
                    @StartAt,
                    @EndAt,
                    @UserId,
                    @TypeId
                )";

            using (var connection = new SqlConnection(
                SQLServerHelper.GetConnectionStringWithWindowsAuth("(localdb)\\MSSQLLocalDB", "TR")))
            {
                return connection.Execute(query, timerLog);
            }
        }

        public int Update(T_TimerLog timerLog)
        {
            var query = @"
                UPDATE T_TimerLog
                SET
                    StartAt = @StartAt,
                    EndAt = @EndAt,
                    UserId = @UserId,
                    TypeId = @TypeId
                WHERE
                    Id = @Id";

            using (var connection = new SqlConnection(
                SQLServerHelper.GetConnectionStringWithWindowsAuth("(localdb)\\MSSQLLocalDB", "TR")))
            {
                return connection.Execute(query, timerLog);
            }
        }

        public int Delete(long id)
        {
            var query = "DELETE FROM T_TimerLog WHERE Id = @Id";

            using (var connection = new SqlConnection(
                SQLServerHelper.GetConnectionStringWithWindowsAuth("(localdb)\\MSSQLLocalDB", "TR")))
            {
                return connection.Execute(query, new { Id = id });
            }
        }

    }
}
