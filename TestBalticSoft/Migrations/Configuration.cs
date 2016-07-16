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
            context.Persons.Add(new Person("������ �.�.", "�������� 1"));
            context.Persons.Add(new Person("������ �.�.", "������� 3"));
            context.Persons.Add(new Person("������� �.�.", "���� 5"));

            context.Organizations = context.Set<Organization>();
            context.Organizations.Add(new Organization(
                "�������� 2", "������� 5","123123123123123"));
            context.Organizations.Add(new Organization(
                "���� 82", "�������� 25", "923402323"));
        }
    }
}
