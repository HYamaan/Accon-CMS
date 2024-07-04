using AcconAPI.Domain.Common;

namespace AcconAPI.Domain.Entities.Language;

public class Language:BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
}