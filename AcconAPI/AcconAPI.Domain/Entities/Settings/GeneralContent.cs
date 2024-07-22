using AcconAPI.Domain.Common;

namespace AcconAPI.Domain.Entities.Settings;

public class GeneralContent : BaseEntity
{
    public string? FooterCopyRight { get; set; }
    public string? FooterAdress { get; set; }
    public string? FooterPhone { get; set; }
    public string? FooterWorkingHours { get; set; }
    public string? FooterAboutUs { get; set; }
    public string? TopBarEmail { get; set; }
    public string? TopBarPhone { get; set; }
    public string? ContactMap { get; set; }
    public int? RecentPostCount { get; set; }
    public int? PopularPostCount { get; set; }
}