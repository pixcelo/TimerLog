namespace TimerLog.WebAPI.Models
{
    /// <summary>
    /// タイマーログ
    /// </summary>
    public class T_TimerLog
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime StartAt { get; set; }

        /// <summary>
        /// 終了時間
        /// </summary>
        public DateTime EndAt { get; set; }

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
