using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options) { }

        public DbSet<ANAGDIP> ANAGDIPs { get; set; }
        public DbSet<DOCUMENTO_UPLOAD> DOCUMENTO_UPLOADs { get; set; }

        public DbSet<DOCUMENTO_UPLOAD_DIPENDENTE> DOCUMENTO_UPLOAD_DIPENDENTEs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
