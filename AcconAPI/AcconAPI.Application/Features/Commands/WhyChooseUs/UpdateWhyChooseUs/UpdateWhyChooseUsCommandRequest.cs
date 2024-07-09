using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.WhyChooseUs.UpdateWhyChooseUs;

public class UpdateWhyChooseUsCommandRequest : IRequest<ResponseModel<UpdateWhyChooseUsCommandResponse>>
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public IFormFile? Photo { get; set; }
}