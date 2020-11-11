using NXCare.Domain.DTO;

namespace NXCare.Domain.Interfaces.Mappers
{
    public interface ILanguageMapper
    {
        Language ToDTO(Domain.Entities.Language language);
    }
}