namespace Viainternet.OnionArchitecture.Infrastructure.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTablePlr : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserMembership", newName: "UserMemberships");
            RenameTable(name: "dbo.MembershipClaim", newName: "MembershipClaims");
            RenameTable(name: "dbo.MembershipLogin", newName: "MembershipLogins");
            RenameTable(name: "dbo.UserMembershipRole", newName: "UserMembershipRoles");
            RenameTable(name: "dbo.MembershipRole", newName: "MembershipRoles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MembershipRoles", newName: "MembershipRole");
            RenameTable(name: "dbo.UserMembershipRoles", newName: "UserMembershipRole");
            RenameTable(name: "dbo.MembershipLogins", newName: "MembershipLogin");
            RenameTable(name: "dbo.MembershipClaims", newName: "MembershipClaim");
            RenameTable(name: "dbo.UserMemberships", newName: "UserMembership");
        }
    }
}
