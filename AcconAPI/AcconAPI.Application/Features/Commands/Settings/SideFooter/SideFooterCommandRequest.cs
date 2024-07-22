using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Settings.SideFooter;

public class SideFooterCommandRequest : IRequest<ResponseModel<SideFooterCommandResponse>>
{
    public int? PopularPostCount { get; set; }
    public int? RecentPostCount { get; set; }
}