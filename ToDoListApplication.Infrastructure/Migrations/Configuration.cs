namespace ToDoListApplication.Infrastructure.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using ToDoListApplication.Domain.Entities;
    using ToDoListApplication.Domain.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.ToDoListApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.ToDoListApplicationContext context)
        {            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
