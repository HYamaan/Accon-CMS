using AcconAPI.Domain.Entities.Service;

namespace AcconAPI.Domain.Entities.Page;

public class ServicePage:PageEntity
{
    public ICollection<ServiceSection> ServiceSections { get; set; }
}