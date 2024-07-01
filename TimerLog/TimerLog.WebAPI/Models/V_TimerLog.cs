namespace TimerLog.WebAPI.Models
{
    /// <summary>
    /// タイマーログビュー
    /// </summary>
    public class V_TimerLog : T_TimerLog
    {
        /// <summary>
        /// ユーザー名
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// タイプ名
        /// </summary>
        public string? TimerTypeName { get; set; }

        /// <summary>
        /// 経過時間（分）
        /// </summary>
        public int? ElapsedMinutes { get; set;}
    }
}
