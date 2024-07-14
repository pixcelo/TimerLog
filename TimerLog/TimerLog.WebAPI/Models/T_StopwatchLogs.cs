using System.ComponentModel.DataAnnotations;

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
        [Key]
        public long LogId { get; set; }
        
        /// <summary>
        /// 経過時間
        /// </summary>
        public long ElapsedTime { get; set; }

        /// <summary>
        /// ログ日時
        /// </summary>
        public DateTime LogDate { get; set; }

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
