using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Faq.GetAllFaq;

public class GetAllFaqQueryRequest:IRequest<ResponseModel<GetAllFaqQueryResponse>>
{
}