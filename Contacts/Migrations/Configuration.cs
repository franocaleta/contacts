namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Contacts.Models;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<Contacts.Models.ContactContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Contacts.Models.ContactContext context)
        {
            var tags = new List<Tag>();
            tags.Add(new Tag { Name = "bff" , TagId = 1 });
            tags.Add(new Tag { Name = "frend", TagId = 2 });

            var tags2 = new List<Tag>();
            tags2.Add(new Tag { Name = "bff" , TagId = 1 });
            tags2.Add(new Tag { Name = "hakerman", TagId = 3 });

            var emails1 = new List<Email>();
            emails1.Add(new Email { email = "frano@gmail.com" });
            emails1.Add(new Email { email = "caleta@gmail.com" });

            var emails2 = new List<Email>();
            emails2.Add(new Email { email = "ivan@gmail.com" });
            emails2.Add(new Email { email = "ivanovic@gmail.com" });

            var numbers1 = new List<PhoneNumber>();
            numbers1.Add(new PhoneNumber { Number = "098 123 123" });
            numbers1.Add(new PhoneNumber { Number = "098 123 1234" });

            var numbers2 = new List<PhoneNumber>();
            numbers2.Add(new PhoneNumber { Number = "098 132 132" });
            numbers2.Add(new PhoneNumber { Number = "098 132 1324" });

            context.Contacts.AddOrUpdate(p => p.Name,
       new Contact
       {
           ContactId = 1,
           Name = "Frano",
           LastName = "Caleta",
           Address = "Svetice 42",
           Tags = tags,
           Emails = emails1,
           PhoneNumbers = numbers1
       },
       new Contact
       {
           ContactId = 2,
           Name = "Ivan",
           LastName = "Ivanovic",
           Address = "Unska 3",
           Tags = tags2,
           Emails = emails2,
           PhoneNumbers = numbers2
       }

        );
        }
    }
}
