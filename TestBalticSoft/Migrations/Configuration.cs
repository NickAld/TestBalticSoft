namespace TestBalticSoft.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TestBalticSoft.mDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TestBalticSoft.mDbContext context)
        {
            context.Persons = context.Set<Person>();
            context.Persons.Add(new Person("Иванов В.И.", "Гагарина 1"));
            context.Persons.Add(new Person("Петров С.Е.", "Красная 3"));
            context.Persons.Add(new Person("Сидоров Е.В.", "Мира 5"));

            context.Organizations = context.Set<Organization>();
            context.Organizations.Add(new Organization(
                "Северная 2", "Красная 5","123123123123123"));
            context.Organizations.Add(new Organization(
                "Мира 82", "Гагарина 25", "923402323"));
        }
    }
}
