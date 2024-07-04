using AcconAPI.Application.Models.DTOs.Request;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Language;

public class UpdateLanguageCommandRequest : IRequest<ResponseModel<UpdateLanguageCommandResponse>>
{
    public List<UpdateLanguageRequestDTOs> languages { get; set; }
}