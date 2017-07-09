namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initializedNewDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        contact_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.contact_ContactId)
                .Index(t => t.contact_ContactId);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        contact_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.contact_ContactId)
                .Index(t => t.contact_ContactId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.TagContacts",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Contact_ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Contact_ContactId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Contact_ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagContacts", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.TagContacts", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.PhoneNumbers", "contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Emails", "contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.TagContacts", new[] { "Contact_ContactId" });
            DropIndex("dbo.TagContacts", new[] { "Tag_TagId" });
            DropIndex("dbo.PhoneNumbers", new[] { "contact_ContactId" });
            DropIndex("dbo.Emails", new[] { "contact_ContactId" });
            DropTable("dbo.TagContacts");
            DropTable("dbo.Tags");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.Emails");
            DropTable("dbo.Contacts");
        }
    }
}
