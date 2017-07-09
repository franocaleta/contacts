namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadingmails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Emails", "contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.Emails", new[] { "contact_ContactId" });
            DropIndex("dbo.PhoneNumbers", new[] { "contact_ContactId" });
            CreateIndex("dbo.Emails", "Contact_ContactId");
            CreateIndex("dbo.PhoneNumbers", "Contact_ContactId");
            AddForeignKey("dbo.Emails", "Contact_ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emails", "Contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.PhoneNumbers", new[] { "Contact_ContactId" });
            DropIndex("dbo.Emails", new[] { "Contact_ContactId" });
            CreateIndex("dbo.PhoneNumbers", "contact_ContactId");
            CreateIndex("dbo.Emails", "contact_ContactId");
            AddForeignKey("dbo.Emails", "contact_ContactId", "dbo.Contacts", "ContactId");
        }
    }
}
