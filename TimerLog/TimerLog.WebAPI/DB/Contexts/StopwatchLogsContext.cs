using Microsoft.EntityFrameworkCore;
using TimerLog.WebAPI.Models;

namespace TimerLog.WebAPI.DB.Contexts
{
    public class StopwatchLogsContext : DbContext
    {
        public DbSet<T_StopwatchLogs> T_StopwatchLogs { get; set; }
        public DbSet<V_StopwatchLogs> V_StopwatchLogs { get; set; }
        public DbSet<M_TimerType> M_TimerType { get; set; }

        public StopwatchLogsContext(DbContextOptions<StopwatchLogsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_StopwatchLogs>()
                .UseTptMappingStrategy();
        }
    }
}