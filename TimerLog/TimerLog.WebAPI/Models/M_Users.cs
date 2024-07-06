using TimerLog.WebAPI.Attributes;

namespace TimerLog.WebAPI.Models
{
    /// <summary>
    /// ユーザーマスタ
    /// </summary>
    [Master]
    public class M_Users
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }
    }
}
