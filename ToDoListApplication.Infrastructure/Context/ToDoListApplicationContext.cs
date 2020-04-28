using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using ToDoListApplication.Domain.Entities;
using System.Data;

namespace ToDoListApplication.Infrastructure.Context
{
    public class ToDoListApplicationContext : DbContext
    {
        public ToDoListApplicationContext()
            : base("ToDoListApplicationDatabase")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Properties<DateTime>()
                .Configure(p => p.HasColumnType("datetime2"));
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("LastInsertionDate") != null))
            {
                entry.Property("LastInsertionDate").CurrentValue = DateTime.Now;
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreationDate") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("CreationDate").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("CreationDate").IsModified = false;
            }
            return base.SaveChanges();
        }                     
    }
}
