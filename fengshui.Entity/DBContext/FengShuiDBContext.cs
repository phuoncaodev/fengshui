
namespace fengshui.Entity.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using fengshui.Entity.FluentConfiguration;
    using fengshui.Entity.Models;
    using System.Reflection;

    public class FengShuiDBContext : DbContext
    {
        public DbSet<MobileNumber> MobileNumbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=FengShui.db;", options => {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            optionsBuilder.EnableSensitiveDataLogging(true);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MobileNumberConfiguration());

            modelBuilder.Entity<MobileNumber>().HasData(
                new MobileNumber()
                {
                    Id = 1,
                    PhoneNumber = "0973591924",
                    ServiceProvider = "Viettel",
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                },
                new MobileNumber()
                {
                    Id = 2,
                    PhoneNumber = "0973591934",
                    ServiceProvider = "Viettel",
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                },
                new MobileNumber()
                {
                    Id = 3,
                    PhoneNumber = "0973591919",
                    ServiceProvider = "Viettel",
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                },
                new MobileNumber()
                {
                    Id = 4,
                    PhoneNumber = "0903591924",
                    ServiceProvider = "Mobi",
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                },
                new MobileNumber()
                {
                    Id = 5,
                    PhoneNumber = "0903591934",
                    ServiceProvider = "Mobi",
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                },
                new MobileNumber()
                {
                    Id = 6,
                    PhoneNumber = "0903591919",
                    ServiceProvider = "Mobi",
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                },
                new MobileNumber()
                {
                    Id = 7,
                    PhoneNumber = "0943591924",
                    ServiceProvider = "Vina",
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                },
                new MobileNumber()
                {
                    Id = 8,
                    PhoneNumber = "0943591934",
                    ServiceProvider = "Vina",
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                },
                new MobileNumber()
                {
                    Id = 9,
                    PhoneNumber = "0943591919",
                    ServiceProvider = "Vina",
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
