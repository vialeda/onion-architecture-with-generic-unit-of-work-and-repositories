
namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    public class TranslationText : Entity
    {
        public int TranslationId { get; set; }
        public int LanguageId { get; set; }
        public string Text { get; set; }
        public virtual Language Language { get; set; }
        public virtual Translation Translation { get; set; }
    }
}