using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CoiffeurApp.Models
{
    public class DbConnect:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        public DbConnect() : base(SingleConnection.ConString) //base(string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", ".", "D104", "sa", "sa12345"))
        {
            //Database.SetInitializer(new DbInit
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbConnect, CoiffeurApp.Models.Migrations.Configuration>());
        


        }
        public DbSet<User> User { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<StaffPermission> StaffPermission { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookService> BookService { get; set; }
    }
}