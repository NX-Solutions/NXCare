using NXCare.Domain.DTO;
using NXCare.Domain.Interfaces.Mappers;

namespace NXCare.Mappers
{
    public class LanguageMapper : ILanguageMapper
    {
        public Language ToDTO(Domain.Entities.Language language)
        {
            if (language == null) return null;

            return new Language
            {
                Alpha2Code = language.Alpha2Code,
                Alpha3Code = language.Alpha3Code,
                Name       = language.NameTranslationKey
            };
        }
    }
}