using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;

namespace AcconAPI.Domain.Entities.Partner;

public class Partner:BaseEntity
{
    public string Name { get; set; }
    public PartnerPhoto Photo { get; set; }
}