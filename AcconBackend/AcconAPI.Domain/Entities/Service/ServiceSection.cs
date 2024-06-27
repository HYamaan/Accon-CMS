using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.Service;
using AcconAPI.Domain.Entities.Page;

namespace AcconAPI.Domain.Entities.Service;

public class ServiceSection:BaseEntity
{
    public string Title { get; set; }
    public string ShortContent { get; set; }
    public string Content { get; set; }
    public ServicePhoto Photo { get; set; }
    public ServiceBanner Banner { get; set; }

    public bool IsPublished { get; set; }
    public SeoItems SeoItems { get; set; }

    public ServicePage ServicePage { get; set; }
}