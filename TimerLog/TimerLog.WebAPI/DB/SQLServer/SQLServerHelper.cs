using System.Data;
using System.Data.SqlClient;

namespace TimerLog.WebAPI.DB.SQLServer
{
    /// <summary>
    /// SQLServerお助けクラス
    /// </summary>
    public static class SQLServerHelper
    {
        private static readonly IConfiguration? configuration;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="configuration"></param>
        static SQLServerHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            
            configuration = builder.Build();
        }

        /// <summary>
        /// SQLServerへの接続を作成する
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateConnection()
        {
            var connectionString = configuration?.GetConnectionString("SQLServerConnection");
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// 接続文字列を取得する
        /// </summary>
        /// <param name="server"></param>
        /// <param name="database"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetConnectionString(
            string server,
            string database,
            string user,
            string password)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.InitialCatalog = database;
            builder.UserID = user;
            builder.Password = password;

            return builder.ConnectionString;
        }

        /// <summary>
        /// Windows認証を使用して接続文字列を取得する
        /// </summary>
        /// <param name="server">サーバー名</param>
        /// <param name="database">データベース名</param>
        /// <returns>接続文字列</returns>
        public static string GetConnectionStringWithWindowsAuth(
            string server,
            string database)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.InitialCatalog = database;
            builder.IntegratedSecurity = true;

            return builder.ConnectionString;
        }        

    }
}
