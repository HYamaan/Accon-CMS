using AcconAPI.Application.Models.DTOs.Request;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Menu;

public class UpdateMenuCommandRequest:IRequest<ResponseModel<UpdateMenuCommandResponse>>
{
    public List<UpdateCommandRequestDTOs> pages { get; set; }
}