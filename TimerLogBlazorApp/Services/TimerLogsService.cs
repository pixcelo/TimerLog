﻿using TimerLogBlazorApp.Models;
using TimerLogBlazorApp.Repositories;
using static System.Reflection.Metadata.BlobBuilder;

namespace TimerLogBlazorApp.Services
{
    /// <summary>
    /// タイマーログサービス
    /// </summary>

    public sealed class TimerLogsService : ITimerLogsService
    {
        private readonly ITimerLogsRepository timerLogsRepository;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="timerLogsRepository"></param>
        public TimerLogsService(ITimerLogsRepository timerLogsRepository)
        {
            this.timerLogsRepository = timerLogsRepository;
        }

        public List<V_TimerLogs> Find()
        {
            return this.timerLogsRepository.Find();
        }

        public int Save(T_TimerLogs timerLog)
        {
            return this.timerLogsRepository.Insert(timerLog);
        }

        public　List<V_TimerLogs> GetLogsByDate(DateTime date)
        {
            return this.timerLogsRepository.GetLogsByDate(date);
        }
    }
}
