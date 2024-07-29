using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.ClientPages.ContactPage;

public class ContactClientPageQueryRequest : IRequest<ResponseModel<ContactClientPageQueryResponse>>
{
    
}