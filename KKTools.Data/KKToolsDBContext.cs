using KKTools.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKTools.Data
{
   public class KKToolsDBContext : DbContext
    {
        protected string DBName = "KKToolsDB.db3";
        public KKToolsDBContext() :  base("KKToolsConectionString")
        {

        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<ServiceTTS> ServiceTTSs { get; set; }
        public DbSet<ServiceSupported> ServiceSupporteds { get; set; }
        public DbSet<Result> Results { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
