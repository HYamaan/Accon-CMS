using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Menu;

public class UpdateMenuCommandRequest:IRequest<ResponseModel<UpdateMenuCommandResponse>>
{
    public string Id { get; set; }
    public bool IsPublished { get; set; }
}