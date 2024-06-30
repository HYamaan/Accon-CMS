using AcconAPI.Application.Features.Commands.Faq;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Faq.GetFaqEdit;

public class GetFaqEditQueryRequest:IRequest<ResponseModel<GetFaqEditQueryResponse>>
{
    public Guid Id { get; set; }
}