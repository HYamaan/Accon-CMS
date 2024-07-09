using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.Settings.GeneralContent.WorkingHour;

public class WorkingHourIconCommandRequest : IRequest<ResponseModel<WorkingHourIconCommandResponse>>
{
    public IFormFile Photo { get; set; }
}