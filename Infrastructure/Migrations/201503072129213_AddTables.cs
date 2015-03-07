namespace Viainternet.OnionArchitecture.Infrastructure.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        NativeName = c.String(),
                        Name = c.String(),
                        TwoLetterISOLanguageName = c.String(),
                        ThreeLetterISOLanguageName = c.String(),
                        EnglishName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TranslationTexts",
                c => new
                    {
                        TranslationId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => new { t.TranslationId, t.LanguageId })
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Translations", t => t.TranslationId, cascadeDelete: true)
                .Index(t => t.TranslationId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Translations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NeutralText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeZones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        StandardName = c.String(),
                        HasDaylightSavingTime = c.Boolean(nullable: false),
                        UTCOffset = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PhoneNumbers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserProfiles", "LanguageId", c => c.Int(nullable: false));
            AddColumn("dbo.UserProfiles", "TimeZoneId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserProfiles", "LanguageId");
            CreateIndex("dbo.UserProfiles", "TimeZoneId");
            AddForeignKey("dbo.UserProfiles", "LanguageId", "dbo.Languages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserProfiles", "TimeZoneId", "dbo.TimeZones", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "TimeZoneId", "dbo.TimeZones");
            DropForeignKey("dbo.UserProfiles", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.TranslationTexts", "TranslationId", "dbo.Translations");
            DropForeignKey("dbo.TranslationTexts", "LanguageId", "dbo.Languages");
            DropIndex("dbo.TranslationTexts", new[] { "LanguageId" });
            DropIndex("dbo.TranslationTexts", new[] { "TranslationId" });
            DropIndex("dbo.UserProfiles", new[] { "TimeZoneId" });
            DropIndex("dbo.UserProfiles", new[] { "LanguageId" });
            DropColumn("dbo.UserProfiles", "TimeZoneId");
            DropColumn("dbo.UserProfiles", "LanguageId");
            DropColumn("dbo.PhoneNumbers", "PhoneNumberConfirmed");
            DropTable("dbo.TimeZones");
            DropTable("dbo.Translations");
            DropTable("dbo.TranslationTexts");
            DropTable("dbo.Languages");
        }
    }
}
