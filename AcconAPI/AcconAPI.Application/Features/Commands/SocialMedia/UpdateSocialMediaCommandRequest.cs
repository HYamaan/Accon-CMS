using AcconAPI.Application.Models.DTOs.Request;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.SocialMedia;

public class UpdateSocialMediaCommandRequest : IRequest<ResponseModel<UpdateSocialMediaCommandResponse>>
{
    public List<UpdateSocialMediaRequestDTOs> Socials { get; set; }
}