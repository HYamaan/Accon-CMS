using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Faq.DeleteFaq;

public class DeleteFaqCommandRequest : IRequest<ResponseModel<DeleteFaqCommandResponse>>
{
    public Guid Id { get; set; }
}