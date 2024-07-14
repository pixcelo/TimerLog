namespace TimerLog.WebAPI.Models
{
    /// <summary>
    /// ストップウォッチログ
    /// </summary>
    public class T_StopwatchLogs
    {
        /// <summary>
        /// ログID
        /// </summary>
        public long LogId { get; set; }
        
        /// <summary>
        /// 経過時間
        /// </summary>
        public DateTime ElapsedTime { get; set; }

        /// <summary>
        /// ユーザーID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// タイプID
        /// </summary>
        public long TypeId { get; set; }
    }
}
