namespace TimerLog.WebAPI.Models
{
    /// <summary>
    /// ストップウォッチログビュー
    /// </summary>
    public class V_StopwatchLogs : T_StopwatchLogs
    {
        /// <summary>
        /// 経過時間（フォーマット済み）
        /// </summary>
        public string? ElapsedTimeFormatted { get; set; }

        /// <summary>
        /// ユーザー名
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// タイプ名
        /// </summary>
        public string? TimerTypeName { get; set; }
    }
}
