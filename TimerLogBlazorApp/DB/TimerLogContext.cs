using Microsoft.EntityFrameworkCore;
using TimerLogBlazorApp.Models;

namespace TimerLogBlazorApp.DB
{
    public sealed class TimerLogContext : DbContext
    {
        public DbSet<T_TimerLogs> T_TimerLogs { get; set; }
        public DbSet<V_TimerLogs> V_TimerLogs { get; set; }
        public DbSet<M_Users> M_Users { get; set; }
        public DbSet<M_TimerTypes> M_TimerTypes { get; set; }

        public TimerLogContext(DbContextOptions<TimerLogContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_TimerLogs>()
                .UseTptMappingStrategy();
        }
    }
}
