namespace Viainternet.OnionArchitecture.Infrastructure.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserProfileId = c.Int(nullable: false),
                        TranslationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Translations", t => t.TranslationId, cascadeDelete: true)
                .Index(t => t.TranslationId);
            
            AddColumn("dbo.UserProfiles", "Gender_Id", c => c.Int());
            CreateIndex("dbo.UserProfiles", "Gender_Id");
            AddForeignKey("dbo.UserProfiles", "Gender_Id", "dbo.Genders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.Genders", "TranslationId", "dbo.Translations");
            DropIndex("dbo.Genders", new[] { "TranslationId" });
            DropIndex("dbo.UserProfiles", new[] { "Gender_Id" });
            DropColumn("dbo.UserProfiles", "Gender_Id");
            DropTable("dbo.Genders");
        }
    }
}
