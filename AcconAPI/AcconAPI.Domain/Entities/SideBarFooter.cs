using AcconAPI.Domain.Common;

namespace AcconAPI.Domain.Entities;

public class SideBarFooter:BaseEntity
{
    public int RecentPosts { get; set; }
    public int PopularPosts { get; set; }
}