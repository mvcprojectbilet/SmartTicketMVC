
using SmartTicket.DataAccess.Migrations;
using SmartTicket.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTicket.DataAccess.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<User> Users { get; set; }

        public DatabaseContext() : base("DatabaseContext")//Default Connection
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>("DatabaseContext"));
            // Değişiklikleri tarayarak update yapıyor.
            //Database'i her defasında uçurmuyor.
        }
        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }
    }

    //public DatabaseContext() : base("DefCon")//Default Connection
    //{
    //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>("DefCon"));
    //    // Değişiklikleri tarayarak update yapıyor.
    //    //Database'i her defasında uçurmuyor.
    //}
    //public static DatabaseContext Create()
    //{
    //    return new DatabaseContext();
    //}
}
