
using System.Collections.Generic;
namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    public class Translation : Entity
    {
        public Translation()
        {
            TranslationTexts = new HashSet<TranslationText>();
        }

        public int Id { get; set; }
        public string NeutralText { get; set; }
        public virtual ICollection<Gender> Genders { get; set; }
        public virtual ICollection<TranslationText> TranslationTexts { get; set; }
    }
}
