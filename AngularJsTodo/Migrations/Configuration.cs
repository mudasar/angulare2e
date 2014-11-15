using AngularJsTodo.Models;

namespace AngularJsTodo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularJsTodo.Models.AngularJsTodoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AngularJsTodo.Models.AngularJsTodoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var random = new Random();

            var items = Enumerable.Range(1, 50).Select(o => new TodoItem
            {
                Text = "Todo " + o.ToString(),
                Priority = random.Next(1, 10),
                DueDate = new DateTime(2015, random.Next(1, 12), random.Next(1, 28))
            }).ToArray();

            context.TodoItems.AddOrUpdate(items);

        }
    }
}
