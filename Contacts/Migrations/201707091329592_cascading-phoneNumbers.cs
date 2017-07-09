namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadingphoneNumbers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhoneNumbers", "Contact_ContactId", "dbo.Contacts");
            AddForeignKey("dbo.PhoneNumbers", "Contact_ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "Contact_ContactId", "dbo.Contacts");
            AddForeignKey("dbo.PhoneNumbers", "Contact_ContactId", "dbo.Contacts", "ContactId");
        }
    }
}
