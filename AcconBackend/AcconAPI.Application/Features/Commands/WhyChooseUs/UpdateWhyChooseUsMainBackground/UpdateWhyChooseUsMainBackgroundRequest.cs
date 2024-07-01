using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.WhyChooseUs.UpdateWhyChooseUsMainBackground;

public class UpdateWhyChooseUsMainBackgroundRequest : IRequest<ResponseModel<UpdateWhyChooseUsMainBackgroundResponse>>
{
    public IFormFile Photo { get; set; }
}