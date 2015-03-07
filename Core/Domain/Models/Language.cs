using System;
using System.Collections.Generic;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    public class Language : Entity
    {
        public Language()
        {
            UserProfiles = new HashSet<UserProfile>();
            TranslationTexts = new HashSet<TranslationText>();
        }
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string NativeName { get; set; }
        public string Name { get; set; }
        public string TwoLetterISOLanguageName { get; set; }
        public string ThreeLetterISOLanguageName { get; set; }
        public string EnglishName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual ICollection<TranslationText> TranslationTexts { get; set; }
    }
}
