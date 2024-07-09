using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Pages.ContactPage;

public class ContactPageQueryRequest : IRequest<ResponseModel<ContactPageQueryResponse>>
{
    
}