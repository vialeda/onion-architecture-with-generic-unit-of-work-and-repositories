namespace Viainternet.OnionArchitecture.Infrastructure.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AreaCodes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Value = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        Name = c.String(),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Municipalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateId = c.Int(nullable: false),
                        Name = c.String(),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.CompanyProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserMembershipId = c.String(),
                        MunicipalityId = c.Int(nullable: false),
                        Name = c.String(),
                        DisplayName = c.String(),
                        Website = c.String(),
                        Email = c.String(),
                        NE = c.String(),
                        NEQ = c.String(),
                        EmployeesNumber = c.Int(nullable: false),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        LastestUpdateDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        FileName = c.String(),
                        DisplayFileName = c.String(),
                        FileDescription = c.String(),
                        ContentType = c.String(),
                        ContentLength = c.String(),
                        FileExtension = c.String(),
                        File = c.Binary(),
                        StreetNumber = c.Int(nullable: false),
                        StreetName = c.String(),
                        PostalCode = c.String(),
                        PostalBox = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Municipalities", t => t.MunicipalityId)
                .Index(t => t.MunicipalityId);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserMembershipId = c.String(nullable: false, maxLength: 128),
                        CompanyProfileId = c.Int(nullable: false),
                        AreaCodeId = c.Int(nullable: false),
                        DisplayName = c.String(),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AreaCodes", t => t.AreaCodeId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserMembershipId, cascadeDelete: true)
                .ForeignKey("dbo.CompanyProfiles", t => t.CompanyProfileId, cascadeDelete: true)
                .Index(t => t.UserMembershipId)
                .Index(t => t.CompanyProfileId)
                .Index(t => t.AreaCodeId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserMembershipId = c.String(nullable: false, maxLength: 128),
                        MunicipalityId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        StreetNumber = c.Int(nullable: false),
                        StreetName = c.String(),
                        PostalCode = c.String(),
                        PostalBox = c.String(),
                    })
                .PrimaryKey(t => t.UserMembershipId)
                .ForeignKey("dbo.Municipalities", t => t.MunicipalityId)
                .ForeignKey("dbo.UserMembership", t => t.UserMembershipId)
                .Index(t => t.UserMembershipId)
                .Index(t => t.MunicipalityId);
            
            CreateTable(
                "dbo.UserMembership",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PhoneNumber = c.String(),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Email = c.String(maxLength: 256),
                        SecurityStamp = c.String(),
                        IsAccountClosed = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LatestLogonDate = c.DateTime(nullable: false),
                        UnsubscribeDate = c.DateTime(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.MembershipClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserMembership", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MembershipLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.UserMembership", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserMembershipRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.UserMembership", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.MembershipRole", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserMembershipSettings",
                c => new
                    {
                        UserMembershipId = c.String(nullable: false, maxLength: 128),
                        UserSettingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserMembershipId, t.UserSettingId })
                .ForeignKey("dbo.UserMembership", t => t.UserMembershipId, cascadeDelete: true)
                .ForeignKey("dbo.UserSettings", t => t.UserSettingId, cascadeDelete: true)
                .Index(t => t.UserMembershipId)
                .Index(t => t.UserSettingId);
            
            CreateTable(
                "dbo.UserSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                        ValueType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MembershipRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.SystemSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                        IsActivate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserMembershipCompanyProfile",
                c => new
                    {
                        UserMembershipId = c.String(nullable: false, maxLength: 128),
                        CompanyProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserMembershipId, t.CompanyProfileId })
                .ForeignKey("dbo.UserMembership", t => t.UserMembershipId, cascadeDelete: true)
                .ForeignKey("dbo.CompanyProfiles", t => t.CompanyProfileId, cascadeDelete: true)
                .Index(t => t.UserMembershipId)
                .Index(t => t.CompanyProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMembershipRole", "RoleId", "dbo.MembershipRole");
            DropForeignKey("dbo.Municipalities", "StateId", "dbo.States");
            DropForeignKey("dbo.PhoneNumbers", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.UserProfiles", "UserMembershipId", "dbo.UserMembership");
            DropForeignKey("dbo.UserMembershipSettings", "UserSettingId", "dbo.UserSettings");
            DropForeignKey("dbo.UserMembershipSettings", "UserMembershipId", "dbo.UserMembership");
            DropForeignKey("dbo.UserMembershipRole", "UserId", "dbo.UserMembership");
            DropForeignKey("dbo.MembershipLogin", "UserId", "dbo.UserMembership");
            DropForeignKey("dbo.UserMembershipCompanyProfile", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.UserMembershipCompanyProfile", "UserMembershipId", "dbo.UserMembership");
            DropForeignKey("dbo.MembershipClaim", "UserId", "dbo.UserMembership");
            DropForeignKey("dbo.PhoneNumbers", "UserMembershipId", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "MunicipalityId", "dbo.Municipalities");
            DropForeignKey("dbo.PhoneNumbers", "AreaCodeId", "dbo.AreaCodes");
            DropForeignKey("dbo.CompanyProfiles", "MunicipalityId", "dbo.Municipalities");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.AreaCodes", "Id", "dbo.Countries");
            DropIndex("dbo.UserMembershipCompanyProfile", new[] { "CompanyProfileId" });
            DropIndex("dbo.UserMembershipCompanyProfile", new[] { "UserMembershipId" });
            DropIndex("dbo.MembershipRole", "RoleNameIndex");
            DropIndex("dbo.UserMembershipSettings", new[] { "UserSettingId" });
            DropIndex("dbo.UserMembershipSettings", new[] { "UserMembershipId" });
            DropIndex("dbo.UserMembershipRole", new[] { "RoleId" });
            DropIndex("dbo.UserMembershipRole", new[] { "UserId" });
            DropIndex("dbo.MembershipLogin", new[] { "UserId" });
            DropIndex("dbo.MembershipClaim", new[] { "UserId" });
            DropIndex("dbo.UserMembership", "UserNameIndex");
            DropIndex("dbo.UserProfiles", new[] { "MunicipalityId" });
            DropIndex("dbo.UserProfiles", new[] { "UserMembershipId" });
            DropIndex("dbo.PhoneNumbers", new[] { "AreaCodeId" });
            DropIndex("dbo.PhoneNumbers", new[] { "CompanyProfileId" });
            DropIndex("dbo.PhoneNumbers", new[] { "UserMembershipId" });
            DropIndex("dbo.CompanyProfiles", new[] { "MunicipalityId" });
            DropIndex("dbo.Municipalities", new[] { "StateId" });
            DropIndex("dbo.States", new[] { "CountryId" });
            DropIndex("dbo.AreaCodes", new[] { "Id" });
            DropTable("dbo.UserMembershipCompanyProfile");
            DropTable("dbo.SystemSettings");
            DropTable("dbo.MembershipRole");
            DropTable("dbo.UserSettings");
            DropTable("dbo.UserMembershipSettings");
            DropTable("dbo.UserMembershipRole");
            DropTable("dbo.MembershipLogin");
            DropTable("dbo.MembershipClaim");
            DropTable("dbo.UserMembership");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.CompanyProfiles");
            DropTable("dbo.Municipalities");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
            DropTable("dbo.AreaCodes");
        }
    }
}
