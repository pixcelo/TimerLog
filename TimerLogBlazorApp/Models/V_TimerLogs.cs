using System.ComponentModel.DataAnnotations.Schema;

namespace TimerLogBlazorApp.Models
{
    public sealed class V_TimerLogs : T_TimerLogs
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
        /// 経過時間（表示用）
        /// </summary>
        [NotMapped]
        public string DisplayElapsedTime
        {
            get
            {
                TimeSpan timeSpan = TimeSpan.FromMilliseconds(ElapsedTime);
                return string.Format("{0:D2}:{1:D2}.{2:D3}",
                    timeSpan.Minutes,
                    timeSpan.Seconds,
                    timeSpan.Milliseconds);
            }
        }
    }
}
