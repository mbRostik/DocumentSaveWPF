using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options) { }

        //public DbSet<Notification> Notifications { get; set; }

        //public DbSet<User> Users { get; set; }

        //public DbSet<NotificationType> NotificationTypes { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationDbContext).Assembly);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
