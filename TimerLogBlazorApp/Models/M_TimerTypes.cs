using TimerLogBlazorApp.Attributes;

namespace TimerLogBlazorApp.Models
{
    /// <summary>
    /// タイマータイプマスタ
    /// </summary>
    [Master]
    public sealed class M_TimerTypes
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
