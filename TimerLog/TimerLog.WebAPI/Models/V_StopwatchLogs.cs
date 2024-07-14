namespace TimerLog.WebAPI.Models
{
    /// <summary>
    /// ストップウォッチログビュー
    /// </summary>
    public class V_StopwatchLogs : T_StopwatchLogs
    {
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
