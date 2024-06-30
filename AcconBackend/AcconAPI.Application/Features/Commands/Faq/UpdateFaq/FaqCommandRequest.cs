using AcconAPI.Domain.Common;
using AcconAPI.Domain.Enum;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Faq.UpdateFaq;

public class FaqCommandRequest : IRequest<ResponseModel<FaqCommandResponse>>
{

    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public VisiblePlace VisiblePlace { get; set; }
}