using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    public class Gender
    {
        public Gender()
        {
            UserProfiles = new HashSet<UserProfile>();
        }
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int TranslationId { get; set; }
        [NotMapped]
        public string DisplayName { get { return Translation.TranslationTexts.Single(x => x.LanguageId == 1).Text; } }
        public virtual Translation Translation { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
