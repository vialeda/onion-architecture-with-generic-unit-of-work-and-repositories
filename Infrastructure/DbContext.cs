using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using Viainternet.OnionArchitecture.Core.Domain.Models;
using Viainternet.OnionArchitecture.Core.Interfaces;

namespace Viainternet.OnionArchitecture.Infrastructure
{
    
    public class ApplicationDbContext : IdentityDbContext<UserMembership>, IDataContextAsync
    {

        public ApplicationDbContext()
            : base("name=local")
        {
        }

        private ApplicationDbContext(string connectionString)
            : base(connectionString)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<AreaCode> AreaCodes { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<UserMembershipSetting> MembershipSettings { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Viainternet.OnionArchitecture.Core.Domain.Models.TimeZone> TimeZones { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<TranslationText> TranslationTexts { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserClaim>().ToTable("MembershipClaims");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserMembershipRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("MembershipLogins");
            modelBuilder.Entity<IdentityRole>().ToTable("MembershipRoles");
            modelBuilder.Entity<UserMembership>().ToTable("UserMemberships");
            
            SetKeys(modelBuilder);
            SetOneNavigation(modelBuilder);
            SetOneToOne(modelBuilder);
            SetOneToMany(modelBuilder);
            SetManyToMany(modelBuilder);
        }

        private void SetOneToMany(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyProfile>()
                .HasMany(x => x.PhoneNumbers)
                .WithRequired(x => x.CompanyProfile)
                .HasForeignKey(x => x.CompanyProfileId);

            modelBuilder.Entity<CompanyProfile>()
                .HasRequired(x => x.Municipality)
                .WithMany(x => x.CompanyProfiles)
                .HasForeignKey(x => x.MunicipalityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserProfile>()
                .HasMany(x => x.PhoneNumbers)
                .WithRequired(x => x.UserProfile)
                .HasForeignKey(x => x.UserMembershipId);

            modelBuilder.Entity<UserProfile>()
                .HasRequired(x => x.Municipality)
                .WithMany(x => x.UserProfiles)
                .HasForeignKey(x => x.MunicipalityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserProfile>()
                .HasRequired(x => x.Language)
                .WithMany(x => x.UserProfiles)
                .HasForeignKey(x => x.LanguageId);

            modelBuilder.Entity<UserProfile>()
                .HasRequired(x => x.TimeZone)
                .WithMany(x => x.UserProfiles)
                .HasForeignKey(x => x.TimeZoneId);

            modelBuilder.Entity<Municipality>()
                .HasRequired(x => x.State)
                .WithMany(x => x.Municipalities)
                .HasForeignKey(x => x.StateId);

            modelBuilder.Entity<State>()
                .HasRequired(x => x.Country)
                .WithMany(x => x.States)
                .HasForeignKey(x => x.CountryId);

            modelBuilder.Entity<PhoneNumber>()
                .HasRequired(x => x.AreaCode)
                .WithMany(x => x.PhoneNumbers)
                .HasForeignKey(x => x.AreaCodeId);

            modelBuilder.Entity<TranslationText>()
                .HasRequired(x => x.Translation)
                .WithMany(x => x.TranslationTexts)
                .HasForeignKey(x => x.TranslationId);

            modelBuilder.Entity<TranslationText>()
                .HasRequired(x => x.Language)
                .WithMany(x => x.TranslationTexts)
                .HasForeignKey(x => x.LanguageId);

            // Those two mapping are a many to many but define like 
            // one two many because we need the between table exist
            // in c# class to save extra data in it.
            modelBuilder.Entity<UserMembershipSetting>()
                .HasRequired(x => x.UserSetting)
                .WithMany(x => x.UserMembershipSettings)
                .HasForeignKey(x => x.UserSettingId);

            modelBuilder.Entity<UserMembershipSetting>()
                .HasRequired(x => x.UserMembership)
                .WithMany(x => x.UserMembershipSettings)
                .HasForeignKey(x => x.UserMembershipId);

            SetTranslationMapping(modelBuilder);
        }
        /// <summary>
        /// The translation table could have many one to many mapping between tables. So use that method to setup those mapping.
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void SetTranslationMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>()
                .HasRequired(x => x.Translation)
                .WithMany(x => x.Genders)
                .HasForeignKey(x => x.TranslationId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void SetManyToMany(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMembership>()
                .HasMany(x => x.CompagnyProfiles)
                .WithMany(x => x.UserMemberships)
                .Map(m => m.MapLeftKey("UserMembershipId")
                .MapRightKey("CompanyProfileId")
                .ToTable("UserMembershipCompanyProfile"));
        }
        /// <summary>
        /// In most cases the Entity Framework can infer which type is the dependent and which is the principal in a relationship. However, when both ends of the relationship are required or both sides are optional the Entity Framework cannot identify the dependent and principal. When both ends of the relationship are required, use WithRequiredPrincipal or WithRequiredDependent after the HasRequired method. When both ends of the relationship are optional, use WithOptionalPrincipal or WithOptionalDependent after the HasOptional method.
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void SetOneToOne(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasRequired(x => x.AreaCode)
                .WithRequiredPrincipal(x => x.Country);
        }
        /// <summary>
        /// A one-directional (also called unidirectional) relationship is when a navigation property is defined on only one of the relationship ends and not on both. By convention, Code First always interprets a unidirectional relationship as one-to-many.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <remarks>Those class do not have foreign keys explicitly.</remarks>
        private void SetOneNavigation(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMembership>()
              .HasOptional(x => x.UserProfile)
              .WithRequired(x => x.UserMembership);
        }
        /// <summary>
        /// Set the primary key.
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void SetKeys(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMembership>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<UserProfile>()
                .HasKey(x => x.UserMembershipId);

            modelBuilder.Entity<CompanyProfile>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Country>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<State>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Municipality>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<PhoneNumber>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<AreaCode>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<UserSetting>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Translation>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Language>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Gender>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Viainternet.OnionArchitecture.Core.Domain.Models.TimeZone>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<UserMembershipSetting>()
                .HasKey(x => new { x.UserMembershipId, x.UserSettingId });

            modelBuilder.Entity<TranslationText>()
                .HasKey(x => new { x.TranslationId, x.LanguageId });
        }

        public void SyncObjectsStatePostCommit()
        {
            throw new NotImplementedException();
        }

        public void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState
        {
            throw new NotImplementedException();
        }
    }
}
