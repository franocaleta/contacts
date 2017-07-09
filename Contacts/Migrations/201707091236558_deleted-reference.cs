namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedreference : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Emails", new[] { "contact_ContactId" });
            DropIndex("dbo.PhoneNumbers", new[] { "contact_ContactId" });
            CreateIndex("dbo.Emails", "Contact_ContactId");
            CreateIndex("dbo.PhoneNumbers", "Contact_ContactId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PhoneNumbers", new[] { "Contact_ContactId" });
            DropIndex("dbo.Emails", new[] { "Contact_ContactId" });
            CreateIndex("dbo.PhoneNumbers", "contact_ContactId");
            CreateIndex("dbo.Emails", "contact_ContactId");
        }
    }
}
