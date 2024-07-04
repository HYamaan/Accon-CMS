using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.WhyChooseUs.DeleteWhyChooseUs;

public class DeleteWhyChooseUsCommandRequest : IRequest<ResponseModel<DeleteWhyChooseUsCommandResponse>>
{
    public Guid Id { get; set; }
}