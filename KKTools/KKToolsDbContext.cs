using KKTools.Models;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKTools
{
   public  class KKToolsDbContext : DbContext
    {
        public KKToolsDbContext(): base("KKToolsConnectionString")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<KKToolsDbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<ServiceTTS> ServiceTTSs { get; set; }
        public DbSet<ServiceSupported> ServiceSupporteds { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Stream> Streams { get; set; }
    }
}
