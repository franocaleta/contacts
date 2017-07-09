using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class ContactContext2 : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Email> Emails { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }


       

protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasMany(a => a.Emails)
                .WithOptional()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Contact>()
                .HasMany(a => a.PhoneNumbers)
                .WithOptional()
                .WillCascadeOnDelete(true);
        }

    }
    
}