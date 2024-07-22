using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using AcconAPI.Domain.Enum;

namespace AcconAPI.Domain.Entities.Settings;

public class HomePageSettings:BaseEntity
{
    public HomePageEnum SettingId { get; set; }
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public bool Status { get; set; }
    public CounterBackgroundPhoto? CounterBackgroundPhoto { get; set; }
    public string? Counter1Text { get; set; }
    public string? Counter1Value { get; set; }
    public string? Counter2Text { get; set; }
    public string? Counter2Value { get; set; }
    public string? Counter3Text { get; set; }
    public string? Counter3Value { get; set; }
    public string? Counter4Text { get; set; }
    public string? Counter4Value { get; set; }
    public int? TotalRecentPosts { get; set; }
}