using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using AcconAPI.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.Settings.HomePageSettings;

public class HomePageSettingsCommandRequest : IRequest<ResponseModel<HomePageSettingsCommandResponse>>
{
    public HomePageEnum SettingId { get; set; }
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public bool Status { get; set; }
    public IFormFile? CounterBackgroundPhoto { get; set; }
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